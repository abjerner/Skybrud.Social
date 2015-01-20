using Skybrud.Social.Http;
using Skybrud.Social.Instagram.Objects;
using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Responses {

    public class InstagramMediaResponse : InstagramResponse<InstagramMediaResponseBody> {

        #region Constructors

        private InstagramMediaResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static InstagramMediaResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new InstagramMediaResponse(response) {
                Body = InstagramMediaResponseBody.Parse(obj)
            };

        }

        #endregion

    }

    public class InstagramMediaResponseBody : InstagramResponseBody<InstagramMedia> {

        public static InstagramMediaResponseBody Parse(JsonObject obj) {
            return new InstagramMediaResponseBody {
                Data = obj.GetObject("data", InstagramMedia.Parse)
            };
        }

    }

}