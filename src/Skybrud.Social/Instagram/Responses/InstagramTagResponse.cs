using Skybrud.Social.Http;
using Skybrud.Social.Instagram.Objects;
using Skybrud.Social.Json;

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

        public static InstagramTagResponseBody Parse(JsonObject obj) {
            return new InstagramTagResponseBody {
                Data = obj.GetObject("data", InstagramTag.Parse)
            };
        }

    }

}