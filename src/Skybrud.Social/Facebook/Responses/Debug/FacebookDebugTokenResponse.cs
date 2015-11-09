using Skybrud.Social.Facebook.Objects.Debug;
using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Responses.Debug {

    /// <summary>
    /// Class representing the response for getting information about a given access token.
    /// </summary>
    public class FacebookDebugTokenResponse : FacebookResponse<FacebookDebugToken> {

        #region Constructors

        private FacebookDebugTokenResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>FacebookDebugTokenResponse</code>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <code>FacebookDebugTokenResponse</code> representing the response.</returns>
        public static FacebookDebugTokenResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new FacebookDebugTokenResponse(response) {
                Body = FacebookDebugToken.Parse(obj)
            };

        }

        #endregion

    }

}