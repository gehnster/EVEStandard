using System.Collections.Generic;
using System.Threading.Tasks;
using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;

namespace EVEStandard.API
{
    public class UserInterface : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<UserInterface>();
        internal UserInterface(string dataSource) : base(dataSource)
        {
        }

        public async Task SetAutopilotWaypointV2Async(AuthDTO auth, bool addToBeginning, bool clearOtherWaypoints, long destinationId)
        {
            checkAuth(auth, Scopes.ESI_UI_WRITE_WAYPOINT_1);

            var queryParameters = new Dictionary<string, string>
            {
                {"add_to_beginning", addToBeginning.ToString()},
                {"clear_other_waypoints", clearOtherWaypoints.ToString()},
                {"destination_id", destinationId.ToString()}
            };

            var responseModel = await PostAsync("/v2/ui/autopilot/waypoint/", auth, null, queryParameters);

            checkResponse("SetAutopilotWaypointV2Async", responseModel.Error, responseModel.LegacyWarning, Logger);
        }

        public async Task OpenContractWindowV1Async(AuthDTO auth, long contractId)
        {
            checkAuth(auth, Scopes.ESI_UI_OPEN_WINDOW_1);

            var queryParameters = new Dictionary<string, string>
            {
                {"contract_id", contractId.ToString()}
            };

            var responseModel = await PostAsync("/v1/ui/openwindow/contract/", auth, null, queryParameters);

            checkResponse("OpenContractWindowV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);
        }

        public async Task OpenInformationWindowV1Async(AuthDTO auth, long targetId)
        {
            checkAuth(auth, Scopes.ESI_UI_OPEN_WINDOW_1);

            var queryParameters = new Dictionary<string, string>
            {
                {"target_id", targetId.ToString()}
            };

            var responseModel = await PostAsync("/v1/ui/openwindow/information/", auth, null, queryParameters);

            checkResponse("OpenInformationWindowV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);
        }

        public async Task OpenMarketDetailsV1Async(AuthDTO auth, long typeId)
        {
            checkAuth(auth, Scopes.ESI_UI_OPEN_WINDOW_1);

            var queryParameters = new Dictionary<string, string>
            {
                {"type_id", typeId.ToString()}
            };

            var responseModel = await PostAsync("/v1/ui/openwindow/marketdetails/", auth, null, queryParameters);

            checkResponse("OpenMarketDetailsV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);
        }

        public async Task OpenNewMailWindowV1Async(AuthDTO auth, UiNewMail mail)
        {
            checkAuth(auth, Scopes.ESI_UI_OPEN_WINDOW_1);

            var responseModel = await PostAsync("/v1/ui/openwindow/newmail/", auth, mail);

            checkResponse("OpenNewMailWindowV1Async", responseModel.Error, responseModel.LegacyWarning, Logger);
        }
    }
}
