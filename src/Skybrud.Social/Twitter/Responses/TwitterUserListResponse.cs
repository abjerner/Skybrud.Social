using Skybrud.Social.Http;
using Skybrud.Social.Json;
using Skybrud.Social.Twitter.Objects;

namespace Skybrud.Social.Twitter.Responses {

    public class TwitterUserListResponse : TwitterResponse<TwitterUserCollection> {

        #region Constructors

        private TwitterUserListResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static TwitterUserListResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new TwitterUserListResponse(response) {
                Body = JsonObject.ParseJson(response.Body, TwitterUserCollection.Parse)
            };

        }

        #endregion

    }

}