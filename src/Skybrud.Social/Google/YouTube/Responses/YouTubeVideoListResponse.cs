using Skybrud.Social.Google.YouTube.Objects.Videos;
using Skybrud.Social.Json;

namespace Skybrud.Social.Google.YouTube.Responses {

    public class YouTubeVideoListResponse : GoogleApiResponse {

        #region Properties

        public int TotalResults { get; private set; }
        public int ResultsPerPage { get; private set; }
        public string PrevPageToken { get; private set; }
        public string NextPageToken { get; private set; }
        public YouTubeVideo[] Items { get; private set; }

        #endregion
        
        #region Constructors

        private YouTubeVideoListResponse(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Loads an instance of <var>YouTubeVideoListResponse</var> from the JSON file at the
        /// specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public static YouTubeVideoListResponse LoadJson(string path) {
            return JsonObject.LoadJson(path, Parse);
        }

        /// <summary>
        /// Gets an instance of <var>YouTubeVideoListResponse</var> from the specified JSON string.
        /// </summary>
        /// <param name="json">The JSON string representation of the object.</param>
        public static YouTubeVideoListResponse ParseJson(string json) {
            return JsonObject.ParseJson(json, Parse);
        }

        /// <summary>
        /// Gets an instance of <var>YouTubeVideoListResponse</var> from the specified
        /// <var>JsonObject</var>.
        /// </summary>
        /// <param name="obj">The instance of <var>JsonObject</var> to parse.</param>
        public static YouTubeVideoListResponse Parse(JsonObject obj) {

            // Check whether "obj" is NULL
            if (obj == null) return null;

            // Check for any API errors
            ValidateResponse(obj);

            // Get object with paging information
            JsonObject pageInfo = obj.GetObject("pageInfo");

            // Initialize the response object
            return new YouTubeVideoListResponse(obj) {
                Kind = obj.GetString("kind"),
                ETag = obj.GetString("etag"),
                TotalResults = pageInfo.GetInt("totalResults"),
                ResultsPerPage = pageInfo.GetInt("resultsPerPage"),
                PrevPageToken = obj.GetString("prevPageToken"),
                NextPageToken = obj.GetString("nextPageToken"),
                Items = obj.GetArray("items", YouTubeVideo.Parse) ?? new YouTubeVideo[0]
            };
        }

        #endregion

    }

}
