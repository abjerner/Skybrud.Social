// This class is auto-generated based on metrics from the Google Analytics API. If you have suggestions for any
// changes, please create a new issue at https://github.com/abjerner/Skybrud.Social/issues/new

using Skybrud.Social.Google.Analytics.Objects;

namespace Skybrud.Social.Google.Analytics.Dimensions {

    /// <summary>
    /// Static class with constants for dimensions of the Google Analytics Realtime API.
    /// </summary>
    public static class AnalyticsRealtimeDimensions {

        // ReSharper disable InconsistentNaming

        #region User

        /// <summary>
        /// Gets a boolean indicating if a user is new or returning. Possible values are <code>new</code> and <code>returning</code> (id: <code>rt:userType</code>).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/realtime/dimsmets/user.html#rt:userType</cref>
        /// </see>
        public static readonly AnalyticsDimension UserType = new AnalyticsDimension("rt:userType", "User");

        #endregion

        #region Time

        /// <summary>
        /// Gets the number of minutes ago a hit occurred (id: <code>rt:minutesAgo</code>).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/realtime/dimsmets/time.html#rt:minutesAgo</cref>
        /// </see>
        public static readonly AnalyticsDimension MinutesAgo = new AnalyticsDimension("rt:minutesAgo", "Time");

        #endregion

        #region Traffic Sources

        /// <summary>
        /// Gets the path of the referring URL (e.g. document.referrer). If someone places a link to your property on their website, this element contains the path of the page that contains the referring link. This value is only set when <code>rt:medium=referral</code> (id: <code>rt:referralPath</code>).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/realtime/dimsmets/trafficsources.html#rt:referralPath</cref>
        /// </see>
        public static readonly AnalyticsDimension ReferralPath = new AnalyticsDimension("rt:referralPath", "Traffic Sources");

        /// <summary>
        /// When using manual campaign tracking, the value of the <code>utm_campaign</code> campaign tracking parameter. When using AdWords autotagging, the name(s) of the online ad campaign that you use for your property. Otherwise the value <code>(not set)</code> is used (id: <code>rt:campaign</code>).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/realtime/dimsmets/trafficsources.html#rt:campaign</cref>
        /// </see>
        public static readonly AnalyticsDimension Campaign = new AnalyticsDimension("rt:campaign", "Traffic Sources");

        /// <summary>
        /// Gets the source of referrals to your property. When using manual campaign tracking, the value of the <code>utm_source</code> campaign tracking parameter. When using AdWords autotagging, the value is <code>google</code>. Otherwise the domain of the source referring the user to your property (e.g. <code>document.referrer</code>). The value may also contain a port address. If the user arrived without a referrer, the value is <code>(direct)</code> (id: <code>rt:source</code>).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/realtime/dimsmets/trafficsources.html#rt:source</cref>
        /// </see>
        public static readonly AnalyticsDimension Source = new AnalyticsDimension("rt:source", "Traffic Sources");

        /// <summary>
        /// Gets the type of referrals to your property. When using manual campaign tracking, the value of the <code>utm_medium</code> campaign tracking parameter. When using AdWords autotagging, the value is <code>ppc</code>. If the user comes from a search engine detected by Google Analytics, the value is <code>organic</code>. If the referrer is not a search engine, the value is <code>referral</code>. If the user came directly to the property, and <code>document.referrer</code> is empty, the value is <code>(direct)</code> (id: <code>rt:medium</code>).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/realtime/dimsmets/trafficsources.html#rt:medium</cref>
        /// </see>
        public static readonly AnalyticsDimension Medium = new AnalyticsDimension("rt:medium", "Traffic Sources");

        /// <summary>
        /// This dimension is similar to <code>rt:medium</code> for constant values such as <code>organic</code>, <code>referral</code>, <code>direct</code>, etc. It is different for custom referral types. As an example, if you add the <code>utm_campaign</code> parameter to your URL with value <strong>email</strong>, <code>rt:medium</code> will be <strong>email</strong> but <code>rt:trafficType</code> will be <strong>custom</strong> (id: <code>rt:trafficType</code>).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/realtime/dimsmets/trafficsources.html#rt:trafficType</cref>
        /// </see>
        public static readonly AnalyticsDimension TrafficType = new AnalyticsDimension("rt:trafficType", "Traffic Sources");

