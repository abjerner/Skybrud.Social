using Skybrud.Social.Json;

namespace Skybrud.Social.Google.YouTube.Objects.Channels {

    public class YouTubeChannelStatistics : GoogleApiObject {

        #region Properties

        public long ViewCount { get; private set; }

        public long CommentCount { get; private set; }

        public long SubscriberCount { get; private set; }

        public bool HiddenSubscriberCount { get; private set; }

        public int VideoCount { get; private set; }

        #endregion

        #region Constructors

        protected YouTubeChannelStatistics(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <code>YouTubeChannelStatistics</code> from the specified <code>JsonObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        public static YouTubeChannelStatistics Parse(JsonObject obj) {
            if (obj == null) return null;
            return new YouTubeChannelStatistics(obj) {
                ViewCount = obj.GetInt64("viewCount"),
                CommentCount = obj.GetInt64("commentCount"),
                SubscriberCount = obj.GetInt64("subscriberCount"),
                HiddenSubscriberCount = obj.GetBoolean("hiddenSubscriberCount"),
                VideoCount = obj.GetInt32("videoCount")
            };
        }

        #endregion

    }

}