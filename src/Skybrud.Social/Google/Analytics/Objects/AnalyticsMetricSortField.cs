using System;
using Skybrud.Social.Google.Analytics.Interfaces;

namespace Skybrud.Social.Google.Analytics.Objects {
    
    public class AnalyticsMetricSortField : IAnalyticsSortField {

        #region Properties

        public AnalyticsSortOrder Order { get; set; }

        public IAnalyticsField Field {
            get { return Metric; }
        }

        public AnalyticsMetric Metric { get; set; }

        #endregion

        #region Constructors

        public AnalyticsMetricSortField() {
            // Default constructor
        }

        public AnalyticsMetricSortField(AnalyticsMetric metric, AnalyticsSortOrder order) {
            if (metric == null) throw new ArgumentNullException("metric");
            Metric = metric;
            Order = order;
        }

        #endregion

    }

}