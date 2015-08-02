using System;
using System.Collections.Specialized;
using Skybrud.Social.Google.Analytics.Endpoints.Raw;
using Skybrud.Social.Google.Analytics.Objects;
using Skybrud.Social.Google.OAuth;

namespace Skybrud.Social.Google.Analytics {

    /// <summary>
    /// Raw implementation of the Analytics endpoint.
    /// </summary>
    public class AnalyticsRawEndpoint {

        // TODO: Move class to the "Skybrud.Social.Google.Analytics.Endpoints.Raw" namespace for v1.0

        protected const string ManagementUrl = "https://www.googleapis.com/analytics/v3/management/";

        #region Properties

        /// <summary>
        /// Gets a reference to the Google OAuth client.
        /// </summary>
        public GoogleOAuthClient Client { get; private set; }

        /// <summary>
        /// Gets a reference to the raw management endpoint.
        /// </summary>
        public AnalyticsManagementRawEndpoint Management { get; private set; }

        /// <summary>
        /// Gets a reference to the raw data endpoint.
        /// </summary>
        public AnalyticsDataRawEndpoint Data { get; private set; }

        #endregion

        #region Constructors

        internal AnalyticsRawEndpoint(GoogleOAuthClient client) {
            Client = client;
            Management = new AnalyticsManagementRawEndpoint(client);
            Data = new AnalyticsDataRawEndpoint(client);
        }

        #endregion

        #region Accounts

