using System;

namespace Skybrud.Social.Google.Analytics.Objects {
    
    [Obsolete("Use class AnalyticsMetric instead")]
    public class AnalyticsMetrics {

        #region Visitor

        public static readonly string Visitors = "ga:visitors";
        public static readonly string NewVisits = "ga:newVisits";
        public static readonly string PercentNewVisits = "ga:percentNewVisits";

        #endregion

        #region Session

        public static readonly string Visits = "ga:visits";
        public static readonly string Bounces = "ga:bounces";
        public static readonly string EntranceBounceRate = "ga:entranceBounceRate";
        public static readonly string VisitBounceRate = "ga:visitBounceRate";
        public static readonly string TimeOnSite = "ga:timeOnSite";
        public static readonly string AvgTimeOnSite = "ga:avgTimeOnSite";

        #endregion

        #region Traffic Sources

        public static readonly string OrganicSearches = "ga:organicSearches";

        #endregion

        #region AdWords

        public static readonly string Impressions = "ga:impressions";
        public static readonly string AdClicks = "ga:adClicks";
        public static readonly string AdCost = "ga:adCost";
        public static readonly string CPM = "ga:CPM";
        public static readonly string CPC = "ga:CPC";
        public static readonly string CTR = "ga:CTR";
        public static readonly string CostPerTransaction = "ga:costPerTransaction";
        public static readonly string CostPerGoalConversion = "ga:costPerGoalConversion";
        public static readonly string CostPerConversion = "ga:costPerConversion";
        public static readonly string RPC = "ga:RPC";
        public static readonly string ROI = "ga:ROI";
        public static readonly string Margin = "ga:margin";

        #endregion

        #region Goal Conversions

        public static readonly string GoalXXStarts = "ga:goalXXStarts";
        public static readonly string GoalStartsAll = "ga:goalStartsAll";
        public static readonly string GoalXXCompletions = "ga:goalXXCompletions";
        public static readonly string GoalCompletionsAll = "ga:goalCompletionsAll";
        public static readonly string GoalXXValue = "ga:goalXXValue";
        public static readonly string GoalValueAll = "ga:goalValueAll";
        public static readonly string GoalValuePerVisit = "ga:goalValuePerVisit";
        public static readonly string GoalXXConversionRate = "ga:goalXXConversionRate";
        public static readonly string GoalConversionRateAll = "ga:goalConversionRateAll";
        public static readonly string GoalXXAbandons = "ga:goalXXAbandons";
        public static readonly string GoalAbandonsAll = "ga:goalAbandonsAll";
        public static readonly string GoalXXAbandonRate = "ga:goalXXAbandonRate";
        public static readonly string GoalAbandonRateAll = "ga:goalAbandonRateAll";

        #endregion

        #region Platform / Device


        #endregion

        #region Geo / Network


        #endregion

        #region System


        #endregion

        #region Social Activities

        public static readonly string SocialActivities = "ga:socialActivities";

        #endregion

        #region Page Tracking

        public static readonly string Entrances = "ga:entrances";
        public static readonly string EntranceRate = "ga:entranceRate";
        public static readonly string Pageviews = "ga:pageviews";
        public static readonly string PageviewsPerVisit = "ga:pageviewsPerVisit";
        public static readonly string UniquePageviews = "ga:uniquePageviews";
        public static readonly string PageValue = "ga:pageValue";
        public static readonly string TimeOnPage = "ga:timeOnPage";
        public static readonly string AvgTimeOnPage = "ga:avgTimeOnPage";
        public static readonly string Exits = "ga:exits";
        public static readonly string ExitRate = "ga:exitRate";

        #endregion

        #region Internal Search

        public static readonly string SearchResultViews = "ga:searchResultViews";
        public static readonly string SearchUniques = "ga:searchUniques";
        public static readonly string AvgSearchResultViews = "ga:avgSearchResultViews";
        public static readonly string SearchVisits = "ga:searchVisits";
        public static readonly string PercentVisitsWithSearch = "ga:percentVisitsWithSearch";
        public static readonly string SearchDepth = "ga:searchDepth";
        public static readonly string AvgSearchDepth = "ga:avgSearchDepth";
        public static readonly string SearchRefinements = "ga:searchRefinements";
        public static readonly string PercentSearchRefinements = "ga:percentSearchRefinements";
        public static readonly string SearchDuration = "ga:searchDuration";
        public static readonly string AvgSearchDuration = "ga:avgSearchDuration";
        public static readonly string SearchExits = "ga:searchExits";
        public static readonly string SearchExitRate = "ga:searchExitRate";
        public static readonly string SearchGoalXXConversionRate = "ga:searchGoalXXConversionRate";
        public static readonly string SearchGoalConversionRateAll = "ga:searchGoalConversionRateAll";
        public static readonly string GoalValueAllPerSearch = "ga:goalValueAllPerSearch";

        #endregion

        #region Site Speed

