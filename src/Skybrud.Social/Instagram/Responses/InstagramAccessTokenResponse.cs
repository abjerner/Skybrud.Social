using System;
using Skybrud.Social.Http;
using Skybrud.Social.Json;
using Skybrud.Social.Instagram.Objects;

namespace Skybrud.Social.Instagram.Responses {

    /// <summary>
    /// Class representing the response of a call to exchange an authorization code for an access token.
    /// </summary>
    public class InstagramAccessTokenResponse : InstagramResponse<InstagramAccessTokenSummary> {

        #region Constructors

        private InstagramAccessTokenResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>InstagramAccessTokenResponse</code>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <code>InstagramAccessTokenResponse</code> representing the response.</returns>
        public static InstagramAccessTokenResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new InstagramAccessTokenResponse(response) {
                Body = InstagramAccessTokenSummary.Parse(obj)
            };

        }

        #endregion

    }

}