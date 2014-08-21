using Skybrud.Social.Google.Analytics.Objects;

namespace Skybrud.Social.Google.Analytics.Interfaces {
    
    public interface IAnalyticsSortField {

        AnalyticsSortOrder Order { get; }

        IAnalyticsField Field { get; }

    }

}