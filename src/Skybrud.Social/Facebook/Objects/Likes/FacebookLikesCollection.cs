using Skybrud.Social.Facebook.Objects.Pagination;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects.Likes {
    
    public class FacebookLikesCollection : SocialJsonObject {

        #region Properties

        public FacebookLike[] Data { get; private set; }

        public FacebookCursorBasedPagination Paging { get; private set; }

        /// <summary>
        /// Gets a summary for all likes. The summary is only present in the response if <code>IncludeSummary</code>
        /// was <code>TRUE</code> in the request options.
        /// </summary>
        public FacebookLikesSummary Summary { get; private set; }

        #endregion
        
        #region Constructors

        private FacebookLikesCollection(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static FacebookLikesCollection Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookLikesCollection(obj) {
                Data = obj.GetArray("data", FacebookLike.Parse),
                Paging = obj.GetObject("paging", FacebookCursorBasedPagination.Parse),
                Summary = obj.GetObject("summary", FacebookLikesSummary.Parse)
            };
        }

        #endregion

    }

}