using Skybrud.Social.Json;

namespace Skybrud.Social.Google.YouTube.Objects.PlaylistItems {

    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/playlistItems#snippet.thumbnails</cref>
    /// </see>
    public class YouTubePlaylistItemThumbnail : GoogleApiObject {

        #region Properties

        public string Url { get; private set; }

        public int Width { get; private set; }

        public int Height { get; private set; }

        #endregion

        #region Constructors

        protected YouTubePlaylistItemThumbnail(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static YouTubePlaylistItemThumbnail Parse(JsonObject obj) {
            if (obj == null) return null;
            return new YouTubePlaylistItemThumbnail(obj) {
                Url = obj.GetString("url"),
                Width = obj.GetInt32("width"),
                Height = obj.GetInt32("height")
            };
        }

        #endregion

    }

}