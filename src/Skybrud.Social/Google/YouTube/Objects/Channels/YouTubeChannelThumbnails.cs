using Skybrud.Social.Json;

namespace Skybrud.Social.Google.YouTube.Objects.Channels {

    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/channels#snippet.thumbnails</cref>
    /// </see>
    public class YouTubeChannelThumbnails : GoogleApiObject {

        #region Properties

        public YouTubeChannelThumbnail Default { get; private set; }

        public YouTubeChannelThumbnail Medium { get; private set; }

        public YouTubeChannelThumbnail High { get; private set; }

        #endregion

        #region Constructors

        protected YouTubeChannelThumbnails(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static YouTubeChannelThumbnails Parse(JsonObject obj) {
            if (obj == null) return null;
            return new YouTubeChannelThumbnails(obj) {
                Default = obj.GetObject("default", YouTubeChannelThumbnail.Parse),
                Medium = obj.GetObject("medium", YouTubeChannelThumbnail.Parse),
                High = obj.GetObject("high", YouTubeChannelThumbnail.Parse)
            };
        }

        #endregion

    }

}