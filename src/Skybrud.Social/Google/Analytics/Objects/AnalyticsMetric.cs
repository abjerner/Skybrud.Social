using Skybrud.Social.Google.Analytics.Interfaces;

namespace Skybrud.Social.Google.Analytics.Objects {

    public class AnalyticsMetric : IAnalyticsField {

        #region Readonly properties

        #region Visitor

        public static readonly AnalyticsMetric Visitors = "ga:visitors";
        public static readonly AnalyticsMetric NewVisits = "ga:newVisits";
        public static readonly AnalyticsMetric PercentNewVisits = "ga:percentNewVisits";

        #endregion

        #region Session

        public static readonly AnalyticsMetric Visits = "ga:visits";
        public static readonly AnalyticsMetric Bounces = "ga:bounces";
        public static readonly AnalyticsMetric EntranceBounceRate = "ga:entranceBounceRate";
        public static readonly AnalyticsMetric VisitBounceRate = "ga:visitBounceRate";
        public static readonly AnalyticsMetric TimeOnSite = "ga:timeOnSite";
        public static readonly AnalyticsMetric AvgTimeOnSite = "ga:avgTimeOnSite";

        #endregion

        #region Traffic Sources

        public static readonly AnalyticsMetric OrganicSearches = "ga:organicSearches";

        #endregion

        #region AdWords

        public static readonly AnalyticsMetric Impressions = "ga:impressions";
        public static readonly AnalyticsMetric AdClicks = "ga:adClicks";
        public static readonly AnalyticsMetric AdCost = "ga:adCost";
        public static readonly AnalyticsMetric CPM = "ga:CPM";
        public static readonly AnalyticsMetric CPC = "ga:CPC";
        public static readonly AnalyticsMetric CTR = "ga:CTR";
        public static readonly AnalyticsMetric CostPerTransaction = "ga:costPerTransaction";
        public static readonly AnalyticsMetric CostPerGoalConversion = "ga:costPerGoalConversion";
        public static readonly AnalyticsMetric CostPerConversion = "ga:costPerConversion";
        public static readonly AnalyticsMetric RPC = "ga:RPC";
        public static readonly AnalyticsMetric ROI = "ga:ROI";
        public static readonly AnalyticsMetric Margin = "ga:margin";

        #endregion

        #region Goal Conversions

        public static readonly AnalyticsMetric GoalXXStarts = "ga:goalXXStarts";
        public static readonly AnalyticsMetric GoalStartsAll = "ga:goalStartsAll";
        public static readonly AnalyticsMetric GoalXXCompletions = "ga:goalXXCompletions";
        public static readonly AnalyticsMetric GoalCompletionsAll = "ga:goalCompletionsAll";
        public static readonly AnalyticsMetric GoalXXValue = "ga:goalXXValue";
        public static readonly AnalyticsMetric GoalValueAll = "ga:goalValueAll";
        public static readonly AnalyticsMetric GoalValuePerVisit = "ga:goalValuePerVisit";
        public static readonly AnalyticsMetric GoalXXConversionRate = "ga:goalXXConversionRate";
        public static readonly AnalyticsMetric GoalConversionRateAll = "ga:goalConversionRateAll";
        public static readonly AnalyticsMetric GoalXXAbandons = "ga:goalXXAbandons";
        public static readonly AnalyticsMetric GoalAbandonsAll = "ga:goalAbandonsAll";
        public static readonly AnalyticsMetric GoalXXAbandonRate = "ga:goalXXAbandonRate";
        public static readonly AnalyticsMetric GoalAbandonRateAll = "ga:goalAbandonRateAll";

        #endregion

        #region Platform / Device


        #endregion

        #region Geo / Network


        #endregion

        #region System


        #endregion

        #region Social Activities

        public static readonly AnalyticsMetric SocialActivities = "ga:socialActivities";

        #endregion

        #region Page Tracking

