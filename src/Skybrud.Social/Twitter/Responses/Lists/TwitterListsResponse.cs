using System;
using Skybrud.Social.Http;
using Skybrud.Social.Json;
using Skybrud.Social.Twitter.Objects.Lists;

namespace Skybrud.Social.Twitter.Responses.Lists {
    
    /// <summary>
    /// Class respresenting the response for a list of lists.
    /// </summary>
    public class TwitterListsResponse : TwitterResponse<TwitterList[]> {

        #region Constructors

        private TwitterListsResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses and validates the specified <code>response</code>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        public static TwitterListsResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new TwitterListsResponse(response) {
                Body = JsonArray.ParseJson(response.Body).ParseMultiple(TwitterList.Parse)
            };

        }

        #endregion

    }

}