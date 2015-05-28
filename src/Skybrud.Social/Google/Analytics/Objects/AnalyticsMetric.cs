using System;
using System.Linq;
using System.Reflection;
using Skybrud.Social.Google.Analytics.Interfaces;

namespace Skybrud.Social.Google.Analytics.Objects {

    /// <summary>
    /// Class representing a metric in the Google Analytics API.
    /// </summary>
    public class AnalyticsMetric : IAnalyticsField {

        private const string GroupUser = "User";
        private const string GroupSession = "Session";
        private const string GroupPageTracking = "Page Tracking";

        #region Readonly properties

        // ReSharper disable InconsistentNaming

        #region Users

        /// <summary>
        /// Gets the total number of users for the requested time period (type: integer).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/core/dimsmets#view=detail&amp;group=user&amp;jump=ga_users</cref>
        /// </see>
        public static readonly AnalyticsMetric Users = new AnalyticsMetric("ga:users", GroupUser);

        /// <summary>
        /// Use <code>Users</code> instead.
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/core/dimsmets#view=detail&amp;group=user&amp;jump=ga_visitors</cref>
        /// </see>
        [Obsolete("Use ga:users instead.")]
        public static readonly AnalyticsMetric Visitors = new AnalyticsMetric("ga:visitors", GroupUser, true);

        /// <summary>
        /// Gets the number of users whose session was marked as a first-time session (type: integer).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/core/dimsmets#view=detail&amp;group=user&amp;jump=ga_newusers</cref>
        /// </see>
        public static readonly AnalyticsMetric NewUsers = new AnalyticsMetric("ga:newUsers", GroupUser);

        /// <summary>
        /// Use <code>NewUsers</code> instead.
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/core/dimsmets#view=detail&amp;group=user&amp;jump=ga_newvisits</cref>
        /// </see>
        [Obsolete("Use ga:newUsers instead")]
        public static readonly AnalyticsMetric NewVisits = new AnalyticsMetric("ga:newVisits", GroupUser, true);

        /// <summary>
        /// Gets the percentage of sessions by people who had never visited your property before (type: percent).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/core/dimsmets#view=detail&amp;group=user&amp;jump=ga_percentnewsessions</cref>
        /// </see>
        public static readonly AnalyticsMetric PercentNewSessions = new AnalyticsMetric("ga:percentNewSessions", GroupUser);

        /// <summary>
        /// Use <code>PercentNewSessions</code> instead.
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/core/dimsmets#view=detail&amp;group=user&amp;jump=ga_percentnewvisits</cref>
        /// </see>
        [Obsolete("Use ga:percentNewSessions instead")]
        public static readonly AnalyticsMetric PercentNewVisits = new AnalyticsMetric("ga:percentNewVisits", GroupUser, true);

        /// <summary>
        /// Gets the total number of sessions divided by the total number of users (type: float).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/core/dimsmets#view=detail&amp;group=user&amp;jump=ga_sessionsperuser</cref>
        /// </see>
        public static readonly AnalyticsMetric SessionsPerUser = new AnalyticsMetric("ga:sessionsPerUser", GroupUser);

        #endregion

        #region Session

        /// <summary>
        /// Gets the total number of sessions (type = integer).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/core/dimsmets#view=detail&amp;group=session&amp;jump=ga_sessions</cref>
        /// </see>
        public static readonly AnalyticsMetric Sessions = new AnalyticsMetric("ga:sessions", GroupSession);

        /// <summary>
        /// Use <code>Sessions</code> instead.
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/core/dimsmets#view=detail&amp;group=session&amp;jump=ga_visits</cref>
        /// </see>
        [Obsolete("Use ga:sessions instead.")]
        public static readonly AnalyticsMetric Visits = new AnalyticsMetric("ga:visits", GroupSession, true);

