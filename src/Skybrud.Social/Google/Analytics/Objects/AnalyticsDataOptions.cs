using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Skybrud.Social.Google.Analytics.Interfaces;

namespace Skybrud.Social.Google.Analytics.Objects {

    public class AnalyticsDataOptions {

        #region Private fields

        private List<IAnalyticsFilter> _filters = new List<IAnalyticsFilter>();

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the start date from when to pull data.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets the metrics.
        /// </summary>
        public AnalyticsMetricCollection Metrics { get; set; }

        /// <summary>
        /// Gets or sets the dimensions.
        /// </summary>
        public AnalyticsDimensionCollection Dimensions { get; set; }

        /// <summary>
        /// Gets or sets the array of filters.
        /// </summary>
        public IAnalyticsFilter[] Filters {
            get { return _filters.ToArray(); }
            set { _filters = (value == null ? new List<IAnalyticsFilter>() : value.ToList()); }
        }

        #endregion

        #region Constructors

        public AnalyticsDataOptions() {
            StartDate = DateTime.Now.Subtract(TimeSpan.FromDays(31));
            EndDate = DateTime.Now;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Generates a NameValueCollection with all present arguments.
        /// </summary>
        /// <param name="profileId">The ID of the profile.</param>
        /// <param name="accessToken">A valid access token.</param>
        /// <returns></returns>
        public NameValueCollection ToNameValueCollection(string profileId, string accessToken) {
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("ids", (profileId.StartsWith("ga:") ? profileId : "ga:" + profileId));
            nvc.Add("start-date", StartDate.ToString("yyyy-MM-dd"));
            nvc.Add("end-date", EndDate.ToString("yyyy-MM-dd"));
            nvc.Add("metrics", Metrics == null ? "" : Metrics.ToString());
            nvc.Add("dimensions", Dimensions == null ? "" : Dimensions.ToString());
            nvc.Add("access_token", accessToken);
            return nvc;
        }

        /// <summary>
        /// Adds the specified metric.
        /// </summary>
        /// <param name="metric">The metric to add.</param>
        public AnalyticsDataOptions AddMetric(AnalyticsMetric metric) {
            if (Metrics == null) Metrics = new AnalyticsMetricCollection();
            Metrics.Add(metric);
            return this;
        }

        /// <summary>
        /// Adds the specified sequence of metrics.
        /// </summary>
        /// <param name="metrics">The metrics to add.</param>
        public AnalyticsDataOptions AddMetrics(params AnalyticsMetric[] metrics) {
            if (Metrics == null) Metrics = new AnalyticsMetricCollection();
            Metrics.AddRange(metrics);
            return this;
        }

        /// <summary>
        /// Adds the specified dimension.
        /// </summary>
        /// <param name="dimension">The dimension to add.</param>
        public AnalyticsDataOptions AddDimension(AnalyticsDimension dimension) {
            if (Dimensions == null) Dimensions = new AnalyticsDimensionCollection();
            Dimensions.Add(dimension);
            return this;
        }

        /// <summary>
        /// Adds the specified sequence of dimensions.
        /// </summary>
        /// <param name="dimensions">The dimensions to add.</param>
        public AnalyticsDataOptions AddDimensions(params AnalyticsDimension[] dimensions) {
            if (Dimensions == null) Dimensions = new AnalyticsDimensionCollection();
            Dimensions.AddRange(dimensions);
            return this;
        }

        /// <summary>
        /// Adds the specified metric filter.
        /// </summary>
        /// <param name="filter">The filter to add.</param>
        public AnalyticsDataOptions AddMetricFilter(AnalyticsMetricFilter filter) {
            _filters.Add(filter);
            return this;
        }

        /// <summary>
        /// Adds a metric filter with the specified information.
        /// </summary>
        /// <param name="metric">The metric.</param>
        /// <param name="op">The operator.</param>
        /// <param name="value">The value.</param>
        public AnalyticsDataOptions AddMetricFilter(AnalyticsMetric metric, AnalyticsMetricOperator op, string value) {
            _filters.Add(new AnalyticsMetricFilter(metric, op, value));
            return this;
        }

        /// <summary>
        /// Adds the specified dimension filter.
        /// </summary>
        /// <param name="filter">The filter to add.</param>
        public AnalyticsDataOptions AddDimensionFilter(AnalyticsDimensionFilter filter) {
            _filters.Add(filter);
            return this;
        }

        /// <summary>
        /// Adds a dimension filter with the specified information.
        /// </summary>
        /// <param name="dimension">The dimension.</param>
        /// <param name="op">The operator.</param>
        /// <param name="value">The value.</param>
        public AnalyticsDataOptions AddDimensionFilter(AnalyticsDimension dimension, AnalyticsDimensionOperator op, string value) {
            _filters.Add(new AnalyticsDimensionFilter(dimension, op, value));
            return this;
        }

        #endregion

    }
}