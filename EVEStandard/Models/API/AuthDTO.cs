using System;
using System.Collections.Generic;
using EVEStandard.Models.SSO;

namespace EVEStandard.Models.API
{
    public class AuthDTO
    {
        public long CharacterId { get; set; }
        public AccessTokenDetails AccessToken { get; set; }
        public string Scopes { get; set; }
    }
}
