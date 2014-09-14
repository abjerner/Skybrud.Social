using Skybrud.Social.Instagram.Objects;
using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Responses {

    public class InstagramMediaResponse : InstagramResponse {

        #region Properties

        /// <summary>
        /// Gets the media.
        /// </summary>
        public InstagramMedia Data { get; private set; }

        #endregion

        #region Constructors

        private InstagramMediaResponse(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Loads an instance of <var>InstagramMediaResponse</var> from
        /// the JSON file at the specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public static InstagramMediaResponse LoadJson(string path) {
            return JsonObject.LoadJson(path, Parse);
        }

        /// <summary>
        /// Gets an instance of <var>InstagramMediaResponse</var> from
        /// the specified JSON string.
        /// </summary>
        /// <param name="json">The JSON string representation of the object.</param>
        public static InstagramMediaResponse ParseJson(string json) {
            return JsonConverter.ParseObject(json, Parse);
        }

        /// <summary>
        /// Gets an instance of <var>InstagramMediaResponse</var> from
        /// the specified <var>JsonObject</var>.
        /// </summary>
        /// <param name="obj">The instance of <var>JsonObject</var> to parse.</param>
        public static InstagramMediaResponse Parse(JsonObject obj) {

            // Check if null
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(obj);

            // Parse the response
            return new InstagramMediaResponse(obj) {
                Data = obj.GetObject("data", InstagramMedia.Parse)
            };

        }

        #endregion

    }

}
