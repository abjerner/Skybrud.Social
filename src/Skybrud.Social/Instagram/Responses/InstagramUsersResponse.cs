using Skybrud.Social.Http;
using Skybrud.Social.Instagram.Objects;
using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Responses {

    public class InstagramUsersResponse : InstagramResponse<InstagramUserSummarysResponseBody> {

        #region Constructors

        private InstagramUsersResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static InstagramUsersResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new InstagramUsersResponse(response) {
                Body = InstagramUserSummarysResponseBody.Parse(obj)
            };

        }

        #endregion

    }

    public class InstagramUserSummarysResponseBody : InstagramResponseBody<InstagramUserSummary[]> {

        public static InstagramUserSummarysResponseBody Parse(JsonObject obj) {
            return new InstagramUserSummarysResponseBody {
                Data = obj.GetArray("data", InstagramUserSummary.Parse)
            };
        }

    }

}