        /// <summary>
        /// Gets the total number of single page (or single engagement hit) sessions for your property (type: integer).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/core/dimsmets#view=detail&amp;group=session&amp;jump=ga_bounces</cref>
        /// </see>
        public static readonly AnalyticsMetric Bounces = new AnalyticsMetric("ga:bounces", GroupSession);

        /// <summary>
        /// Gets the total duration of user sessions represented in total seconds (type: time).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/core/dimsmets#view=detail&amp;group=session&amp;jump=ga_sessionduration</cref>
        /// </see>
        public static readonly AnalyticsMetric SessionDuration = new AnalyticsMetric("ga:sessionDuration", GroupSession);

        /// <summary>
        /// Use <code>SessionDuration</code> instead.
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/core/dimsmets#view=detail&amp;group=session&amp;jump=ga_timeonsite</cref>
        /// </see>
        [Obsolete("Use ga:sessionDuration instead.")]
        public static readonly AnalyticsMetric TimeOnSite = new AnalyticsMetric("ga:timeOnSite", GroupSession, true);

        /// <summary>
        /// Use <code>BounceRate</code> instead.
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/core/dimsmets#view=detail&amp;group=session&amp;jump=ga_entrancebouncerate</cref>
        /// </see>
        [Obsolete("Use ga:bounceRate instead.")]
        public static readonly AnalyticsMetric EntranceBounceRate = new AnalyticsMetric("ga:entranceBounceRate", GroupSession, true);

        /// <summary>
        /// Gets the percentage of single-page session (i.e., session in which the person left your property from the first page) (type: percent).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/core/dimsmets#view=detail&amp;group=session&amp;jump=ga_bouncerate</cref>
        /// </see>
        public static readonly AnalyticsMetric BounceRate = new AnalyticsMetric("ga:bounceRate", GroupSession);

        /// <summary>
        /// Use <code>BounceRate</code> instead.
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/core/dimsmets#view=detail&amp;group=session&amp;jump=ga_visitbouncerate</cref>
        /// </see>
        [Obsolete("Use ga:bounceRate instead.")]
        public static readonly AnalyticsMetric VisitBounceRate = new AnalyticsMetric("ga:visitBounceRate", GroupSession, true);

        /// <summary>
        /// Gets the average duration of user sessions represented in total seconds.
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/core/dimsmets#view=detail&amp;group=session&amp;jump=ga_avgsessionduration</cref>
        /// </see>
        public static readonly AnalyticsMetric AvgSessionDuration = new AnalyticsMetric("ga:avgSessionDuration", GroupSession);

        /// <summary>
        /// Use <code>AvgSessionDuration</code> instead.
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/core/dimsmets#view=detail&amp;group=session&amp;jump=ga_avgtimeonsite</cref>
        /// </see>
        [Obsolete("Use ga:avgSessionDuration instead.")]
        public static readonly AnalyticsMetric AvgTimeOnSite = new AnalyticsMetric("ga:avgTimeOnSite", GroupSession, true);

        #endregion

        #region Traffic Sources

        public static readonly AnalyticsMetric OrganicSearches = new AnalyticsMetric("ga:organicSearches");

        #endregion

        #region AdWords

        public static readonly AnalyticsMetric Impressions = new AnalyticsMetric("ga:impressions");
        public static readonly AnalyticsMetric AdClicks = new AnalyticsMetric("ga:adClicks");
        public static readonly AnalyticsMetric AdCost = new AnalyticsMetric("ga:adCost");
        public static readonly AnalyticsMetric CPM = new AnalyticsMetric("ga:CPM");
        public static readonly AnalyticsMetric CPC = new AnalyticsMetric("ga:CPC");
        public static readonly AnalyticsMetric CTR = new AnalyticsMetric("ga:CTR");
        public static readonly AnalyticsMetric CostPerTransaction = new AnalyticsMetric("ga:costPerTransaction");
        public static readonly AnalyticsMetric CostPerGoalConversion = new AnalyticsMetric("ga:costPerGoalConversion");
        public static readonly AnalyticsMetric CostPerConversion = new AnalyticsMetric("ga:costPerConversion");
        public static readonly AnalyticsMetric RPC = new AnalyticsMetric("ga:RPC");
        public static readonly AnalyticsMetric ROI = new AnalyticsMetric("ga:ROI");
        public static readonly AnalyticsMetric Margin = new AnalyticsMetric("ga:margin");

