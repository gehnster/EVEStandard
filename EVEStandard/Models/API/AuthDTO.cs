using EVEStandard.Models.SSO;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVEStandard.Models.API
{
    public class AuthDTO
    {
        public AccessTokenDetails AccessToken { get; set; }
        public CharacterDetails Character { get; set; }
    }
}
