using Skybrud.Social.Google.Analytics.Interfaces;

namespace Skybrud.Social.Google.Analytics.Objects {
    
    public class AnalyticsFilterOperator : IAnalyticsFilterBlock {

        public string Operator { get; private set; }

        public static readonly AnalyticsFilterOperator And = new AnalyticsFilterOperator(";");

        public static readonly AnalyticsFilterOperator Or = new AnalyticsFilterOperator(",");
        
        private AnalyticsFilterOperator(string op) {
            Operator = op;
        }
        
        public override string ToString() {
            return Operator;
        }
    
    }

}