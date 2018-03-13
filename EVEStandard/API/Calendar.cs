using EVEStandard.Enumerations;
using EVEStandard.Models;
using EVEStandard.Models.API;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EVEStandard.API
{
    public class Calendar : APIBase
    {
        internal Calendar(string dataSource) : base(dataSource)
        {
        }

        public async Task<List<EventSummary>> ListCalendarEventSummariesV1Async(AuthDTO auth, long? fromEventId=null)
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

            var responseModel = await this.GetAsync("/v1/characters/" + auth.Character.CharacterID + "/calendar/", auth, queryParameters);

            if (responseModel.Error)
            {
                throw new EVEStandardException("ListCalendarEventSummariesV1Async failed");
            }
            if (responseModel.LegacyWarning)
            {
                // log it? unsure how best to handle this. Maybe throw a legacy exception?
            }

            return JsonConvert.DeserializeObject<List<EventSummary>>(responseModel.JSONString);
        }

        public async Task<Event> GetAnEventV3Async(AuthDTO auth, long eventId)
        {
            checkAuth(auth, Scopes.ESI_CALENDAR_READ_CALENDAR_EVENTS_1);

            var responseModel = await this.GetAsync("/v3/characters/" + auth.Character.CharacterID + "/calendar/" + eventId + "/", auth);

            if (responseModel.Error)
            {
                throw new EVEStandardException("GetAnEventV3Async failed");
            }
            if (responseModel.LegacyWarning)
            {
                // log it? unsure how best to handle this. Maybe throw a legacy exception?
            }

            return JsonConvert.DeserializeObject<Event>(responseModel.JSONString);
        }

        public async Task RespondToAnEventV3Async(AuthDTO auth, long eventId, EventResponse response)
        {
            checkAuth(auth, Scopes.ESI_CALENDAR_RESPOND_CALENDAR_EVENTS_1);

            dynamic body = new JObject();
            body.response = response.ToString();

            var responseModel = await this.PutAsync("/v3/characters/" + auth.Character.CharacterID + "/calendar/" + eventId + "/", auth, body);

            if (responseModel.Error)
            {
                throw new EVEStandardException("RespondToAnEventV3Async failed");
            }
            if (responseModel.LegacyWarning)
            {
                // log it? unsure how best to handle this. Maybe throw a legacy exception?
            }
        }

        public async Task<List<EventAttendee>> GetAttendeesV1Async(AuthDTO auth, long eventId)
        {
            checkAuth(auth, Scopes.ESI_CALENDAR_READ_CALENDAR_EVENTS_1);

            var responseModel = await this.GetAsync("/v1/characters/" + auth.Character.CharacterID + "/calendar/" + eventId + "/attendees/", auth);

            if (responseModel.Error)
            {
                throw new EVEStandardException("GetAttendeesV1Async failed");
            }
            if (responseModel.LegacyWarning)
            {
                // log it? unsure how best to handle this. Maybe throw a legacy exception?
            }

            return JsonConvert.DeserializeObject<List<EventAttendee>>(responseModel.JSONString);
        }
    }
}
