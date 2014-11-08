using System;
using Skybrud.Social.Google.Analytics.Objects;
using Skybrud.Social.Google.Analytics.Responses;

namespace Skybrud.Social.Google.Analytics {

    public class AnalyticsEndpoint {

        /// <summary>
        /// Gets the parent service of this endpoint.
        /// </summary>
        public GoogleService Service { get; private set; }

        public AnalyticsRawEndpoint Raw {
            get { return Service.Client.Analytics; }
        }

        internal AnalyticsEndpoint(GoogleService service) {
            Service = service;
        }

        #region Accounts

        /// <summary>
        /// Gets a list of all accounts the user has access to.
        /// </summary>
        /// <returns></returns>
        public AnalyticsAccountsResponse GetAccounts() {
            return AnalyticsAccountsResponse.ParseJson(Service.Client.Analytics.GetAccounts());
        }

        #endregion

        #region Web properties

        /// <summary>
        /// Gets a list of all web properties accross all accounts. 
        /// </summary>
        /// <param name="maxResults">The maximum number of results per page (default is 1000).</param>
        /// <param name="startIndex">The start index (default is 1).</param>
        public AnalyticsWebPropertiesResponse GetWebProperties(int maxResults = 0, int startIndex = 0) {
            return AnalyticsWebPropertiesResponse.ParseJson(Service.Client.Analytics.GetWebProperties(maxResults, startIndex));
        }

        /// <summary>
        /// Get a list of all web propeties of the specified account.
        /// </summary>
        /// <param name="account">The parent account.</param>
        /// <param name="maxResults">The maximum number of results per page (default is 1000).</param>
        /// <param name="startIndex">The start index (default is 1).</param>
        public AnalyticsWebPropertiesResponse GetWebProperties(AnalyticsAccount account, int maxResults = 0, int startIndex = 0) {
            return AnalyticsWebPropertiesResponse.ParseJson(Service.Client.Analytics.GetWebProperties(account.Id, maxResults, startIndex));
        }

        /// <summary>
        /// Gets a list of all web properties of the specified account.
        /// </summary>
        /// <param name="accountId">The ID of the parent account.</param>
        /// <param name="maxResults">The maximum number of results per page (default is 1000).</param>
        /// <param name="startIndex">The start index (default is 1).</param>
        public AnalyticsWebPropertiesResponse GetWebProperties(string accountId, int maxResults = 0, int startIndex = 0) {
            return AnalyticsWebPropertiesResponse.ParseJson(Service.Client.Analytics.GetWebProperties(accountId, maxResults, startIndex));
        }

        #endregion

        #region Profiles

        /// <summary>
        /// Gets a view (profile) to which the user has access.
        /// </summary>
        /// <param name="accountId">Account ID to retrieve the goal for.</param>
        /// <param name="webPropertyId">Web property ID to retrieve the goal for.</param>
        /// <param name="profileId">View (Profile) ID to retrieve the goal for.</param>
        public AnalyticsProfile GetProfile(string accountId, string webPropertyId, string profileId) {
            return AnalyticsProfile.ParseJson(Raw.GetProfile(accountId, webPropertyId, profileId));
        }

        /// <summary>
        /// Gets a list of all profiles the user has access to.
        /// </summary>
        /// <param name="maxResults">The maximum number of views (profiles) to include in this response.</param>
        /// <param name="startIndex">An index of the first entity to retrieve. Use this parameter as a pagination mechanism along with the max-results parameter.</param>
        public AnalyticsProfilesResponse GetProfiles(int maxResults = 0, int startIndex = 0) {
            return AnalyticsProfilesResponse.ParseJson(Service.Client.Analytics.GetProfiles("~all", "~all", maxResults, startIndex));
        }

        /// <summary>
        /// Gets a list of all profiles for the specified account. The result will profiles of all web properties of the account.
        /// </summary>
        /// <param name="account">The parent account.</param>
        /// <param name="maxResults">The maximum number of views (profiles) to include in this response.</param>
        /// <param name="startIndex">An index of the first entity to retrieve. Use this parameter as a pagination mechanism along with the max-results parameter.</param>
        public AnalyticsProfilesResponse GetProfiles(AnalyticsAccount account, int maxResults = 0, int startIndex = 0) {
            return AnalyticsProfilesResponse.ParseJson(Service.Client.Analytics.GetProfiles(account.Id, "~all", maxResults, startIndex));
        }

        /// <summary>
        /// Gets a list of profiles for the specified web property.
        /// </summary>
        /// <param name="property">The parent web propaerty.</param>
        /// <param name="maxResults">The maximum number of views (profiles) to include in this response.</param>
        /// <param name="startIndex">An index of the first entity to retrieve. Use this parameter as a pagination mechanism along with the max-results parameter.</param>
        public AnalyticsProfilesResponse GetProfiles(AnalyticsWebProperty property, int maxResults = 0, int startIndex = 0) {
            return AnalyticsProfilesResponse.ParseJson(Service.Client.Analytics.GetProfiles(property.AccountId, property.Id, maxResults, startIndex));
        }

        /// <summary>
        /// Gets a list of profiles for the specified account.
        /// </summary>
        /// <param name="accountId">Account ID for the view (profiles) to retrieve. Can either be a specific account ID or '~all', which refers to all the accounts to which the user has access.</param>
        /// <param name="maxResults">The maximum number of views (profiles) to include in this response.</param>
        /// <param name="startIndex">An index of the first entity to retrieve. Use this parameter as a pagination mechanism along with the max-results parameter.</param>
        public AnalyticsProfilesResponse GetProfiles(string accountId, int maxResults = 0, int startIndex = 0) {
            return AnalyticsProfilesResponse.ParseJson(Service.Client.Analytics.GetProfiles(accountId, "~all", maxResults, startIndex));
        }

