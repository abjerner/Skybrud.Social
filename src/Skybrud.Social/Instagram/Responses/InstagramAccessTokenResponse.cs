using Skybrud.Social.Http;
using Skybrud.Social.Json;
using Skybrud.Social.Instagram.Objects;

namespace Skybrud.Social.Instagram.Responses {

    public class InstagramAccessTokenResponse : InstagramResponse<InstagramAccessTokenSummaryResponseBody> {

        #region Constructors

        private InstagramAccessTokenResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static InstagramAccessTokenResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new InstagramAccessTokenResponse(response) {
                Body = InstagramAccessTokenSummaryResponseBody.Parse(obj)
            };

        }

        #endregion

    }

    public class InstagramAccessTokenSummaryResponseBody : InstagramResponseBody<InstagramAccessTokenSummary> {

        #region Constructors

        protected InstagramAccessTokenSummaryResponseBody(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static InstagramAccessTokenSummaryResponseBody Parse(JsonObject obj) {
            return new InstagramAccessTokenSummaryResponseBody(obj) {
                Data = obj.GetObject("data", InstagramAccessTokenSummary.Parse)
            };
        }

        #endregion

    }

}