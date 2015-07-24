using Skybrud.Social.Google.Analytics.Objects;

namespace Skybrud.Social.Google.Analytics.Interfaces {
    
    /// <summary>
    /// Interface representing a sort field in the Analytics API.
    /// </summary>
    public interface IAnalyticsSortField {

        /// <summary>
        /// Gets the order of the field.
        /// </summary>
        AnalyticsSortOrder Order { get; }

        /// <summary>
        /// Gets the field.
        /// </summary>
        IAnalyticsField Field { get; }

    }

}