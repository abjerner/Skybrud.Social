using Skybrud.Social.Instagram.Objects;
using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Responses {

    public class InstagramTagResponse : InstagramResponse {

        #region Properties

        /// <summary>
        /// Gets the internal JsonObject the object was created from.
        /// </summary>
        public JsonObject JsonObject { get; private set; }

        /// <summary>
        /// Gets the object representing the tag.
        /// </summary>
        public InstagramTag Data { get; private set; }

        /// <summary>
        /// Gets the object representing the tag (same as Data).
        /// </summary>
        public InstagramTag Tag {
            get { return Data; }
        }

        #endregion

        #region Constructor(s)

        internal InstagramTagResponse() {
            // Hide default constructor
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a JSON string representing the object.
        /// </summary>
        public string ToJson() {
            return JsonObject == null ? null : JsonObject.ToJson();
        }

        /// <summary>
        /// Saves the object to a JSON file at the specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to save the file.</param>
        public void SaveJson(string path) {
            if (JsonObject != null) JsonObject.SaveJson(path);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Loads an instance of <var>InstagramTagResponse</var> from
        /// the JSON file at the specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public static InstagramTagResponse LoadJson(string path) {
            return JsonObject.LoadJson(path, Parse);
        }

        /// <summary>
        /// Gets an instance of <var>InstagramTagResponse</var> from
        /// the specified JSON string.
        /// </summary>
        /// <param name="json">The JSON string representation of the object.</param>
        public static InstagramTagResponse ParseJson(string json) {
            return JsonConverter.ParseObject(json, Parse);
        }

        /// <summary>
        /// Gets an instance of <var>InstagramTagResponse</var> from
        /// the specified <var>JsonObject</var>.
        /// </summary>
        /// <param name="obj">The instance of <var>JsonObject</var> to parse.</param>
        public static InstagramTagResponse Parse(JsonObject obj) {

            // Check if null
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(obj);

            // Parse the response
            return new InstagramTagResponse {
                JsonObject = obj,
                Data = obj.GetObject("data", InstagramTag.Parse)
            };

        }

        #endregion

    }

}
