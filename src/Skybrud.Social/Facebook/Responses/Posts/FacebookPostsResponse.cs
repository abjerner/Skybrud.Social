using Skybrud.Social.Facebook.Objects.Posts;
using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Responses.Posts {

    public class FacebookPostsResponse : FacebookResponse<FacebookPostsCollection> {

        #region Constructors

        private FacebookPostsResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static FacebookPostsResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new FacebookPostsResponse(response) {
                Body = FacebookPostsCollection.Parse(obj)
            };

        }

        #endregion

    }

}