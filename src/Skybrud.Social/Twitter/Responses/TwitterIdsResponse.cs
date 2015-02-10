using Skybrud.Social.Http;
using Skybrud.Social.Json;
using Skybrud.Social.Twitter.Objects;

namespace Skybrud.Social.Twitter.Responses {

    public class TwitterIdsResponse : TwitterResponse<TwitterIdsCollection> {

        #region Constructors

        private TwitterIdsResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static TwitterIdsResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new TwitterIdsResponse(response) {
                Body = JsonObject.ParseJson(response.Body, TwitterIdsCollection.Parse)
            };

        }

        #endregion

    }

}