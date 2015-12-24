using System;
using Skybrud.Social.Http;
using Skybrud.Social.Json;
using Skybrud.Social.Instagram.Objects;

namespace Skybrud.Social.Instagram.Responses {
    
    /// <summary>
    /// Class representing the response of a call for getting a list of locations.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/locations/#get_locations_search</cref>
    /// </see>
    public class InstagramLocationsResponse : InstagramResponse<InstagramLocationsResponseBody> {

        #region Constructors

        private InstagramLocationsResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>InstagramLocationsResponse</code>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <code>InstagramLocationsResponse</code>.</returns>
        public static InstagramLocationsResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new InstagramLocationsResponse(response) {
                Body = InstagramLocationsResponseBody.Parse(obj)
            };

        }

        #endregion

    }

    /// <summary>
    /// Class representing the response body of a call for getting a list of locations.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/locations/#get_locations_search</cref>
    /// </see>
    public class InstagramLocationsResponseBody : InstagramResponseBody<InstagramLocation[]> {

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <code>obj</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> representing the response body.</param>
        protected InstagramLocationsResponseBody(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <code>InstagramLocationsResponseBody</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to be parsed.</param>
        /// <returns>Returns an instance of <code>InstagramLocationsResponseBody</code>.</returns>
        public static InstagramLocationsResponseBody Parse(JsonObject obj) {
            return new InstagramLocationsResponseBody(obj) {
                Data = obj.GetArray("data", InstagramLocation.Parse)
            };
        }

        #endregion

    }

}