        public static readonly AnalyticsMetric Entrances = "ga:entrances";
        public static readonly AnalyticsMetric EntranceRate = "ga:entranceRate";
        public static readonly AnalyticsMetric Pageviews = "ga:pageviews";
        public static readonly AnalyticsMetric PageviewsPerVisit = "ga:pageviewsPerVisit";
        public static readonly AnalyticsMetric UniquePageviews = "ga:uniquePageviews";
        public static readonly AnalyticsMetric PageValue = "ga:pageValue";
        public static readonly AnalyticsMetric TimeOnPage = "ga:timeOnPage";
        public static readonly AnalyticsMetric AvgTimeOnPage = "ga:avgTimeOnPage";
        public static readonly AnalyticsMetric Exits = "ga:exits";
        public static readonly AnalyticsMetric ExitRate = "ga:exitRate";

        #endregion

        #region Internal Search

        public static readonly AnalyticsMetric SearchResultViews = "ga:searchResultViews";
        public static readonly AnalyticsMetric SearchUniques = "ga:searchUniques";
        public static readonly AnalyticsMetric AvgSearchResultViews = "ga:avgSearchResultViews";
        public static readonly AnalyticsMetric SearchVisits = "ga:searchVisits";
        public static readonly AnalyticsMetric PercentVisitsWithSearch = "ga:percentVisitsWithSearch";
        public static readonly AnalyticsMetric SearchDepth = "ga:searchDepth";
        public static readonly AnalyticsMetric AvgSearchDepth = "ga:avgSearchDepth";
        public static readonly AnalyticsMetric SearchRefinements = "ga:searchRefinements";
        public static readonly AnalyticsMetric PercentSearchRefinements = "ga:percentSearchRefinements";
        public static readonly AnalyticsMetric SearchDuration = "ga:searchDuration";
        public static readonly AnalyticsMetric AvgSearchDuration = "ga:avgSearchDuration";
        public static readonly AnalyticsMetric SearchExits = "ga:searchExits";
        public static readonly AnalyticsMetric SearchExitRate = "ga:searchExitRate";
        public static readonly AnalyticsMetric SearchGoalXXConversionRate = "ga:searchGoalXXConversionRate";
        public static readonly AnalyticsMetric SearchGoalConversionRateAll = "ga:searchGoalConversionRateAll";
        public static readonly AnalyticsMetric GoalValueAllPerSearch = "ga:goalValueAllPerSearch";

        #endregion

        #region Site Speed

        public static readonly AnalyticsMetric PageLoadTime = "ga:pageLoadTime";
        public static readonly AnalyticsMetric PageLoadSample = "ga:pageLoadSample";
        public static readonly AnalyticsMetric AvgPageLoadTime = "ga:avgPageLoadTime";
        public static readonly AnalyticsMetric DomainLookupTime = "ga:domainLookupTime";
        public static readonly AnalyticsMetric AvgDomainLookupTime = "ga:avgDomainLookupTime";
        public static readonly AnalyticsMetric PageDownloadTime = "ga:pageDownloadTime";
        public static readonly AnalyticsMetric AvgPageDownloadTime = "ga:avgPageDownloadTime";
        public static readonly AnalyticsMetric RedirectionTime = "ga:redirectionTime";
        public static readonly AnalyticsMetric AvgRedirectionTime = "ga:avgRedirectionTime";
        public static readonly AnalyticsMetric ServerConnectionTime = "ga:serverConnectionTime";
        public static readonly AnalyticsMetric AvgServerConnectionTime = "ga:avgServerConnectionTime";
        public static readonly AnalyticsMetric ServerResponseTime = "ga:serverResponseTime";
        public static readonly AnalyticsMetric AvgServerResponseTime = "ga:avgServerResponseTime";
        public static readonly AnalyticsMetric SpeedMetricsSample = "ga:speedMetricsSample";
        public static readonly AnalyticsMetric DomInteractiveTime = "ga:domInteractiveTime";
        public static readonly AnalyticsMetric AvgDomInteractiveTime = "ga:avgDomInteractiveTime";
        public static readonly AnalyticsMetric DomContentLoadedTime = "ga:domContentLoadedTime";
        public static readonly AnalyticsMetric AvgDomContentLoadedTime = "ga:avgDomContentLoadedTime";
        public static readonly AnalyticsMetric DomLatencyMetricsSample = "ga:domLatencyMetricsSample";

        #endregion

        #region App Tracking

