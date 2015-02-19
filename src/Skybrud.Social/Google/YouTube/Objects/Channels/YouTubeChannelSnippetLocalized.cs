using Skybrud.Social.Json;

namespace Skybrud.Social.Google.YouTube.Objects.Channels {

    public class YouTubeChannelSnippetLocalized : GoogleApiObject {

        #region Properties

        public string Title { get; private set; }

        public string Description { get; private set; }

        #endregion

        #region Constructors

        protected YouTubeChannelSnippetLocalized(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static YouTubeChannelSnippetLocalized Parse(JsonObject obj) {
            if (obj == null) return null;
            return new YouTubeChannelSnippetLocalized(obj) {
                Title = obj.GetString("title"),
                Description = obj.GetString("description")
            };
        }

        #endregion

    }

}