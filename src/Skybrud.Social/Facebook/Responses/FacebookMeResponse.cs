using System;
using Skybrud.Social.Facebook.Exceptions;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Responses {

    public class FacebookMeResponse {

        public long Id { get; private set; }
        public string Name { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Link { get; private set; }
        public string UserName { get; private set; }
        public string Gender { get; private set; }
        public int? TimeZone { get; private set; }
        public string Locale { get; private set; }
        public bool? IsVerified { get; private set; }
        public DateTime UpdatedTime { get; private set; }

        public static FacebookMeResponse ParseJson(string contents) {
            return Parse(JsonConverter.ParseObject(contents));
        }

        public static FacebookMeResponse Parse(JsonObject obj) {
            if (obj == null) return null;
            if (obj.HasValue("error")) throw obj.GetObject("error", FacebookException.Parse);
            return new FacebookMeResponse {
                Id = obj.GetLong("id"),
                Name = obj.GetString("name"),
                FirstName = obj.GetString("first_name"),
                LastName = obj.GetString("last_name"),
                Link = obj.GetString("link"),
                UserName = obj.GetString("username"),
                Gender = obj.GetString("gender"),
                TimeZone = obj.HasValue("timezone") ? (int?) obj.GetInt("timezone") : null,
                Locale = obj.GetString("locale"),
                IsVerified = obj.HasValue("verified") ? (bool?) obj.GetBoolean("verified") : null,
                UpdatedTime = obj.GetDateTime("updated_time")
            };
        }

    }

}
