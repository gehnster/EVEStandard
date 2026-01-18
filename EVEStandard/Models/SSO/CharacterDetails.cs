using System;
using System.Collections.Generic;

namespace EVEStandard.Models.SSO
{
    public class CharacterDetails
    {
        public long CharacterId { get; set; }
        public string CharacterName { get; set; }
        public DateTime ExpiresOn { get; set; }
        public List<string> Scopes { get; set; }
        public string TokenType { get; set; }
        public string CharacterOwnerHash { get; set; }
        public string ClientId { get; set; }
    }
}
