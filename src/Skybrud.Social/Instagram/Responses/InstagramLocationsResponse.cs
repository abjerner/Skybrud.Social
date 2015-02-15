using Skybrud.Social.Http;
using Skybrud.Social.Json;
using Skybrud.Social.Instagram.Objects;

namespace Skybrud.Social.Instagram.Responses {

    public class InstagramLocationsResponse : InstagramResponse<InstagramLocationsResponseBody> {

        #region Constructors

        private InstagramLocationsResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static InstagramLocationsResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new InstagramLocationsResponse(response) {
                Body = InstagramLocationsResponseBody.Parse(obj)
            };

        }

        #endregion

    }

    public class InstagramLocationsResponseBody : InstagramResponseBody<InstagramLocation[]> {

        #region Constructors

        protected InstagramLocationsResponseBody(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static InstagramLocationsResponseBody Parse(JsonObject obj) {
            return new InstagramLocationsResponseBody(obj) {
                Data = obj.GetArray("data", InstagramLocation.Parse)
            };
        }

        #endregion

    }

}