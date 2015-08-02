using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.Google.Analytics.Options.Management {

    /// <summary>
    /// Class representing the options for getting accounts from the Analytics API.
    /// </summary>
    public class AnalyticsAccountsOptions : IGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the maximum amount of results returned. If <code>0</code>, the default maximum of the API will
        /// be used.
        /// </summary>
        public int MaxResults { get; set; }

        /// <summary>
        /// Gets or sets the start index.
        /// </summary>
        public int StartIndex { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public AnalyticsAccountsOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <code>maxResults</code>.
        /// </summary>
        /// <param name="maxResults">The maximum number of accounts to include in this response.</param>
        public AnalyticsAccountsOptions(int maxResults) {
            MaxResults = maxResults;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <code>maxResults</code> and <code>startIndex</code>.
        /// </summary>
        /// <param name="maxResults">The maximum number of accounts to include in this response.</param>
        /// <param name="startIndex">The index of the first account to retrieve. The first account holds the index <code>1</code>.</param>
        public AnalyticsAccountsOptions(int maxResults, int startIndex) {
            MaxResults = maxResults;
            StartIndex = startIndex;
        }
        
        #endregion

        #region Methods

        public SocialQueryString GetQueryString() {
            SocialQueryString query = new SocialQueryString();
            if (StartIndex > 0) query.Add("start-index", StartIndex);
            if (MaxResults > 0) query.Add("max-results", MaxResults);
            return query;
        }

        #endregion

    }

}