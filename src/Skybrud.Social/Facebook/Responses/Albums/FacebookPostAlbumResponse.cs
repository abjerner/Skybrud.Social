using Skybrud.Social.Facebook.Objects.Albums;
using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Responses.Albums {

    public class FacebookPostAlbumResponse : FacebookResponse<FacebookPostAlbumSummary> {

        #region Constructors

        private FacebookPostAlbumResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static FacebookPostAlbumResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new FacebookPostAlbumResponse(response) {
                Body = FacebookPostAlbumSummary.Parse(obj)
            };

        }

        #endregion

    }

}