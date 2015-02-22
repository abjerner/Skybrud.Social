using Skybrud.Social.Json;

namespace Skybrud.Social.Google.YouTube.Objects.Channels {

    public class YouTubeChannelLocalized : GoogleApiObject {

        #region Properties

        public string Title { get; private set; }

        public string Description { get; private set; }

        #endregion

        #region Constructors

        protected YouTubeChannelLocalized(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static YouTubeChannelLocalized Parse(JsonObject obj) {
            if (obj == null) return null;
            return new YouTubeChannelLocalized(obj) {
                Title = obj.GetString("title"),
                Description = obj.GetString("description")
            };
        }

        #endregion

    }

}