        #endregion

        #region Goal Conversions

        public static readonly AnalyticsMetric GoalXXStarts = new AnalyticsMetric("ga:goalXXStarts");
        public static readonly AnalyticsMetric GoalStartsAll = new AnalyticsMetric("ga:goalStartsAll");
        public static readonly AnalyticsMetric GoalXXCompletions = new AnalyticsMetric("ga:goalXXCompletions");
        public static readonly AnalyticsMetric GoalCompletionsAll = new AnalyticsMetric("ga:goalCompletionsAll");
        public static readonly AnalyticsMetric GoalXXValue = new AnalyticsMetric("ga:goalXXValue");
        public static readonly AnalyticsMetric GoalValueAll = new AnalyticsMetric("ga:goalValueAll");
        public static readonly AnalyticsMetric GoalValuePerVisit = new AnalyticsMetric("ga:goalValuePerVisit");
        public static readonly AnalyticsMetric GoalXXConversionRate = new AnalyticsMetric("ga:goalXXConversionRate");
        public static readonly AnalyticsMetric GoalConversionRateAll = new AnalyticsMetric("ga:goalConversionRateAll");
        public static readonly AnalyticsMetric GoalXXAbandons = new AnalyticsMetric("ga:goalXXAbandons");
        public static readonly AnalyticsMetric GoalAbandonsAll = new AnalyticsMetric("ga:goalAbandonsAll");
        public static readonly AnalyticsMetric GoalXXAbandonRate = new AnalyticsMetric("ga:goalXXAbandonRate");
        public static readonly AnalyticsMetric GoalAbandonRateAll = new AnalyticsMetric("ga:goalAbandonRateAll");

        #endregion

        #region Social Activities

        public static readonly AnalyticsMetric SocialActivities = new AnalyticsMetric("ga:socialActivities");

        #endregion

        #region Page Tracking

        /// <summary>
        /// Gets the average value of this page or set of pages. Page Value is (ga:transactionRevenue + ga:goalValueAll) / ga:uniquePageviews (for the page or set of pages) (type: currency).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/core/dimsmets#view=detail&amp;group=page_tracking&amp;jump=ga_pagevalue</cref>
        /// </see>
        public static readonly AnalyticsMetric PageValue = new AnalyticsMetric("ga:pageValue", GroupPageTracking);

        /// <summary>
        /// Gets the number of entrances to your property measured as the first pageview in a session. Typically used with landingPagePath (type: integer).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/core/dimsmets#view=detail&amp;group=page_tracking&amp;jump=ga_entrances</cref>
        /// </see>
        public static readonly AnalyticsMetric Entrances = new AnalyticsMetric("ga:entrances", GroupPageTracking);

        /// <summary>
        /// Gets the total number of pageviews for your property (type: integer).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/core/dimsmets#view=detail&amp;group=page_tracking&amp;jump=ga_pageviews</cref>
        /// </see>
        public static readonly AnalyticsMetric Pageviews = new AnalyticsMetric("ga:pageviews", GroupPageTracking);

        /// <summary>
        /// Gets the number of different (unique) pages within a session. This takes into account both the pagePath and pageTitle to determine uniqueness (type: integer).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/core/dimsmets#view=detail&amp;group=page_tracking&amp;jump=ga_uniquepageviews</cref>
        /// </see>
        public static readonly AnalyticsMetric UniquePageviews = new AnalyticsMetric("ga:uniquePageviews", GroupPageTracking);

