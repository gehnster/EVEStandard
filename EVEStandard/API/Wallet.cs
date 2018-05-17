using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EVEStandard.API
{
    public class Wallet : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Wallet>();
        internal Wallet(string dataSource) : base(dataSource)
        {
        }

        public async Task<ESIModelDTO<double>> GetCharacterWalletBalanceV1Async(AuthDTO auth, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_WALLET_READ_CHARACTER_WALLET_1);

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/wallet/", auth, ifNoneMatch);

            checkResponse("CalculationCSPAChargeCostV4Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<double>(responseModel);
        }

        public async Task<ESIModelDTO<List<CharacterWalletJournal>>> GetCharacterWalletJournalV4Async(AuthDTO auth, int page, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_WALLET_READ_CHARACTER_WALLET_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v4/characters/" + auth.Character.CharacterID + "/wallet/journal/", auth, ifNoneMatch, queryParameters);

            checkResponse("GetCharacterWalletJournalV4Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<CharacterWalletJournal>>(responseModel);
        }

        public async Task<ESIModelDTO<List<WalletTransaction>>> GetCharacterWalletTransactionsV1Async(AuthDTO auth, long fromId, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_WALLET_READ_CHARACTER_WALLET_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "from_id", fromId.ToString() }
            };

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/wallet/transactions/", auth, ifNoneMatch, queryParameters);

            checkResponse("GetCharacterWalletTransactionsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<WalletTransaction>>(responseModel);
        }

        public async Task<ESIModelDTO<List<CorporationWallet>>> ReturnCorporationWalletBalanceV1Async(AuthDTO auth, int corpId, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_WALLET_READ_CORPORATION_WALLETS_1);

            var responseModel = await GetAsync("/v1/corporations/" + corpId + "/wallet/", auth, ifNoneMatch);

            checkResponse("ReturnCorporationWalletBalanceV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<CorporationWallet>>(responseModel);
        }

        public async Task<ESIModelDTO<List<CorporationWalletJournal>>> GetCorporationWalletJournalV3Async(AuthDTO auth, int corpId, int division, int page=1, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_WALLET_READ_CORPORATION_WALLETS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v3/corporations/" + corpId + "/wallet/" + division + "/journal/", auth, ifNoneMatch, queryParameters);

            checkResponse("GetCorporationWalletJournalV3Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<CorporationWalletJournal>>(responseModel);
        }

        public async Task<ESIModelDTO<List<WalletTransaction>>> GetCorporationWalletTransactionsV1Async(AuthDTO auth, int corpId, int division, long fromId, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_WALLET_READ_CORPORATION_WALLETS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "from_id", fromId.ToString() }
            };

            var responseModel = await GetAsync("/v1/corporations/" + corpId + "/wallet/" + division + "/transactions/", auth, ifNoneMatch, queryParameters);

            checkResponse("GetCharacterWalletTransactionsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return returnModelDTO<List<WalletTransaction>>(responseModel);
        }
    }
}
