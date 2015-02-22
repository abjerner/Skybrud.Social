using Skybrud.Social.Google.YouTube.Objects.PlaylistItems;
using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.Google.YouTube.Responses {

    public class YouTubePlaylistItemListResponse : YouTubeResponse<YouTubePlaylistItemList> {

        #region Constructors

        private YouTubePlaylistItemListResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static YouTubePlaylistItemListResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new YouTubePlaylistItemListResponse(response) {
                Body = YouTubePlaylistItemList.Parse(obj)
            };

        }

        #endregion

    }

}