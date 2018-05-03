using EVEStandard.Models.SSO;

namespace EVEStandard.Models.API
{
    public class AuthDTO
    {
        public AccessTokenDetails AccessToken { get; set; }
        public CharacterDetails Character { get; set; }
    }
}
