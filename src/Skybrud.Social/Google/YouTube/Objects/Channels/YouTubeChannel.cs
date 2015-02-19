using Skybrud.Social.Json;

namespace Skybrud.Social.Google.YouTube.Objects.Channels {

    public class YouTubeChannel : GoogleApiResource {

        #region Properties

        public string Id { get; private set; }

        public YouTubeChannelSnippet Snippet { get; private set; }

        public YouTubeChannelStatistics Statistics { get; private set; }

        #endregion

        #region Constructors

        protected YouTubeChannel(JsonObject obj) : base(obj) { }

        #endregion
        
        #region Static methods

        /// <summary>
        /// Gets an instance of <code>YouTubeChannel</code> from the specified <code>JsonObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        public static YouTubeChannel Parse(JsonObject obj) {
            if (obj == null) return null;
            return new YouTubeChannel(obj) {
                Id = obj.GetString("id"),
                Snippet = obj.GetObject("snippet", YouTubeChannelSnippet.Parse),
                Statistics = obj.GetObject("statistics", YouTubeChannelStatistics.Parse)
            };
        }

        #endregion

    }

}