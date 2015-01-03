using Skybrud.Social.Facebook.Objects.Pagination;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects.Comments {
    
    public class FacebookCommentsCollection : SocialJsonObject {

        #region Properties

        public FacebookComment[] Data { get; private set; }

        public FacebookCursorBasedPagination Paging { get; private set; }

        /// <summary>
        /// Gets a summary for all comments. The summary is only present in the response if <code>IncludeSummary</code>
        /// was <code>TRUE</code> in the request options.
        /// </summary>
        public FacebookCommentsSummary Summary { get; private set; }

        #endregion
        
        #region Constructors

        private FacebookCommentsCollection(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static FacebookCommentsCollection Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookCommentsCollection(obj) {
                Data = obj.GetArray("data", FacebookComment.Parse),
                Paging = obj.GetObject("paging", FacebookCursorBasedPagination.Parse),
                Summary = obj.GetObject("summary", FacebookCommentsSummary.Parse)
            };
        }

        #endregion

    }

}