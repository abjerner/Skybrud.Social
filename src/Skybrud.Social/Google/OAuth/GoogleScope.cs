using System;

namespace Skybrud.Social.Google.OAuth {
    
    /// <summary>
    /// Class representing a scope in the Google ecosystem.
    /// </summary>
    public class GoogleScope {

        #region Constants (global Google scopes)

        /// <see>
        ///     <cref>https://developers.google.com/+/web/api/rest/oauth#openid</cref>
        /// </see>
        [Obsolete("Use GoogleScopes.OpenId instead.")]
        public static readonly GoogleScope OpenId = GoogleScopes.OpenId;

        /// <summary>
        /// Scope giving access the email address of the authenticated user.
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/+/web/api/rest/oauth#email</cref>
        /// </see>
        [Obsolete("Use GoogleScopes.Email instead.")]
        public static readonly GoogleScope Email = GoogleScopes.Email;

        /// <summary>
        /// Scope giving access to profile information of the authenticated user.
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/+/web/api/rest/oauth#profile</cref>
        /// </see>
        [Obsolete("Use GoogleScopes.Profile instead.")]
        public static readonly GoogleScope Profile = GoogleScopes.Profile;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the name of the scope.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the description of the scope.
        /// </summary>
        public string Description { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new scope with the specified <code>name</code>.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        public GoogleScope(string name) {
            Name = name;
        }

        /// <summary>
        /// Initializes a new scope with the specified <code>name</code> and <code>description</code>.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        /// <param name="description">The description of the scope.</param>
        public GoogleScope(string name, string description) {
            Name = name;
            Description = description;
        }

        #endregion
        
        #region Member methods

        public override string ToString() {
            return Name;
        }

        #endregion
        
        #region Operators

        /// <summary>
        /// Adding two instance of <code>GoogleScope</code> will result in a <code>GoogleScopeCollection</code>
        /// containing both scopes.
        /// </summary>
        /// <param name="left">The left scope.</param>
        /// <param name="right">The right scope.</param>
        public static GoogleScopeCollection operator +(GoogleScope left, GoogleScope right) {
            return new GoogleScopeCollection(left, right);
        }

        #endregion

    }

}