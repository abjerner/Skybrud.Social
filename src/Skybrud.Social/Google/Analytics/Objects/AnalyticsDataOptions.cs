using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Skybrud.Social.Google.Analytics.Interfaces;

namespace Skybrud.Social.Google.Analytics.Objects {

    public class AnalyticsDataOptions {

        private List<IAnalyticsFilter> _filters = new List<IAnalyticsFilter>(); 

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public AnalyticsMetricCollection Metrics { get; set; }
        public AnalyticsDimensionCollection Dimensions { get; set; }

        public IAnalyticsFilter[] Filters {
            get { return _filters.ToArray(); }
            set { _filters = (value == null ? new List<IAnalyticsFilter>() : value.ToList()); }
        }

        public AnalyticsDataOptions() {
            StartDate = DateTime.Now.Subtract(TimeSpan.FromDays(31));
            EndDate = DateTime.Now;
        }

        public NameValueCollection ToNameValueCollection(string profileId, string accessToken) {
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("ids", "ga:" + profileId);
            nvc.Add("start-date", StartDate.ToString("yyyy-MM-dd"));
            nvc.Add("end-date", EndDate.ToString("yyyy-MM-dd"));
            nvc.Add("metrics", Metrics == null ? "" : Metrics.ToString());
            nvc.Add("dimensions", Dimensions == null ? "" : Dimensions.ToString());
            nvc.Add("access_token", accessToken);
            return nvc;
        }

        public AnalyticsDataOptions AddMetric(AnalyticsMetric metric) {
            if (Metrics == null) Metrics = new AnalyticsMetricCollection();
            Metrics.Add(metric);
            return this;
        }

        public AnalyticsDataOptions AddMetrics(params AnalyticsMetric[] metrics) {
            if (Metrics == null) Metrics = new AnalyticsMetricCollection();
            Metrics.AddRange(metrics);
            return this;
        }

        public AnalyticsDataOptions AddDimension(AnalyticsDimension dimension) {
            if (Dimensions == null) Dimensions = new AnalyticsDimensionCollection();
            Dimensions.Add(dimension);
            return this;
        }

        public AnalyticsDataOptions AddDimensions(params AnalyticsDimension[] dimensions) {
            if (Dimensions == null) Dimensions = new AnalyticsDimensionCollection();
            Dimensions.AddRange(dimensions);
            return this;
        }

        public AnalyticsDataOptions AddMetricFilter(AnalyticsMetricFilter filter) {
            _filters.Add(filter);
            return this;
        }

        public AnalyticsDataOptions AddMetricFilter(AnalyticsMetric metric, AnalyticsMetricOperator op, string value) {
            _filters.Add(new AnalyticsMetricFilter(metric, op, value));
            return this;
        }

        public AnalyticsDataOptions AddDimensionFilter(AnalyticsDimensionFilter filter) {
            _filters.Add(filter);
            return this;
        }

        public AnalyticsDataOptions AddDimensionFilter(AnalyticsDimension dimension, AnalyticsDimensionOperator op, string value) {
            _filters.Add(new AnalyticsDimensionFilter(dimension, op, value));
            return this;
        }

    }
}