        /// <summary>
        /// Gets how long a user spent on a particular page in seconds. Calculated by subtracting the initial view time for a particular page from the initial view time for a subsequent page. Thus, this metric does not apply to exit pages for your property (type: time).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/core/dimsmets#view=detail&amp;group=page_tracking&amp;jump=ga_timeonpage</cref>
        /// </see>
        public static readonly AnalyticsMetric TimeOnPage = new AnalyticsMetric("ga:timeOnPage", GroupPageTracking);

        /// <summary>
        /// Gets the number of exits from your property (type: integer).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/core/dimsmets#view=detail&amp;group=page_tracking&amp;jump=ga_exits</cref>
        /// </see>
        public static readonly AnalyticsMetric Exits = new AnalyticsMetric("ga:exits", GroupPageTracking);

        /// <summary>
        /// Gets the percentage of pageviews in which this page was the entrance (type: percent).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/core/dimsmets#view=detail&amp;group=page_tracking&amp;jump=ga_entrancerate</cref>
        /// </see>
        public static readonly AnalyticsMetric EntranceRate = new AnalyticsMetric("ga:entranceRate", GroupPageTracking);

        /// <summary>
        /// Gets the average number of pages viewed during a session, including repeated views of a single page (type: float).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/core/dimsmets#view=detail&amp;group=page_tracking&amp;jump=ga_pageviewspersession</cref>
        /// </see>
        public static readonly AnalyticsMetric PageviewsPerSession = new AnalyticsMetric("ga:pageviewsPerSession", GroupPageTracking);

        /// <summary>
        /// Use <code>PageviewsPerSession</code> instead.
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/core/dimsmets#view=detail&amp;group=page_tracking&amp;jump=ga_pageviewspervisit</cref>
        /// </see>
        [Obsolete("Use ga:pageviewsPerSession instead.")]
        public static readonly AnalyticsMetric PageviewsPerVisit = new AnalyticsMetric("ga:pageviewsPerVisit", GroupPageTracking, true);

        /// <summary>
        /// Gets the average amount of time users spent viewing this page or a set of pages (type: time).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/core/dimsmets#view=detail&amp;group=page_tracking&amp;jump=ga_avgtimeonpage</cref>
        /// </see>
        public static readonly AnalyticsMetric AvgTimeOnPage = new AnalyticsMetric("ga:avgTimeOnPage", GroupPageTracking);

        /// <summary>
        /// Gets the percentage of exits from your property that occurred out of the total page views (type: time).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/core/dimsmets#view=detail&amp;group=page_tracking&amp;jump=ga_exitrate</cref>
        /// </see>
        public static readonly AnalyticsMetric ExitRate = new AnalyticsMetric("ga:exitRate", GroupPageTracking);

        #endregion

        #region Internal Search

        public static readonly AnalyticsMetric SearchResultViews = new AnalyticsMetric("ga:searchResultViews");
        public static readonly AnalyticsMetric SearchUniques = new AnalyticsMetric("ga:searchUniques");
        public static readonly AnalyticsMetric AvgSearchResultViews = new AnalyticsMetric("ga:avgSearchResultViews");
        public static readonly AnalyticsMetric SearchVisits = new AnalyticsMetric("ga:searchVisits");
        public static readonly AnalyticsMetric PercentVisitsWithSearch = new AnalyticsMetric("ga:percentVisitsWithSearch");
        public static readonly AnalyticsMetric SearchDepth = new AnalyticsMetric("ga:searchDepth");
        public static readonly AnalyticsMetric AvgSearchDepth = new AnalyticsMetric("ga:avgSearchDepth");
        public static readonly AnalyticsMetric SearchRefinements = new AnalyticsMetric("ga:searchRefinements");
        public static readonly AnalyticsMetric PercentSearchRefinements = new AnalyticsMetric("ga:percentSearchRefinements");
        public static readonly AnalyticsMetric SearchDuration = new AnalyticsMetric("ga:searchDuration");
        public static readonly AnalyticsMetric AvgSearchDuration = new AnalyticsMetric("ga:avgSearchDuration");
        public static readonly AnalyticsMetric SearchExits = new AnalyticsMetric("ga:searchExits");
        public static readonly AnalyticsMetric SearchExitRate = new AnalyticsMetric("ga:searchExitRate");
        public static readonly AnalyticsMetric SearchGoalXXConversionRate = new AnalyticsMetric("ga:searchGoalXXConversionRate");
        public static readonly AnalyticsMetric SearchGoalConversionRateAll = new AnalyticsMetric("ga:searchGoalConversionRateAll");
        public static readonly AnalyticsMetric GoalValueAllPerSearch = new AnalyticsMetric("ga:goalValueAllPerSearch");

