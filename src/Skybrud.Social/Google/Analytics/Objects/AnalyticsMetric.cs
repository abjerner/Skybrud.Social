using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Skybrud.Social.Google.Analytics.Interfaces;

namespace Skybrud.Social.Google.Analytics.Objects {

    public class AnalyticsMetric : IAnalyticsField {

        #region Readonly properties
        // ReSharper disable InconsistentNaming
        #region Visitor

        public static readonly AnalyticsMetric Visitors = new AnalyticsMetric("ga:visitors");
        public static readonly AnalyticsMetric NewVisits = new AnalyticsMetric("ga:newVisits");
        public static readonly AnalyticsMetric PercentNewVisits = new AnalyticsMetric("ga:percentNewVisits");

        #endregion

        #region Session

        public static readonly AnalyticsMetric Visits = new AnalyticsMetric("ga:visits");
        public static readonly AnalyticsMetric Bounces = new AnalyticsMetric("ga:bounces");
        public static readonly AnalyticsMetric EntranceBounceRate = new AnalyticsMetric("ga:entranceBounceRate");
        public static readonly AnalyticsMetric VisitBounceRate = new AnalyticsMetric("ga:visitBounceRate");
        public static readonly AnalyticsMetric TimeOnSite = new AnalyticsMetric("ga:timeOnSite");
        public static readonly AnalyticsMetric AvgTimeOnSite = new AnalyticsMetric("ga:avgTimeOnSite");

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

        public static readonly AnalyticsMetric Entrances = new AnalyticsMetric("ga:entrances");
        public static readonly AnalyticsMetric EntranceRate = new AnalyticsMetric("ga:entranceRate");
        public static readonly AnalyticsMetric Pageviews = new AnalyticsMetric("ga:pageviews");
        public static readonly AnalyticsMetric PageviewsPerVisit = new AnalyticsMetric("ga:pageviewsPerVisit");
        public static readonly AnalyticsMetric UniquePageviews = new AnalyticsMetric("ga:uniquePageviews");
        public static readonly AnalyticsMetric PageValue = new AnalyticsMetric("ga:pageValue");
        public static readonly AnalyticsMetric TimeOnPage = new AnalyticsMetric("ga:timeOnPage");
        public static readonly AnalyticsMetric AvgTimeOnPage = new AnalyticsMetric("ga:avgTimeOnPage");
        public static readonly AnalyticsMetric Exits = new AnalyticsMetric("ga:exits");
        public static readonly AnalyticsMetric ExitRate = new AnalyticsMetric("ga:exitRate");

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

        public static AnalyticsMetric[] Values {
            get {
                return (
                    from property in typeof(AnalyticsMetric).GetFields(BindingFlags.Public | BindingFlags.Static)
                    select (AnalyticsMetric) property.GetValue(null)
                ).ToArray();
            }
        }

        #endregion

        #region Member properties

        /// <summary>
        /// The name of the dimension.
        /// </summary>
        public string Name { get; private set; }

        #endregion

        #region Constructor

        private AnalyticsMetric(string name) {
            Name = name;
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

        public static implicit operator AnalyticsMetric(string name) {
            return Parse(name);
        }

        public static AnalyticsMetricCollection operator +(AnalyticsMetric left, AnalyticsMetric right) {
            return new AnalyticsMetricCollection(left, right);
        }

        #endregion

    }

}
