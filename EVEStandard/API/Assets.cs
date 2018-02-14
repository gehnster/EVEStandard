using EVEStandard.Models;
using EVEStandard.Models.API;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    public class Assets : APIBase
    {
        internal Assets(string dataSource) : base(dataSource)
        {
        }

        public async Task<List<Asset>> GetCharacterAssetsV3Async(AuthDTO dto)
        {
            if(dto == null || dto.Character == null || dto.AccessToken == null)
            {
                throw new ArgumentNullException();
            }

            if(!dto.Character.Scopes.Contains("esi-assets.read_assets.v1"))
            {
                // throw same standard exception or a new no scope exception?
            }

            var responseModel = await this.GetAuthAsync(ESI_BASE + "/v3/characters/" + dto.Character.CharacterID + "/assets/", dto);

            if (responseModel.Error)
            {
                throw new EVEStandardException("GetCharacterAssetsV3Async failed");
            }
            if (responseModel.LegacyWarning)
            {
                // log it? unsure how best to handle this. Maybe throw a legacy exception?
            }

            return JsonConvert.DeserializeObject<List<Asset>>(responseModel.JSONString);
        }
    }
}
