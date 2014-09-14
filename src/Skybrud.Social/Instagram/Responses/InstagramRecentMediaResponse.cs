using System.Linq;
using Newtonsoft.Json;
using Skybrud.Social.Instagram.Objects;
using Skybrud.Social.Json;
using JsonConverter = Skybrud.Social.Json.JsonConverter;

namespace Skybrud.Social.Instagram.Responses {

    public class InstagramRecentMediaResponse : InstagramResponse {

        #region Properties

        /// <summary>
        /// Gets an array of all media in the response.
        /// </summary>
        public InstagramMedia[] Data { get; private set; }

        /// <summary>
        /// Gets an array of all media in the response (same as Data).
        /// </summary>
        [JsonIgnore]
        public InstagramMedia[] Media {
            get { return Data; }
        }

        /// <summary>
        /// Gets an array of all images in the response.
        /// </summary>
        [JsonIgnore]
        public InstagramImage[] Images {
            get { return Data.OfType<InstagramImage>().ToArray(); }
        }

        /// <summary>
        /// Gets an array of all videos in the response.
        /// </summary>
        [JsonIgnore]
        public InstagramVideo[] Videos {
            get { return Data.OfType<InstagramVideo>().ToArray(); }
        }

        public string NextUrl { get; private set; }
        public string NextMaxId { get; private set; }

        #endregion

        #region Constructors

        private InstagramRecentMediaResponse(JsonObject obj) : base(obj) { }

        #endregion

        #region Member methods

        public InstagramRecentMediaResponse GetNextPage() {
            return NextUrl == null ? null : Parse(SocialUtils.DoHttpGetRequestAndGetBodyAsJsonObject(NextUrl));
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Loads an instance of <var>InstagramRecentMediaResponse</var> from
        /// the JSON file at the specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public static InstagramRecentMediaResponse LoadJson(string path) {
            return JsonObject.LoadJson(path, Parse);
        }

        /// <summary>
        /// Gets an instance of <var>InstagramRecentMediaResponse</var> from
        /// the specified JSON string.
        /// </summary>
        /// <param name="json">The JSON string representation of the object.</param>
        public static InstagramRecentMediaResponse ParseJson(string json) {
            return JsonConverter.ParseObject(json, Parse);
        }

        /// <summary>
        /// Gets an instance of <var>InstagramRecentMediaResponse</var> from
        /// the specified <var>JsonObject</var>.
        /// </summary>
        /// <param name="obj">The instance of <var>JsonObject</var> to parse.</param>
        public static InstagramRecentMediaResponse Parse(JsonObject obj) {

            // Check if null
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(obj);

            // Get the "paging" object
            JsonObject pagination = obj.GetObject("pagination");

            // Parse the response
            return new InstagramRecentMediaResponse(obj) {
                NextUrl = pagination == null ? null : pagination.GetString("next_url"),
                NextMaxId = pagination == null ? null : pagination.GetString("next_max_id"),
                Data = obj.GetArray("data", InstagramMedia.Parse)
            };

        }

        #endregion

    }

}
