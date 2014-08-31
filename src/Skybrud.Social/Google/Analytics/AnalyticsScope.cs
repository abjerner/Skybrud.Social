namespace Skybrud.Social.Google.Analytics {
    
    /// <summary>
    /// Scopes related to the Google Analytics API.
    /// </summary>
    public static class AnalyticsScope {
        
        /// <summary>
        /// Read-only access to the Analytics API.
        /// </summary>
        public const string Readonly = "https://www.googleapis.com/auth/analytics.readonly";
        
        /// <summary>
        /// Write access to the Analytics API.
        /// </summary>
        public const string Write = "https://www.googleapis.com/auth/analytics";
        
        /// <summary>
        /// View and manage user permissions for Analytics accounts.
        /// </summary>
        public const string ManageUsers = "https://www.googleapis.com/auth/analytics.readonly";

    }

}
