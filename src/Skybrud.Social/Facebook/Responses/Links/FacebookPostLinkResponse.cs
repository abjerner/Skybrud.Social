using Skybrud.Social.Facebook.Objects.Links;
using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Responses.Links {

    public class FacebookPostLinkResponse : FacebookResponse<FacebookPostLinkSummary> {

        #region Constructors

        private FacebookPostLinkResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static FacebookPostLinkResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new FacebookPostLinkResponse(response) {
                Body = FacebookPostLinkSummary.Parse(obj)
            };

        }

        #endregion

    }

}