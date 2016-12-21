using System;
using System.Linq;
using System.Reflection;
using Skybrud.Social.Google.Analytics.Interfaces;

namespace Skybrud.Social.Google.Analytics.Objects {

    public class AnalyticsDimension : IAnalyticsField {

        #region Readonly properties
        // ReSharper disable InconsistentNaming
        #region Visitor

        public static readonly AnalyticsDimension VisitorType = new AnalyticsDimension("ga:visitorType");
        public static readonly AnalyticsDimension VisitCount = new AnalyticsDimension("ga:visitCount");
        public static readonly AnalyticsDimension DaysSinceLastVisit = new AnalyticsDimension("ga:daysSinceLastVisit");
        public static readonly AnalyticsDimension UserDefinedValue = new AnalyticsDimension("ga:userDefinedValue");

        #endregion

        #region Session

        public static readonly AnalyticsDimension VisitLength = new AnalyticsDimension("ga:visitLength");

        #endregion

        #region Traffic Sources

        public static readonly AnalyticsDimension ReferralPath = new AnalyticsDimension("ga:referralPath");
        public static readonly AnalyticsDimension FullReferrer = new AnalyticsDimension("ga:fullReferrer");
        public static readonly AnalyticsDimension Campaign = new AnalyticsDimension("ga:campaign");
        public static readonly AnalyticsDimension Source = new AnalyticsDimension("ga:source");
        public static readonly AnalyticsDimension Medium = new AnalyticsDimension("ga:medium");
        public static readonly AnalyticsDimension SourceMedium = new AnalyticsDimension("ga:sourceMedium");
        public static readonly AnalyticsDimension Keyword = new AnalyticsDimension("ga:keyword");
        public static readonly AnalyticsDimension AdContent = new AnalyticsDimension("ga:adContent");
        public static readonly AnalyticsDimension SocialNetwork = new AnalyticsDimension("ga:socialNetwork");
        public static readonly AnalyticsDimension HasSocialSourceReferral = new AnalyticsDimension("ga:hasSocialSourceReferral");

        #endregion

        #region AdWords

        public static readonly AnalyticsDimension AdGroup = new AnalyticsDimension("ga:adGroup");
        public static readonly AnalyticsDimension AdSlot = new AnalyticsDimension("ga:adSlot");
        public static readonly AnalyticsDimension AdSlotPosition = new AnalyticsDimension("ga:adSlotPosition");
        public static readonly AnalyticsDimension AdDistributionNetwork = new AnalyticsDimension("ga:adDistributionNetwork");
        public static readonly AnalyticsDimension AdMatchType = new AnalyticsDimension("ga:adMatchType");
        public static readonly AnalyticsDimension AdMatchedQuery = new AnalyticsDimension("ga:adMatchedQuery");
        public static readonly AnalyticsDimension AdPlacementDomain = new AnalyticsDimension("ga:adPlacementDomain");
        public static readonly AnalyticsDimension AdPlacementUrl = new AnalyticsDimension("ga:adPlacementUrl");
        public static readonly AnalyticsDimension AdFormat = new AnalyticsDimension("ga:adFormat");
        public static readonly AnalyticsDimension AdTargetingType = new AnalyticsDimension("ga:adTargetingType");
        public static readonly AnalyticsDimension AdTargetingOption = new AnalyticsDimension("ga:adTargetingOption");
        public static readonly AnalyticsDimension AdDisplayUrl = new AnalyticsDimension("ga:adDisplayUrl");
        public static readonly AnalyticsDimension AdDestinationUrl = new AnalyticsDimension("ga:adDestinationUrl");
        public static readonly AnalyticsDimension AdwordsCustomerID = new AnalyticsDimension("ga:adwordsCustomerID");
        public static readonly AnalyticsDimension AdwordsCampaignID = new AnalyticsDimension("ga:adwordsCampaignID");
        public static readonly AnalyticsDimension AdwordsAdGroupID = new AnalyticsDimension("ga:adwordsAdGroupID");
        public static readonly AnalyticsDimension AdwordsCreativeID = new AnalyticsDimension("ga:adwordsCreativeID");
        public static readonly AnalyticsDimension AdwordsCriteriaID = new AnalyticsDimension("ga:adwordsCriteriaID");

        #endregion

        #region Goal Conversions

        public static readonly AnalyticsDimension GoalCompletionLocation = new AnalyticsDimension("ga:goalCompletionLocation");
        public static readonly AnalyticsDimension GoalPreviousStep1 = new AnalyticsDimension("ga:goalPreviousStep1");
        public static readonly AnalyticsDimension GoalPreviousStep2 = new AnalyticsDimension("ga:goalPreviousStep2");
        public static readonly AnalyticsDimension GoalPreviousStep3 = new AnalyticsDimension("ga:goalPreviousStep3");