        public static readonly AnalyticsMetric Appviews = "ga:appviews";
        public static readonly AnalyticsMetric UniqueAppviews = "ga:uniqueAppviews";
        public static readonly AnalyticsMetric AppviewsPerVisit = "ga:appviewsPerVisit";
        public static readonly AnalyticsMetric Screenviews = "ga:screenviews";
        public static readonly AnalyticsMetric UniqueScreenviews = "ga:uniqueScreenviews";
        public static readonly AnalyticsMetric ScreenviewsPerSession = "ga:screenviewsPerSession";
        public static readonly AnalyticsMetric TimeOnScreen = "ga:timeOnScreen";
        public static readonly AnalyticsMetric AvgScreenviewDuration = "ga:avgScreenviewDuration";

        #endregion

        #region Event Tracking

        public static readonly AnalyticsMetric TotalEvents = "ga:totalEvents";
        public static readonly AnalyticsMetric UniqueEvents = "ga:uniqueEvents";
        public static readonly AnalyticsMetric EventValue = "ga:eventValue";
        public static readonly AnalyticsMetric AvgEventValue = "ga:avgEventValue";
        public static readonly AnalyticsMetric VisitsWithEvent = "ga:visitsWithEvent";
        public static readonly AnalyticsMetric EventsPerVisitWithEvent = "ga:eventsPerVisitWithEvent";

        #endregion

        #region Ecommerce

        public static readonly AnalyticsMetric Transactions = "ga:transactions";
        public static readonly AnalyticsMetric TransactionsPerVisit = "ga:transactionsPerVisit";
        public static readonly AnalyticsMetric TransactionRevenue = "ga:transactionRevenue";
        public static readonly AnalyticsMetric RevenuePerTransaction = "ga:revenuePerTransaction";
        public static readonly AnalyticsMetric TransactionRevenuePerVisit = "ga:transactionRevenuePerVisit";
        public static readonly AnalyticsMetric TransactionShipping = "ga:transactionShipping";
        public static readonly AnalyticsMetric TransactionTax = "ga:transactionTax";
        public static readonly AnalyticsMetric TotalValue = "ga:totalValue";
        public static readonly AnalyticsMetric ItemQuantity = "ga:itemQuantity";
        public static readonly AnalyticsMetric UniquePurchases = "ga:uniquePurchases";
        public static readonly AnalyticsMetric RevenuePerItem = "ga:revenuePerItem";
        public static readonly AnalyticsMetric ItemRevenue = "ga:itemRevenue";
        public static readonly AnalyticsMetric ItemsPerPurchase = "ga:itemsPerPurchase";
        public static readonly AnalyticsMetric LocalItemRevenue = "ga:localItemRevenue";
        public static readonly AnalyticsMetric LocalTransactionRevenue = "ga:localTransactionRevenue";
        public static readonly AnalyticsMetric LocalTransactionTax = "ga:localTransactionTax";
        public static readonly AnalyticsMetric LocalTransactionShipping = "ga:localTransactionShipping";

        #endregion

        #region Social Interactions

        public static readonly AnalyticsMetric SocialInteractions = "ga:socialInteractions";
        public static readonly AnalyticsMetric UniqueSocialInteractions = "ga:uniqueSocialInteractions";
        public static readonly AnalyticsMetric SocialInteractionsPerVisit = "ga:socialInteractionsPerVisit";

        #endregion

        #region User Timings

        public static readonly AnalyticsMetric UserTimingValue = "ga:userTimingValue";
        public static readonly AnalyticsMetric UserTimingSample = "ga:userTimingSample";
        public static readonly AnalyticsMetric AvgUserTimingValue = "ga:avgUserTimingValue";

        #endregion

        #region Exception Tracking

        public static readonly AnalyticsMetric Exceptions = "ga:exceptions";
        public static readonly AnalyticsMetric ExceptionsPerScreenview = "ga:exceptionsPerScreenview";
        public static readonly AnalyticsMetric FatalExceptions = "ga:fatalExceptions";
        public static readonly AnalyticsMetric FatalExceptionsPerScreenview = "ga:fatalExceptionsPerScreenview";

        #endregion

        #region Experiments


        #endregion

        #region Custom Variables or Columns

        public static readonly AnalyticsMetric MetricXX = "ga:metricXX";

        #endregion

        #region Time


        #endregion

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

        #region Operator overloading

        public static implicit operator AnalyticsMetric(string name) {
            return new AnalyticsMetric(name);
        }

        #endregion

    }

}
