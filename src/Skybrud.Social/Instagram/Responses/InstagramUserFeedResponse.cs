using System;
using Skybrud.Social.Http;
using Skybrud.Social.Json;
using Skybrud.Social.Instagram.Objects;

namespace Skybrud.Social.Instagram.Responses {
    
    /// <summary>
    /// Class representing the response of a call for getting the feed of the autenticated user.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/users/#get_users_feed</cref>
    /// </see>
    public class InstagramUserFeedResponse : InstagramResponse<InstagramUserFeedResponseBody> {

        #region Constructors

        private InstagramUserFeedResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>InstagramUserFeedResponse</code>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <code>InstagramUserFeedResponse</code>.</returns>
        public static InstagramUserFeedResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new InstagramUserFeedResponse(response) {
                Body = InstagramUserFeedResponseBody.Parse(obj)
            };

        }

        #endregion

    }

    /// <summary>
    /// Class representing the response body of a call for getting the feed of the autenticated user.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/users/#get_users_feed</cref>
    /// </see>
    public class InstagramUserFeedResponseBody : InstagramResponseBody<InstagramMedia[]> {

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <code>obj</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> representing the response body.</param>
        protected InstagramUserFeedResponseBody(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <code>InstagramUserFeedResponseBody</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to be parsed.</param>
        /// <returns>Returns an instance of <code>InstagramUserFeedResponseBody</code>.</returns>
        public static InstagramUserFeedResponseBody Parse(JsonObject obj) {
            return new InstagramUserFeedResponseBody(obj) {
                Data = obj.GetArray("data", InstagramMedia.Parse)
            };
        }

        #endregion

    }

}