using EVEStandard.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EVEStandard.API
{
    public class Alliances : APIBase
    {
        internal Alliances(string dataSource) : base(dataSource)
        {
        }

        public async Task<Alliance> GetAllianceInfoV3Async(long allianceId)
        {
            var responseModel = await this.GetAsync("/v3/alliances/" + allianceId + "/");

            if (responseModel.Error)
            {
                throw new EVEStandardException("GetAllianceInfoV3Async failed");
            }
            if (responseModel.LegacyWarning)
            {
                // log it? unsure how best to handle this. Maybe throw a legacy exception?
            }

            return JsonConvert.DeserializeObject<Alliance>(responseModel.JSONString);
        }

        public async Task<List<long>> ListAllianceCorporationsV1Async(long allianceId)
        {
            var responseModel = await this.GetAsync("/v1/alliances/" + allianceId + "/corporations/");

            if (responseModel.Error)
            {
                throw new EVEStandardException("ListAllianceCorporationsV1Async failed");
            }
            if (responseModel.LegacyWarning)
            {
                // log it? unsure how best to handle this. Maybe throw a legacy exception?
            }

            return JsonConvert.DeserializeObject<List<long>>(responseModel.JSONString);
        }

        public async Task<List<AllianceName>> GetAllianceNamesV2Async(List<long> allianceIds)
        {
            var queryParameters = new Dictionary<string, string>
            {
                { "alliance_ids", allianceIds == null || allianceIds.Count == 0 ? "" : string.Join(",", allianceIds) }
            };

            var responseModel = await this.GetAsync("/v2/alliances/names/", queryParameters);

            if (responseModel.Error)
            {
                throw new EVEStandardException("GetAllianceNamesV2Async failed");
            }
            if (responseModel.LegacyWarning)
            {
                // log it? unsure how best to handle this. Maybe throw a legacy exception?
            }

            return JsonConvert.DeserializeObject<List<AllianceName>>(responseModel.JSONString);
        }

        public async Task<AllianceIcons> GetAllianceIconV1Async(long allianceId)
        {
            var responseModel = await this.GetAsync("/v1/alliances/" + allianceId + "/icons/");

            if (responseModel.Error)
            {
                throw new EVEStandardException("GetAllianceIconV1Async failed");
            }
            if (responseModel.LegacyWarning)
            {
                // log it? unsure how best to handle this. Maybe throw a legacy exception?
            }

            return JsonConvert.DeserializeObject<AllianceIcons>(responseModel.JSONString);
        }

        public async Task<List<long>> ListAllAlliancesV1Async()
        {
            var responseModel = await this.GetAsync("/v1/alliances/");

            if (responseModel.Error)
            {
                throw new EVEStandardException("ListAllAlliancesV1Async failed");
            }
            if (responseModel.LegacyWarning)
            {
                // log it? unsure how best to handle this. Maybe throw a legacy exception?
            }

            return JsonConvert.DeserializeObject<List<long>>(responseModel.JSONString);
        }
    }
}
