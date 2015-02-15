using Skybrud.Social.Http;
using Skybrud.Social.Json;
using Skybrud.Social.Instagram.Objects;

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

        #region Constructors

        protected InstagramMediaResponseBody(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static InstagramMediaResponseBody Parse(JsonObject obj) {
            return new InstagramMediaResponseBody(obj) {
                Data = obj.GetObject("data", InstagramMedia.Parse)
            };
        }

        #endregion

    }

}