using Skybrud.Social.Google.Analytics;

namespace Skybrud.Social.Google.OAuth {
    
    public static class GoogleScope {

        public const string OpenId = "openid";
        public const string Email = "email";
        public const string Profile = "profile";

        #region Analytics

        /// <summary>
        /// Read-only access to the Analytics API.
        /// </summary>
        public const string AnalyticsReadonly = AnalyticsScope.Readonly;

        /// <summary>
        /// Write access to the Analytics API.
        /// </summary>
        public const string AnalyticsWrite = AnalyticsScope.Write;

        /// <summary>
        /// View and manage user permissions for Analytics accounts.
        /// </summary>
        public const string AnalyticsManageUsers = AnalyticsScope.ManageUsers;

        #endregion

    }

}