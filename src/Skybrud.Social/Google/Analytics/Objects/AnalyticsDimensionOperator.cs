using Skybrud.Social.Google.Analytics.Interfaces;

namespace Skybrud.Social.Google.Analytics.Objects {

    public class AnalyticsDimensionOperator : IAnalyticsFieldOperator {

        #region Static properties

        public static readonly AnalyticsDimensionOperator ExactMatch = new AnalyticsDimensionOperator("==");
        public static readonly AnalyticsDimensionOperator DoesNotMatch = new AnalyticsDimensionOperator("!=");
        public static readonly AnalyticsDimensionOperator ContainsSubstring = new AnalyticsDimensionOperator("=@");
        public static readonly AnalyticsDimensionOperator DoesNotContainSubstring = new AnalyticsDimensionOperator("!@");
        public static readonly AnalyticsDimensionOperator RegexMatch = new AnalyticsDimensionOperator("=~");
        public static readonly AnalyticsDimensionOperator RegexNotMatch = new AnalyticsDimensionOperator("!~");

        #endregion

        #region Properties

        public string Value { get; private set; }

        #endregion

        #region Constructor

        private AnalyticsDimensionOperator(string value) {
            Value = value;
        }

        #endregion

        #region Operator overloading

        public static implicit operator AnalyticsDimensionOperator(string value) {
            return new AnalyticsDimensionOperator(value);
        }

        #endregion

    }

}