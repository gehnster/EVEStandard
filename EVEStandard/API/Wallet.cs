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

        public async Task<double> GetCharacterWalletBalanceV1Async(AuthDTO auth)
        {
            checkAuth(auth, Scopes.ESI_WALLET_READ_CHARACTER_WALLET_1);

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/wallet/", auth);

            checkResponse("CalculationCSPAChargeCostV4Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<double>(responseModel.JSONString);
        }

        public async Task<(List<CharacterWalletJournal>, long)> GetCharacterWalletJournalV4Async(AuthDTO auth, long page)
        {
            checkAuth(auth, Scopes.ESI_WALLET_READ_CHARACTER_WALLET_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v4/characters/" + auth.Character.CharacterID + "/wallet/journal/", auth, queryParameters);

            checkResponse("GetCharacterWalletJournalV4Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return (JsonConvert.DeserializeObject<List<CharacterWalletJournal>>(responseModel.JSONString), responseModel.MaxPages);
        }

        public async Task<List<WalletTransaction>> GetCharacterWalletTransactionsV1Async(AuthDTO auth, long fromId)
        {
            checkAuth(auth, Scopes.ESI_WALLET_READ_CHARACTER_WALLET_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "from_id", fromId.ToString() }
            };

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/wallet/transactions/", auth, queryParameters);

            checkResponse("GetCharacterWalletTransactionsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<WalletTransaction>>(responseModel.JSONString);
        }

        public async Task<List<CorporationWallet>> ReturnCorporationWalletBalanceV1Async(AuthDTO auth, int corpId)
        {
            checkAuth(auth, Scopes.ESI_WALLET_READ_CORPORATION_WALLETS_1);

            var responseModel = await GetAsync("/v1/corporations/" + corpId + "/wallet/", auth);

            checkResponse("ReturnCorporationWalletBalanceV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<CorporationWallet>>(responseModel.JSONString);
        }

        public async Task<(List<CorporationWalletJournal>, long)> GetCorporationWalletJournalV3Async(AuthDTO auth, int corpId, int division, long page)
        {
            checkAuth(auth, Scopes.ESI_WALLET_READ_CORPORATION_WALLETS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync("/v3/corporations/" + corpId + "/wallet/" + division + "/journal/", auth, queryParameters);

            checkResponse("GetCorporationWalletJournalV3Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return (JsonConvert.DeserializeObject<List<CorporationWalletJournal>>(responseModel.JSONString), responseModel.MaxPages);
        }

        public async Task<List<WalletTransaction>> GetCorporationWalletTransactionsV1Async(AuthDTO auth, int corpId, int division, long fromId)
        {
            checkAuth(auth, Scopes.ESI_WALLET_READ_CORPORATION_WALLETS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "from_id", fromId.ToString() }
            };

            var responseModel = await GetAsync("/v1/corporations/" + corpId + "/wallet/" + division + "/transactions/", auth, queryParameters);

            checkResponse("GetCharacterWalletTransactionsV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, Logger);

            return JsonConvert.DeserializeObject<List<WalletTransaction>>(responseModel.JSONString);
        }
    }
}
