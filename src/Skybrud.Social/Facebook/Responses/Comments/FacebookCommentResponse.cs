using Skybrud.Social.Facebook.Objects.Comments;
using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Responses.Comments {

    public class FacebookCommentResponse : FacebookResponse<FacebookComment> {

        // TODO: Rename to "FacebookGetCommentResponse" in v1.0

        #region Constructors

        private FacebookCommentResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static FacebookCommentResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new FacebookCommentResponse(response) {
                Body = FacebookComment.Parse(obj)
            };

        }

        #endregion

    }

}