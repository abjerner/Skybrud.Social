using Skybrud.Social.Json;

namespace Skybrud.Social.Google.YouTube.Objects.Playlists {

    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/playlists#contentDetails</cref>
    /// </see>
    public class YouTubePlaylistContentDetails : GoogleApiObject {

        #region Properties

        public int ItemCount { get; private set; }

        #endregion

        #region Constructor

        protected YouTubePlaylistContentDetails(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <code>YouTubePlaylistContentDetails</code> from the specified <code>JsonObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        public static YouTubePlaylistContentDetails Parse(JsonObject obj) {
            if (obj == null) return null;
            return new YouTubePlaylistContentDetails(obj) {
                ItemCount = obj.GetInt32("itemCount")
            };
        }

        #endregion

    }

}