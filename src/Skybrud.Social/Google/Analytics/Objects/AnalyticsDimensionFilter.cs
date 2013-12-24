using System;
using Skybrud.Social.Google.Analytics.Interfaces;

namespace Skybrud.Social.Google.Analytics.Objects {

    public class AnalyticsDimensionFilter : IAnalyticsFilter {

        #region Private fields

        private AnalyticsDimension _dimension;
        private AnalyticsDimensionOperator _operator;

        #endregion

        #region Properties

        public AnalyticsDimension Dimension {
            get { return _dimension; }
            set {
                if (value == null) throw new ArgumentNullException("value");
                _dimension = value;
            }
        }

        public AnalyticsDimensionOperator Operator {
            get { return _operator; }
            set {
                if (value == null) throw new ArgumentNullException("value");
                _operator = value;
            }
        }

        public string Value { get; set; }

        #endregion

        #region Constructor

        public AnalyticsDimensionFilter(AnalyticsDimension dimension, AnalyticsDimensionOperator op, string value) {

            if (dimension == null) throw new ArgumentNullException("dimension");
            if (op == null) throw new ArgumentNullException("op");

            Dimension = dimension;
            Operator = op;
            Value = value;

        }

        #endregion
    
    }

}