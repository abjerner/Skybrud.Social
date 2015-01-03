using Skybrud.Social.Facebook.Objects.Posts;
using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Responses.Posts {

    public class FacebookPostResponse : FacebookResponse<FacebookPost> {

        #region Constructors

        private FacebookPostResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static FacebookPostResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new FacebookPostResponse(response) {
                Body = FacebookPost.Parse(obj)
            };

        }

        #endregion

    }

}