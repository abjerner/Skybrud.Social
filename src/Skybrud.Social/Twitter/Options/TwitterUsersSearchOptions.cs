using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.Twitter.Options {

    public class TwitterUsersSearchOptions : IGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the search query.
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// Specifies the page of results to retrieve.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// The number of potential user results to retrieve per page. This value has a maximum of 20.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// The entities node will be disincluded from embedded tweet objects when set to <code>false</code>.
        /// </summary>
        public bool IncludeEntities { get; set; }

        #endregion

        #region Constructors

        public TwitterUsersSearchOptions() {
            Page = 1;
            Count = 20;
            IncludeEntities = true;
        }

        #endregion

        #region Member methods

        public SocialQueryString GetQueryString() {
            SocialQueryString qs = new SocialQueryString();
            qs.Set("q", Query);
            if (Page > 1) qs.Set("page", Page);
            if (Count != 20) qs.Set("count", Count);
            if (!IncludeEntities) qs.Set("include_entities", "false");
            return qs;
        }

        #endregion

    }

}