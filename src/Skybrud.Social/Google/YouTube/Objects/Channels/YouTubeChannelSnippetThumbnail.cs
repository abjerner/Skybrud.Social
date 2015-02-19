using Skybrud.Social.Json;

namespace Skybrud.Social.Google.YouTube.Objects.Channels {

    public class YouTubeChannelSnippetThumbnail : GoogleApiObject {

        #region Properties

        public string Url { get; private set; }

        #endregion

        #region Constructors

        protected YouTubeChannelSnippetThumbnail(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static YouTubeChannelSnippetThumbnail Parse(JsonObject obj) {
            if (obj == null) return null;
            return new YouTubeChannelSnippetThumbnail(obj) {
                Url = obj.GetString("url")
            };
        }

        #endregion

    }

}