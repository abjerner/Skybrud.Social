using System;
using Skybrud.Social.Google.Analytics.Objects;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.Google.Analytics.Options.Data {

    /// <summary>
    /// Class representing the options for getting realtime data from the Analytics API.
    /// </summary>
    public class AnalyticsRealtimeDataOptions : IGetOptions {

        #region Private fields

        private AnalyticsFilterOptions _filters = new AnalyticsFilterOptions();
        private AnalyticsSortOptions _sorting = new AnalyticsSortOptions();

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the ID of the profile.
        /// </summary>
        public string ProfileId { get; set; }

        /// <summary>
        /// Gets or sets the metrics.
        /// </summary>
        public AnalyticsMetricCollection Metrics { get; set; }

        /// <summary>
        /// Gets or sets the dimensions.
        /// </summary>
        public AnalyticsDimensionCollection Dimensions { get; set; }

        /// <summary>
        /// Gets or sets the filter options.
        /// </summary>
        public AnalyticsFilterOptions Filters {
            get { return _filters; }
            set { _filters = value ?? new AnalyticsFilterOptions(); }
        }

        /// <summary>
        /// A list of metrics and dimensions indicating the sorting order and sorting direction for the returned data.
        /// </summary>
        public AnalyticsSortOptions Sorting {
            get { return _sorting; }
            set { _sorting = value ?? new AnalyticsSortOptions(); }
        }

        /// <summary>
        /// Gets or sets the maximum amount of results returned (default: 1000).
        /// </summary>
        public int MaxResults { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public AnalyticsRealtimeDataOptions() {
            MaxResults = 1000;
        }

        /// <summary>
        /// Initializes a new instance with default options and based on the specified <code>profile</code>.
        /// </summary>
        /// <param name="profile">The profile.</param>
        public AnalyticsRealtimeDataOptions(AnalyticsProfile profile) : this() {
            if (profile == null) throw new ArgumentNullException("profile");
            ProfileId = profile.Id;
        }

        /// <summary>
        /// Initializes a new instance with default options and based on the profile with the specified <code>profileId</code>.
        /// </summary>
        /// <param name="profileId">The ID of the profile.</param>
        public AnalyticsRealtimeDataOptions(string profileId) : this() {
            ProfileId = profileId;
        }

        #endregion

        #region Methods

        public SocialQueryString GetQueryString() {
            SocialQueryString query = new SocialQueryString();
            if (!String.IsNullOrWhiteSpace(ProfileId)) query.Add("ids", (ProfileId.StartsWith("ga:") ? ProfileId : "ga:" + ProfileId));
            query.Add("metrics", Metrics == null ? "" : Metrics.ToString());
            if (Dimensions != null && Dimensions.Count > 0) query.Add("dimensions", Dimensions == null ? "" : Dimensions.ToString());
            if (Filters.HasBlocks) query.Add("filters", Filters.ToString());
            if (Sorting.HasFields) query.Add("sort", Sorting.ToString());
            if (MaxResults > 0 && MaxResults != 1000) query.Add("max-results", MaxResults + "");
            return query;
        }

        /// <summary>
        /// Adds the specified metric.
        /// </summary>
        /// <param name="metric">The metric to add.</param>
        public AnalyticsRealtimeDataOptions AddMetric(AnalyticsMetric metric) {
            if (Metrics == null) Metrics = new AnalyticsMetricCollection();
            Metrics.Add(metric);
            return this;
        }

        /// <summary>
        /// Adds the specified sequence of metrics.
        /// </summary>
        /// <param name="metrics">The metrics to add.</param>
        public AnalyticsRealtimeDataOptions AddMetrics(params AnalyticsMetric[] metrics) {
            if (Metrics == null) Metrics = new AnalyticsMetricCollection();
            Metrics.AddRange(metrics);
            return this;
        }

        /// <summary>
        /// Adds the specified dimension.
        /// </summary>
        /// <param name="dimension">The dimension to add.</param>
        public AnalyticsRealtimeDataOptions AddDimension(AnalyticsDimension dimension) {
            if (Dimensions == null) Dimensions = new AnalyticsDimensionCollection();
            Dimensions.Add(dimension);
            return this;
        }

        /// <summary>
        /// Adds the specified sequence of dimensions.
        /// </summary>
        /// <param name="dimensions">The dimensions to add.</param>
        public AnalyticsRealtimeDataOptions AddDimensions(params AnalyticsDimension[] dimensions) {
            if (Dimensions == null) Dimensions = new AnalyticsDimensionCollection();
            Dimensions.AddRange(dimensions);
            return this;
        }

        /// <summary>
        /// Adds the specified metric filter.
        /// </summary>
        /// <param name="filter">The filter to add.</param>
        public AnalyticsRealtimeDataOptions AddMetricFilter(AnalyticsMetricFilter filter) {
            _filters.Add(filter);
            return this;
        }

        /// <summary>
        /// Adds a metric filter with the specified information.
        /// </summary>
        /// <param name="metric">The metric.</param>
        /// <param name="op">The operator.</param>
        /// <param name="value">The value.</param>
        public AnalyticsRealtimeDataOptions AddMetricFilter(AnalyticsMetric metric, AnalyticsMetricOperator op, string value) {
            _filters.Add(new AnalyticsMetricFilter(metric, op, value));
            return this;
        }

        /// <summary>
        /// Adds the specified dimension filter.
        /// </summary>
        /// <param name="filter">The filter to add.</param>
        public AnalyticsRealtimeDataOptions AddDimensionFilter(AnalyticsDimensionFilter filter) {
            _filters.Add(filter);
            return this;
        }

        /// <summary>
        /// Adds a dimension filter with the specified information.
        /// </summary>
        /// <param name="dimension">The dimension.</param>
        /// <param name="op">The operator.</param>
        /// <param name="value">The value.</param>
        public AnalyticsRealtimeDataOptions AddDimensionFilter(AnalyticsDimension dimension, AnalyticsDimensionOperator op, string value) {
            _filters.Add(new AnalyticsDimensionFilter(dimension, op, value));
            return this;
        }

        #endregion

    }

}