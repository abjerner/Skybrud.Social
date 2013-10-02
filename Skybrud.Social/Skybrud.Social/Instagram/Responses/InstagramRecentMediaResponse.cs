using System.IO;
using System.Linq;
using Skybrud.Social.Instagram.Objects;
using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Responses {

    public class InstagramRecentMediaResponse : InstagramResponse {

        /// <summary>
        /// Gets the internal JsonObject the object was created from.
        /// </summary>
        public JsonObject JsonObject { get; private set; }

        /// <summary>
        /// Gets an array of all media in the response.
        /// </summary>
        public InstagramMedia[] Data { get; private set; }

        /// <summary>
        /// Gets an array of all media in the response.
        /// </summary>
        public InstagramMedia[] Media {
            get { return Data; }
        }

        /// <summary>
        /// Gets an array of all images in the response.
        /// </summary>
        public InstagramImage[] Images {
            get { return Data.OfType<InstagramImage>().ToArray(); }
        }

        /// <summary>
        /// Gets an array of all videos in the response.
        /// </summary>
        public InstagramVideo[] Videos {
            get { return Data.OfType<InstagramVideo>().ToArray(); }
        }

        public string NextUrl { get; private set; }
        public string NextMaxId { get; private set; }

        #region Member methods

        /// <summary>
        /// Gets a JSON string representing the user.
        /// </summary>
        public string ToJson() {
            return JsonObject == null ? null : JsonObject.ToJson();
        }

        /// <summary>
        /// Save the response to a JSON file at the specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to save the file.</param>
        public void SaveJson(string path) {
            File.WriteAllText(path, ToJson());
        }

        public InstagramRecentMediaResponse GetNextPage() {
            return NextUrl == null ? null : Parse(SocialUtils.DoHttpGetRequestAndGetBodyAsJsonObject(NextUrl));
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Load a response from the JSON file at the specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public static InstagramRecentMediaResponse LoadJson(string path) {
            return ParseJson(File.ReadAllText(path));
        }
        
        public static InstagramRecentMediaResponse ParseJson(string json) {
            return JsonConverter.ParseObject(json, Parse);
        }

        public static InstagramRecentMediaResponse Parse(JsonObject obj) {

            // Check if null
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(obj);

            // Get the "paging" object
            JsonObject pagination = obj.GetObject("pagination");

            // Parse the response
            return new InstagramRecentMediaResponse {
                JsonObject = obj,
                NextUrl = pagination == null ? null : pagination.GetString("next_url"),
                NextMaxId = pagination == null ? null : pagination.GetString("next_max_id"),
                Data = InstagramMedia.ParseMultiple(obj.GetArray("data"))
            };

        }

        #endregion

    }

}
