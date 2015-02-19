using Skybrud.Social.Json;

namespace Skybrud.Social.Google.YouTube.Objects.Channels {

    public class YouTubeChannelSnippetThumbnails : GoogleApiObject {

        #region Properties

        public YouTubeChannelSnippetThumbnail Default { get; private set; }

        public YouTubeChannelSnippetThumbnail Medium { get; private set; }

        public YouTubeChannelSnippetThumbnail High { get; private set; }

        #endregion

        #region Constructors

        protected YouTubeChannelSnippetThumbnails(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static YouTubeChannelSnippetThumbnails Parse(JsonObject obj) {
            if (obj == null) return null;
            return new YouTubeChannelSnippetThumbnails(obj) {
                Default = obj.GetObject("default", YouTubeChannelSnippetThumbnail.Parse),
                Medium = obj.GetObject("medium", YouTubeChannelSnippetThumbnail.Parse),
                High = obj.GetObject("high", YouTubeChannelSnippetThumbnail.Parse)
            };
        }

        #endregion

    }

}