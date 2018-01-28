using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Web;

namespace EVEStandard
{
    public class SSO
    {
        private HttpClient http;

        private static readonly string SINGULARITY_SSO_BASE_URL = "https://login.eveonline.com";
        private static readonly string TRANQUILITY_SSO_BASE_URL = "https://sisilogin.testeveonline.com";
        private static readonly string SSO_AUTHORIZE = "/oauth/authorize/?";
        private static readonly string SSO_TOKEN = "/oauth/token";
        private static readonly string SSO_VERIFY = "/oauth/verify";

        private string callbackUri = null;
        private string clientId = null;
        private string secretKey = null;

        public SSO(string callbackUri, string clientId, string secretKey)
        {
            if(string.IsNullOrEmpty(callbackUri) || string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(secretKey))
            {
                throw new EVEStandardException("SSO initialized with invalid strings. callbackUri: " + callbackUri + " clientId: " + clientId + " secretKey: " + secretKey);
            }

            this.callbackUri = callbackUri;
            this.clientId = clientId;
            this.secretKey = secretKey;
        }

        public string AuthorizeToEVEURI(List<string> scopes, out string expectedState)
        {
            expectedState = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            if(scopes.Count == 0 || scopes == null)
            {
                throw new EVEStandardException("scopes parameter in SSO.AuthorizeToEVEURI is invalid");
            }

            return SINGULARITY_SSO_BASE_URL + SSO_AUTHORIZE + "response_type=code&redirect_uri="
                + HttpUtility.UrlEncode(this.callbackUri) + "&client_id=" + this.clientId + "&scope=" + HttpUtility.UrlEncode(String.Join(" ", scopes)) + "&state=" + expectedState;
        }
    }
}
