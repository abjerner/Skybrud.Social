// This class is auto-generated based on metrics from the Google Analytics API. If you have suggestions for any
// changes, please create a new issue at https://github.com/abjerner/Skybrud.Social/issues/new

using Skybrud.Social.Google.Analytics.Objects;

namespace Skybrud.Social.Google.Analytics.Metrics {

    /// <summary>
    /// Static class with constants for metrics of the Google Analytics Realtime API.
    /// </summary>
    public static class AnalyticsRealtimeMetrics {

        // ReSharper disable InconsistentNaming

        #region User

        /// <summary>
        /// Gets the number of users interacting with the property right now (id: <code>rt:activeUsers</code>).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/realtime/dimsmets/user.html#rt:activeUsers</cref>
        /// </see>
        public static readonly AnalyticsMetric ActiveUsers = new AnalyticsMetric("rt:activeUsers", "User");

        #endregion

        #region Goal Conversions

        /// <summary>
        /// Gets the total numeric value for the requested goal number, where XX is a number between 1 and 20.  (id: <code>rt:goalXXValue</code>).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/realtime/dimsmets/goalconversions.html#rt:goalXXValue</cref>
        /// </see>
        public static readonly AnalyticsMetric GoalXXValue = new AnalyticsMetric("rt:goalXXValue", "Goal Conversions");

        /// <summary>
        /// Gets the total numeric value for all goals defined for your view (profile).  (id: <code>rt:goalValueAll</code>).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/realtime/dimsmets/goalconversions.html#rt:goalValueAll</cref>
        /// </see>
        public static readonly AnalyticsMetric GoalValueAll = new AnalyticsMetric("rt:goalValueAll", "Goal Conversions");

        /// <summary>
        /// Gets the total number of completions for the requested goal number, where XX is a number between 1 and 20.  (id: <code>rt:goalXXCompletions</code>).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/realtime/dimsmets/goalconversions.html#rt:goalXXCompletions</cref>
        /// </see>
        public static readonly AnalyticsMetric GoalXXCompletions = new AnalyticsMetric("rt:goalXXCompletions", "Goal Conversions");

        /// <summary>
        /// Gets the total number of completions for all goals defined for your view (profile) (id: <code>rt:goalCompletionsAll</code>).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/realtime/dimsmets/goalconversions.html#rt:goalCompletionsAll</cref>
        /// </see>
        public static readonly AnalyticsMetric GoalCompletionsAll = new AnalyticsMetric("rt:goalCompletionsAll", "Goal Conversions");

        #endregion

        #region Page Tracking

        /// <summary>
        /// Gets the total number of page views (id: <code>rt:pageviews</code>).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/realtime/dimsmets/pagetracking.html#rt:pageviews</cref>
        /// </see>
        public static readonly AnalyticsMetric Pageviews = new AnalyticsMetric("rt:pageviews", "Page Tracking");

        #endregion

        #region App Tracking

        /// <summary>
        /// Gets the total number of screen views (id: <code>rt:screenViews</code>).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/realtime/dimsmets/apptracking.html#rt:screenViews</cref>
        /// </see>
        public static readonly AnalyticsMetric ScreenViews = new AnalyticsMetric("rt:screenViews", "App Tracking");

        #endregion

        #region Event Tracking

        /// <summary>
        /// Gets the total number of events for the view (profile), across all categories (id: <code>rt:totalEvents</code>).
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/analytics/devguides/reporting/realtime/dimsmets/eventtracking.html#rt:totalEvents</cref>
        /// </see>
        public static readonly AnalyticsMetric TotalEvents = new AnalyticsMetric("rt:totalEvents", "Event Tracking");

        #endregion

        // ReSharper restore InconsistentNaming

    }

}