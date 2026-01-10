using EVEStandard.Models.SSO;

namespace EVEStandard.Models.API
{
    public class AuthDTO
    {
        public AccessTokenDetails AccessToken { get; set; }
        public long CharacterId { get; set; }
        public string Scopes { get; set; }
    }
}
