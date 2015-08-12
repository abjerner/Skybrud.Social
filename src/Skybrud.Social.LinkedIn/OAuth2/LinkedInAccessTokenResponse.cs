using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.LinkedIn.OAuth2 {

    public class LinkedInAccessTokenResponse {
        
        public string AccessToken { get; private set; }
        public TimeSpan ExpiresIn { get; private set; }

        // Methods
        public static LinkedInAccessTokenResponse Parse(JsonObject obj) {
            if (obj == null) return null;

            if (obj.HasValue("error")) {
                throw new Exception(obj.GetString("error") + " " + obj.GetString("error_description"));
            }

            return new LinkedInAccessTokenResponse {
                ExpiresIn = TimeSpan.FromSeconds(obj.GetInt32("expires_in")),
                AccessToken = obj.GetString("access_token")
            };
        }

        public static LinkedInAccessTokenResponse Parse(string str) {
            if (str != null) return Parse(JsonConverter.ParseObject(str));
            return null;
        }

    }

}
