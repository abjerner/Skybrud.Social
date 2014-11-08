using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.Vimeo.Advanced.Responses {
    
    public class VimeoTestLoginResponse {

        /// <summary>
        /// The time the Vimeo API used to generated the response.
        /// </summary>
        public double GeneratedIn { get; private set; }

        /// <summary>
        /// The ID of the current user.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// The username of the current user.
        /// </summary>
        public string Username { get; private set; }

        public static VimeoTestLoginResponse Parse(string str) {
            return Parse(JsonConverter.ParseObject(str));
        }

        public static VimeoTestLoginResponse Parse(JsonObject obj) {
            if (obj == null) return null;
            JsonObject user = obj.GetObject("user");
            if (user == null) return null;
            return new VimeoTestLoginResponse {
                GeneratedIn = obj.GetDouble("generated_in"),
                Id = user.GetInt32("id"),
                Username = user.GetString("username")
            };
        }

    }

}