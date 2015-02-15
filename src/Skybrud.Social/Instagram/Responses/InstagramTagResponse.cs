using Skybrud.Social.Http;
using Skybrud.Social.Json;
using Skybrud.Social.Instagram.Objects;

namespace Skybrud.Social.Instagram.Responses {

    public class InstagramTagResponse : InstagramResponse<InstagramTagResponseBody> {

        #region Constructors

        private InstagramTagResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static InstagramTagResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new InstagramTagResponse(response) {
                Body = InstagramTagResponseBody.Parse(obj)
            };

        }

        #endregion

    }

    public class InstagramTagResponseBody : InstagramResponseBody<InstagramTag> {

        #region Constructors

        protected InstagramTagResponseBody(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static InstagramTagResponseBody Parse(JsonObject obj) {
            return new InstagramTagResponseBody(obj) {
                Data = obj.GetObject("data", InstagramTag.Parse)
            };
        }

        #endregion

    }

}