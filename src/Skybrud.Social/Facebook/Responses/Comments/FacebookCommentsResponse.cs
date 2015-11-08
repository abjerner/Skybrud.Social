using Skybrud.Social.Facebook.Objects.Comments;
using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Responses.Comments {

    public class FacebookCommentsResponse : FacebookResponse<FacebookCommentsCollection> {

        // TODO: Rename to "FacebookGetCommentsResponse" in v1.0

        #region Constructors

        private FacebookCommentsResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static FacebookCommentsResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new FacebookCommentsResponse(response) {
                Body = FacebookCommentsCollection.Parse(obj)
            };

        }

        #endregion

    }

}