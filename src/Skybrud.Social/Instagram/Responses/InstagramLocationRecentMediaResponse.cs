using Skybrud.Social.Http;
using Skybrud.Social.Instagram.Objects;
using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Responses {

    public class InstagramLocationRecentMediaResponse : InstagramResponse<InstagramLocationRecentMediaResponseBody> {

        #region Constructors

        private InstagramLocationRecentMediaResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static InstagramLocationRecentMediaResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new InstagramLocationRecentMediaResponse(response) {
                Body = InstagramLocationRecentMediaResponseBody.Parse(obj)
            };

        }

        #endregion

    }

    public class InstagramLocationRecentMediaResponseBody : InstagramResponseBody<InstagramMedia[]> {

        public static InstagramLocationRecentMediaResponseBody Parse(JsonObject obj) {
            return new InstagramLocationRecentMediaResponseBody {
                Data = obj.GetArray("data", InstagramMedia.Parse)
            };
        }

    }

}