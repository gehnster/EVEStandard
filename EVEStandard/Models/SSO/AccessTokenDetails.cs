using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

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
            get => this._expiresIn;
            set
            {
                this.Expires = DateTime.UtcNow.AddSeconds(value);
                this._expiresIn = value;
            }
        }
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
        public DateTime Expires { get; set; }

        private int _expiresIn;
    }
}
