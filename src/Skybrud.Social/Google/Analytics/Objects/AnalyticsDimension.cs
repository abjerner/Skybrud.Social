using Skybrud.Social.Google.Analytics.Interfaces;

namespace Skybrud.Social.Google.Analytics.Objects {

    public class AnalyticsDimension : IAnalyticsField {

        #region Readonly properties

        #region Visitor

        public static readonly AnalyticsDimension VisitorType = "ga:visitorType";
        public static readonly AnalyticsDimension VisitCount = "ga:visitCount";
        public static readonly AnalyticsDimension DaysSinceLastVisit = "ga:daysSinceLastVisit";
        public static readonly AnalyticsDimension UserDefinedValue = "ga:userDefinedValue";

        #endregion

        #region Session

        public static readonly AnalyticsDimension VisitLength = "ga:visitLength";

        #endregion

        #region Traffic Sources

        public static readonly AnalyticsDimension ReferralPath = "ga:referralPath";
        public static readonly AnalyticsDimension FullReferrer = "ga:fullReferrer";
        public static readonly AnalyticsDimension Campaign = "ga:campaign";
        public static readonly AnalyticsDimension Source = "ga:source";
        public static readonly AnalyticsDimension Medium = "ga:medium";
        public static readonly AnalyticsDimension SourceMedium = "ga:sourceMedium";
        public static readonly AnalyticsDimension Keyword = "ga:keyword";
        public static readonly AnalyticsDimension AdContent = "ga:adContent";
        public static readonly AnalyticsDimension SocialNetwork = "ga:socialNetwork";
        public static readonly AnalyticsDimension HasSocialSourceReferral = "ga:hasSocialSourceReferral";

        #endregion

        #region AdWords

        public static readonly AnalyticsDimension AdGroup = "ga:adGroup";
        public static readonly AnalyticsDimension AdSlot = "ga:adSlot";
        public static readonly AnalyticsDimension AdSlotPosition = "ga:adSlotPosition";
        public static readonly AnalyticsDimension AdDistributionNetwork = "ga:adDistributionNetwork";
        public static readonly AnalyticsDimension AdMatchType = "ga:adMatchType";
        public static readonly AnalyticsDimension AdMatchedQuery = "ga:adMatchedQuery";
        public static readonly AnalyticsDimension AdPlacementDomain = "ga:adPlacementDomain";
        public static readonly AnalyticsDimension AdPlacementUrl = "ga:adPlacementUrl";
        public static readonly AnalyticsDimension AdFormat = "ga:adFormat";
        public static readonly AnalyticsDimension AdTargetingType = "ga:adTargetingType";
        public static readonly AnalyticsDimension AdTargetingOption = "ga:adTargetingOption";
        public static readonly AnalyticsDimension AdDisplayUrl = "ga:adDisplayUrl";
        public static readonly AnalyticsDimension AdDestinationUrl = "ga:adDestinationUrl";
        public static readonly AnalyticsDimension AdwordsCustomerID = "ga:adwordsCustomerID";
        public static readonly AnalyticsDimension AdwordsCampaignID = "ga:adwordsCampaignID";
        public static readonly AnalyticsDimension AdwordsAdGroupID = "ga:adwordsAdGroupID";
        public static readonly AnalyticsDimension AdwordsCreativeID = "ga:adwordsCreativeID";
        public static readonly AnalyticsDimension AdwordsCriteriaID = "ga:adwordsCriteriaID";

        #endregion

        #region Goal Conversions

        public static readonly AnalyticsDimension GoalCompletionLocation = "ga:goalCompletionLocation";
        public static readonly AnalyticsDimension GoalPreviousStep1 = "ga:goalPreviousStep1";
        public static readonly AnalyticsDimension GoalPreviousStep2 = "ga:goalPreviousStep2";
        public static readonly AnalyticsDimension GoalPreviousStep3 = "ga:goalPreviousStep3";

        #endregion

        #region Platform / Device

        public static readonly AnalyticsDimension Browser = "ga:browser";
        public static readonly AnalyticsDimension BrowserVersion = "ga:browserVersion";
        public static readonly AnalyticsDimension OperatingSystem = "ga:operatingSystem";
        public static readonly AnalyticsDimension OperatingSystemVersion = "ga:operatingSystemVersion";
        public static readonly AnalyticsDimension DeviceCategory = "ga:deviceCategory";
        public static readonly AnalyticsDimension IsMobile = "ga:isMobile";
        public static readonly AnalyticsDimension IsTablet = "ga:isTablet";
        public static readonly AnalyticsDimension MobileDeviceBranding = "ga:mobileDeviceBranding";
        public static readonly AnalyticsDimension MobileDeviceMarketingName = "ga:mobileDeviceMarketingName";
        public static readonly AnalyticsDimension MobileDeviceModel = "ga:mobileDeviceModel";
        public static readonly AnalyticsDimension MobileInputSelector = "ga:mobileInputSelector";
        public static readonly AnalyticsDimension MobileDeviceInfo = "ga:mobileDeviceInfo";