        #endregion

        #region Platform / Device

        public static readonly AnalyticsDimension Browser = new AnalyticsDimension("ga:browser");
        public static readonly AnalyticsDimension BrowserVersion = new AnalyticsDimension("ga:browserVersion");
        public static readonly AnalyticsDimension OperatingSystem = new AnalyticsDimension("ga:operatingSystem");
        public static readonly AnalyticsDimension OperatingSystemVersion = new AnalyticsDimension("ga:operatingSystemVersion");
        public static readonly AnalyticsDimension DeviceCategory = new AnalyticsDimension("ga:deviceCategory");
        public static readonly AnalyticsDimension IsMobile = new AnalyticsDimension("ga:isMobile");
        public static readonly AnalyticsDimension IsTablet = new AnalyticsDimension("ga:isTablet");
        public static readonly AnalyticsDimension MobileDeviceBranding = new AnalyticsDimension("ga:mobileDeviceBranding");
        public static readonly AnalyticsDimension MobileDeviceMarketingName = new AnalyticsDimension("ga:mobileDeviceMarketingName");
        public static readonly AnalyticsDimension MobileDeviceModel = new AnalyticsDimension("ga:mobileDeviceModel");
        public static readonly AnalyticsDimension MobileInputSelector = new AnalyticsDimension("ga:mobileInputSelector");
        public static readonly AnalyticsDimension MobileDeviceInfo = new AnalyticsDimension("ga:mobileDeviceInfo");

        #endregion

        #region Geo / Network

        public static readonly AnalyticsDimension Continent = new AnalyticsDimension("ga:continent");
        public static readonly AnalyticsDimension SubContinent = new AnalyticsDimension("ga:subContinent");
        public static readonly AnalyticsDimension Country = new AnalyticsDimension("ga:country");
        public static readonly AnalyticsDimension Region = new AnalyticsDimension("ga:region");
        public static readonly AnalyticsDimension Metro = new AnalyticsDimension("ga:metro");
        public static readonly AnalyticsDimension City = new AnalyticsDimension("ga:city");
        public static readonly AnalyticsDimension Latitude = new AnalyticsDimension("ga:latitude");
        public static readonly AnalyticsDimension Longitude = new AnalyticsDimension("ga:longitude");
        public static readonly AnalyticsDimension NetworkDomain = new AnalyticsDimension("ga:networkDomain");
        public static readonly AnalyticsDimension NetworkLocation = new AnalyticsDimension("ga:networkLocation");

        #endregion

        #region System

        public static readonly AnalyticsDimension FlashVersion = new AnalyticsDimension("ga:flashVersion");
        public static readonly AnalyticsDimension JavaEnabled = new AnalyticsDimension("ga:javaEnabled");
        public static readonly AnalyticsDimension Language = new AnalyticsDimension("ga:language");
        public static readonly AnalyticsDimension ScreenColors = new AnalyticsDimension("ga:screenColors");
        public static readonly AnalyticsDimension ScreenResolution = new AnalyticsDimension("ga:screenResolution");

        #endregion

        #region Social Activities

        public static readonly AnalyticsDimension SocialActivityEndorsingUrl = new AnalyticsDimension("ga:socialActivityEndorsingUrl");
        public static readonly AnalyticsDimension SocialActivityDisplayName = new AnalyticsDimension("ga:socialActivityDisplayName");
        public static readonly AnalyticsDimension SocialActivityPost = new AnalyticsDimension("ga:socialActivityPost");
        public static readonly AnalyticsDimension SocialActivityTimestamp = new AnalyticsDimension("ga:socialActivityTimestamp");
        public static readonly AnalyticsDimension SocialActivityUserHandle = new AnalyticsDimension("ga:socialActivityUserHandle");
        public static readonly AnalyticsDimension SocialActivityUserPhotoUrl = new AnalyticsDimension("ga:socialActivityUserPhotoUrl");
        public static readonly AnalyticsDimension SocialActivityUserProfileUrl = new AnalyticsDimension("ga:socialActivityUserProfileUrl");
        public static readonly AnalyticsDimension SocialActivityContentUrl = new AnalyticsDimension("ga:socialActivityContentUrl");
        public static readonly AnalyticsDimension SocialActivityTagsSummary = new AnalyticsDimension("ga:socialActivityTagsSummary");
        public static readonly AnalyticsDimension SocialActivityAction = new AnalyticsDimension("ga:socialActivityAction");
        public static readonly AnalyticsDimension SocialActivityNetworkAction = new AnalyticsDimension("ga:socialActivityNetworkAction");

