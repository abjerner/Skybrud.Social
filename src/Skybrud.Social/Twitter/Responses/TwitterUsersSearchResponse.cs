using Skybrud.Social.Http;
using Skybrud.Social.Json;
using Skybrud.Social.Twitter.Objects;

namespace Skybrud.Social.Twitter.Responses {

    public class TwitterUsersSearchResponse : TwitterResponse<TwitterUser[]> {

        #region Constructors

        private TwitterUsersSearchResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static TwitterUsersSearchResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new TwitterUsersSearchResponse(response) {
                Body = JsonArray.ParseJson(response.Body).ParseMultiple(TwitterUser.Parse)
            };

        }

        #endregion

    }

}