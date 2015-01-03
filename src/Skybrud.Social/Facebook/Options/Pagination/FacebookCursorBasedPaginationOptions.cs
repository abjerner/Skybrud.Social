using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.Facebook.Options.Pagination {
    
    /// <summary>
    /// Class with options for cursor-based pagination.
    /// </summary>
    /// <see>
    ///     <cref>https://developers.facebook.com/docs/graph-api/using-graph-api/v2.2#cursors</cref>
    /// </see>
    public class FacebookCursorBasedPaginationOptions : IGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the number of individual objects that are returned in each page.
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// Gets or sets the cursor that points to the start of the page of data that has been returned.
        /// </summary>
        public string Before { get; set; }

        /// <summary>
        /// Gets or sets the cursor that points to the end of the page of data that has been returned.
        /// </summary>
        public string After { get; set; }

        #endregion

        #region Methods

        public virtual SocialQueryString GetQueryString() {
            SocialQueryString query = new SocialQueryString();
            if (Limit != null && Limit.Value >= 0) query.Set("limit", Limit.Value);
            if (Before != null) query.Set("before", Before);
            if (After != null) query.Set("after", After);
            return query;
        }

        #endregion
    
    }

}