        #endregion

        #region Page Tracking

        public static readonly AnalyticsDimension Hostname = new AnalyticsDimension("ga:hostname");
        public static readonly AnalyticsDimension PagePath = new AnalyticsDimension("ga:pagePath");
        public static readonly AnalyticsDimension PagePathLevel1 = new AnalyticsDimension("ga:pagePathLevel1");
        public static readonly AnalyticsDimension PagePathLevel2 = new AnalyticsDimension("ga:pagePathLevel2");
        public static readonly AnalyticsDimension PagePathLevel3 = new AnalyticsDimension("ga:pagePathLevel3");
        public static readonly AnalyticsDimension PagePathLevel4 = new AnalyticsDimension("ga:pagePathLevel4");
        public static readonly AnalyticsDimension PageTitle = new AnalyticsDimension("ga:pageTitle");
        public static readonly AnalyticsDimension LandingPagePath = new AnalyticsDimension("ga:landingPagePath");
        public static readonly AnalyticsDimension SecondPagePath = new AnalyticsDimension("ga:secondPagePath");
        public static readonly AnalyticsDimension ExitPagePath = new AnalyticsDimension("ga:exitPagePath");
        public static readonly AnalyticsDimension PreviousPagePath = new AnalyticsDimension("ga:previousPagePath");
        public static readonly AnalyticsDimension NextPagePath = new AnalyticsDimension("ga:nextPagePath");
        public static readonly AnalyticsDimension PageDepth = new AnalyticsDimension("ga:pageDepth");

        #endregion

        #region Internal Search

        public static readonly AnalyticsDimension SearchUsed = new AnalyticsDimension("ga:searchUsed");
        public static readonly AnalyticsDimension SearchKeyword = new AnalyticsDimension("ga:searchKeyword");
        public static readonly AnalyticsDimension SearchKeywordRefinement = new AnalyticsDimension("ga:searchKeywordRefinement");
        public static readonly AnalyticsDimension SearchCategory = new AnalyticsDimension("ga:searchCategory");
        public static readonly AnalyticsDimension SearchStartPage = new AnalyticsDimension("ga:searchStartPage");
        public static readonly AnalyticsDimension SearchDestinationPage = new AnalyticsDimension("ga:searchDestinationPage");

        #endregion

        #region Site Speed


        #endregion

        #region App Tracking

        public static readonly AnalyticsDimension AppName = new AnalyticsDimension("ga:appName");
        public static readonly AnalyticsDimension AppId = new AnalyticsDimension("ga:appId");
        public static readonly AnalyticsDimension AppVersion = new AnalyticsDimension("ga:appVersion");
        public static readonly AnalyticsDimension AppInstallerId = new AnalyticsDimension("ga:appInstallerId");
        public static readonly AnalyticsDimension LandingScreenName = new AnalyticsDimension("ga:landingScreenName");
        public static readonly AnalyticsDimension ScreenName = new AnalyticsDimension("ga:screenName");
        public static readonly AnalyticsDimension ExitScreenName = new AnalyticsDimension("ga:exitScreenName");
        public static readonly AnalyticsDimension ScreenDepth = new AnalyticsDimension("ga:screenDepth");

        #endregion

        #region Event Tracking

        public static readonly AnalyticsDimension EventCategory = new AnalyticsDimension("ga:eventCategory");
        public static readonly AnalyticsDimension EventAction = new AnalyticsDimension("ga:eventAction");
        public static readonly AnalyticsDimension EventLabel = new AnalyticsDimension("ga:eventLabel");

        #endregion

        #region Ecommerce

        public static readonly AnalyticsDimension TransactionId = new AnalyticsDimension("ga:transactionId");
        public static readonly AnalyticsDimension Affiliation = new AnalyticsDimension("ga:affiliation");
        public static readonly AnalyticsDimension VisitsToTransaction = new AnalyticsDimension("ga:visitsToTransaction");
        public static readonly AnalyticsDimension DaysToTransaction = new AnalyticsDimension("ga:daysToTransaction");
        public static readonly AnalyticsDimension ProductSku = new AnalyticsDimension("ga:productSku");
        public static readonly AnalyticsDimension ProductName = new AnalyticsDimension("ga:productName");
        public static readonly AnalyticsDimension ProductCategory = new AnalyticsDimension("ga:productCategory");
        public static readonly AnalyticsDimension CurrencyCode = new AnalyticsDimension("ga:currencyCode");

        #endregion

        #region Social Interactions

