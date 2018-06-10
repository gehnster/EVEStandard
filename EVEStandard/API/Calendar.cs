using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    public class Calendar : APIBase
    {
        private readonly ILogger logger = LibraryLogging.CreateLogger<Calendar>();

        internal Calendar(string dataSource) : base(dataSource)
        {
        }

        public async Task<ESIModelDTO<List<EventSummary>>> ListCalendarEventSummariesV1Async(AuthDTO auth, long? fromEventId=null, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_CALENDAR_READ_CALENDAR_EVENTS_1);

            Dictionary<string, string> queryParameters = null;
            if (fromEventId != null)
            {
                queryParameters = new Dictionary<string, string>
                {
                    { "from_event", fromEventId.ToString() }
                };
            }

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/calendar/", auth, ifNoneMatch, queryParameters);

            checkResponse("ListCalendarEventSummariesV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<EventSummary>>(responseModel);
        }

        public async Task<ESIModelDTO<Event>> GetAnEventV3Async(AuthDTO auth, long eventId, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_CALENDAR_READ_CALENDAR_EVENTS_1);

            var responseModel = await GetAsync("/v3/characters/" + auth.Character.CharacterID + "/calendar/" + eventId + "/", auth, ifNoneMatch);

            checkResponse("GetAnEventV3Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<Event>(responseModel);
        }

        public async Task RespondToAnEventV3Async(AuthDTO auth, long eventId, EventResponse response)
        {
            checkAuth(auth, Scopes.ESI_CALENDAR_RESPOND_CALENDAR_EVENTS_1);

            dynamic body = new JObject();
            body.response = response.ToString();

            var responseModel = await this.PutAsync("/v3/characters/" + auth.Character.CharacterID + "/calendar/" + eventId + "/", auth, body);

            checkResponse("RespondToAnEventV3Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);
        }

        public async Task<ESIModelDTO<List<EventAttendee>>> GetAttendeesV1Async(AuthDTO auth, long eventId, string ifNoneMatch = null)
        {
            checkAuth(auth, Scopes.ESI_CALENDAR_READ_CALENDAR_EVENTS_1);

            var responseModel = await GetAsync("/v1/characters/" + auth.Character.CharacterID + "/calendar/" + eventId + "/attendees/", auth, ifNoneMatch);

            checkResponse("GetAttendeesV1Async", responseModel.Error, responseModel.Message, responseModel.LegacyWarning, logger);

            return returnModelDTO<List<EventAttendee>>(responseModel);
        }
    }
}
