using Skybrud.Social.Json;

namespace Skybrud.Social.Google.YouTube.Objects.PlaylistItem {
    
    public class YouTubePlaylistItemStatus : GoogleApiObject {

        #region Properties
        
        public string PrivacyStatus { get; private set; }

        #endregion
        
        #region Constructors

        private YouTubePlaylistItemStatus() {
            // Hide default constructor
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Loads an instance of <var>YouTubePlaylistItemStatus</var> from the JSON file at the
        /// specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public static YouTubePlaylistItemStatus LoadJson(string path) {
            return JsonObject.LoadJson(path, Parse);
        }

        /// <summary>
        /// Gets an instance of <var>YouTubePlaylistItemStatus</var> from the specified JSON
        /// string.
        /// </summary>
        /// <param name="json">The JSON string representation of the object.</param>
        public static YouTubePlaylistItemStatus ParseJson(string json) {
            return JsonObject.ParseJson(json, Parse);
        }

        /// <summary>
        /// Gets an instance of <var>YouTubePlaylistItemStatus</var> from the specified
        /// <var>JsonObject</var>.
        /// </summary>
        /// <param name="obj">The instance of <var>JsonObject</var> to parse.</param>
        public static YouTubePlaylistItemStatus Parse(JsonObject obj) {
            
            // Check whether "obj" is NULL
            if (obj == null) return null;
            
            // Initialize and return the status object
            return new YouTubePlaylistItemStatus {
                JsonObject = obj,
                PrivacyStatus = obj.GetString("privacyStatus")
            };

        }

        #endregion

    }

}