        public static readonly AnalyticsDimension SocialInteractionNetwork = new AnalyticsDimension("ga:socialInteractionNetwork");
        public static readonly AnalyticsDimension SocialInteractionAction = new AnalyticsDimension("ga:socialInteractionAction");
        public static readonly AnalyticsDimension SocialInteractionNetworkAction = new AnalyticsDimension("ga:socialInteractionNetworkAction");
        public static readonly AnalyticsDimension SocialInteractionTarget = new AnalyticsDimension("ga:socialInteractionTarget");
        public static readonly AnalyticsDimension SocialEngagementType = new AnalyticsDimension("ga:socialEngagementType");

        #endregion

        #region User Timings

        public static readonly AnalyticsDimension UserTimingCategory = new AnalyticsDimension("ga:userTimingCategory");
        public static readonly AnalyticsDimension UserTimingLabel = new AnalyticsDimension("ga:userTimingLabel");
        public static readonly AnalyticsDimension UserTimingVariable = new AnalyticsDimension("ga:userTimingVariable");

        #endregion

        #region Exception Tracking

        public static readonly AnalyticsDimension ExceptionDescription = new AnalyticsDimension("ga:exceptionDescription");

        #endregion

        #region Experiments

        public static readonly AnalyticsDimension ExperimentId = new AnalyticsDimension("ga:experimentId");
        public static readonly AnalyticsDimension ExperimentVariant = new AnalyticsDimension("ga:experimentVariant");

        #endregion

        #region Custom Variables or Columns

        public static readonly AnalyticsDimension CustomVarNameXX = new AnalyticsDimension("ga:customVarNameXX");
        public static readonly AnalyticsDimension CustomVarValueXX = new AnalyticsDimension("ga:customVarValueXX");
        public static readonly AnalyticsDimension DimensionXX = new AnalyticsDimension("ga:dimensionXX");

        #endregion

        #region Time

        public static readonly AnalyticsDimension Date = new AnalyticsDimension("ga:date");
        public static readonly AnalyticsDimension Year = new AnalyticsDimension("ga:year");
        public static readonly AnalyticsDimension Month = new AnalyticsDimension("ga:month");
        public static readonly AnalyticsDimension Week = new AnalyticsDimension("ga:week");
        public static readonly AnalyticsDimension Day = new AnalyticsDimension("ga:day");
        public static readonly AnalyticsDimension Hour = new AnalyticsDimension("ga:hour");
        public static readonly AnalyticsDimension YearMonth = new AnalyticsDimension("ga:yearMonth");
        public static readonly AnalyticsDimension YearWeek = new AnalyticsDimension("ga:yearWeek");
        public static readonly AnalyticsDimension DateHour = new AnalyticsDimension("ga:dateHour");
        public static readonly AnalyticsDimension NthMonth = new AnalyticsDimension("ga:nthMonth");
        public static readonly AnalyticsDimension NthWeek = new AnalyticsDimension("ga:nthWeek");
        public static readonly AnalyticsDimension NthDay = new AnalyticsDimension("ga:nthDay");
        public static readonly AnalyticsDimension IsoWeek = new AnalyticsDimension("ga:isoWeek");
        public static readonly AnalyticsDimension DayOfWeek = new AnalyticsDimension("ga:dayOfWeek");
        public static readonly AnalyticsDimension DayOfWeekName = new AnalyticsDimension("ga:dayOfWeekName");

        #endregion
// ReSharper restore InconsistentNaming
        #endregion

        #region Static properties

        public static AnalyticsDimension[] Values {
            get {
                return (
                    from property in typeof(AnalyticsDimension).GetFields(BindingFlags.Public | BindingFlags.Static)
                    select (AnalyticsDimension) property.GetValue(null)
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

        public AnalyticsDimension(string name) {
            Name = name;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets the name of the dimension (eg. "ga:country").
        /// </summary>
        public override string ToString() {
            return Name;
        }

        #endregion

        #region Static methods

        public static AnalyticsDimension Parse(string str) {
            AnalyticsDimension dimension;
            if (TryParse(str, out dimension)) return dimension;
            throw new Exception("Invalid dimension '" + str + "'");
        }

        public static bool TryParse(string str, out AnalyticsDimension dimension) {
            dimension = Values.FirstOrDefault(temp => temp.Name == str);
            return dimension != null;
        }

        #endregion

        #region Operator overloading

        public static implicit operator AnalyticsDimension(string name) {
            return Parse(name);
        }

        public static AnalyticsDimensionCollection operator +(AnalyticsDimension left, AnalyticsDimension right) {
            return new AnalyticsDimensionCollection(left, right);
        }

        #endregion

    }

}