        /// <summary>
        /// Gets a list of profiles for the specified account and web property.
        /// </summary>
        /// <param name="accountId">Account ID for the view (profiles) to retrieve. Can either be a specific account ID or '~all', which refers to all the accounts to which the user has access.</param>
        /// <param name="webPropertyId">Web property ID for the views (profiles) to retrieve. Can either be a specific web property ID or '~all', which refers to all the web properties to which the user has access.</param>
        /// <param name="maxResults">The maximum number of views (profiles) to include in this response.</param>
        /// <param name="startIndex">An index of the first entity to retrieve. Use this parameter as a pagination mechanism along with the max-results parameter.</param>
        public AnalyticsProfilesResponse GetProfiles(string accountId, string webPropertyId, int maxResults = 0, int startIndex = 0) {
            return AnalyticsProfilesResponse.ParseJson(Service.Client.Analytics.GetProfiles(accountId, webPropertyId, maxResults, startIndex));
        }

        #endregion

        #region Data

        public AnalyticsDataResponse GetData(AnalyticsProfile profile, DateTime startDate, DateTime endDate, string[] metrics, string[] dimensions) {
            return AnalyticsDataResponse.ParseJson(Raw.GetData(profile, startDate, endDate, metrics, dimensions));
        }

        public AnalyticsDataResponse GetData(string profileId, DateTime startDate, DateTime endDate, string[] metrics, string[] dimensions) {
            return AnalyticsDataResponse.ParseJson(Raw.GetData(profileId, startDate, endDate, metrics, dimensions));
        }

        public AnalyticsDataResponse GetData(AnalyticsProfile profile, DateTime startDate, DateTime endDate, AnalyticsMetricCollection metrics, AnalyticsDimensionCollection dimensions) {
            return AnalyticsDataResponse.ParseJson(Raw.GetData(profile, startDate, endDate, metrics, dimensions));
        }

        public AnalyticsDataResponse GetData(string profileId, DateTime startDate, DateTime endDate, AnalyticsMetricCollection metrics, AnalyticsDimensionCollection dimensions) {
            return AnalyticsDataResponse.ParseJson(Raw.GetData(profileId, startDate, endDate, metrics, dimensions));
        }

        public AnalyticsDataResponse GetData(AnalyticsProfile profile, AnalyticsDataOptions options) {
            return AnalyticsDataResponse.ParseJson(Raw.GetData(profile.Id, options));
        }

        public AnalyticsDataResponse GetData(string profileId, AnalyticsDataOptions options) {
            return AnalyticsDataResponse.ParseJson(Raw.GetData(profileId, options));
        }

        #endregion

        #region Realtime data

        /// <summary>
        /// Gets the realtime data from the specified profile and metrics.
        /// </summary>
        /// <param name="profile">The Analytics profile to gather realtime data from.</param>
        /// <param name="metrics">The metrics collection of what data to return.</param>
        public AnalyticsRealtimeDataResponse GetRealtimeData(AnalyticsProfile profile, AnalyticsMetricCollection metrics) {
            return GetRealtimeData(profile.Id, metrics);
        }

        /// <summary>
        /// Gets the realtime data from the specified profile, metrics and dimensions.
        /// </summary>
        /// <param name="profile">The Analytics profile to gather realtime data from.</param>
        /// <param name="metrics">The metrics collection of what data to return.</param>
        /// <param name="dimensions">The dimensions collection of what data to return.</param>
        public AnalyticsRealtimeDataResponse GetRealtimeData(AnalyticsProfile profile, AnalyticsMetricCollection metrics, AnalyticsDimensionCollection dimensions) {
            return GetRealtimeData(profile.Id, metrics, dimensions);
        }

        /// <summary>
        /// Gets realtime data for the specified profile and options.
        /// </summary>
        /// <param name="profile">The Analytics profile to gather realtime data from.</param>
        /// <param name="options">The options specifying the query.</param>
        public AnalyticsRealtimeDataResponse GetRealtimeData(AnalyticsProfile profile, AnalyticsRealtimeDataOptions options) {
            return AnalyticsRealtimeDataResponse.ParseJson(Raw.GetRealtimeData(profile.Id, options));
        }

        /// <summary>
        /// Gets the realtime data from the specified profile and metrics.
        /// </summary>
        /// <param name="profileId">The ID of the Analytics profile.</param>
        /// <param name="metrics">The metrics collection of what data to return.</param>
        public AnalyticsRealtimeDataResponse GetRealtimeData(string profileId, AnalyticsMetricCollection metrics) {
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
        public AnalyticsRealtimeDataResponse GetRealtimeData(string profileId, AnalyticsMetricCollection metrics, AnalyticsDimensionCollection dimensions) {
            return GetRealtimeData(profileId, new AnalyticsRealtimeDataOptions {
                Metrics = metrics,
                Dimensions = dimensions
            });
        }

        /// <summary>
        /// Gets realtime data for the specified profile and options.
        /// </summary>
        /// <param name="profileId">The ID of the Analytics profile.</param>
        /// <param name="options">The options specifying the query.</param>
        public AnalyticsRealtimeDataResponse GetRealtimeData(string profileId, AnalyticsRealtimeDataOptions options) {
            return AnalyticsRealtimeDataResponse.ParseJson(Raw.GetRealtimeData(profileId, options));
        }

        #endregion

    }

}
