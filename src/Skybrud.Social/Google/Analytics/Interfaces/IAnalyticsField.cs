namespace Skybrud.Social.Google.Analytics.Interfaces {
    
    /// <summary>
    /// Interface representing a field (dimension or metric) in the Analytics API.
    /// </summary>
    public interface IAnalyticsField {
    
        /// <summary>
        /// Gets the name of the field.
        /// </summary>
        string Name { get; }
    
    }

}