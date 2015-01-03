using Skybrud.Social.Facebook.Objects.Pages;
using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Responses.Pages {

    public class FacebookPageResponse : FacebookResponse<FacebookPage> {

        #region Constructors

        private FacebookPageResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static FacebookPageResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new FacebookPageResponse(response) {
                Body = FacebookPage.Parse(obj)
            };

        }

        #endregion

    }

}