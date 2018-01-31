using EVEStandard.Enumerations;
using EVEStandard.Models.SSO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EVEStandard
{
    /// <summary>
    /// The SSO specifies the workflow required to use Single Sign-On with EVE Online. SSO can be used purely 
    /// for authentication or also for accessing ESI API endpoints that require specific scopes.
    /// </summary>
    /// <remarks>
    /// For information on how to utilize the SSO class please refer to the README on our GitHub.
    /// <see cref="https://github.com/gehnster/EVEStandard"/>
    /// </remarks>
    public class SSO
    {
        private static HttpClient http;

        private static readonly string SINGULARITY_SSO_BASE_URL = "https://login.eveonline.com";
        private static readonly string TRANQUILITY_SSO_BASE_URL = "https://sisilogin.testeveonline.com";
        private static readonly string SSO_AUTHORIZE = "/oauth/authorize/?";
        private static readonly string SSO_TOKEN = "/oauth/token";
        private static readonly string SSO_VERIFY = "/oauth/verify";
        private static readonly string SSO_REVOKE = "/oauth/revoke";

        private string callbackUri = null;
        private string clientId = null;
        private string secretKey = null;

        /// <summary>
        /// Contructor for SSO class.
        /// </summary>
        /// <param name="callbackUri">The Callback URL that you provided in your ESI application. If this doesn't match with what ESI has then SSO auth will fail.</param>
        /// <param name="clientId">The Client Id you were assigned in your ESI application.</param>
        /// <param name="secretKey">The Secret Key you were assigned in your ESI application, this should NEVER be human-readable in your application.</param>
        /// <exception cref="EVEStandardException" >Called when any of the parameters is null or empty.</exception>
        /// <remarks>
        /// Except for public data within ESI, you need an application to gain access behind SSO. You can create an application at <see cref="https://developers.eveonline.com/"/>
        /// You will probably want to create at least two applications, one for local development and one for production since the <paramref name="callbackUri"/> requires to match in the callback.
        /// </remarks>
        public SSO(string callbackUri, string clientId, string secretKey)
        {
            if(string.IsNullOrEmpty(callbackUri) || string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(secretKey))
            {
                throw new EVEStandardException("SSO should be initialized with non-null and non-empty strings. callbackUri: " + callbackUri + " clientId: " + clientId + " secretKey: " + secretKey);
            }

            http = new HttpClient();

            this.callbackUri = callbackUri;
            this.clientId = clientId;
            this.secretKey = secretKey;
        }

        /// <summary>
        /// Generates the URL you should have users click on with one of the EVE Online provided button images.
        /// A state parameter in the URL is optional, but expected for security so this function creates one based on a Base64 encoded Guid.
        /// </summary>
        /// <param name="scopes">List of the required scopes for your application</param>
        /// <returns>The <c>Authorization</c> POCO with the SignInURI parameter set and the ExpectedState parameter set.</returns>
        /// <exception cref="EVEStandardException" ><paramref name="scopes"/> parameter was empty or null</exception>
        public Authorization AuthorizeToEVEURI(List<string> scopes)
        {
            return AuthorizeToEVEURI(scopes, Convert.ToBase64String(Guid.NewGuid().ToByteArray()));
        }

        /// <summary>
        /// Generates the URL you should have users click on with one of the EVE Online provided button images.
        /// A state parameter in the URL is optional, but expected for security.
        /// </summary>
        /// <param name="scopes">List of the required scopes for your application</param>
        /// <param name="state">State is used to verify that the callback is coming from where you expect it to come from.</param>
        /// <returns>The <c>Authorization</c> POCO with the SignInURI parameter set and the ExpectedState parameter set.</returns>
        /// <exception cref="EVEStandardException" ><paramref name="scopes"/> parameter was empty or null</exception>
        public Authorization AuthorizeToEVEURI(List<string> scopes, string state)
        {
            if (scopes.Count == 0 || scopes == null)
            {
                throw new EVEStandardException("scopes parameter in SSO.AuthorizeToEVEURI is invalid");
            }

            var model = new Authorization
            {
                ExpectedState = state ?? ""
            };

            model.SignInURI = SINGULARITY_SSO_BASE_URL + SSO_AUTHORIZE + "response_type=code&redirect_uri=" + HttpUtility.UrlEncode(this.callbackUri) +
                "&client_id=" + this.clientId + "&scope=" + HttpUtility.UrlEncode(String.Join(" ", scopes)) + "&state=" + model.ExpectedState;

            return model;
        }

        public async Task<AccessTokenDetails> VerifyAuthorizationAsync(Authorization model)
        {
            if(model.ReturnedState == null)
            {
                model.ReturnedState = "";
            }

            if(model.ExpectedState != model.ReturnedState)
            {
                throw new EVEStandardException("model parameter expected the ExpectedState to match the ReturnedState");
            }

            var byteArray = Encoding.ASCII.GetBytes(this.clientId + ":" + this.secretKey);
            http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            var stringContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "authorization_code"),
                new KeyValuePair<string, string>("code", model.AuthorizationCode),
            });

            var response = await http.PostAsync(SINGULARITY_SSO_BASE_URL + SSO_TOKEN, stringContent);
            return JsonConvert.DeserializeObject<AccessTokenDetails>(response.Content.ReadAsStringAsync().Result);
        }

        public async Task<AccessTokenDetails> GetRefreshTokenAsync(AccessTokenDetails model)
        {
            var byteArray = Encoding.ASCII.GetBytes(this.clientId + ":" + this.secretKey);
            http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            var stringContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "refresh_token"),
                new KeyValuePair<string, string>("refresh_token", model.RefreshToken),
            });

            var response = await http.PostAsync(SINGULARITY_SSO_BASE_URL + SSO_TOKEN, stringContent);
            return JsonConvert.DeserializeObject<AccessTokenDetails>(response.Content.ReadAsStringAsync().Result);
        }

        public async Task<CharacterDetails> GetCharacterDetailsAsync(AccessTokenDetails model)
        {
            http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", model.AccessToken);
            var verifyResponse = await http.GetAsync(SINGULARITY_SSO_BASE_URL + SSO_VERIFY);
            var s = verifyResponse.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<CharacterDetails>(verifyResponse.Content.ReadAsStringAsync().Result);
        }

        /// <summary>
        /// Revokes either the access token or the refresh token a user gave access to.
        /// </summary>
        /// <param name="type">Was it an access or refresh token you are trying to revoke?</param>
        /// <param name="token">The token you are trying to revoke.</param>
        /// <returns>True if the token was revoked.</returns>
        public async Task<bool> RevokeTokenAsync(RevokeType type, string token)
        {
            var byteArray = Encoding.ASCII.GetBytes(this.clientId + ":" + this.secretKey);
            http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            var stringContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("token_type_hint", type == RevokeType.ACCESS_TOKEN ? "access_token" : "refresh_token"),
                new KeyValuePair<string, string>("token", token),
            });

            var response = await http.PostAsync(SINGULARITY_SSO_BASE_URL + SSO_TOKEN, stringContent);
            return response.IsSuccessStatusCode;
        }
    }
}