        #endregion

        #region Site Speed

        public static readonly AnalyticsMetric PageLoadTime = new AnalyticsMetric("ga:pageLoadTime");
        public static readonly AnalyticsMetric PageLoadSample = new AnalyticsMetric("ga:pageLoadSample");
        public static readonly AnalyticsMetric AvgPageLoadTime = new AnalyticsMetric("ga:avgPageLoadTime");
        public static readonly AnalyticsMetric DomainLookupTime = new AnalyticsMetric("ga:domainLookupTime");
        public static readonly AnalyticsMetric AvgDomainLookupTime = new AnalyticsMetric("ga:avgDomainLookupTime");
        public static readonly AnalyticsMetric PageDownloadTime = new AnalyticsMetric("ga:pageDownloadTime");
        public static readonly AnalyticsMetric AvgPageDownloadTime = new AnalyticsMetric("ga:avgPageDownloadTime");
        public static readonly AnalyticsMetric RedirectionTime = new AnalyticsMetric("ga:redirectionTime");
        public static readonly AnalyticsMetric AvgRedirectionTime = new AnalyticsMetric("ga:avgRedirectionTime");
        public static readonly AnalyticsMetric ServerConnectionTime = new AnalyticsMetric("ga:serverConnectionTime");
        public static readonly AnalyticsMetric AvgServerConnectionTime = new AnalyticsMetric("ga:avgServerConnectionTime");
        public static readonly AnalyticsMetric ServerResponseTime = new AnalyticsMetric("ga:serverResponseTime");
        public static readonly AnalyticsMetric AvgServerResponseTime = new AnalyticsMetric("ga:avgServerResponseTime");
        public static readonly AnalyticsMetric SpeedMetricsSample = new AnalyticsMetric("ga:speedMetricsSample");
        public static readonly AnalyticsMetric DomInteractiveTime = new AnalyticsMetric("ga:domInteractiveTime");
        public static readonly AnalyticsMetric AvgDomInteractiveTime = new AnalyticsMetric("ga:avgDomInteractiveTime");
        public static readonly AnalyticsMetric DomContentLoadedTime = new AnalyticsMetric("ga:domContentLoadedTime");
        public static readonly AnalyticsMetric AvgDomContentLoadedTime = new AnalyticsMetric("ga:avgDomContentLoadedTime");
        public static readonly AnalyticsMetric DomLatencyMetricsSample = new AnalyticsMetric("ga:domLatencyMetricsSample");

        #endregion

        #region App Tracking

        public static readonly AnalyticsMetric Appviews = new AnalyticsMetric("ga:appviews");
        public static readonly AnalyticsMetric UniqueAppviews = new AnalyticsMetric("ga:uniqueAppviews");
        public static readonly AnalyticsMetric AppviewsPerVisit = new AnalyticsMetric("ga:appviewsPerVisit");
        public static readonly AnalyticsMetric Screenviews = new AnalyticsMetric("ga:screenviews");
        public static readonly AnalyticsMetric UniqueScreenviews = new AnalyticsMetric("ga:uniqueScreenviews");
        public static readonly AnalyticsMetric ScreenviewsPerSession = new AnalyticsMetric("ga:screenviewsPerSession");
        public static readonly AnalyticsMetric TimeOnScreen = new AnalyticsMetric("ga:timeOnScreen");
        public static readonly AnalyticsMetric AvgScreenviewDuration = new AnalyticsMetric("ga:avgScreenviewDuration");

