using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects {

    public class FacebookEventSummary {

        public long Id { get; private set; }
        public string Name { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime? EndTime { get; private set; }
        public string TimeZone { get; private set; }
        public string Location { get; private set; }

        public static FacebookEventSummary Parse(JsonObject obj) {
            return new FacebookEventSummary {
                Id = obj.GetLong("id"),
                Name = obj.GetString("name"),
                StartTime = obj.GetDateTime("start_time"),
                EndTime = obj.HasValue("end_time") ? (DateTime?) obj.GetDateTime("end_time") : null,
                TimeZone = obj.GetString("timezone"),
                Location = obj.GetString("location")
            };
        }

        public static FacebookEventSummary[] ParseMultiple(JsonArray array) {
            return array == null ? new FacebookEventSummary[0] : array.ParseMultiple(Parse);
        }

    }

}
