using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects {

    public class FacebookEventSummary : SocialJsonObject {

        #region Properties

        public string Id { get; private set; }
        public string Name { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime? EndTime { get; private set; }
        public string TimeZone { get; private set; }
        public string Location { get; private set; }

        #endregion

        #region Constructors

        private FacebookEventSummary(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static FacebookEventSummary Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookEventSummary(obj) {
                Id = obj.GetString("id"),
                Name = obj.GetString("name"),
                StartTime = obj.GetDateTime("start_time"),
                EndTime = obj.HasValue("end_time") ? (DateTime?) obj.GetDateTime("end_time") : null,
                TimeZone = obj.GetString("timezone"),
                Location = obj.GetString("location")
            };
        }

        #endregion

    }

}