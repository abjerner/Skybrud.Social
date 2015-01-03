using Skybrud.Social.Facebook.Objects.Feed;
using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Responses.Feed {

    public class FacebookFeedResponse : FacebookResponse<FacebookFeedCollection> {

        #region Constructors

        private FacebookFeedResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static FacebookFeedResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new FacebookFeedResponse(response) {
                Body = FacebookFeedCollection.Parse(obj)
            };

        }

        #endregion

    }

}