        /// <summary>
        /// When using manual campaign tracking, the value of the <code>utm_term</code> campaign tracking parameter. When using AdWords autotagging or if a user used organic search to reach your property, the keywords used by users to reach your property. Otherwise the value is <code>(not set)</code> (id: <code>rt:keyword</code>).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/realtime/dimsmets/trafficsources.html#rt:keyword</cref>
        /// </see>
        public static readonly AnalyticsDimension Keyword = new AnalyticsDimension("rt:keyword", "Traffic Sources");

        #endregion

        #region Goal Conversions

        /// <summary>
        /// Gets a string. Corresponds to the goal ID (id: <code>rt:goalId</code>).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/realtime/dimsmets/goalconversions.html#rt:goalId</cref>
        /// </see>
        public static readonly AnalyticsDimension GoalId = new AnalyticsDimension("rt:goalId", "Goal Conversions");

        #endregion

        #region Platform / Device

        /// <summary>
        /// Gets the names of browsers used by users to your property (id: <code>rt:browser</code>).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/realtime/dimsmets/platform.html#rt:browser</cref>
        /// </see>
        public static readonly AnalyticsDimension Browser = new AnalyticsDimension("rt:browser", "Platform / Device");

        /// <summary>
        /// Gets the browser versions used by users to your property (id: <code>rt:browserVersion</code>).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/realtime/dimsmets/platform.html#rt:browserVersion</cref>
        /// </see>
        public static readonly AnalyticsDimension BrowserVersion = new AnalyticsDimension("rt:browserVersion", "Platform / Device");

        /// <summary>
        /// Gets the operating system used by users to your property (id: <code>rt:operatingSystem</code>).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/realtime/dimsmets/platform.html#rt:operatingSystem</cref>
        /// </see>
        public static readonly AnalyticsDimension OperatingSystem = new AnalyticsDimension("rt:operatingSystem", "Platform / Device");

        /// <summary>
        /// Gets the version of the operating system used by users to your property (id: <code>rt:operatingSystemVersion</code>).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/realtime/dimsmets/platform.html#rt:operatingSystemVersion</cref>
        /// </see>
        public static readonly AnalyticsDimension OperatingSystemVersion = new AnalyticsDimension("rt:operatingSystemVersion", "Platform / Device");

        /// <summary>
        /// Gets the type of device: Desktop, Tablet, or Mobile (id: <code>rt:deviceCategory</code>).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/realtime/dimsmets/platform.html#rt:deviceCategory</cref>
        /// </see>
        public static readonly AnalyticsDimension DeviceCategory = new AnalyticsDimension("rt:deviceCategory", "Platform / Device");

        /// <summary>
        /// Mobile manufacturer or branded name (e.g: Samsung, HTC, Verizon, T-Mobile) (id: <code>rt:mobileDeviceBranding</code>).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/realtime/dimsmets/platform.html#rt:mobileDeviceBranding</cref>
        /// </see>
        public static readonly AnalyticsDimension MobileDeviceBranding = new AnalyticsDimension("rt:mobileDeviceBranding", "Platform / Device");

        /// <summary>
        /// Mobile device model (e.g.: Nexus S) (id: <code>rt:mobileDeviceModel</code>).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/realtime/dimsmets/platform.html#rt:mobileDeviceModel</cref>
        /// </see>
        public static readonly AnalyticsDimension MobileDeviceModel = new AnalyticsDimension("rt:mobileDeviceModel", "Platform / Device");

        #endregion

        #region Geo

        /// <summary>
        /// Gets the countries of website users, derived from IP addresses (id: <code>rt:country</code>).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/realtime/dimsmets/geonetwork.html#rt:country</cref>
        /// </see>
        public static readonly AnalyticsDimension Country = new AnalyticsDimension("rt:country", "Geo");

