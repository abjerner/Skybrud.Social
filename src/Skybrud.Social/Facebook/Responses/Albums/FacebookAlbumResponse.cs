using Skybrud.Social.Facebook.Objects.Albums;
using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Responses.Albums {

    public class FacebookAlbumResponse : FacebookResponse<FacebookAlbum> {

        #region Constructors

        private FacebookAlbumResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static FacebookAlbumResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new FacebookAlbumResponse(response) {
                Body = FacebookAlbum.Parse(obj)
            };

        }

        #endregion

    }

}