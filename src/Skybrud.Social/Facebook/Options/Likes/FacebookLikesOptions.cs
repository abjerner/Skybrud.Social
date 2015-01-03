using Skybrud.Social.Facebook.Options.Pagination;
using Skybrud.Social.Http;

namespace Skybrud.Social.Facebook.Options.Likes {

    public class FacebookLikesOptions : FacebookCursorBasedPaginationOptions {

        #region Properties

        /// <summary>
        /// Gets or sets whether a summary of metadata about the likes on the object should be included in the
        /// response. The summary will contain the total count of likes.
        /// </summary>
        public bool IncludeSummary { get; set; }

        #endregion

        #region Methods

        public override SocialQueryString GetQueryString() {
            SocialQueryString query = base.GetQueryString();
            if (IncludeSummary) query.Set("summary", "true");
            return query;
        }

        #endregion

    }

}
