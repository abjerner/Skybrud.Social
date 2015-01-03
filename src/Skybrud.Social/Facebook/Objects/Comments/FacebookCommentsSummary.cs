using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects.Comments {

    /// <summary>
    /// Class representing a summary for the comments of a given object.
    /// </summary>
    public class FacebookCommentsSummary : SocialJsonObject {

        #region Properties

        /// <summary>
        /// Order in which comments were returned. <code>Ranked</code> indicates the most interesting comments are
        /// sorted first. <code>Chronological</code> indicates comments are sorted by the oldest comments first.
        /// </summary>
        public string Order { get; private set; }

        /// <summary>
        /// Gets the count of comments on this node. It is important to note that this value is changed depending on
        /// the filter modifier being used (where comment replies are available):
        /// 
        /// - <code>toplevel</code> - this is the default, returns all top-level comments in either <code>ranked</code>
        /// or <code>chronological</code> order depending on how the comments are ordered on Facebook. This filter is
        /// useful for displaying comments in the same structure as they appear on Facebook.
        /// 
        /// - <code>stream</code> - all-level comments in <code>chronological</code> order. This filter is useful for
        /// comment moderation tools where it is helpful to see a chronological list of all comments.
        /// </summary>
        public int TotalCount { get; private set; }

        #endregion

        #region Constructors

        private FacebookCommentsSummary(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static FacebookCommentsSummary Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookCommentsSummary(obj) {
                Order = obj.GetString("order"),
                TotalCount = obj.GetInt32("total_count")
            };
        }

        #endregion

    }

}