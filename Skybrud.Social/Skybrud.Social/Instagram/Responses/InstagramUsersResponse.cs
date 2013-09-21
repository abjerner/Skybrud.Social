using Skybrud.Social.Instagram.Objects;
using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Responses {

    public class InstagramUsersResponse : InstagramResponse {

        /// <summary>
        /// Gets an array of all users in the response.
        /// </summary>
        public InstagramUser[] Data { get; private set; }

        /// <summary>
        /// Gets an array of all users in the response (same as Data).
        /// </summary>
        public InstagramUser[] Users {
            get { return Data; }
        }

        public static InstagramUsersResponse ParseJson(string json) {
            return JsonConverter.ParseObject(json, Parse);
        }

        public static InstagramUsersResponse Parse(JsonObject obj) {

            // Check if null
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(obj);

            // Parse the response
            return new InstagramUsersResponse {
                Data = obj.GetArray("data", InstagramUser.Parse)
            };

        }

    }

}
