using Skybrud.Social.Json;

namespace Skybrud.Social.Google.YouTube.Objects.Videos {

    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/videos#statistics</cref>
    /// </see>
    public class YouTubeVideoStatistics : GoogleApiObject {

        #region Properties

        public long ViewCount { get; private set; }

        public long LikeCount { get; private set; }

        public long DislikeCount { get; private set; }

        public long FavoriteCount { get; private set; }

        public long CommentCount { get; private set; }

        #endregion

        #region Constructors

        protected YouTubeVideoStatistics(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <code>YouTubeVideoStatistics</code> from the specified <code>JsonObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        public static YouTubeVideoStatistics Parse(JsonObject obj) {
            if (obj == null) return null;
            return new YouTubeVideoStatistics(obj) {
                ViewCount = obj.GetInt64("viewCount"),
                LikeCount = obj.GetInt64("likeCount"),
                DislikeCount = obj.GetInt64("dislikeCount"),
                FavoriteCount = obj.GetInt64("favoriteCount"),
                CommentCount = obj.GetInt64("commentCount")
            };
        }

        #endregion

    }

}