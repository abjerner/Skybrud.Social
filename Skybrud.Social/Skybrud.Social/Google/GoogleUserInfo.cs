using System;
using System.Collections.Generic;
using System.Linq;
using Skybrud.Social.Json;

namespace Skybrud.Social.Google {
    
    public class GoogleUserInfo {
        
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string GivenName { get; private set; }
        public string FamilyName { get; private set; }

        /// <summary>
        /// A link to the user's Google+ profile (if the user is on Google+).
        /// </summary>
        public string Profile { get; private set; }
        public string Picture { get; private set; }
        public string Email { get; private set; }
        public bool IsEmailVerified { get; private set; }
        public string Gender { get; private set; }
        public string Birthdate { get; private set; }
        public string Locale { get; private set; }

        public static GoogleUserInfo ParseJson(string json) {
            return Parse(JsonConverter.ParseObject(json));
        }

        public static GoogleUserInfo Parse(JsonObject obj) {
            if (obj == null) return null;
            return new GoogleUserInfo {
                Id = obj.GetString("sub"),
                Name = obj.GetString("name"),
                GivenName = obj.GetString("given_name"),
                FamilyName = obj.GetString("family_name"),
                Profile = obj.GetString("profile"),
                Picture = obj.GetString("picture"),
                Email = obj.GetString("email"),
                IsEmailVerified = obj.GetBoolean("email_verified"),
                Gender = obj.GetString("gender"),
                Birthdate = obj.GetString("birthdate"),
                Locale = obj.GetString("locale")
            };
        }

    }

}
