using Skybrud.Social.Instagram.Objects;
using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Responses {

    public class InstagramLocationResponse : InstagramResponse {

        /// <summary>
        /// Gets an array of all locations in the response.
        /// </summary>
        public InstagramLocation[] Data { get; private set; }

        /// <summary>
        /// Gets an array of all locations in the response (same as Data).
        /// </summary>
        public InstagramLocation[] Locations {
            get { return Data; }
        }

        public static InstagramLocationResponse ParseJson(string json) {
            return JsonConverter.ParseObject(json, Parse);
        }

        public static InstagramLocationResponse Parse(JsonObject obj) {

            // Check if null
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(obj);

            // Parse the response
            return new InstagramLocationResponse {
                Data = obj.GetArray("data", InstagramLocation.Parse)
            };

        }

    }

}
