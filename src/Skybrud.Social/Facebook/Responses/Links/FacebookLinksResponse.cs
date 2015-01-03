using Skybrud.Social.Facebook.Objects.Links;
using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Responses.Links {

    public class FacebookLinksResponse : FacebookResponse<FacebookLinksCollection> {

        #region Constructors

        private FacebookLinksResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static FacebookLinksResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new FacebookLinksResponse(response) {
                Body = FacebookLinksCollection.Parse(obj)
            };

        }

        #endregion

    }

}