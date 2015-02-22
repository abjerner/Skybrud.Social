using Skybrud.Social.Json;

namespace Skybrud.Social.Google.YouTube.Objects.PlaylistItems {

    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/playlistItems#snippet.thumbnails</cref>
    /// </see>
    public class YouTubePlaylistItemThumbnails : GoogleApiObject {

        #region Properties

        public YouTubePlaylistItemThumbnail Default { get; private set; }

        public YouTubePlaylistItemThumbnail Medium { get; private set; }

        public YouTubePlaylistItemThumbnail High { get; private set; }

        public YouTubePlaylistItemThumbnail Standard { get; private set; }

        public YouTubePlaylistItemThumbnail MaxRes { get; private set; }

        #endregion

        #region Constructors

        protected YouTubePlaylistItemThumbnails(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static YouTubePlaylistItemThumbnails Parse(JsonObject obj) {
            if (obj == null) return null;
            return new YouTubePlaylistItemThumbnails(obj) {
                Default = obj.GetObject("default", YouTubePlaylistItemThumbnail.Parse),
                Medium = obj.GetObject("medium", YouTubePlaylistItemThumbnail.Parse),
                High = obj.GetObject("high", YouTubePlaylistItemThumbnail.Parse),
                Standard = obj.GetObject("standard", YouTubePlaylistItemThumbnail.Parse),
                MaxRes = obj.GetObject("maxres", YouTubePlaylistItemThumbnail.Parse)
            };
        }

        #endregion

    }

}