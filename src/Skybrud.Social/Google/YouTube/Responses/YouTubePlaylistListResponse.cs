using Skybrud.Social.Google.YouTube.Objects.Playlists;
using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.Google.YouTube.Responses {

    public class YouTubePlaylistListResponse : YouTubeResponse<YouTubePlaylistList> {

        #region Constructors

        private YouTubePlaylistListResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static YouTubePlaylistListResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new YouTubePlaylistListResponse(response) {
                Body = YouTubePlaylistList.Parse(obj)
            };

        }

        #endregion

    }

}