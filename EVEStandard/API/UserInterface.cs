using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    /// <summary>
    /// User Interface API
    /// </summary>
    /// <seealso cref="EVEStandard.API.APIBase" />
    public class UserInterface : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<UserInterface>();

        internal UserInterface(string dataSource, CompatibilityDate compatibilityDate) : base(dataSource, compatibilityDate)
        {
        }

        /// <summary>
        /// Set a solar system as autopilot waypoint.
        /// <para>POST /ui/autopilot/waypoint/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="addToBeginning">Whether this solar system should be added to the beginning of all waypoints. Default value: false.</param>
        /// <param name="clearOtherWaypoints">Whether clean other waypoints beforing adding this one. Default value: false.</param>
        /// <param name="destinationId">The destination to travel to, can be solar system, station or structure’s id.</param>
        /// <returns></returns>
        public async Task SetAutopilotWaypointAsync(AuthDTO auth, bool addToBeginning, bool clearOtherWaypoints, long destinationId)
        {
            CheckAuth(auth, Scopes.ESI_UI_WRITE_WAYPOINT_1);

            var queryParameters = new Dictionary<string, string>
            {
                {"add_to_beginning", addToBeginning.ToString()},
                {"clear_other_waypoints", clearOtherWaypoints.ToString()},
                {"destination_id", destinationId.ToString()}
            };

            var responseModel = await PostAsync("/ui/autopilot/waypoint/", auth, null, null, queryParameters);

            CheckResponse(nameof(SetAutopilotWaypointAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);
        }

        /// <summary>
        /// Open the contract window inside the client.
        /// <para>POST /ui/openwindow/contract/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="contractId">The contract to open.</param>
        /// <returns></returns>
        public async Task OpenContractWindowAsync(AuthDTO auth, long contractId)
        {
            CheckAuth(auth, Scopes.ESI_UI_OPEN_WINDOW_1);

            var queryParameters = new Dictionary<string, string>
            {
                {"contract_id", contractId.ToString()}
            };

            var responseModel = await PostAsync("/ui/openwindow/contract/", auth, null, null, queryParameters);

            CheckResponse(nameof(OpenContractWindowAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);
        }

        /// <summary>
        /// Open the information window for a character, corporation or alliance inside the client.
        /// <para>POST /ui/openwindow/information/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="targetId">The target to open.</param>
        /// <returns></returns>
        public async Task OpenInformationWindowAsync(AuthDTO auth, long targetId)
        {
            CheckAuth(auth, Scopes.ESI_UI_OPEN_WINDOW_1);

            var queryParameters = new Dictionary<string, string>
            {
                {"target_id", targetId.ToString()}
            };

            var responseModel = await PostAsync("/ui/openwindow/information/", auth, null, null, queryParameters);

            CheckResponse(nameof(OpenInformationWindowAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);
        }

        /// <summary>
        /// Open the market details window for a specific typeID inside the client.
        /// <para>GET /ui/openwindow/marketdetails/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="typeId">The item type to open in market window.</param>
        /// <returns></returns>
        public async Task OpenMarketDetailsAsync(AuthDTO auth, long typeId)
        {
            CheckAuth(auth, Scopes.ESI_UI_OPEN_WINDOW_1);

            var queryParameters = new Dictionary<string, string>
            {
                {"type_id", typeId.ToString()}
            };

            var responseModel = await PostAsync("/ui/openwindow/marketdetails/", auth, null, null, queryParameters);

            CheckResponse(nameof(OpenMarketDetailsAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);
        }

        /// <summary>
        /// Open the New Mail window, according to settings from the request if applicable.
        /// <para>GET /ui/openwindow/newmail/</para>
        /// </summary>
        /// <param name="auth">The <see cref="AuthDTO"/> object.</param>
        /// <param name="mail">The details of mail to create.</param>
        /// <returns></returns>
        public async Task OpenNewMailWindowAsync(AuthDTO auth, UiNewMail mail)
        {
            CheckAuth(auth, Scopes.ESI_UI_OPEN_WINDOW_1);

            var responseModel = await PostAsync("/ui/openwindow/newmail/", auth, mail);

            CheckResponse(nameof(OpenNewMailWindowAsync), responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);
        }
    }
}
