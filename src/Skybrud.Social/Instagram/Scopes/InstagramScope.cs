using System;
using System.Collections.Generic;

namespace Skybrud.Social.Instagram.Scopes {
    
    /// <summary>
    /// Class representing a scope of the Instagram API.
    /// </summary>
    public class InstagramScope {

        #region Private fields

        private static readonly Dictionary<string, InstagramScope> Scopes = new Dictionary<string, InstagramScope>();

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

        #region Constructors

        /// <summary>
        /// Default and private constructor.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        /// <param name="description">The description of the scope.</param>
        public InstagramScope(string name, string description = null) {
            Name = name;
            Description = String.IsNullOrWhiteSpace(description) ? null : description.Trim();
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets the name of the scope.
        /// </summary>
        /// <returns>Returns the name of the scope.</returns>
        public override string ToString() {
            return Name;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Registers a scope in the internal dictionary.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        /// <param name="description">The description of the scope.</param>
        internal static InstagramScope RegisterScope(string name, string description = null) {
            InstagramScope scope = new InstagramScope(name, description);
            Scopes.Add(scope.Name, scope);
            return scope;
        }

        /// <summary>
        /// Attempts to get a scope with the specified <code>name</code>.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        /// <returns>Gets a scope matching the specified <code>name</code>, or <code>null</code> if not found-</returns>
        public static InstagramScope GetScope(string name) {
            InstagramScope scope;
            return Scopes.TryGetValue(name, out scope) ? scope : null;
        }

        /// <summary>
        /// Gets whether the scope is a known scope.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        /// <returns>Returns <code>true</code> if the specified <code>name</code> matches a known
        /// scope, otherwise <code>false</code>.</returns>
        public static bool ScopeExists(string name) {
            return Scopes.ContainsKey(name);
        }

        #endregion
        
        #region Operators

        /// <summary>
        /// Adding two instances of <code>FacebookScope</code> will result in a
        /// <code>FacebookScopeCollection</code> containing both scopes.
        /// </summary>
        /// <param name="left">The left scope.</param>
        /// <param name="right">The right scope.</param>
        public static InstagramScopeCollection operator +(InstagramScope left, InstagramScope right) {
            return new InstagramScopeCollection(left, right);
        }

        #endregion

    }

}
