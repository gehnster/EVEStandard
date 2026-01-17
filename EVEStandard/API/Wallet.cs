using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    /// <summary>
    /// Wallet API
    /// </summary>
    /// <seealso cref="EVEStandard.API.APIBase" />
    public class Wallet : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Wallet>();

        internal Wallet(string dataSource, CompatibilityDate compatibilityDate) : base(dataSource, compatibilityDate)
        {
        }

        /// <summary>
        /// Returns a character’s wallet balance.
        /// <para>GET /characters/{character_id}/wallet/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing wallet balance.</returns>
        public async Task<ESIModelDTO<double>> GetCharacterWalletBalanceAsync(AuthDTO auth, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_WALLET_READ_CHARACTER_WALLET_1);

            var responseModel = await GetAsync($"/characters/{auth.CharacterId}/wallet/", auth, ifNoneMatch);

            CheckResponse(nameof(GetCharacterWalletBalanceAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<double>(responseModel);
        }

        /// <summary>
        /// Retrieve the given character’s wallet journal going 30 days back.
        /// <para>GET /characters/{character_id}/wallet/journal/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing journal entries.</returns>
        public async Task<ESIModelDTO<List<CharacterWalletJournal>>> GetCharacterWalletJournalAsync(AuthDTO auth, int page, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_WALLET_READ_CHARACTER_WALLET_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/characters/{auth.CharacterId}/wallet/journal/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetCharacterWalletJournalAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<CharacterWalletJournal>>(responseModel);
        }

        /// <summary>
        /// Get wallet transactions of a character.
        /// <para>GET /characters/{character_id}/wallet/transactions/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="fromId">Only show transactions happened before the one referenced by this id.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing wallet transactions.</returns>
        public async Task<ESIModelDTO<List<WalletTransaction>>> GetCharacterWalletTransactionsAsync(AuthDTO auth, long fromId, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_WALLET_READ_CHARACTER_WALLET_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "from_id", fromId.ToString() }
            };

            var responseModel = await GetAsync($"/characters/{auth.CharacterId}/wallet/transactions/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetCharacterWalletTransactionsAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<WalletTransaction>>(responseModel);
        }

        /// <summary>
        /// Get a corporation’s wallets.
        /// <para>GET /corporations/{corporation_id}/wallets/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corpId">An EVE corporation ID.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing list of corporation wallets.</returns>
        public async Task<ESIModelDTO<List<CorporationWallet>>> ReturnCorporationWalletBalanceAsync(AuthDTO auth, long corpId, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_WALLET_READ_CORPORATION_WALLETS_1);

            var responseModel = await GetAsync($"/corporations/{corpId}/wallets/", auth, ifNoneMatch);

            CheckResponse(nameof(ReturnCorporationWalletBalanceAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<CorporationWallet>>(responseModel);
        }

        /// <summary>
        /// Retrieve the given corporation’s wallet journal for the given division going 30 days back.
        /// <para>GET /corporations/{corporation_id}/wallets/{division}/journal/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corpId">An EVE corporation ID.</param>
        /// <param name="division">Wallet key of the division to fetch journals from.</param>
        /// <param name="page">Which page of results to return. Default value: 1.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing journal entries.</returns>
        public async Task<ESIModelDTO<List<CorporationWalletJournal>>> GetCorporationWalletJournalAsync(AuthDTO auth, long corpId, int division, int page = 1, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_WALLET_READ_CORPORATION_WALLETS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "page", page.ToString() }
            };

            var responseModel = await GetAsync($"/corporations/{corpId}/wallets/{division}/journal/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetCorporationWalletJournalAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<CorporationWalletJournal>>(responseModel);
        }

        /// <summary>
        /// Get wallet transactions of a corporation.
        /// <para>GET /corporations/{corporation_id}/wallets/{division}/transactions/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="corpId">An EVE corporation ID.</param>
        /// <param name="division">Wallet key of the division to fetch journals from.</param>
        /// <param name="fromId">Only show transactions happened before the one referenced by this id.</param>
        /// <param name="ifNoneMatch">ETag from a previous request. A 304 will be returned if this matches the current ETag.</param>
        /// <returns><see cref="ESIModelDTO{T}"/> containing wallet transactions.</returns>
        public async Task<ESIModelDTO<List<WalletTransaction>>> GetCorporationWalletTransactionsAsync(AuthDTO auth, long corpId, int division, long fromId, string ifNoneMatch = null)
        {
            CheckAuth(auth, Scopes.ESI_WALLET_READ_CORPORATION_WALLETS_1);

            var queryParameters = new Dictionary<string, string>
            {
                { "from_id", fromId.ToString() }
            };

            var responseModel = await GetAsync($"/corporations/{corpId}/wallets/{division}/transactions/", auth, ifNoneMatch, queryParameters);

            CheckResponse(nameof(GetCorporationWalletTransactionsAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return ReturnModelDTO<List<WalletTransaction>>(responseModel);
        }
    }
}
