using Skybrud.Social.Instagram.Objects;
using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Responses {

    public class InstagramLocationResponse : InstagramResponse {

        #region Properties

        /// <summary>
        /// Gets the object representing the location.
        /// </summary>
        public InstagramLocation Data { get; private set; }

        /// <summary>
        /// Gets the object representing the location (same as Data).
        /// </summary>
        public InstagramLocation User {
            get { return Data; }
        }

        #endregion

        #region Constructors

        internal InstagramLocationResponse(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Loads an instance of <var>InstagramLocationResponse</var> from
        /// the JSON file at the specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public static InstagramLocationResponse LoadJson(string path) {
            return JsonObject.LoadJson(path, Parse);
        }

        /// <summary>
        /// Gets an instance of <var>InstagramLocationResponse</var> from
        /// the specified JSON string.
        /// </summary>
        /// <param name="json">The JSON string representation of the object.</param>
        public static InstagramLocationResponse ParseJson(string json) {
            return JsonConverter.ParseObject(json, Parse);
        }

        /// <summary>
        /// Gets an instance of <var>InstagramLocationResponse</var> from
        /// the specified <var>JsonObject</var>.
        /// </summary>
        /// <param name="obj">The instance of <var>JsonObject</var> to parse.</param>
        public static InstagramLocationResponse Parse(JsonObject obj) {

            // Check if null
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(obj);

            // Parse the response
            return new InstagramLocationResponse(obj) {
                Data = obj.GetObject("data", InstagramLocation.Parse)
            };

        }

        #endregion

    }

}