        #endregion

        #region Event Tracking

        public static readonly AnalyticsMetric TotalEvents = new AnalyticsMetric("ga:totalEvents");
        public static readonly AnalyticsMetric UniqueEvents = new AnalyticsMetric("ga:uniqueEvents");
        public static readonly AnalyticsMetric EventValue = new AnalyticsMetric("ga:eventValue");
        public static readonly AnalyticsMetric AvgEventValue = new AnalyticsMetric("ga:avgEventValue");
        public static readonly AnalyticsMetric VisitsWithEvent = new AnalyticsMetric("ga:visitsWithEvent");
        public static readonly AnalyticsMetric EventsPerVisitWithEvent = new AnalyticsMetric("ga:eventsPerVisitWithEvent");

        #endregion

        #region Ecommerce

        public static readonly AnalyticsMetric Transactions = new AnalyticsMetric("ga:transactions");
        public static readonly AnalyticsMetric TransactionsPerVisit = new AnalyticsMetric("ga:transactionsPerVisit");
        public static readonly AnalyticsMetric TransactionRevenue = new AnalyticsMetric("ga:transactionRevenue");
        public static readonly AnalyticsMetric RevenuePerTransaction = new AnalyticsMetric("ga:revenuePerTransaction");
        public static readonly AnalyticsMetric TransactionRevenuePerVisit = new AnalyticsMetric("ga:transactionRevenuePerVisit");
        public static readonly AnalyticsMetric TransactionShipping = new AnalyticsMetric("ga:transactionShipping");
        public static readonly AnalyticsMetric TransactionTax = new AnalyticsMetric("ga:transactionTax");
        public static readonly AnalyticsMetric TotalValue = new AnalyticsMetric("ga:totalValue");
        public static readonly AnalyticsMetric ItemQuantity = new AnalyticsMetric("ga:itemQuantity");
        public static readonly AnalyticsMetric UniquePurchases = new AnalyticsMetric("ga:uniquePurchases");
        public static readonly AnalyticsMetric RevenuePerItem = new AnalyticsMetric("ga:revenuePerItem");
        public static readonly AnalyticsMetric ItemRevenue = new AnalyticsMetric("ga:itemRevenue");
        public static readonly AnalyticsMetric ItemsPerPurchase = new AnalyticsMetric("ga:itemsPerPurchase");
        public static readonly AnalyticsMetric LocalItemRevenue = new AnalyticsMetric("ga:localItemRevenue");
        public static readonly AnalyticsMetric LocalTransactionRevenue = new AnalyticsMetric("ga:localTransactionRevenue");
        public static readonly AnalyticsMetric LocalTransactionTax = new AnalyticsMetric("ga:localTransactionTax");
        public static readonly AnalyticsMetric LocalTransactionShipping = new AnalyticsMetric("ga:localTransactionShipping");

        #endregion

        #region Social Interactions

        public static readonly AnalyticsMetric SocialInteractions = new AnalyticsMetric("ga:socialInteractions");
        public static readonly AnalyticsMetric UniqueSocialInteractions = new AnalyticsMetric("ga:uniqueSocialInteractions");
        public static readonly AnalyticsMetric SocialInteractionsPerVisit = new AnalyticsMetric("ga:socialInteractionsPerVisit");

        #endregion

        #region User Timings

        public static readonly AnalyticsMetric UserTimingValue = new AnalyticsMetric("ga:userTimingValue");
        public static readonly AnalyticsMetric UserTimingSample = new AnalyticsMetric("ga:userTimingSample");
        public static readonly AnalyticsMetric AvgUserTimingValue = new AnalyticsMetric("ga:avgUserTimingValue");

