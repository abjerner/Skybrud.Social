using System;
using Skybrud.Social.Google.Analytics.Interfaces;

namespace Skybrud.Social.Google.Analytics.Objects {

    public class AnalyticsMetricFilter : IAnalyticsFilter {

        #region Private fields

        private AnalyticsMetric _metric;
        private AnalyticsMetricOperator _operator;

        #endregion

        #region Properties

        public string Name {
            get { return Metric.Name; }
        }

        public string OperatorValue {
            get { return Operator.Value; }
        }

        public AnalyticsMetric Metric {
            get { return _metric; }
            set {
                if (value == null) throw new ArgumentNullException("value");
                _metric = value;
            }
        }
        
        public AnalyticsMetricOperator Operator {
            get { return _operator; }
            set {
                if (value == null) throw new ArgumentNullException("value");
                _operator = value;
            }
        }

        public object Value { get; set; }

        #endregion

        #region Constructor

        public AnalyticsMetricFilter(AnalyticsMetric metric, AnalyticsMetricOperator op, object value) {

            if (metric == null) throw new ArgumentNullException("metric");
            if (op == null) throw new ArgumentNullException("op");
         
            Metric = metric;
            Operator = op;
            Value = value;

        }

        #endregion

    }

}