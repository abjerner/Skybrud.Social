using Skybrud.Social.Google.OAuth;

namespace Skybrud.Social.Google.Analytics {
    
    /// <summary>
    /// Scopes related to the Google Analytics API.
    /// </summary>
    public class AnalyticsScope : GoogleScope {
        
        #region Constants (Analytics-related scopes)

        /// <summary>
        /// Read-only access to the Analytics API.
        /// </summary>
        public static readonly AnalyticsScope Readonly = new AnalyticsScope(
            "https://www.googleapis.com/auth/analytics.readonly",
            "Read-only access to the Analytics API."
        );

        /// <summary>
        /// Write access to the Analytics API.
        /// </summary>
        public static readonly AnalyticsScope Write = new AnalyticsScope(
            "https://www.googleapis.com/auth/analytics",
            "Write access to the Analytics API."
        );

        /// <summary>
        /// Edit Google Analytics management entities.
        /// </summary>
        public static readonly AnalyticsScope Edit = new AnalyticsScope(
            "https://www.googleapis.com/auth/analytics.edit",
            "Edit Google Analytics management entities."
        );

        /// <summary>
        /// View and manage user permissions for Analytics accounts.
        /// </summary>
        public static readonly AnalyticsScope ManageUsers = new AnalyticsScope(
            "https://www.googleapis.com/auth/analytics.readonly",
            "View and manage user permissions for Analytics accounts."
        );

        /// <summary>
        /// View Google Analytics user permissions.
        /// </summary>
        public static readonly AnalyticsScope ManageUsersReadonly = new AnalyticsScope(
            "https://www.googleapis.com/auth/analytics.manage.users.readonly",
            "View Google Analytics user permissions."
        );

        #endregion

        #region Constructors

        public AnalyticsScope(string name) : base(name) { }

        public AnalyticsScope(string name, string description) : base(name, description) { }

        #endregion

    }

}
