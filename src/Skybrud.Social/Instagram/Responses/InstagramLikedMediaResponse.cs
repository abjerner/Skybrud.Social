using System;
using Skybrud.Social.Http;
using Skybrud.Social.Json;
using Skybrud.Social.Instagram.Objects;
using Skybrud.Social.Instagram.Objects.Pagination;

namespace Skybrud.Social.Instagram.Responses {

    /// <summary>
    /// Class representing the response of a call to the liked media of the authenticated user.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/users/#get_users_feed_liked</cref>
    /// </see>
    public class InstagramLikedMediaResponse : InstagramResponse<InstagramLikedMediaResponseBody> {

        #region Constructors

        private InstagramLikedMediaResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>InstagramLikedMediaResponse</code>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <code>InstagramLikedMediaResponse</code>.</returns>
        public static InstagramLikedMediaResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new InstagramLikedMediaResponse(response) {
                Body = InstagramLikedMediaResponseBody.Parse(obj)
            };

        }

        #endregion

    }

    /// <summary>
    /// Class representing the response body of a call to the liked media of the authenticated user.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/users/#get_users_feed_liked</cref>
    /// </see>
    public class InstagramLikedMediaResponseBody : InstagramResponseBody<InstagramMedia[]> {

        #region Properties

        /// <summary>
        /// Gets pagination information of the response.
        /// </summary>
        public InstagramLikedMediaPagination Pagination { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <code>obj</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> representing the response body.</param>
        protected InstagramLikedMediaResponseBody(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <code>InstagramLikedMediaResponseBody</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to be parsed.</param>
        /// <returns>Returns an instance of <code>InstagramLikedMediaResponseBody</code>.</returns>
        public static InstagramLikedMediaResponseBody Parse(JsonObject obj) {
            return new InstagramLikedMediaResponseBody(obj) {
                Pagination = obj.GetObject("pagination", InstagramLikedMediaPagination.Parse),
                Data = obj.GetArray("data", InstagramMedia.Parse)
            };
        }

        #endregion

    }

}