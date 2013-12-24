using Skybrud.Social.Google.Analytics.Interfaces;

namespace Skybrud.Social.Google.Analytics.Objects {
    
    public class AnalyticsMetricOperator : IAnalyticsFieldOperator {

        #region Static properties

        public new static readonly AnalyticsMetricOperator Equals = new AnalyticsMetricOperator("==");
        public static readonly AnalyticsMetricOperator DoesNotEqual = new AnalyticsMetricOperator("!=");
        public static readonly AnalyticsMetricOperator GreaterThan = new AnalyticsMetricOperator("=@");
        public static readonly AnalyticsMetricOperator LessThan = new AnalyticsMetricOperator("!@");
        public static readonly AnalyticsMetricOperator GreaterThanOrEqualTo = new AnalyticsMetricOperator("=~");
        public static readonly AnalyticsMetricOperator LessThanOrEqualTo = new AnalyticsMetricOperator("!~");

        #endregion

        #region Properties

        public string Value { get; private set; }

        #endregion

        #region Constructor

        private AnalyticsMetricOperator(string value) {
            Value = value;
        }

        #endregion

        #region Operator overloading

        public static implicit operator AnalyticsMetricOperator(string value) {
            return new AnalyticsMetricOperator(value);
        }

        #endregion

    }

}