using System;
using Skybrud.Social.Http;
using Skybrud.Social.Json;
using Skybrud.Social.Instagram.Objects;
using Skybrud.Social.Instagram.Objects.Pagination;

namespace Skybrud.Social.Instagram.Responses {
    
    /// <summary>
    /// Class representing the response of a call to get recent media of a location.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/locations/#get_locations_media_recent</cref>
    /// </see>
    public class InstagramLocationRecentMediaResponse : InstagramResponse<InstagramLocationRecentMediaResponseBody> {

        #region Constructors

        private InstagramLocationRecentMediaResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>ParseResponse</code>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <code>ParseResponse</code>.</returns>
        public static InstagramLocationRecentMediaResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new InstagramLocationRecentMediaResponse(response) {
                Body = InstagramLocationRecentMediaResponseBody.Parse(obj)
            };

        }

        #endregion

    }

    /// <summary>
    /// Class representing the response body of a call to get recent media of a location.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/locations/#get_locations_media_recent</cref>
    /// </see>
    public class InstagramLocationRecentMediaResponseBody : InstagramResponseBody<InstagramMedia[]> {

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
        protected InstagramLocationRecentMediaResponseBody(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <code>InstagramLocationRecentMediaResponseBody</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to be parsed.</param>
        /// <returns>Returns an instance of <code>InstagramLocationRecentMediaResponseBody</code>.</returns>
        public static InstagramLocationRecentMediaResponseBody Parse(JsonObject obj) {
            return new InstagramLocationRecentMediaResponseBody(obj) {
                Pagination = obj.GetObject("pagination", InstagramIdBasedPagination.Parse),
                Data = obj.GetArray("data", InstagramMedia.Parse)
            };
        }

        #endregion

    }

}