        #endregion

        #region Exception Tracking

        public static readonly AnalyticsMetric Exceptions = new AnalyticsMetric("ga:exceptions");
        public static readonly AnalyticsMetric ExceptionsPerScreenview = new AnalyticsMetric("ga:exceptionsPerScreenview");
        public static readonly AnalyticsMetric FatalExceptions = new AnalyticsMetric("ga:fatalExceptions");
        public static readonly AnalyticsMetric FatalExceptionsPerScreenview = new AnalyticsMetric("ga:fatalExceptionsPerScreenview");

        #endregion

        #region Custom Variables or Columns

        public static readonly AnalyticsMetric MetricXX = new AnalyticsMetric("ga:metricXX");

        #endregion

        #region Realtime

        public static readonly AnalyticsMetric ActiveVisitors = new AnalyticsMetric("ga:activeVisitors");

        #endregion

        // ReSharper restore InconsistentNaming

        #endregion

        #region Static properties

        /// <summary>
        /// Gets an array of all metrics.
        /// </summary>
        public static AnalyticsMetric[] Values {
            get {
                return (
                    from property in typeof(AnalyticsMetric).GetFields(BindingFlags.Public | BindingFlags.Static)
                    select (AnalyticsMetric)property.GetValue(null)
                ).ToArray();
            }
        }

        #endregion

        #region Member properties

        /// <summary>
        /// Gets the name of the metric.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the name of the group of the metric.
        /// </summary>
        public string GroupName { get; private set; }

        /// <summary>
        /// Gets whether the metric is obsolete.
        /// </summary>
        public bool IsObsolete { get; private set; }

        #endregion

        #region Constructor

        private AnalyticsMetric(string name) {
            Name = name;
        }

        private AnalyticsMetric(string name, string groupName) {
            Name = name;
            GroupName = groupName;
        }

        private AnalyticsMetric(string name, string groupName, bool obsolete) {
            Name = name;
            GroupName = groupName;
            IsObsolete = obsolete;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets the name of the metric (eg. "ga:visits").
        /// </summary>
        public override string ToString() {
            return Name;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Attempts to parse the specified string as a metric. The parsing is done against a list
        /// of known metrics. If the parsing fails, an exception will be thrown.
        /// </summary>
        /// <param name="str">The string to parse.</param>
        public static AnalyticsMetric Parse(string str) {
            AnalyticsMetric metric;
            if (TryParse(str, out metric)) return metric;
            throw new Exception("Invalid metric '" + str + "'");
        }

        /// <summary>
        /// Attempts to parse the specified string as a metric. The parsing is done against a list
        /// of known metrics. The method will return TRUE if the parsing succeeds, otherwise FALSE.
        /// </summary>
        /// <param name="str">The string to parse.</param>
        /// <param name="metric">The parsed metric.</param>
        public static bool TryParse(string str, out AnalyticsMetric metric) {
            metric = Values.FirstOrDefault(temp => temp.Name == str);
            return metric != null;
        }

        #endregion

        #region Operator overloading

        /// <summary>
        /// Gets a reference to the metric with the specified <code>name</code>. If an unknown
        /// metric is specified, a new instance of <code>AnalyticsMetric</code> will be initialized.
        /// </summary>
        /// <param name="name">The name of the metric.</param>
        public static implicit operator AnalyticsMetric(string name) {
            AnalyticsMetric metric;
            return TryParse(name, out metric) ? metric : new AnalyticsMetric(name);
        }

        /// <summary>
        /// Initializes a new instance of <code>AnalyticsMetricCollection</code> containing both <code>left</code> and <code>right</code>.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        public static AnalyticsMetricCollection operator +(AnalyticsMetric left, AnalyticsMetric right) {
            return new AnalyticsMetricCollection(left, right);
        }

        #endregion

    }

}