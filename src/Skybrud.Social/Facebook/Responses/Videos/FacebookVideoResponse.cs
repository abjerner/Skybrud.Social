using Skybrud.Social.Facebook.Objects.Videos;
using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Responses.Videos {

    public class FacebookVideoResponse : FacebookResponse<FacebookVideo> {

        #region Constructors

        private FacebookVideoResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static FacebookVideoResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new FacebookVideoResponse(response) {
                Body = FacebookVideo.Parse(obj)
            };

        }

        #endregion

    }

}