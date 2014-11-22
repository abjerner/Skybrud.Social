using Skybrud.Social.Facebook.Options.Pagination;
using Skybrud.Social.Http;

namespace Skybrud.Social.Facebook.Options {

    public class FacebookCommentsOptions : FacebookCursorBasedPaginationOptions {

        #region Properties

        /// <summary>
        /// Gets or sets whether a summary of metadata about the comments on the object should be included in the
        /// response. The summary will contain the total count of comments and how the comments are sorted (either
        /// <code>ranked</code> or <code>chronological</code>).
        /// </summary>
        public bool IncludeSummary { get; set; }

        #endregion

        #region Methods

        public override SocialQueryString GetQuery() {
            SocialQueryString query = base.GetQuery();
            if (IncludeSummary) query.Set("summary", "true");
            // TODO: Implement the "filter" modifier
            return query;
        }

        #endregion

    }

}
