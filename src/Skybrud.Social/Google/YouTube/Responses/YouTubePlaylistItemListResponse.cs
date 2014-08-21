using Skybrud.Social.Google.YouTube.Objects.PlaylistItem;
using Skybrud.Social.Json;

namespace Skybrud.Social.Google.YouTube.Responses {
    
    public class YouTubePlaylistItemListResponse : GoogleApiResponse {

        #region Properties

        public int TotalResults { get; private set; }
        public int ResultsPerPage { get; private set; }
        public string PrevPageToken { get; private set; }
        public string NextPageToken { get; private set; }
        public YouTubePlaylistItem[] Items { get; private set; }

        #endregion

        #region Static methods

        /// <summary>
        /// Loads an instance of <var>YouTubePlaylistItemListResponse</var> from the JSON file at the
        /// specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public static YouTubePlaylistItemListResponse LoadJson(string path) {
            return JsonObject.LoadJson(path, Parse);
        }

        /// <summary>
        /// Gets an instance of <var>YouTubePlaylistItemListResponse</var> from the specified JSON string.
        /// </summary>
        /// <param name="json">The JSON string representation of the object.</param>
        public static YouTubePlaylistItemListResponse ParseJson(string json) {
            return JsonObject.ParseJson(json, Parse);
        }

        /// <summary>
        /// Gets an instance of <var>YouTubePlaylistItemListResponse</var> from the specified
        /// <var>JsonObject</var>.
        /// </summary>
        /// <param name="obj">The instance of <var>JsonObject</var> to parse.</param>
        public static YouTubePlaylistItemListResponse Parse(JsonObject obj) {

            // Check whether "obj" is NULL
            if (obj == null) return null;

            // Check for any API errors
            ValidateResponse(obj);

            // Get object with paging information
            JsonObject pageInfo = obj.GetObject("pageInfo");

            // Initialize the response object
            return new YouTubePlaylistItemListResponse {
                JsonObject = obj,
                Kind = obj.GetString("kind"),
                ETag = obj.GetString("etag"),
                TotalResults = pageInfo.GetInt("totalResults"),
                ResultsPerPage = pageInfo.GetInt("resultsPerPage"),
                PrevPageToken = obj.GetString("prevPageToken"),
                NextPageToken = obj.GetString("nextPageToken"),
                Items = obj.GetArray("items", YouTubePlaylistItem.Parse) ?? new YouTubePlaylistItem[0]
            };
        }

        #endregion

    }

}