        /// <summary>
        /// Gets the region of users to your property, derived from IP addresses. In the U.S., a region is a state, such as <code>New York</code> (id: <code>rt:region</code>).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/realtime/dimsmets/geonetwork.html#rt:region</cref>
        /// </see>
        public static readonly AnalyticsDimension Region = new AnalyticsDimension("rt:region", "Geo");

        /// <summary>
        /// Gets the cities of users, derived from IP addresses (id: <code>rt:city</code>).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/realtime/dimsmets/geonetwork.html#rt:city</cref>
        /// </see>
        public static readonly AnalyticsDimension City = new AnalyticsDimension("rt:city", "Geo");

        /// <summary>
        /// Gets the approximate latitude of the user's city. Derived from IP address. Locations north of the equator are represented by positive values and locations south of the equator by negative values (id: <code>rt:latitude</code>).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/realtime/dimsmets/geonetwork.html#rt:latitude</cref>
        /// </see>
        public static readonly AnalyticsDimension Latitude = new AnalyticsDimension("rt:latitude", "Geo");

        /// <summary>
        /// Gets the approximate longitude of the user's city. Derived from IP address. Locations east of the prime meridian are represented by positive values and locations west of the prime meridian by negative values (id: <code>rt:longitude</code>).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/realtime/dimsmets/geonetwork.html#rt:longitude</cref>
        /// </see>
        public static readonly AnalyticsDimension Longitude = new AnalyticsDimension("rt:longitude", "Geo");

        #endregion

        #region Page Tracking

        /// <summary>
        /// Gets a page on your property specified by path and/or query parameters (id: <code>rt:pagePath</code>).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/realtime/dimsmets/pagetracking.html#rt:pagePath</cref>
        /// </see>
        public static readonly AnalyticsDimension PagePath = new AnalyticsDimension("rt:pagePath", "Page Tracking");

        /// <summary>
        /// Gets the title of a page. Keep in mind that multiple pages might have the same page title (id: <code>rt:pageTitle</code>).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/realtime/dimsmets/pagetracking.html#rt:pageTitle</cref>
        /// </see>
        public static readonly AnalyticsDimension PageTitle = new AnalyticsDimension("rt:pageTitle", "Page Tracking");

        #endregion

        #region App Tracking

        /// <summary>
        /// Gets the name of the application (id: <code>rt:appName</code>).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/realtime/dimsmets/apptracking.html#rt:appName</cref>
        /// </see>
        public static readonly AnalyticsDimension AppName = new AnalyticsDimension("rt:appName", "App Tracking");

        /// <summary>
        /// Gets the version of the application (id: <code>rt:appVersion</code>).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/realtime/dimsmets/apptracking.html#rt:appVersion</cref>
        /// </see>
        public static readonly AnalyticsDimension AppVersion = new AnalyticsDimension("rt:appVersion", "App Tracking");

        /// <summary>
        /// Gets the name of a screen (id: <code>rt:screenName</code>).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/realtime/dimsmets/apptracking.html#rt:screenName</cref>
        /// </see>
        public static readonly AnalyticsDimension ScreenName = new AnalyticsDimension("rt:screenName", "App Tracking");

        #endregion

        #region Event Tracking

        /// <summary>
        /// Gets the action of the event (id: <code>rt:eventAction</code>).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/realtime/dimsmets/eventtracking.html#rt:eventAction</cref>
        /// </see>
        public static readonly AnalyticsDimension EventAction = new AnalyticsDimension("rt:eventAction", "Event Tracking");

        /// <summary>
        /// Gets the category of the event (id: <code>rt:eventCategory</code>).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/realtime/dimsmets/eventtracking.html#rt:eventCategory</cref>
        /// </see>
        public static readonly AnalyticsDimension EventCategory = new AnalyticsDimension("rt:eventCategory", "Event Tracking");

        /// <summary>
        /// Gets the label of the event (id: <code>rt:eventLabel</code>).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/realtime/dimsmets/eventtracking.html#rt:eventLabel</cref>
        /// </see>
        public static readonly AnalyticsDimension EventLabel = new AnalyticsDimension("rt:eventLabel", "Event Tracking");

        #endregion

        // ReSharper restore InconsistentNaming

    }

}