using Skybrud.Social.Google.YouTube.Objects;
using Skybrud.Social.Google.YouTube.Objects.Playlist;
using Skybrud.Social.Json;

namespace Skybrud.Social.Google.YouTube.Responses {

    public class YouTubePlaylistListResponse : GoogleApiResponse {

        #region Properties

        public int TotalResults { get; private set; }
        public int ResultsPerPage { get; private set; }
        public YouTubePlaylist[] Items { get; private set; }

        #endregion
       
        #region Constructors

        private YouTubePlaylistListResponse() {
            // Hide default constructor
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a JSON string representing the object.
        /// </summary>
        public string ToJson() {
            return JsonObject == null ? null : JsonObject.ToJson();
        }

        /// <summary>
        /// Saves the object to a JSON file at the specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to save the file.</param>
        public void SaveJson(string path) {
            if (JsonObject != null) JsonObject.SaveJson(path);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Loads an instance of <var>YouTubePlaylistListResponse</var> from the JSON file at the
        /// specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public static YouTubePlaylistListResponse LoadJson(string path) {
            return JsonObject.LoadJson(path, Parse);
        }

        /// <summary>
        /// Gets an instance of <var>YouTubePlaylistListResponse</var> from the specified JSON string.
        /// </summary>
        /// <param name="json">The JSON string representation of the object.</param>
        public static YouTubePlaylistListResponse ParseJson(string json) {
            return JsonObject.ParseJson(json, Parse);
        }

        /// <summary>
        /// Gets an instance of <var>YouTubePlaylistListResponse</var> from the specified
        /// <var>JsonObject</var>.
        /// </summary>
        /// <param name="obj">The instance of <var>JsonObject</var> to parse.</param>
        public static YouTubePlaylistListResponse Parse(JsonObject obj) {

            // Check whether "obj" is NULL
            if (obj == null) return null;

            // Check for any API errors
            ValidateResponse(obj);

            // Get object with paging information
            JsonObject pageInfo = obj.GetObject("pageInfo");

            // Initialize the response object
            return new YouTubePlaylistListResponse {
                JsonObject = obj,
                Kind = obj.GetString("kind"),
                ETag = obj.GetString("etag"),
                TotalResults = pageInfo.GetInt("totalResults"),
                ResultsPerPage = pageInfo.GetInt("resultsPerPage"),
                Items = obj.GetArray("items", YouTubePlaylist.Parse) ?? new YouTubePlaylist[0]
            };
        }

        #endregion

    }

}