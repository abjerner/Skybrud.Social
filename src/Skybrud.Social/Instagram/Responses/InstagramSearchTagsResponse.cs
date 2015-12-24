using System;
using Skybrud.Social.Http;
using Skybrud.Social.Json;
using Skybrud.Social.Instagram.Objects;

namespace Skybrud.Social.Instagram.Responses {
    
    /// <summary>
    /// Class representing the response of a call for getting a list of tags matching a given query.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/tags/#get_tags_search</cref>
    /// </see>
    public class InstagramSearchTagsResponse : InstagramResponse<InstagramSearchTagsResponseBody> {

        #region Constructors

        private InstagramSearchTagsResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>InstagramSearchTagsResponse</code>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <code>InstagramSearchTagsResponse</code>.</returns>
        public static InstagramSearchTagsResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new InstagramSearchTagsResponse(response) {
                Body = InstagramSearchTagsResponseBody.Parse(obj)
            };

        }

        #endregion

    }

    /// <summary>
    /// Class representing the response body of a call for getting a list of tags matching a given query.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/tags/#get_tags_search</cref>
    /// </see>
    public class InstagramSearchTagsResponseBody : InstagramResponseBody<InstagramTag[]> {

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <code>obj</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> representing the response body.</param>
        protected InstagramSearchTagsResponseBody(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <code>InstagramSearchTagsResponseBody</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JObject</code> to be parsed.</param>
        /// <returns>Returns an instance of <code>InstagramSearchTagsResponseBody</code>.</returns>
        public static InstagramSearchTagsResponseBody Parse(JsonObject obj) {
            return new InstagramSearchTagsResponseBody(obj) {
                Data = obj.GetArray("data", InstagramTag.Parse)
            };
        }

        #endregion

    }

}