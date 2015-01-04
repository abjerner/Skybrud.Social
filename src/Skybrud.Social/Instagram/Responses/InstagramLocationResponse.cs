using Skybrud.Social.Http;
using Skybrud.Social.Instagram.Objects;
using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Responses {

    public class InstagramLocationResponse : InstagramResponse<InstagramLocationResponseBody> {

        #region Constructors

        private InstagramLocationResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static InstagramLocationResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new InstagramLocationResponse(response) {
                Body = InstagramLocationResponseBody.Parse(obj)
            };

        }

        #endregion

    }

    public class InstagramLocationResponseBody : InstagramResponseBody<InstagramLocation> {

        public static InstagramLocationResponseBody Parse(JsonObject obj) {
            return new InstagramLocationResponseBody {
                Data = obj.GetObject("data", InstagramLocation.Parse)
            };
        }

    }

}