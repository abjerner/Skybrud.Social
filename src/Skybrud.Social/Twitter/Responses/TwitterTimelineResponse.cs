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

            if (response == null) return null;

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