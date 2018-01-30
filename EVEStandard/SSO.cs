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

        public SSO(string callbackUri, string clientId, string secretKey)
        {
            if(string.IsNullOrEmpty(callbackUri) || string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(secretKey))
            {
                throw new EVEStandardException("SSO initialized with invalid strings. callbackUri: " + callbackUri + " clientId: " + clientId + " secretKey: " + secretKey);
            }

            http = new HttpClient();

            this.callbackUri = callbackUri;
            this.clientId = clientId;
            this.secretKey = secretKey;
        }

        public Authorization AuthorizeToEVEURI(List<string> scopes)
        {
            return AuthorizeToEVEURI(scopes, Convert.ToBase64String(Guid.NewGuid().ToByteArray()));
        }

        public Authorization AuthorizeToEVEURI(List<string> scopes, string state)
        {
            var model = new Authorization
            {
                ExpectedState = state
            };

            if (scopes.Count == 0 || scopes == null)
            {
                throw new EVEStandardException("scopes parameter in SSO.AuthorizeToEVEURI is invalid");
            }

            model.SignInURI = SINGULARITY_SSO_BASE_URL + SSO_AUTHORIZE + "response_type=code&redirect_uri=" + HttpUtility.UrlEncode(this.callbackUri) +
                "&client_id=" + this.clientId + "&scope=" + HttpUtility.UrlEncode(String.Join(" ", scopes)) + "&state=" + model.ExpectedState;

            return model;
        }

        public async Task<AccessTokenDetails> VerifyAuthorizationAsync(Authorization model)
        {
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

        public async Task<AccessTokenDetails> RefreshToken(AccessTokenDetails model)
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

        public async Task<CharacterDetails> GetCharacterAsync(AccessTokenDetails model)
        {
            http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", model.AccessToken);
            var verifyResponse = await http.GetAsync(SINGULARITY_SSO_BASE_URL + SSO_VERIFY);
            var s = verifyResponse.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<CharacterDetails>(verifyResponse.Content.ReadAsStringAsync().Result);
        }

        public async Task<bool> RevokeToken(RevokeType type, string token)
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
