using EVEStandard.Enumerations;
using EVEStandard.Models.SSO;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace EVEStandard
{
    /// <summary>
    /// The SSOv2 specifies the workflow required to use Single Sign-On with EVE Online. SSOv2 can be used purely 
    /// for authentication or also for accessing ESI API endpoints that require specific scopes. You also don't have to
    /// use SSOv2 with EVEStandard but go with your own implementation.
    /// </summary>
    /// <remarks>
    /// For information on how to utilize the SSO class please refer to the README on our GitHub.
    /// <see>
    ///     <cref>https://github.com/gehnster/EVEStandard</cref>
    /// </see>
    /// </remarks>
    public class SSOv2
    {
        private static HttpClient _httpClient;
        private readonly string _callbackUri;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly DataSource _dataSource;

        private const string TRANQUILITY_SSO_BASE_URL = "https://login.eveonline.com/v2";
        private const string SERENITY_SSO_BASE_URL = "https://login.evepc.163.com/v2";
        private readonly string SSO_AUTHORIZE = "/oauth/authorize";
        private readonly string SSO_TOKEN = "/oauth/token";
        private readonly string SSO_REVOKE = "/oauth/revoke";
        private readonly string SSO_META_DATA_URL = "https://login.eveonline.com/.well-known/oauth-authorization-server";
        private readonly List<string> JWK_ISSUERS = new List<string> { "login.eveonline.com", "https://login.eveonline.com" };
        private readonly string JWK_AUDIENCE = "EVE Online";

        /// <summary>
        /// Constructor for SSO class.
        /// </summary>
        /// <param name="callbackUri">The Callback URL that you provided in your ESI application. If this doesn't match with what ESI has then SSO auth will fail.</param>
        /// <param name="clientId">The Client Id you were assigned in your ESI application.</param>
        /// <param name="clientSecret">The Secret Key you were assigned in your ESI application, this should NEVER be human-readable in your application.</param>
        /// <param name="dataSource"></param>
        /// <exception cref="EVEStandardException" >Called when any of the parameters is null or empty.</exception>
        /// <remarks>
        /// Except for public data within ESI, you need an application to gain access behind SSO. You can create an application at <see>
        ///         <cref>https://developers.eveonline.com/</cref>
        ///     </see>
        ///     You will probably want to create at least two applications, one for local development and one for production since the <paramref name="callbackUri"/> requires to match in the callback.
        /// </remarks>
        public SSOv2(DataSource dataSource, string callbackUri, string clientId, string clientSecret, HttpClient httpClient = null)
        {
            if (string.IsNullOrEmpty(callbackUri) || string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(clientSecret))
            {
                throw new ArgumentNullException($"SSOv2 should be initialized with non-null and non-empty strings. callbackUriEmpty?: {string.IsNullOrEmpty(callbackUri)} clientIdEmpty?: {string.IsNullOrEmpty(clientId)} secretKeyEmpty?: {string.IsNullOrEmpty(clientSecret)}");
            }

            _callbackUri = callbackUri;
            _clientId = clientId;
            _clientSecret = clientSecret;
            _dataSource = dataSource;

            if(httpClient == null)
            {
                _httpClient = new HttpClient();
            }
        }

        /// <summary>
        /// Generates the URL you should have users click on with one of the EVE Online provided button images.
        /// </summary>
        /// <param name="state">State is used to verify that the callback is coming from where you expect it to come from.<</param>
        /// <param name="scopes">List of the required scopes for your application. You don't have to pass scopes if you don't need any.</param>
        /// <returns>The sign-in url for your user to use to sign-in.</returns>
        /// <exception cref="ArgumentNullException" ><paramref name="scopes"/> parameter was empty or null</exception>
        /// <seealso href="https://auth0.com/docs/secure/attack-protection/state-parameters">State Parameter</seealso>
        public string AuthorizeToSSOBasicAuthUri(string state, List<string> scopes = null)
        {
            if (string.IsNullOrEmpty(state))
            {
                throw new ArgumentNullException();
            }

            var url = GetBaseURL() + SSO_AUTHORIZE + "/?response_type=code&redirect_uri=" + HttpUtility.UrlEncode(_callbackUri) +
                "&client_id=" + _clientId + "&state=" + HttpUtility.UrlEncode(state);

            if (scopes.Any())
            {
                url += "&scope=" + HttpUtility.UrlEncode(String.Join(" ", scopes));
            }

            return url;
        }

        /// <summary>
        /// Generates the URL you should have users click on with one of the EVE Online provided button images.
        /// </summary>
        /// <param name="state">State is used to verify that the callback is coming from where you expect it to come from.<</param>
        /// <param name="challengeCode">The challenge code needed for PCKE protocol. 
        /// To create a code challenge your application will first need to create a one time use code verifier. 
        /// A simple way to do this is to generate 32 random bytes and base64url encode them. Store this code verifier as you’ll need it in a later step. 
        /// To create a corresponding code challenge, SHA-256 hash the code verifier, and then base64url encode the raw hash output. 
        /// The base64url encoding is defined in RFC 4648 and should not contain padding.</param>
        /// <param name="scopes">List of the required scopes for your application. You don't have to pass scopes if you don't need any.</param>
        /// <returns>The sign-in url for your user.</returns>
        /// <exception cref="ArgumentNullException" ><paramref name="scopes"/> parameter was empty or null</exception>
        /// <seealso href="https://auth0.com/docs/secure/attack-protection/state-parameters">State Parameter</seealso>
        public string AuthorizeToSSOPKCEUri(string state, string challengeCode, List<string> scopes = null)
        {
            if (string.IsNullOrEmpty(state))
            {
                throw new ArgumentNullException();
            }

            var url = GetBaseURL() + SSO_AUTHORIZE + "/?response_type=code&redirect_uri=" + HttpUtility.UrlEncode(_callbackUri) +
                "&client_id=" + _clientId + "&state=" + HttpUtility.UrlEncode(state) + "&code_challenge=" + challengeCode + "&code_challenge_method=S256";

            if (scopes.Any())
            {
                url += "&scope=" + HttpUtility.UrlEncode(String.Join(" ", scopes));
            }

            return url;
        }

        /// <summary>
        /// Once your application receives the callback from SSO, you call this to verify the state is the expected one to be returned and to request an access code with the authenication code you were given.
        /// </summary>
        /// <param name="authorizationCode">The authorizationCode to use to get the access/refresh tokens.</param>
        /// <returns><c>AccessTokenDetails</c></returns>
        /// <exception cref="EVEStandardException" ></exception>
        public async Task<AccessTokenDetails> VerifyAuthorizationForBasicAuthAsync(string authorizationCode)
        {
            try
            {
                var byteArray = Encoding.ASCII.GetBytes(_clientId + ":" + _clientSecret);

                var stringContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("grant_type", "authorization_code"),
                    new KeyValuePair<string, string>("code", authorizationCode)
                });
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri(GetBaseURL() + SSO_TOKEN),
                    Method = HttpMethod.Post,
                    Content = stringContent
                };
                request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                var response = await _httpClient.SendAsync(request).ConfigureAwait(false);
                return JsonSerializer.Deserialize<AccessTokenDetails>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception inner)
            {

                throw new EVEStandardException("An error occured with the SSO.VerifyAuthorizationAsync request/response", inner);
            }
        }

        /// <summary>
        /// Once your application receives the callback from SSO, you call this to verify the state is the expected one to be returned and to request an access code with the authenication code you were given.
        /// </summary>
        /// <param name="authorizationCode">The authorizationCode to use to get the access/refresh tokens.</param>
        /// <param name="challengeCode">This is the same challengeCode you passed to <see cref="AuthorizeToSSOPKCEUri"/></param>
        /// <returns><c>AccessTokenDetails</c></returns>
        /// <exception cref="EVEStandardException" ></exception>
        public async Task<AccessTokenDetails> VerifyAuthorizationForPKCEAuthAsync(string authorizationCode, string challengeCode)
        {
            try
            {
                var stringContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("grant_type", "authorization_code"),
                    new KeyValuePair<string, string>("code", authorizationCode),
                    new KeyValuePair<string, string>("client_id", _clientId),
                    new KeyValuePair<string, string>("code_verifier", challengeCode)
                });
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri(GetBaseURL() + SSO_TOKEN),
                    Method = HttpMethod.Post,
                    Content = stringContent
                };

                var response = await _httpClient.SendAsync(request).ConfigureAwait(false);
                return JsonSerializer.Deserialize<AccessTokenDetails>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception inner)
            {

                throw new EVEStandardException("An error occured with the SSO.VerifyAuthorizationAsync request/response", inner);
            }
        }

        /// <summary>
        /// If your access token has expired and you need a new one you can pass the <c>AccessTokenDetails</c> POCO here, with a valid refresh token, to retrieve a new access token and a new refresh token.
        /// </summary>
        /// <param name="refreshToken">The refresh token you want to use to get a new access token.</param>
        /// <param name="scopes">A subset of the original scopes assigned to the authorization and refresh token. If omitted, all original scopes will be assigned to the new access token.</param>
        /// <returns><c>AccessTokenDetails</c></returns>
        /// <exception cref="EVEStandardException" ></exception>
        public async Task<AccessTokenDetails> GetNewBasicAuthAccessAndRefreshTokenAsync(string refreshToken, List<string> scopes = null)
        {
            try
            {
                var byteArray = Encoding.ASCII.GetBytes(_clientId + ":" + _clientSecret);

                var urlEncodedContent = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("grant_type", "refresh_token"),
                    new KeyValuePair<string, string>("refresh_token", refreshToken)
                };

                if (scopes.Any())
                {
                    urlEncodedContent.Add(new KeyValuePair<string, string>("scope", HttpUtility.UrlEncode(String.Join(" ", scopes))));
                }

                var stringContent = new FormUrlEncodedContent(urlEncodedContent);

                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri(GetBaseURL() + SSO_TOKEN),
                    Method = HttpMethod.Post,
                    Content = stringContent
                };
                request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                var response = await _httpClient.SendAsync(request).ConfigureAwait(false);
                return JsonSerializer.Deserialize<AccessTokenDetails>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception inner)
            {

                throw new EVEStandardException("An error occured with some part of the http request/response", inner);
            }
        }

        /// <summary>
        /// If your access token has expired and you need a new one you can pass the <c>AccessTokenDetails</c> POCO here, with a valid refresh token, to retrieve a new access token and a new refresh token.
        /// </summary>
        /// <param name="refreshToken">The refresh token you want to use to get a new access token.</param>
        /// <param name="scopes">A subset of the original scopes assigned to the authorization and refresh token. If omitted, all original scopes will be assigned to the new access token.</param>
        /// <returns><c>AccessTokenDetails</c></returns>
        /// <exception cref="EVEStandardException" ></exception>
        public async Task<AccessTokenDetails> GetNewPKCEAccessAndRefreshTokenAsync(string refreshToken, List<string> scopes = null)
        {
            try
            {
                var urlEncodedContent = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("grant_type", "refresh_token"),
                    new KeyValuePair<string, string>("refresh_token", refreshToken),
                    new KeyValuePair<string, string>("client_id", _clientId)
                };

                if (scopes.Any())
                {
                    urlEncodedContent.Add(new KeyValuePair<string, string>("scope", HttpUtility.UrlEncode(String.Join(" ", scopes))));
                }

                var stringContent = new FormUrlEncodedContent(urlEncodedContent);

                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri(GetBaseURL() + SSO_TOKEN),
                    Method = HttpMethod.Post,
                    Content = stringContent
                };

                var response = await _httpClient.SendAsync(request).ConfigureAwait(false);
                return JsonSerializer.Deserialize<AccessTokenDetails>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception inner)
            {

                throw new EVEStandardException("An error occured with some part of the http request/response", inner);
            }
        }

        /// <summary>
        /// Returns the character and token data inside the access token.
        /// </summary>
        /// <param name="accessToken">The access token used to retrieve character details.</param>
        /// <returns><c>CharacterDetails</c></returns>
        /// <exception cref="EVEStandardException" ></exception>
        public async Task<CharacterDetails> GetCharacterDetailsAsync(string accessToken)
        {
            try
            {
                var wellKnownResponse = await _httpClient.GetAsync(SSO_META_DATA_URL);
                wellKnownResponse.EnsureSuccessStatusCode();
                var wellKnownData = JsonDocument.Parse(await wellKnownResponse.Content.ReadAsStreamAsync());
                var jwksUrl = wellKnownData.RootElement.GetProperty("jwks_uri").GetString() ?? throw new EVEStandardException("Could not get jwks_uri to verify access token.");

                var jwksResponse = await _httpClient.GetAsync(jwksUrl);
                jwksResponse.EnsureSuccessStatusCode();
                var keys = new JsonWebKeySet(await jwksResponse.Content.ReadAsStringAsync());

                var validationParameters = new TokenValidationParameters
                {
                    IssuerSigningKeys = keys.GetSigningKeys(),
                    ValidAudience = JWK_AUDIENCE, // Your API Audience, can be disabled via ValidateAudience = false
                    ValidIssuers = JWK_ISSUERS  // Your token issuer, can be disabled via ValidateIssuer = false
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                tokenHandler.ValidateToken(accessToken, validationParameters, out var validatedToken);
                if(validatedToken == null)
                {
                    throw new EVEStandardException("Token given was invalid");
                }
                var token = tokenHandler.ReadJwtToken(accessToken);

                return new CharacterDetails
                {
                    CharacterId = int.Parse(token.Subject.Split(":")[2]),
                    CharacterName = token.Claims.ToList().Single(x => x.Type == "name").Value,
                    ExpiresOn = token.ValidTo,
                    Scopes = token.Claims.ToList().Where(x => x.Type == "scp").Select(x => x.Value).ToList(),
                    TokenType = "JWT",
                    CharacterOwnerHash = token.Claims.ToList().Single(x => x.Type == "owner").Value,
                    ClientId = token.Claims.ToList().Single(x => x.Type == "azp").Value
                };
            }
            catch (HttpRequestException e)
            {
                throw new EVEStandardException("An error occured trying to get the SSO key needed to validate access tokens.", e);
            }
            catch(KeyNotFoundException e)
            {
                throw new EVEStandardException("An error occured trying to get the SSO jwks_uri needed to validate access tokens.", e);
            }
            catch (Exception inner)
            {

                throw new EVEStandardException("An error occured trying to get keys for access token verification.", inner);
            }
        }

        /// <summary>
        /// Revokes either the access token or the refresh token a user gave access to.
        /// </summary>
        /// <param name="type">Was it an access or refresh token you are trying to revoke?</param>
        /// <param name="token">The token you are trying to revoke.</param>
        /// <returns>True if the token was revoked.</returns>
        public async Task<bool> RevokeTokenAsync(RevokeType type, string token)
        {
            try
            {
                var byteArray = Encoding.ASCII.GetBytes(_clientId + ":" + _clientSecret);
                var stringContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("token_type_hint", type == RevokeType.ACCESS_TOKEN ? "access_token" : "refresh_token"),
                    new KeyValuePair<string, string>("token", token)
                });
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri(GetBaseURL() + SSO_REVOKE),
                    Method = HttpMethod.Post,
                    Content = stringContent
                };
                request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                var response = await _httpClient.SendAsync(request);
                return response.IsSuccessStatusCode;
            }
            catch (Exception inner)
            {

                throw new EVEStandardException("An error occured with some part of the http request/response", inner);
            }
        }

        // ReSharper disable once InconsistentNaming
        private string GetBaseURL()
        {
            switch (_dataSource)
            {
                case DataSource.Tranquility:
                    return TRANQUILITY_SSO_BASE_URL;
                case DataSource.Serenity:
                    return SERENITY_SSO_BASE_URL;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
