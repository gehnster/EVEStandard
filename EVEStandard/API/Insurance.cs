using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    /// <summary>
    /// Insurance API
    /// </summary>
    /// <seealso cref="EVEStandard.API.APIBase" />
    public class Insurance : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Insurance>();

        internal Insurance(string dataSource) : base(dataSource)
        {
        }

        /// <summary>
        /// Return available insurance levels for all ship types.
        /// <para>GET /insurance/prices/</para>
        /// </summary>
        /// <param name="ifNoneMatch">If none match.</param>
        /// <returns></returns>
        public async Task<ESIModelDTO<List<InsurancePrice>>> ListInsuranceLevelsV1Async(string ifNoneMatch = null)
        {
            var responseModel = await GetAsync("/v1/insurance/prices/", ifNoneMatch);

            checkResponse(nameof(ListInsuranceLevelsV1Async), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<InsurancePrice>>(responseModel);
        }
    }
}
