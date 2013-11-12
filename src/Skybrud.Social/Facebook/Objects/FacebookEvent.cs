using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects {
    
    
    public class FacebookEvent {
        
        public long Id { get; private set; }
        public object Owner { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime? EndTime { get; private set; }
        public string TimeZone { get; private set; }
        public bool IsDateOnly { get; private set; }
        public string Location { get; private set; }
        public object Venue { get; private set; }
        public string Privacy { get; private set; }
        public DateTime UpdatedTime { get; private set; }

        public static FacebookEvent Parse(JsonObject obj) {
            return new FacebookEvent {
                Id = obj.GetLong("id"),
                Name = obj.GetString("name"),
                Description = obj.GetString("description"),
                StartTime = obj.GetDateTime("start_time"),
                EndTime = obj.HasValue("end_time") ? (DateTime?) obj.GetDateTime("end_time") : null,
                TimeZone = obj.GetString("timezone"),
                IsDateOnly = obj.HasValue("is_date_only") && obj.GetBoolean("is_date_only"),
                Location = obj.GetString("location"),
                Privacy = obj.GetString("privacy"),
                UpdatedTime = obj.GetDateTime("updated_time")
            };
        }

        public static FacebookEvent[] ParseMultiple(JsonArray array) {
            return array == null ? new FacebookEvent[0] : array.ParseMultiple(Parse);
        }
        
    }

}
