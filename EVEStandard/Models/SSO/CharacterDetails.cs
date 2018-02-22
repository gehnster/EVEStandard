using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.Models.SSO
{
    public class CharacterDetails
    {
        [JsonProperty("CharacterID")]
        public int CharacterID { get; set; }
        [JsonProperty("CharacterName")]
        public string CharacterName { get; set; }
        [JsonProperty("ExpiresOn")]
        public DateTime ExpiresOn { get; set; }
        [JsonProperty("Scopes")]
        public string Scopes { get; set; }
        [JsonProperty("TokenType")]
        public string TokenType { get; set; }
        [JsonProperty("CharacterOwnerHash")]
        public string CharacterOwnerHash { get; set; }
    }
}