        /// <summary>
        /// Gets a list of Analytics accounts of the authenticated user.
        /// </summary>
        /// <returns>Returns an instance of <code>SocialHttpResponse</code> representing the response.</returns>
        [Obsolete("Use the GetAccounts method in the new Management endpoint. See release notes for v0.9.4 for further information.")]
        public string GetAccounts() {
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://www.googleapis.com/analytics/v3/management/accounts", new NameValueCollection {
                {"access_token", Client.AccessToken}
            });
        }

        #endregion

        #region Web properties

        [Obsolete("Use the GetWebProperties method in the new Management endpoint. See release notes for v0.9.4 for further information.")]
        public string GetWebProperties(int maxResults = 0, int startIndex = 0) {
            return GetWebProperties("~all", maxResults, startIndex);
        }

        [Obsolete("Use the GetWebProperties method in the new Management endpoint. See release notes for v0.9.4 for further information.")]
        public string GetWebProperties(AnalyticsAccount account, int maxResults = 0, int startIndex = 0) {
            return GetWebProperties(account.Id, maxResults, startIndex);
        }

        [Obsolete("Use the GetWebProperties method in the new Management endpoint. See release notes for v0.9.4 for further information.")]
        public string GetWebProperties(string accountId, int maxResults = 0, int startIndex = 0) {

            NameValueCollection query = new NameValueCollection();
            if (maxResults > 0) query.Add("max-results", maxResults + "");
            if (startIndex > 0) query.Add("start-index", startIndex + "");
            query.Add("access_token", Client.AccessToken);

            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://www.googleapis.com/analytics/v3/management/accounts/" + accountId + "/webproperties", query);

        }

        #endregion

        #region Profiles

        /// <summary>
        /// Gets a view (profile) to which the user has access.
        /// </summary>
        /// <param name="accountId">Account ID to retrieve the goal for.</param>
        /// <param name="webPropertyId">Web property ID to retrieve the goal for.</param>
        /// <param name="profileId">View (Profile) ID to retrieve the goal for.</param>
        public string GetProfile(string accountId, string webPropertyId, string profileId) {

            // Construct the URL
            string url = String.Format(
               "{0}accounts/{1}/webproperties/{2}/profiles/{3}",
               ManagementUrl,
               accountId,
               webPropertyId,
               profileId
            );

            // Make the call to the API
            return Client.DoAuthenticatedGetRequest(url);

        }

        /// <summary>
        /// Gets a list of all profiles the user has access to.
        /// </summary>
        /// <param name="maxResults">The maximum number of views (profiles) to include in this response.</param>
        /// <param name="startIndex">An index of the first entity to retrieve. Use this parameter as a pagination mechanism along with the max-results parameter.</param>
        public string GetProfiles(int maxResults = 0, int startIndex = 0) {
            return GetProfiles("~all", "~all", maxResults, startIndex);
        }

        /// <summary>
        /// Gets a list of all profiles for the specified account. The result will profiles of all web properties of the account.
        /// </summary>
        /// <param name="account">The parent account.</param>
        /// <param name="maxResults">The maximum number of views (profiles) to include in this response.</param>
        /// <param name="startIndex">An index of the first entity to retrieve. Use this parameter as a pagination mechanism along with the max-results parameter.</param>
        public string GetProfiles(AnalyticsAccount account, int maxResults = 0, int startIndex = 0) {
            return GetProfiles(account.Id, "~all", maxResults, startIndex);
        }

        /// <summary>
        /// Gets a list of profiles for the specified web property.
        /// </summary>
        /// <param name="property">The parent web propaerty.</param>
        /// <param name="maxResults">The maximum number of views (profiles) to include in this response.</param>
        /// <param name="startIndex">An index of the first entity to retrieve. Use this parameter as a pagination mechanism along with the max-results parameter.</param>
        public string GetProfiles(AnalyticsWebProperty property, int maxResults = 0, int startIndex = 0) {
            return GetProfiles(property.AccountId, property.Id, maxResults, startIndex);
        }

        /// <summary>
        /// Gets a list of profiles for the specified account.
        /// </summary>
        /// <param name="accountId">Account ID for the view (profiles) to retrieve. Can either be a specific account ID or '~all', which refers to all the accounts to which the user has access.</param>
        /// <param name="maxResults">The maximum number of views (profiles) to include in this response.</param>
        /// <param name="startIndex">An index of the first entity to retrieve. Use this parameter as a pagination mechanism along with the max-results parameter.</param>
        public string GetProfiles(string accountId, int maxResults = 0, int startIndex = 0) {
            return GetProfiles(accountId, "~all", maxResults, startIndex);
        }

        /// <summary>
        /// Gets a list of profiles for the specified account and web property.
        /// </summary>
        /// <param name="accountId">Account ID for the view (profiles) to retrieve. Can either be a specific account ID or '~all', which refers to all the accounts to which the user has access.</param>
        /// <param name="webPropertyId">Web property ID for the views (profiles) to retrieve. Can either be a specific web property ID or '~all', which refers to all the web properties to which the user has access.</param>
        /// <param name="maxResults">The maximum number of views (profiles) to include in this response.</param>
        /// <param name="startIndex">An index of the first entity to retrieve. Use this parameter as a pagination mechanism along with the max-results parameter.</param>
        public string GetProfiles(string accountId, string webPropertyId, int maxResults = 0, int startIndex = 0) {

            // Construct the query string
            NameValueCollection query = new NameValueCollection();
            if (maxResults > 0) query.Add("max-results", maxResults + "");
            if (startIndex > 0) query.Add("start-index", startIndex + "");

            // Construct the URL
            string url = String.Format(
               "{0}accounts/" + accountId + "/webproperties/" + webPropertyId + "/profiles",
               ManagementUrl,
               accountId,
               webPropertyId
            );

            // Make the call to the API
            return Client.DoAuthenticatedGetRequest(url, query);

        }

        #endregion

        #region Data

        [Obsolete("Use the GetData method in the new Data endpoint. See release notes for v0.9.4 for further information.")]
        public string GetData(AnalyticsProfile profile, DateTime startDate, DateTime endDate, string[] metrics, string[] dimensions) {
            return GetData(profile.Id, startDate, endDate, metrics, dimensions);
        }

        [Obsolete("Use the GetData method in the new Data endpoint. See release notes for v0.9.4 for further information.")]
        public string GetData(string profileId, DateTime startDate, DateTime endDate, string[] metrics, string[] dimensions) {
            return GetData(profileId, new AnalyticsDataOptions {
                StartDate = startDate,
                EndDate = endDate,
                Metrics = metrics,
                Dimensions = dimensions
            });
        }

        [Obsolete("Use the GetData method in the new Data endpoint. See release notes for v0.9.4 for further information.")]
        public string GetData(AnalyticsProfile profile, DateTime startDate, DateTime endDate, AnalyticsMetricCollection metrics, AnalyticsDimensionCollection dimensions) {
            return GetData(profile.Id, startDate, endDate, metrics, dimensions);
        }

        [Obsolete("Use the GetData method in the new Data endpoint. See release notes for v0.9.4 for further information.")]
        public string GetData(string profileId, DateTime startDate, DateTime endDate, AnalyticsMetricCollection metrics, AnalyticsDimensionCollection dimensions) {
            return GetData(profileId, new AnalyticsDataOptions {
                StartDate = startDate,
                EndDate = endDate,
                Metrics = metrics,
                Dimensions = dimensions
            });
        }

        [Obsolete("Use the GetData method in the new Data endpoint. See release notes for v0.9.4 for further information.")]
        public string GetData(AnalyticsProfile profile, AnalyticsDataOptions options) {
            return GetData(profile.Id, options);
        }

        [Obsolete("Use the GetData method in the new Data endpoint. See release notes for v0.9.4 for further information.")]
        public string GetData(string profileId, AnalyticsDataOptions options) {

            // Validate arguments
            if (options == null) throw new ArgumentNullException("options");

            // Generate the name value collection
            NameValueCollection query = options.ToNameValueCollection(profileId, Client.AccessToken);

            // Make the call to the API
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://www.googleapis.com/analytics/v3/data/ga", query);

        }

        #endregion

        #region Realtime data

        /// <summary>
        /// Gets the realtime data from the specified profile and metrics.
        /// </summary>
        /// <param name="profile">The Analytics profile to gather realtime data from.</param>
        /// <param name="metrics">The metrics collection of what data to return.</param>
        [Obsolete("Use the GetRealtimeData method in the new Data endpoint. See release notes for v0.9.4 for further information.")]
        public string GetRealtimeData(AnalyticsProfile profile, AnalyticsMetricCollection metrics) {
            return GetRealtimeData(profile.Id, metrics);
        }
        
        /// <summary>
        /// Gets the realtime data from the specified profile, metrics and dimensions.
        /// </summary>
        /// <param name="profile">The Analytics profile to gather realtime data from.</param>
        /// <param name="metrics">The metrics collection of what data to return.</param>
        /// <param name="dimensions">The dimensions collection of what data to return.</param>
        [Obsolete("Use the GetRealtimeData method in the new Data endpoint. See release notes for v0.9.4 for further information.")]
        public string GetRealtimeData(AnalyticsProfile profile, AnalyticsMetricCollection metrics, AnalyticsDimensionCollection dimensions) {
            return GetRealtimeData(profile.Id, metrics, dimensions);
        }

        /// <summary>
        /// Gets the realtime data from the specified profile and options.
        /// </summary>
        /// <param name="profile">The Analytics profile to gather realtime data from.</param>
        /// <param name="options">The options specifying the query.</param>
        [Obsolete("Use the GetRealtimeData method in the new Data endpoint. See release notes for v0.9.4 for further information.")]
        public string GetRealtimeData(AnalyticsProfile profile, AnalyticsRealtimeDataOptions options) {
            return GetRealtimeData(profile.Id, options);
        }

        /// <summary>
        /// Gets the realtime data from the specified profile and metrics.
        /// </summary>
        /// <param name="profileId">The ID of the Analytics profile.</param>
        /// <param name="metrics">The metrics collection of what data to return.</param>
        [Obsolete("Use the GetRealtimeData method in the new Data endpoint. See release notes for v0.9.4 for further information.")]
        public string GetRealtimeData(string profileId, AnalyticsMetricCollection metrics) {
            return GetRealtimeData(profileId, new AnalyticsRealtimeDataOptions {
                Metrics = metrics
            });
        }

        /// <summary>
        /// Gets the realtime data from the specified profile and metrics.
        /// </summary>
        /// <param name="profileId">The ID of the Analytics profile.</param>
        /// <param name="metrics">The metrics collection of what data to return.</param>
        /// <param name="dimensions">The dimensions collection of what data to return.</param>
        [Obsolete("Use the GetRealtimeData method in the new Data endpoint. See release notes for v0.9.4 for further information.")]
        public string GetRealtimeData(string profileId, AnalyticsMetricCollection metrics, AnalyticsDimensionCollection dimensions) {
            return GetRealtimeData(profileId, new AnalyticsRealtimeDataOptions {
                Metrics = metrics,
                Dimensions = dimensions
            });
        }

        /// <summary>
        /// Gets the realtime data from the specified profile and options.
        /// </summary>
        /// <param name="profileId">The ID of the Analytics profile.</param>
        /// <param name="options">The options specifying the query.</param>
        [Obsolete("Use the GetRealtimeData method in the new Data endpoint. See release notes for v0.9.4 for further information.")]
        public string GetRealtimeData(string profileId, AnalyticsRealtimeDataOptions options) {
            
            // Validate arguments
            if (options == null) throw new ArgumentNullException("options");

            // Generate the name value collection
            NameValueCollection query = options.ToNameValueCollection(profileId, Client.AccessToken);

            // Make the call to the API
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://www.googleapis.com/analytics/v3/data/realtime", query);

        }

        #endregion

    }

}