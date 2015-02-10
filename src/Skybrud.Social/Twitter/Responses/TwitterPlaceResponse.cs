using Skybrud.Social.Http;
using Skybrud.Social.Json;
using Skybrud.Social.Twitter.Objects;

namespace Skybrud.Social.Twitter.Responses {

    public class TwitterPlaceResponse : TwitterResponse<TwitterPlace> {

        #region Constructors

        private TwitterPlaceResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static TwitterPlaceResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new TwitterPlaceResponse(response) {
                Body = JsonObject.ParseJson(response.Body, TwitterPlace.Parse)
            };

        }

        #endregion

    }

}