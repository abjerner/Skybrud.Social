using System;
using Skybrud.Social.Http;
using Skybrud.Social.Json;
using Skybrud.Social.Instagram.Objects;
using Skybrud.Social.Instagram.Objects.Pagination;

namespace Skybrud.Social.Instagram.Responses {

    /// <summary>
    /// Class representing the response of a call for getting a list of recent media.
    /// </summary>
    public class InstagramRecentMediaResponse : InstagramResponse<InstagramMediasResponseBody> {

        #region Constructors

        private InstagramRecentMediaResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>InstagramRecentMediaResponse</code>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <code>InstagramRecentMediaResponse</code>.</returns>
        public static InstagramRecentMediaResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new InstagramRecentMediaResponse(response) {
                Body = InstagramMediasResponseBody.Parse(obj)
            };

        }

        #endregion

    }

    /// <summary>
    /// Class representing the response body of a call for getting a list of recent media.
    /// </summary>
    public class InstagramMediasResponseBody : InstagramResponseBody<InstagramMedia[]> {

        #region Properties

        /// <summary>
        /// Gets pagination information of the response.
        /// </summary>
        public InstagramIdBasedPagination Pagination { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <code>obj</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> representing the response body.</param>
        protected InstagramMediasResponseBody(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <code>InstagramMediasResponseBody</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to be parsed.</param>
        /// <returns>Returns an instance of <code>InstagramMediasResponseBody</code>.</returns>
        public static InstagramMediasResponseBody Parse(JsonObject obj) {
            return new InstagramMediasResponseBody(obj) {
                Pagination = obj.GetObject("pagination", InstagramIdBasedPagination.Parse),
                Data = obj.GetArray("data", InstagramMedia.Parse)
            };
        }

        #endregion

    }

}