        public static readonly string PageLoadTime = "ga:pageLoadTime";
        public static readonly string PageLoadSample = "ga:pageLoadSample";
        public static readonly string AvgPageLoadTime = "ga:avgPageLoadTime";
        public static readonly string DomainLookupTime = "ga:domainLookupTime";
        public static readonly string AvgDomainLookupTime = "ga:avgDomainLookupTime";
        public static readonly string PageDownloadTime = "ga:pageDownloadTime";
        public static readonly string AvgPageDownloadTime = "ga:avgPageDownloadTime";
        public static readonly string RedirectionTime = "ga:redirectionTime";
        public static readonly string AvgRedirectionTime = "ga:avgRedirectionTime";
        public static readonly string ServerConnectionTime = "ga:serverConnectionTime";
        public static readonly string AvgServerConnectionTime = "ga:avgServerConnectionTime";
        public static readonly string ServerResponseTime = "ga:serverResponseTime";
        public static readonly string AvgServerResponseTime = "ga:avgServerResponseTime";
        public static readonly string SpeedMetricsSample = "ga:speedMetricsSample";
        public static readonly string DomInteractiveTime = "ga:domInteractiveTime";
        public static readonly string AvgDomInteractiveTime = "ga:avgDomInteractiveTime";
        public static readonly string DomContentLoadedTime = "ga:domContentLoadedTime";
        public static readonly string AvgDomContentLoadedTime = "ga:avgDomContentLoadedTime";
        public static readonly string DomLatencyMetricsSample = "ga:domLatencyMetricsSample";

        #endregion

        #region App Tracking

        public static readonly string Appviews = "ga:appviews";
        public static readonly string UniqueAppviews = "ga:uniqueAppviews";
        public static readonly string AppviewsPerVisit = "ga:appviewsPerVisit";
        public static readonly string Screenviews = "ga:screenviews";
        public static readonly string UniqueScreenviews = "ga:uniqueScreenviews";
        public static readonly string ScreenviewsPerSession = "ga:screenviewsPerSession";
        public static readonly string TimeOnScreen = "ga:timeOnScreen";
        public static readonly string AvgScreenviewDuration = "ga:avgScreenviewDuration";

        #endregion

        #region Event Tracking

        public static readonly string TotalEvents = "ga:totalEvents";
        public static readonly string UniqueEvents = "ga:uniqueEvents";
        public static readonly string EventValue = "ga:eventValue";
        public static readonly string AvgEventValue = "ga:avgEventValue";
        public static readonly string VisitsWithEvent = "ga:visitsWithEvent";
        public static readonly string EventsPerVisitWithEvent = "ga:eventsPerVisitWithEvent";

        #endregion

        #region Ecommerce

        public static readonly string Transactions = "ga:transactions";
        public static readonly string TransactionsPerVisit = "ga:transactionsPerVisit";
        public static readonly string TransactionRevenue = "ga:transactionRevenue";
        public static readonly string RevenuePerTransaction = "ga:revenuePerTransaction";
        public static readonly string TransactionRevenuePerVisit = "ga:transactionRevenuePerVisit";
        public static readonly string TransactionShipping = "ga:transactionShipping";
        public static readonly string TransactionTax = "ga:transactionTax";
        public static readonly string TotalValue = "ga:totalValue";
        public static readonly string ItemQuantity = "ga:itemQuantity";
        public static readonly string UniquePurchases = "ga:uniquePurchases";
        public static readonly string RevenuePerItem = "ga:revenuePerItem";
        public static readonly string ItemRevenue = "ga:itemRevenue";
        public static readonly string ItemsPerPurchase = "ga:itemsPerPurchase";
        public static readonly string LocalItemRevenue = "ga:localItemRevenue";
        public static readonly string LocalTransactionRevenue = "ga:localTransactionRevenue";
        public static readonly string LocalTransactionTax = "ga:localTransactionTax";
        public static readonly string LocalTransactionShipping = "ga:localTransactionShipping";

        #endregion

        #region Social Interactions

        public static readonly string SocialInteractions = "ga:socialInteractions";
        public static readonly string UniqueSocialInteractions = "ga:uniqueSocialInteractions";
        public static readonly string SocialInteractionsPerVisit = "ga:socialInteractionsPerVisit";

        #endregion

        #region User Timings

        public static readonly string UserTimingValue = "ga:userTimingValue";
        public static readonly string UserTimingSample = "ga:userTimingSample";
        public static readonly string AvgUserTimingValue = "ga:avgUserTimingValue";

        #endregion

        #region Exception Tracking

        public static readonly string Exceptions = "ga:exceptions";
        public static readonly string ExceptionsPerScreenview = "ga:exceptionsPerScreenview";
        public static readonly string FatalExceptions = "ga:fatalExceptions";
        public static readonly string FatalExceptionsPerScreenview = "ga:fatalExceptionsPerScreenview";

        #endregion

        #region Experiments


        #endregion

        #region Custom Variables or Columns

        public static readonly string MetricXX = "ga:metricXX";

        #endregion

        #region Time


        #endregion

    }

}
