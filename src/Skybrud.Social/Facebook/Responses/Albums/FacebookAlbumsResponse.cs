using Skybrud.Social.Facebook.Objects.Albums;
using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Responses.Albums {

    public class FacebookAlbumsResponse : FacebookResponse<FacebookAlbumsCollection> {

        #region Constructors

        private FacebookAlbumsResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static FacebookAlbumsResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new FacebookAlbumsResponse(response) {
                Body = FacebookAlbumsCollection.Parse(obj)
            };

        }

        #endregion

    }

}