        #endregion

        #region Geo / Network

        public static readonly AnalyticsDimension Continent = "ga:continent";
        public static readonly AnalyticsDimension SubContinent = "ga:subContinent";
        public static readonly AnalyticsDimension Country = "ga:country";
        public static readonly AnalyticsDimension Region = "ga:region";
        public static readonly AnalyticsDimension Metro = "ga:metro";
        public static readonly AnalyticsDimension City = "ga:city";
        public static readonly AnalyticsDimension Latitude = "ga:latitude";
        public static readonly AnalyticsDimension Longitude = "ga:longitude";
        public static readonly AnalyticsDimension NetworkDomain = "ga:networkDomain";
        public static readonly AnalyticsDimension NetworkLocation = "ga:networkLocation";

        #endregion

        #region System

        public static readonly AnalyticsDimension FlashVersion = "ga:flashVersion";
        public static readonly AnalyticsDimension JavaEnabled = "ga:javaEnabled";
        public static readonly AnalyticsDimension Language = "ga:language";
        public static readonly AnalyticsDimension ScreenColors = "ga:screenColors";
        public static readonly AnalyticsDimension ScreenResolution = "ga:screenResolution";

        #endregion

        #region Social Activities

        public static readonly AnalyticsDimension SocialActivityEndorsingUrl = "ga:socialActivityEndorsingUrl";
        public static readonly AnalyticsDimension SocialActivityDisplayName = "ga:socialActivityDisplayName";
        public static readonly AnalyticsDimension SocialActivityPost = "ga:socialActivityPost";
        public static readonly AnalyticsDimension SocialActivityTimestamp = "ga:socialActivityTimestamp";
        public static readonly AnalyticsDimension SocialActivityUserHandle = "ga:socialActivityUserHandle";
        public static readonly AnalyticsDimension SocialActivityUserPhotoUrl = "ga:socialActivityUserPhotoUrl";
        public static readonly AnalyticsDimension SocialActivityUserProfileUrl = "ga:socialActivityUserProfileUrl";
        public static readonly AnalyticsDimension SocialActivityContentUrl = "ga:socialActivityContentUrl";
        public static readonly AnalyticsDimension SocialActivityTagsSummary = "ga:socialActivityTagsSummary";
        public static readonly AnalyticsDimension SocialActivityAction = "ga:socialActivityAction";
        public static readonly AnalyticsDimension SocialActivityNetworkAction = "ga:socialActivityNetworkAction";

        #endregion

        #region Page Tracking

        public static readonly AnalyticsDimension Hostname = "ga:hostname";
        public static readonly AnalyticsDimension PagePath = "ga:pagePath";
        public static readonly AnalyticsDimension PagePathLevel1 = "ga:pagePathLevel1";
        public static readonly AnalyticsDimension PagePathLevel2 = "ga:pagePathLevel2";
        public static readonly AnalyticsDimension PagePathLevel3 = "ga:pagePathLevel3";
        public static readonly AnalyticsDimension PagePathLevel4 = "ga:pagePathLevel4";
        public static readonly AnalyticsDimension PageTitle = "ga:pageTitle";
        public static readonly AnalyticsDimension LandingPagePath = "ga:landingPagePath";
        public static readonly AnalyticsDimension SecondPagePath = "ga:secondPagePath";
        public static readonly AnalyticsDimension ExitPagePath = "ga:exitPagePath";
        public static readonly AnalyticsDimension PreviousPagePath = "ga:previousPagePath";
        public static readonly AnalyticsDimension NextPagePath = "ga:nextPagePath";
        public static readonly AnalyticsDimension PageDepth = "ga:pageDepth";

        #endregion

        #region Internal Search

        public static readonly AnalyticsDimension SearchUsed = "ga:searchUsed";
        public static readonly AnalyticsDimension SearchKeyword = "ga:searchKeyword";
        public static readonly AnalyticsDimension SearchKeywordRefinement = "ga:searchKeywordRefinement";
        public static readonly AnalyticsDimension SearchCategory = "ga:searchCategory";
        public static readonly AnalyticsDimension SearchStartPage = "ga:searchStartPage";
        public static readonly AnalyticsDimension SearchDestinationPage = "ga:searchDestinationPage";

        #endregion

        #region Site Speed


        #endregion

        #region App Tracking

