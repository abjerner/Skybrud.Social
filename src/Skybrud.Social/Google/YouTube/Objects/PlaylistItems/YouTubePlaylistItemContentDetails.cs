using Skybrud.Social.Json;

namespace Skybrud.Social.Google.YouTube.Objects.PlaylistItems {

    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/playlistItems#contentDetails</cref>
    /// </see>
    public class YouTubePlaylistItemContentDetails : GoogleApiObject {

        #region Properties

        public string VideoId { get; private set; }

        #endregion

        #region Constructor

        protected YouTubePlaylistItemContentDetails(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <code>YouTubePlaylistItemContentDetails</code> from the specified <code>JsonObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        public static YouTubePlaylistItemContentDetails Parse(JsonObject obj) {
            if (obj == null) return null;
            return new YouTubePlaylistItemContentDetails(obj) {
                VideoId = obj.GetString("videoId")
            };
        }

        #endregion

    }

}