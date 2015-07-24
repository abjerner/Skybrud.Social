using System;
using Skybrud.Social.Google.OAuth;

namespace Skybrud.Social.Google.Analytics {
    
    /// <summary>
    /// Class representing a scope in the Google Analytics API.
    /// </summary>
    public class AnalyticsScope : GoogleScope {
        
        #region Constants (Analytics-related scopes)

        /// <summary>
        /// Read-only access to the Analytics API.
        /// </summary>
        [Obsolete("Use AnalyticsScopes.Readonly instead.")]
        public static readonly AnalyticsScope Readonly = AnalyticsScopes.Readonly;

        /// <summary>
        /// Write access to the Analytics API.
        /// </summary>
        [Obsolete("Use AnalyticsScopes.Write instead.")]
        public static readonly AnalyticsScope Write = AnalyticsScopes.Write;

        /// <summary>
        /// Edit Google Analytics management entities.
        /// </summary>
        [Obsolete("Use AnalyticsScopes.Edit instead.")]
        public static readonly AnalyticsScope Edit = AnalyticsScopes.Edit;

        /// <summary>
        /// View and manage user permissions for Analytics accounts.
        /// </summary>
        [Obsolete("Use AnalyticsScopes.ManageUsers instead.")]
        public static readonly AnalyticsScope ManageUsers = AnalyticsScopes.ManageUsers;

        /// <summary>
        /// View Google Analytics user permissions.
        /// </summary>
        [Obsolete("Use AnalyticsScopes.ManageUsersReadonly instead.")]
        public static readonly AnalyticsScope ManageUsersReadonly = AnalyticsScopes.ManageUsersReadonly;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new scope with the specified <code>name</code>.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        public AnalyticsScope(string name) : base(name) { }

        /// <summary>
        /// Initializes a new scope with the specified <code>name</code> and <code>description</code>.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        /// <param name="description">The description of the scope.</param>
        public AnalyticsScope(string name, string description) : base(name, description) { }

        #endregion

    }

}