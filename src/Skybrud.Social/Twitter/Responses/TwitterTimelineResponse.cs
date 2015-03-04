using System;
using Skybrud.Social.Http;
using Skybrud.Social.Json;
using Skybrud.Social.Twitter.Objects;

namespace Skybrud.Social.Twitter.Responses {

    public class TwitterTimelineResponse : TwitterResponse<TwitterStatusMessage[]> {

        #region Constructors

        private TwitterTimelineResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static TwitterTimelineResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new TwitterTimelineResponse(response) {
                Body = JsonArray.ParseJson(response.Body).ParseMultiple(TwitterStatusMessage.Parse)
            };

        }

        #endregion

    }

}