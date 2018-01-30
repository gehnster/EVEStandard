using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.Models.SSO
{
    public class CharacterDetails
    {
        public int CharacterID { get; set; }
        public string CharacterName { get; set; }
        public DateTime ExpiresOn { get; set; }
        public string Scopes { get; set; }
        public string TokenType { get; set; }
        public string CharacterOwnerHash { get; set; }
    }
}
