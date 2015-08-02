using System;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.Google.Analytics.Options.Management {

    /// <summary>
    /// Class representing the options for getting profiles from the Analytics API.
    /// </summary>
    public class AnalyticsProfilesOptions : IGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the ID of the parent account. If set to <code>~all</code>, profiles of all accounts
        /// (that the authenticated user has access to) will be returned.
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the parent web property. If set to <code>~all</code>, profiles of all web properties
        /// (that the authenticated user has access to) will be returned.
        /// </summary>
        public string WebPropertyId { get; set; }

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
        public AnalyticsProfilesOptions() {
            AccountId = "~all";
            WebPropertyId = "~all";
        }

        /// <summary>
        /// Initializes a new instance based on the specified <code>maxResults</code>.
        /// </summary>
        /// <param name="maxResults">The maximum number of profiles to include in this response.</param>
        public AnalyticsProfilesOptions(int maxResults) : this() {
            MaxResults = maxResults;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <code>maxResults</code> and <code>startIndex</code>.
        /// </summary>
        /// <param name="maxResults">The maximum number of profiles to include in this response.</param>
        /// <param name="startIndex">The index of the first profile to retrieve. The first profile holds the index <code>1</code>.</param>
        public AnalyticsProfilesOptions(int maxResults, int startIndex) : this() {
            MaxResults = maxResults;
            StartIndex = startIndex;
        }

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        /// <param name="accountId">The ID of the parent account.</param>
        /// <param name="webPropertyId">The ID of the parent web property.</param>
        public AnalyticsProfilesOptions(string accountId, string webPropertyId) : this() {
            if (String.IsNullOrWhiteSpace(accountId)) throw new ArgumentNullException("accountId");
            AccountId = accountId;
            WebPropertyId = webPropertyId;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <code>maxResults</code>.
        /// </summary>
        /// <param name="accountId">The ID of the parent account.</param>
        /// <param name="webPropertyId">The ID of the parent web property.</param>
        /// <param name="maxResults">The maximum number of profiles to include in this response.</param>
        public AnalyticsProfilesOptions(string accountId, string webPropertyId, int maxResults) : this() {
            if (String.IsNullOrWhiteSpace(accountId)) throw new ArgumentNullException("accountId");
            AccountId = accountId;
            WebPropertyId = webPropertyId;
            MaxResults = maxResults;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <code>maxResults</code> and <code>startIndex</code>.
        /// </summary>
        /// <param name="accountId">The ID of the parent account.</param>
        /// <param name="webPropertyId">The ID of the parent web property.</param>
        /// <param name="maxResults">The maximum number of profiles to include in this response.</param>
        /// <param name="startIndex">The index of the first profile to retrieve. The first profile holds the index <code>1</code>.</param>
        public AnalyticsProfilesOptions(string accountId, string webPropertyId, int maxResults, int startIndex) : this() {
            if (String.IsNullOrWhiteSpace(accountId)) throw new ArgumentNullException("accountId");
            AccountId = accountId;
            WebPropertyId = webPropertyId;
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