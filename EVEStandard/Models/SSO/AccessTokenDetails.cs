using System;
using System.Text.Json.Serialization;

namespace EVEStandard.Models.SSO
{
    public class AccessTokenDetails
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }
        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }
        [JsonPropertyName("expires_in")]
        public int ExpiresIn
        {
            get => _expiresIn;
            set
            {
                ExpiresUtc = DateTime.UtcNow.AddSeconds(value);
                _expiresIn = value;
            }
        }
        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }
        public DateTime ExpiresUtc { get; set; }

        private int _expiresIn;
    }
}
