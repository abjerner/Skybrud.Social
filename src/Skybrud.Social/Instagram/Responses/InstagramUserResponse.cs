using System;
using Skybrud.Social.Http;
using Skybrud.Social.Json;
using Skybrud.Social.Instagram.Objects;

namespace Skybrud.Social.Instagram.Responses {
    
    /// <summary>
    /// Class representing the response of a call for getting information about a given user.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/users/#get_users</cref>
    /// </see>
    public class InstagramUserResponse : InstagramResponse<InstagramUserResponseBody> {

        #region Constructors

        private InstagramUserResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>InstagramUserResponse</code>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <code>InstagramUserResponse</code>.</returns>
        public static InstagramUserResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new InstagramUserResponse(response) {
                Body = InstagramUserResponseBody.Parse(obj)
            };

        }

        #endregion

    }

    /// <summary>
    /// Class representing the response of a call for getting information about a given user.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/users/#get_users</cref>
    /// </see>
    public class InstagramUserResponseBody : InstagramResponseBody<InstagramUser> {

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <code>obj</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> representing the response body.</param>
        protected InstagramUserResponseBody(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <code>InstagramUserResponseBody</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to be parsed.</param>
        /// <returns>Returns an instance of <code>InstagramUserResponseBody</code>.</returns>
        public static InstagramUserResponseBody Parse(JsonObject obj) {
            return new InstagramUserResponseBody(obj) {
                Data = obj.GetObject("data", InstagramUser.Parse)
            };
        }

        #endregion

    }

}