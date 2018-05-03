using System;
using Newtonsoft.Json;

namespace EVEStandard.Models.SSO
{
    public class AccessTokenDetails
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
        [JsonProperty("expires_in")]
        public int ExpiresIn
        {
            get => _expiresIn;
            set
            {
                Expires = DateTime.UtcNow.AddSeconds(value);
                _expiresIn = value;
            }
        }
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
        public DateTime Expires { get; set; }

        private int _expiresIn;
    }
}
