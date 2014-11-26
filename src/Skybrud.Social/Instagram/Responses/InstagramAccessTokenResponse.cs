using Skybrud.Social.Instagram.Objects;
using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Responses {
    
    public class InstagramAccessTokenResponse : InstagramSoonToBeRetiredResponse {

        #region Properties
        /// <summary>
        /// The access token.
        /// </summary>
        public string AccessToken { get; private set; }
        
        /// <summary>
        /// Information about the authenticated user.
        /// </summary>
        public InstagramUser User { get; private set; }

        #endregion

        #region Constructors

        private InstagramAccessTokenResponse(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Loads an instance of <var>InstagramAccessTokenResponse</var> from
        /// the JSON file at the specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public static InstagramAccessTokenResponse LoadJson(string path) {
            return JsonObject.LoadJson(path, Parse);
        }

        /// <summary>
        /// Gets an instance of <var>InstagramAccessTokenResponse</var> from
        /// the specified JSON string.
        /// </summary>
        /// <param name="json">The JSON string representation of the object.</param>
        public static InstagramAccessTokenResponse ParseJson(string json) {
            return JsonConverter.ParseObject(json, Parse);
        }

        /// <summary>
        /// Gets an instance of <var>InstagramAccessTokenResponse</var> from
        /// the specified <var>JsonObject</var>.
        /// </summary>
        /// <param name="obj">The instance of <var>JsonObject</var> to parse.</param>
        public static InstagramAccessTokenResponse Parse(JsonObject obj) {

            // Check if null
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(obj);

            // Parse the response
            return new InstagramAccessTokenResponse(obj) {
                AccessToken = obj.GetString("access_token"),
                User = obj.GetObject("user", InstagramUser.Parse)
            };

        }

        #endregion

    }

}
