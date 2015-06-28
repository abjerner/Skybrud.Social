using System;
using Skybrud.Social.Http;
using Skybrud.Social.Json;
using Skybrud.Social.Twitter.Objects.Lists;

namespace Skybrud.Social.Twitter.Responses.Lists {
    
    /// <summary>
    /// Class respresenting the response for a list.
    /// </summary>
    public class TwitterListResponse : TwitterResponse<TwitterList> {

        #region Constructors

        private TwitterListResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses and validates the specified <code>response</code>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        public static TwitterListResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new TwitterListResponse(response) {
                Body = JsonObject.ParseJson(response.Body, TwitterList.Parse)
            };

        }

        #endregion

    }

}