using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EVEStandard.API
{
    public class Contracts : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Contracts>();
        internal Contracts(string dataSource) : base(dataSource)
        {
        }

        public async Task<ESIModelDTO<List<Contract>>> GetContractsV1Async(AuthDTO auth, int page=1, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_CONTRACTS_READ_CHARACTER_CONTRACTS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/contracts/", auth, ifNoneMatch, queryParameters);

            checkResponse("GetContractsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<Contract>>(responseModel);
        }

        public async Task<ESIModelDTO<List<ContractItem>>> GetContractItemsV1Async(AuthDTO auth, int contractId, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_CONTRACTS_READ_CHARACTER_CONTRACTS_1);

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/contracts/" + contractId + "/items/", auth, ifNoneMatch);

            checkResponse("GetContractItemsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<ContractItem>>(responseModel);
        }

        public async Task<ESIModelDTO<List<ContractBid>>> GetContractBidsV1Async(AuthDTO auth, int contractId, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_CONTRACTS_READ_CHARACTER_CONTRACTS_1);

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/contracts/" + contractId + "/bids/", auth, ifNoneMatch);

            checkResponse("GetContractBidsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<ContractBid>>(responseModel);
        }

        public async Task<ESIModelDTO<List<Contract>>> GetCorporationContractsV1Async(AuthDTO auth, int page, int corporationId, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_CONTRACTS_READ_CORPORATION_CONTRACTS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v1/corporations/" + corporationId + "/contracts/", auth, ifNoneMatch, queryParameters);

            checkResponse("GetCorporationContractsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<Contract>>(responseModel);
        }

        public async Task<ESIModelDTO<List<ContractItem>>> GetCorporationContractItemsV1Async(AuthDTO auth, int contractId, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_CONTRACTS_READ_CORPORATION_CONTRACTS_1);

            var responseModel = await GetAsync("/v1/corporations/" + auth.Character.CharacterID + "/contracts/" + contractId + "/items/", auth, ifNoneMatch);

            checkResponse("GetCorporationContractItemsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<ContractItem>>(responseModel);
        }

        public async Task<ESIModelDTO<List<ContractBid>>> GetCorporationContractBidsV1Async(AuthDTO auth, int contractId, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_CONTRACTS_READ_CORPORATION_CONTRACTS_1);

            var responseModel = await GetAsync("/v1/corporations/" + auth.Character.CharacterID + "/contracts/" + contractId + "/bids/", auth, ifNoneMatch);

            checkResponse("GetCorporationContractBidsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<ContractBid>>(responseModel);
        }
    }
}
