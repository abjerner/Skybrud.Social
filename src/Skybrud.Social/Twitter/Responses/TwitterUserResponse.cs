using Skybrud.Social.Http;
using Skybrud.Social.Json;
using Skybrud.Social.Twitter.Objects;

namespace Skybrud.Social.Twitter.Responses {
    
    public class TwitterUserResponse : TwitterResponse<TwitterUser> {

        #region Constructors

        private TwitterUserResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static TwitterUserResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new TwitterUserResponse(response) {
                Body = JsonObject.ParseJson(response.Body, TwitterUser.Parse)
            };

        }

        #endregion

    }

}