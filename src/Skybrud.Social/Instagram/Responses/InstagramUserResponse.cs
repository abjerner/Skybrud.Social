using Skybrud.Social.Http;
using Skybrud.Social.Json;
using Skybrud.Social.Instagram.Objects;

namespace Skybrud.Social.Instagram.Responses {

    public class InstagramUserResponse : InstagramResponse<InstagramUserResponseBody> {

        #region Constructors

        private InstagramUserResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static InstagramUserResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new InstagramUserResponse(response) {
                Body = InstagramUserResponseBody.Parse(obj)
            };

        }

        #endregion

    }

    public class InstagramUserResponseBody : InstagramResponseBody<InstagramUser> {

        #region Constructors

        protected InstagramUserResponseBody(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static InstagramUserResponseBody Parse(JsonObject obj) {
            return new InstagramUserResponseBody(obj) {
                Data = obj.GetObject("data", InstagramUser.Parse)
            };
        }

        #endregion

    }

}