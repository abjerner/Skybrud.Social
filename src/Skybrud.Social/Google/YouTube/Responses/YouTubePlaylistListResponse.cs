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

        private YouTubePlaylistListResponse(JsonObject obj) : base(obj) { }

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
            return new YouTubePlaylistListResponse(obj) {
                TotalResults = pageInfo.GetInt32("totalResults"),
                ResultsPerPage = pageInfo.GetInt32("resultsPerPage"),
                Items = obj.GetArray("items", YouTubePlaylist.Parse) ?? new YouTubePlaylist[0]
            };
        }

        #endregion

    }

}