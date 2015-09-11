using System.Collections.Generic;

namespace Skybrud.Social.Microsoft.Scopes {

    /// <summary>
    /// Class representing a scope of the various Microsoft APIs.
    /// </summary>
    public class MicrosoftScope {

        #region Private fields

        private static readonly Dictionary<string, MicrosoftScope> Scopes = new Dictionary<string, MicrosoftScope>();

        #endregion

        #region Properties

        /// <summary>
        /// Gets the name of the scope.
        /// </summary>
        public string Name { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new scope based on the specified <code>name</code> a.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        public MicrosoftScope(string name) {
            Name = name;
        }

        #endregion

        #region Member methods

        public override string ToString() {
            return Name;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Registers a scope in the internal dictionary.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        internal static MicrosoftScope RegisterScope(string name) {
            MicrosoftScope scope = new MicrosoftScope(name);
            Scopes.Add(scope.Name, scope);
            return scope;
        }

        /// <summary>
        /// Attempts to get a scope with the specified <code>name</code>.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        /// <returns>Gets a scope matching the specified <code>name</code>, or <code>null</code> if not found-</returns>
        public static MicrosoftScope GetScope(string name) {
            MicrosoftScope scope;
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
        /// Adding two instances of <code>MicrosoftScope</code> will result in a
        /// <code>MicrosoftScopeCollection</code> containing both scopes.
        /// </summary>
        /// <param name="left">The left scope.</param>
        /// <param name="right">The right scope.</param>
        public static MicrosoftScopeCollection operator +(MicrosoftScope left, MicrosoftScope right) {
            return new MicrosoftScopeCollection(left, right);
        }

        #endregion

    }

}