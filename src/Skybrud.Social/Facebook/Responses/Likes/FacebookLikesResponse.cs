using Skybrud.Social.Facebook.Objects.Likes;
using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Responses.Likes {

    public class FacebookLikesResponse : FacebookResponse<FacebookLikesCollection> {

        #region Constructors

        private FacebookLikesResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static FacebookLikesResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new FacebookLikesResponse(response) {
                Body = FacebookLikesCollection.Parse(obj)
            };

        }

        #endregion

    }

}