using Skybrud.Social.Google.Analytics.Objects;

namespace Skybrud.Social.Google.Analytics.Interfaces {

    public interface IAnalyticsFilter : IAnalyticsFilterBlock {

        string Name { get; }
        string OperatorValue { get; }
        object Value { get; }
        
    }

}
