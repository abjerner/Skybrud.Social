using Skybrud.Social.Facebook.Objects.Apps;
using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Responses.Apps {

    public class FacebookAppResponse : FacebookResponse<FacebookApp> {

        #region Constructors

        private FacebookAppResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static FacebookAppResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new FacebookAppResponse(response) {
                Body = FacebookApp.Parse(obj)
            };

        }

        #endregion

    }

}