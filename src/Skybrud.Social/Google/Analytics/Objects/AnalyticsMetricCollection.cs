using System;
using System.Collections.Generic;
using System.Linq;

namespace Skybrud.Social.Google.Analytics.Objects {
    
    public class AnalyticsMetricCollection {

        private List<AnalyticsMetric> _list = new List<AnalyticsMetric>();

        public int Count {
            get { return _list.Count; }
        }

        #region Constructors

        public AnalyticsMetricCollection(params AnalyticsMetric[] metrics) {
            _list.AddRange(metrics);
        }
        
        public AnalyticsMetricCollection(IEnumerable<AnalyticsMetric> metrics) {
            _list.AddRange(metrics);
        }

        #endregion

        #region Methods

        public void Add(AnalyticsMetric metric) {
            _list.Add(metric);
        }

        public void AddRange(IEnumerable<AnalyticsMetric> metrics) {
            _list.AddRange(metrics);
        }

        public AnalyticsMetric[] ToArray() {
            return _list.ToArray();
        }

        public string[] ToStringArray() {
            return (from metric in _list select metric.Name).ToArray();
        }

        public override string ToString() {
            return String.Join(",", from metric in _list select metric.Name);
        }

        #endregion

        #region Operator overloading

        public static implicit operator AnalyticsMetricCollection(AnalyticsMetric metric) {
            return new AnalyticsMetricCollection(metric);
        }

        public static implicit operator AnalyticsMetricCollection(AnalyticsMetric[] metrics) {
            return new AnalyticsMetricCollection(metrics);
        }

        public static AnalyticsMetricCollection operator +(AnalyticsMetricCollection left, AnalyticsMetric right) {
            left.Add(right);
            return left;
        }

        public static implicit operator AnalyticsMetricCollection(string[] metrics) {
            return new AnalyticsMetricCollection(from AnalyticsMetric metric in metrics select metric);
        }

        #endregion

    }

}
