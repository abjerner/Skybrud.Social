using Skybrud.Social.Instagram.Objects;
using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Responses {

    public class InstagramUsersResponse : InstagramResponse {

        #region Properties

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

        #endregion

        #region Constructors

        private InstagramUsersResponse(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Loads an instance of <var>InstagramUsersResponse</var> from
        /// the JSON file at the specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public static InstagramUsersResponse LoadJson(string path) {
            return JsonObject.LoadJson(path, Parse);
        }

        /// <summary>
        /// Gets an instance of <var>InstagramUsersResponse</var> from
        /// the specified JSON string.
        /// </summary>
        /// <param name="json">The JSON string representation of the object.</param>
        public static InstagramUsersResponse ParseJson(string json) {
            return JsonConverter.ParseObject(json, Parse);
        }

        /// <summary>
        /// Gets an instance of <var>InstagramUsersResponse</var> from
        /// the specified <var>JsonObject</var>.
        /// </summary>
        /// <param name="obj">The instance of <var>JsonObject</var> to parse.</param>
        public static InstagramUsersResponse Parse(JsonObject obj) {

            // Check if null
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(obj);

            // Parse the response
            return new InstagramUsersResponse(obj) {
                Data = obj.GetArray("data", InstagramUser.Parse)
            };

        }

        #endregion

    }

}
