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

        public async Task<List<Asset>> GetCharacterAssetsV3Async(AuthDTO auth)
        {
            checkAuth(auth, "esi-assets.read_assets.v1");

            var responseModel = await this.GetAsync("/v3/characters/" + auth.Character.CharacterID + "/assets/", auth);

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
