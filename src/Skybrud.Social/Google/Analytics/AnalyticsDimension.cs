namespace Skybrud.Social.Google.Analytics {

    public class AnalyticsDimension {

        #region Visitor

        public static readonly string VisitorType = "ga:visitorType";
        public static readonly string VisitCount = "ga:visitCount";
        public static readonly string DaysSinceLastVisit = "ga:daysSinceLastVisit";
        public static readonly string UserDefinedValue = "ga:userDefinedValue";

        #endregion

        #region Session

        public static readonly string VisitLength = "ga:visitLength";

        #endregion

        #region Traffic Sources

        public static readonly string ReferralPath = "ga:referralPath";
        public static readonly string FullReferrer = "ga:fullReferrer";
        public static readonly string Campaign = "ga:campaign";
        public static readonly string Source = "ga:source";
        public static readonly string Medium = "ga:medium";
        public static readonly string SourceMedium = "ga:sourceMedium";
        public static readonly string Keyword = "ga:keyword";
        public static readonly string AdContent = "ga:adContent";
        public static readonly string SocialNetwork = "ga:socialNetwork";
        public static readonly string HasSocialSourceReferral = "ga:hasSocialSourceReferral";

        #endregion

        #region AdWords

        public static readonly string AdGroup = "ga:adGroup";
        public static readonly string AdSlot = "ga:adSlot";
        public static readonly string AdSlotPosition = "ga:adSlotPosition";
        public static readonly string AdDistributionNetwork = "ga:adDistributionNetwork";
        public static readonly string AdMatchType = "ga:adMatchType";
        public static readonly string AdMatchedQuery = "ga:adMatchedQuery";
        public static readonly string AdPlacementDomain = "ga:adPlacementDomain";
        public static readonly string AdPlacementUrl = "ga:adPlacementUrl";
        public static readonly string AdFormat = "ga:adFormat";
        public static readonly string AdTargetingType = "ga:adTargetingType";
        public static readonly string AdTargetingOption = "ga:adTargetingOption";
        public static readonly string AdDisplayUrl = "ga:adDisplayUrl";
        public static readonly string AdDestinationUrl = "ga:adDestinationUrl";
        public static readonly string AdwordsCustomerID = "ga:adwordsCustomerID";
        public static readonly string AdwordsCampaignID = "ga:adwordsCampaignID";
        public static readonly string AdwordsAdGroupID = "ga:adwordsAdGroupID";
        public static readonly string AdwordsCreativeID = "ga:adwordsCreativeID";
        public static readonly string AdwordsCriteriaID = "ga:adwordsCriteriaID";

        #endregion

        #region Goal Conversions

        public static readonly string GoalCompletionLocation = "ga:goalCompletionLocation";
        public static readonly string GoalPreviousStep1 = "ga:goalPreviousStep1";
        public static readonly string GoalPreviousStep2 = "ga:goalPreviousStep2";
        public static readonly string GoalPreviousStep3 = "ga:goalPreviousStep3";

        #endregion

        #region Platform / Device

        public static readonly string Browser = "ga:browser";
        public static readonly string BrowserVersion = "ga:browserVersion";
        public static readonly string OperatingSystem = "ga:operatingSystem";
        public static readonly string OperatingSystemVersion = "ga:operatingSystemVersion";
        public static readonly string DeviceCategory = "ga:deviceCategory";
        public static readonly string IsMobile = "ga:isMobile";
        public static readonly string IsTablet = "ga:isTablet";
        public static readonly string MobileDeviceBranding = "ga:mobileDeviceBranding";
        public static readonly string MobileDeviceMarketingName = "ga:mobileDeviceMarketingName";
        public static readonly string MobileDeviceModel = "ga:mobileDeviceModel";
        public static readonly string MobileInputSelector = "ga:mobileInputSelector";
        public static readonly string MobileDeviceInfo = "ga:mobileDeviceInfo";

        #endregion

        #region Geo / Network

        public static readonly string Continent = "ga:continent";
        public static readonly string SubContinent = "ga:subContinent";
        public static readonly string Country = "ga:country";
        public static readonly string Region = "ga:region";
        public static readonly string Metro = "ga:metro";
        public static readonly string City = "ga:city";
        public static readonly string Latitude = "ga:latitude";
        public static readonly string Longitude = "ga:longitude";
        public static readonly string NetworkDomain = "ga:networkDomain";
        public static readonly string NetworkLocation = "ga:networkLocation";

        #endregion

        #region System

        public static readonly string FlashVersion = "ga:flashVersion";
        public static readonly string JavaEnabled = "ga:javaEnabled";
        public static readonly string Language = "ga:language";
        public static readonly string ScreenColors = "ga:screenColors";
        public static readonly string ScreenResolution = "ga:screenResolution";

        #endregion

        #region Social Activities

        public static readonly string SocialActivityEndorsingUrl = "ga:socialActivityEndorsingUrl";
        public static readonly string SocialActivityDisplayName = "ga:socialActivityDisplayName";
        public static readonly string SocialActivityPost = "ga:socialActivityPost";
        public static readonly string SocialActivityTimestamp = "ga:socialActivityTimestamp";
        public static readonly string SocialActivityUserHandle = "ga:socialActivityUserHandle";
        public static readonly string SocialActivityUserPhotoUrl = "ga:socialActivityUserPhotoUrl";
        public static readonly string SocialActivityUserProfileUrl = "ga:socialActivityUserProfileUrl";
        public static readonly string SocialActivityContentUrl = "ga:socialActivityContentUrl";
        public static readonly string SocialActivityTagsSummary = "ga:socialActivityTagsSummary";
        public static readonly string SocialActivityAction = "ga:socialActivityAction";
        public static readonly string SocialActivityNetworkAction = "ga:socialActivityNetworkAction";

        #endregion

        #region Page Tracking

        public static readonly string Hostname = "ga:hostname";
        public static readonly string PagePath = "ga:pagePath";
        public static readonly string PagePathLevel1 = "ga:pagePathLevel1";
        public static readonly string PagePathLevel2 = "ga:pagePathLevel2";
        public static readonly string PagePathLevel3 = "ga:pagePathLevel3";
        public static readonly string PagePathLevel4 = "ga:pagePathLevel4";
        public static readonly string PageTitle = "ga:pageTitle";
        public static readonly string LandingPagePath = "ga:landingPagePath";
        public static readonly string SecondPagePath = "ga:secondPagePath";
        public static readonly string ExitPagePath = "ga:exitPagePath";
        public static readonly string PreviousPagePath = "ga:previousPagePath";
        public static readonly string NextPagePath = "ga:nextPagePath";
        public static readonly string PageDepth = "ga:pageDepth";

        #endregion

        #region Internal Search

        public static readonly string SearchUsed = "ga:searchUsed";
        public static readonly string SearchKeyword = "ga:searchKeyword";
        public static readonly string SearchKeywordRefinement = "ga:searchKeywordRefinement";
        public static readonly string SearchCategory = "ga:searchCategory";
        public static readonly string SearchStartPage = "ga:searchStartPage";
        public static readonly string SearchDestinationPage = "ga:searchDestinationPage";

        #endregion

        #region Site Speed


        #endregion

        #region App Tracking

        public static readonly string AppName = "ga:appName";
        public static readonly string AppId = "ga:appId";
        public static readonly string AppVersion = "ga:appVersion";
        public static readonly string AppInstallerId = "ga:appInstallerId";
        public static readonly string LandingScreenName = "ga:landingScreenName";
        public static readonly string ScreenName = "ga:screenName";
        public static readonly string ExitScreenName = "ga:exitScreenName";
        public static readonly string ScreenDepth = "ga:screenDepth";

        #endregion

        #region Event Tracking

        public static readonly string EventCategory = "ga:eventCategory";
        public static readonly string EventAction = "ga:eventAction";
        public static readonly string EventLabel = "ga:eventLabel";

        #endregion

        #region Ecommerce

        public static readonly string TransactionId = "ga:transactionId";
        public static readonly string Affiliation = "ga:affiliation";
        public static readonly string VisitsToTransaction = "ga:visitsToTransaction";
        public static readonly string DaysToTransaction = "ga:daysToTransaction";
        public static readonly string ProductSku = "ga:productSku";
        public static readonly string ProductName = "ga:productName";
        public static readonly string ProductCategory = "ga:productCategory";
        public static readonly string CurrencyCode = "ga:currencyCode";

        #endregion

        #region Social Interactions

        public static readonly string SocialInteractionNetwork = "ga:socialInteractionNetwork";
        public static readonly string SocialInteractionAction = "ga:socialInteractionAction";
        public static readonly string SocialInteractionNetworkAction = "ga:socialInteractionNetworkAction";
        public static readonly string SocialInteractionTarget = "ga:socialInteractionTarget";
        public static readonly string SocialEngagementType = "ga:socialEngagementType";

        #endregion

        #region User Timings

        public static readonly string UserTimingCategory = "ga:userTimingCategory";
        public static readonly string UserTimingLabel = "ga:userTimingLabel";
        public static readonly string UserTimingVariable = "ga:userTimingVariable";

        #endregion

        #region Exception Tracking

        public static readonly string ExceptionDescription = "ga:exceptionDescription";

        #endregion

        #region Experiments

        public static readonly string ExperimentId = "ga:experimentId";
        public static readonly string ExperimentVariant = "ga:experimentVariant";

        #endregion

        #region Custom Variables or Columns

        public static readonly string CustomVarNameXX = "ga:customVarNameXX";
        public static readonly string CustomVarValueXX = "ga:customVarValueXX";
        public static readonly string DimensionXX = "ga:dimensionXX";

        #endregion

        #region Time

        public static readonly string Date = "ga:date";
        public static readonly string Year = "ga:year";
        public static readonly string Month = "ga:month";
        public static readonly string Week = "ga:week";
        public static readonly string Day = "ga:day";
        public static readonly string Hour = "ga:hour";
        public static readonly string YearMonth = "ga:yearMonth";
        public static readonly string YearWeek = "ga:yearWeek";
        public static readonly string DateHour = "ga:dateHour";
        public static readonly string NthMonth = "ga:nthMonth";
        public static readonly string NthWeek = "ga:nthWeek";
        public static readonly string NthDay = "ga:nthDay";
        public static readonly string IsoWeek = "ga:isoWeek";
        public static readonly string DayOfWeek = "ga:dayOfWeek";
        public static readonly string DayOfWeekName = "ga:dayOfWeekName";

        #endregion

    }

}
