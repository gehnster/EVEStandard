using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    public class Calendar : APIBase
    {
        private ILogger Logger { get; } = LibraryLogging.CreateLogger<Calendar>();
        internal Calendar(string dataSource) : base(dataSource)
        {
        }

        public async Task<List<EventSummary>> ListCalendarEventSummariesV1Async(AuthDTO auth, long? fromEventId=null)
        {
            this.checkAuth(auth, Scopes.ESI_CALENDAR_READ_CALENDAR_EVENTS_1);

            Dictionary<string, string> queryParameters = null;
            if (fromEventId != null)
            {
                queryParameters = new Dictionary<string, string>
                {
                    { "from_event", fromEventId.ToString() }
                };
            }

            var responseModel = await this.GetAsync("/v1/characters/" + auth.Character.CharacterID + "/calendar/", auth, queryParameters);

            this.checkResponse("ListCalendarEventSummariesV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<List<EventSummary>>(responseModel.JSONString);
        }

        public async Task<Event> GetAnEventV3Async(AuthDTO auth, long eventId)
        {
            this.checkAuth(auth, Scopes.ESI_CALENDAR_READ_CALENDAR_EVENTS_1);

            var responseModel = await this.GetAsync("/v3/characters/" + auth.Character.CharacterID + "/calendar/" + eventId + "/", auth);

            this.checkResponse("GetAnEventV3Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<Event>(responseModel.JSONString);
        }

        public async Task RespondToAnEventV3Async(AuthDTO auth, long eventId, EventResponse response)
        {
            this.checkAuth(auth, Scopes.ESI_CALENDAR_RESPOND_CALENDAR_EVENTS_1);

            dynamic body = new JObject();
            body.response = response.ToString();

            var responseModel = await this.PutAsync("/v3/characters/" + auth.Character.CharacterID + "/calendar/" + eventId + "/", auth, body);

            this.checkResponse("RespondToAnEventV3Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);
        }

        public async Task<List<EventAttendee>> GetAttendeesV1Async(AuthDTO auth, long eventId)
        {
            this.checkAuth(auth, Scopes.ESI_CALENDAR_READ_CALENDAR_EVENTS_1);

            var responseModel = await this.GetAsync("/v1/characters/" + auth.Character.CharacterID + "/calendar/" + eventId + "/attendees/", auth);

            this.checkResponse("GetAttendeesV1Async", responseModel.Error, responseModel.LegacyWarning, this.Logger);

            return JsonConvert.DeserializeObject<List<EventAttendee>>(responseModel.JSONString);
        }
    }
}