        public static readonly AnalyticsDimension AppName = "ga:appName";
        public static readonly AnalyticsDimension AppId = "ga:appId";
        public static readonly AnalyticsDimension AppVersion = "ga:appVersion";
        public static readonly AnalyticsDimension AppInstallerId = "ga:appInstallerId";
        public static readonly AnalyticsDimension LandingScreenName = "ga:landingScreenName";
        public static readonly AnalyticsDimension ScreenName = "ga:screenName";
        public static readonly AnalyticsDimension ExitScreenName = "ga:exitScreenName";
        public static readonly AnalyticsDimension ScreenDepth = "ga:screenDepth";

        #endregion

        #region Event Tracking

        public static readonly AnalyticsDimension EventCategory = "ga:eventCategory";
        public static readonly AnalyticsDimension EventAction = "ga:eventAction";
        public static readonly AnalyticsDimension EventLabel = "ga:eventLabel";

        #endregion

        #region Ecommerce

        public static readonly AnalyticsDimension TransactionId = "ga:transactionId";
        public static readonly AnalyticsDimension Affiliation = "ga:affiliation";
        public static readonly AnalyticsDimension VisitsToTransaction = "ga:visitsToTransaction";
        public static readonly AnalyticsDimension DaysToTransaction = "ga:daysToTransaction";
        public static readonly AnalyticsDimension ProductSku = "ga:productSku";
        public static readonly AnalyticsDimension ProductName = "ga:productName";
        public static readonly AnalyticsDimension ProductCategory = "ga:productCategory";
        public static readonly AnalyticsDimension CurrencyCode = "ga:currencyCode";

        #endregion

        #region Social Interactions

        public static readonly AnalyticsDimension SocialInteractionNetwork = "ga:socialInteractionNetwork";
        public static readonly AnalyticsDimension SocialInteractionAction = "ga:socialInteractionAction";
        public static readonly AnalyticsDimension SocialInteractionNetworkAction = "ga:socialInteractionNetworkAction";
        public static readonly AnalyticsDimension SocialInteractionTarget = "ga:socialInteractionTarget";
        public static readonly AnalyticsDimension SocialEngagementType = "ga:socialEngagementType";

        #endregion

        #region User Timings

        public static readonly AnalyticsDimension UserTimingCategory = "ga:userTimingCategory";
        public static readonly AnalyticsDimension UserTimingLabel = "ga:userTimingLabel";
        public static readonly AnalyticsDimension UserTimingVariable = "ga:userTimingVariable";

        #endregion

        #region Exception Tracking

        public static readonly AnalyticsDimension ExceptionDescription = "ga:exceptionDescription";

        #endregion

        #region Experiments

        public static readonly AnalyticsDimension ExperimentId = "ga:experimentId";
        public static readonly AnalyticsDimension ExperimentVariant = "ga:experimentVariant";

        #endregion

        #region Custom Variables or Columns

        public static readonly AnalyticsDimension CustomVarNameXX = "ga:customVarNameXX";
        public static readonly AnalyticsDimension CustomVarValueXX = "ga:customVarValueXX";
        public static readonly AnalyticsDimension DimensionXX = "ga:dimensionXX";

        #endregion

        #region Time

        public static readonly AnalyticsDimension Date = "ga:date";
        public static readonly AnalyticsDimension Year = "ga:year";
        public static readonly AnalyticsDimension Month = "ga:month";
        public static readonly AnalyticsDimension Week = "ga:week";
        public static readonly AnalyticsDimension Day = "ga:day";
        public static readonly AnalyticsDimension Hour = "ga:hour";
        public static readonly AnalyticsDimension YearMonth = "ga:yearMonth";
        public static readonly AnalyticsDimension YearWeek = "ga:yearWeek";
        public static readonly AnalyticsDimension DateHour = "ga:dateHour";
        public static readonly AnalyticsDimension NthMonth = "ga:nthMonth";
        public static readonly AnalyticsDimension NthWeek = "ga:nthWeek";
        public static readonly AnalyticsDimension NthDay = "ga:nthDay";
        public static readonly AnalyticsDimension IsoWeek = "ga:isoWeek";
        public static readonly AnalyticsDimension DayOfWeek = "ga:dayOfWeek";
        public static readonly AnalyticsDimension DayOfWeekName = "ga:dayOfWeekName";

        #endregion

        #endregion

        #region Member properties

        /// <summary>
        /// The name of the dimension.
        /// </summary>
        public string Name { get; private set; }

        #endregion

        #region Constructor

        private AnalyticsDimension(string name) {
            Name = name;
        }

        #endregion

        #region Operator overloading

        public static implicit operator AnalyticsDimension(string name) {
            return new AnalyticsDimension(name);
        }

        public static AnalyticsDimensionCollection operator +(AnalyticsDimension left, AnalyticsDimension right) {
            return new AnalyticsDimensionCollection(left, right);
        }

        #endregion

    }

}
