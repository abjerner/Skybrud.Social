using Skybrud.Social.Instagram.Objects;
using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Responses {

    public class InstagramTagResponse : InstagramResponse {

        /// <summary>
        /// Gets the object representing the tag.
        /// </summary>
        public InstagramTag Data { get; private set; }

        /// <summary>
        /// Gets the object representing the tag.
        /// </summary>
        public InstagramTag Tag {
            get { return Data; }
        }

        public static InstagramTagResponse ParseJson(string json) {
            return JsonConverter.ParseObject(json, Parse);
        }

        public static InstagramTagResponse Parse(JsonObject obj) {

            // Check if null
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(obj);

            // Parse the response
            return new InstagramTagResponse {
                Data = obj.GetObject("data", InstagramTag.Parse)
            };

        }

    }

}
