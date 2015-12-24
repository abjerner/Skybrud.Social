using System;
using Skybrud.Social.Http;
using Skybrud.Social.Json;
using Skybrud.Social.Instagram.Objects;

namespace Skybrud.Social.Instagram.Responses {
    
    /// <summary>
    /// Class representing the response of a call for getting information about a given media.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/media/#get_media</cref>
    /// </see>
    public class InstagramMediaResponse : InstagramResponse<InstagramMediaResponseBody> {

        #region Constructors

        private InstagramMediaResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>InstagramMediaResponse</code>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <code>InstagramMediaResponse</code>.</returns>
        public static InstagramMediaResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new InstagramMediaResponse(response) {
                Body = InstagramMediaResponseBody.Parse(obj)
            };

        }

        #endregion

    }

    /// <summary>
    /// Class representing the response body of a call for getting information of a given media.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/media/#get_media</cref>
    /// </see>
    public class InstagramMediaResponseBody : InstagramResponseBody<InstagramMedia> {

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <code>obj</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> representing the response body.</param>
        protected InstagramMediaResponseBody(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <code>InstagramMediaResponseBody</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to be parsed.</param>
        /// <returns>Returns an instance of <code>InstagramMediaResponseBody</code>.</returns>
        public static InstagramMediaResponseBody Parse(JsonObject obj) {
            return new InstagramMediaResponseBody(obj) {
                Data = obj.GetObject("data", InstagramMedia.Parse)
            };
        }

        #endregion

    }

}