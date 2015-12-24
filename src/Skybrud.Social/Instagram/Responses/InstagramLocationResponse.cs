using System;
using Skybrud.Social.Http;
using Skybrud.Social.Json;
using Skybrud.Social.Instagram.Objects;

namespace Skybrud.Social.Instagram.Responses {

    /// <summary>
    /// Class representing the response of a call to get information about a given location.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/locations/#get_locations</cref>
    /// </see>
    public class InstagramLocationResponse : InstagramResponse<InstagramLocationResponseBody> {

        #region Constructors

        private InstagramLocationResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>InstagramLocationResponse</code>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <code>InstagramLocationResponse</code>.</returns>
        public static InstagramLocationResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new InstagramLocationResponse(response) {
                Body = InstagramLocationResponseBody.Parse(obj)
            };

        }

        #endregion

    }

    /// <summary>
    /// Class representing the response body of a call to get information about a given location.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/locations/#get_locations</cref>
    /// </see>
    public class InstagramLocationResponseBody : InstagramResponseBody<InstagramLocation> {

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <code>obj</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> representing the response body.</param>
        protected InstagramLocationResponseBody(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <code>InstagramLocationResponseBody</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to be parsed.</param>
        /// <returns>Returns an instance of <code>InstagramLocationResponseBody</code>.</returns>
        public static InstagramLocationResponseBody Parse(JsonObject obj) {
            return new InstagramLocationResponseBody(obj) {
                Data = obj.GetObject("data", InstagramLocation.Parse)
            };
        }

        #endregion

    }

}