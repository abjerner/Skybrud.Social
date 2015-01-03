using Skybrud.Social.Facebook.Objects.Photos;
using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Responses.Photos {

    public class FacebookPostPhotoResponse : FacebookResponse<FacebookPostPhotoSummary> {

        #region Constructors

        private FacebookPostPhotoResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static FacebookPostPhotoResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new FacebookPostPhotoResponse(response) {
                Body = FacebookPostPhotoSummary.Parse(obj)
            };

        }

        #endregion

    }

}