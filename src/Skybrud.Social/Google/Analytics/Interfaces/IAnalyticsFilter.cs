namespace Skybrud.Social.Google.Analytics.Interfaces {

    /// <summary>
    /// Interface representing a filter in the Analytics API.
    /// </summary>
    public interface IAnalyticsFilter : IAnalyticsFilterBlock {

        /// <summary>
        /// Gets the name of the filter.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the operator value of the filter.
        /// </summary>
        string OperatorValue { get; }

        /// <summary>
        /// Gets the value of the operator.
        /// </summary>
        object Value { get; }
        
    }

}
