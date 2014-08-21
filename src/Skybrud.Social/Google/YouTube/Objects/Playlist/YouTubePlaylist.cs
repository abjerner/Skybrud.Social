using Skybrud.Social.Json;

namespace Skybrud.Social.Google.YouTube.Objects.Playlist {

    public class YouTubePlaylist : GoogleApiResource {

        #region Properties
        
        public string Id { get; private set; }
        public YouTubePlaylistSnippet Snippet { get; private set; }
        
        #endregion
        
        #region Constructors

        private YouTubePlaylist() {
            // Hide default constructor
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Loads an instance of <var>YouTubePlaylist</var> from the JSON file at the specified
        /// <var>path</var>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public static YouTubePlaylist LoadJson(string path) {
            return JsonObject.LoadJson(path, Parse);
        }

        /// <summary>
        /// Gets an instance of <var>YouTubePlaylist</var> from the specified JSON string.
        /// </summary>
        /// <param name="json">The JSON string representation of the object.</param>
        public static YouTubePlaylist ParseJson(string json) {
            return JsonObject.ParseJson(json, Parse);
        }

        /// <summary>
        /// Gets an instance of <var>YouTubePlaylist</var> from the specified
        /// <var>JsonObject</var>.
        /// </summary>
        /// <param name="obj">The instance of <var>JsonObject</var> to parse.</param>
        public static YouTubePlaylist Parse(JsonObject obj) {
            if (obj == null) return null;
            return new YouTubePlaylist {
                JsonObject = obj,
                Kind = obj.GetString("kind"),
                ETag = obj.GetString("etag"),
                Id = obj.GetString("id"),
                Snippet = obj.GetObject("snippet", YouTubePlaylistSnippet.Parse)
            };
        }

        #endregion

    }

}