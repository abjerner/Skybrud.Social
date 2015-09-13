using System;
using System.Collections.Generic;
using System.Linq;

namespace Skybrud.Social.Slack.Scopes {

    /// <summary>
    /// Class representing a scope of the Slack API.
    /// </summary>
    public class SlackScope {

        #region Private fields

        private static Dictionary<string, SlackScope> _lookup;

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

        /// <summary>
        /// Gets the lookup dictionary of registered scopes.
        /// </summary>
        private static Dictionary<string, SlackScope> Lookup {
            get {
                if (_lookup == null) {
                    _lookup = new Dictionary<string, SlackScope>();
                    _lookup.Add(SlackScopes.Identify.Name, SlackScopes.Identify);
                    _lookup.Add(SlackScopes.Read.Name, SlackScopes.Read);
                    _lookup.Add(SlackScopes.Post.Name, SlackScopes.Post);
                    _lookup.Add(SlackScopes.Client.Name, SlackScopes.Client);
                    _lookup.Add(SlackScopes.Admin.Name, SlackScopes.Admin);
                }
                return _lookup;
            }
        }

        /// <summary>
        /// Gets an array of registered scopes.
        /// </summary>
        public static SlackScope[] Scopes {
            get { return Lookup.Values.ToArray(); }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new scope based on the specified <code>name</code> and <code>description</code>.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        /// <param name="description">The description of the scope.</param>
        internal SlackScope(string name, string description) {
            Name = name;
            Description = description;
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
        /// <param name="scope">The scope to be registered.</param>
        public static SlackScope RegisterScope(SlackScope scope) {
            if (scope == null) throw new ArgumentNullException("scope");
            if (Lookup.ContainsKey(scope.Name)) throw new ArgumentException("A scope with the specified name has already been registered.", "scope");
            Lookup.Add(scope.Name, scope);
            return scope;
        }

        /// <summary>
        /// Registers a scope in the internal dictionary.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        public static SlackScope RegisterScope(string name) {
            return RegisterScope(name, null);
        }

        /// <summary>
        /// Registers a scope in the internal dictionary.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        /// <param name="description">The description of the scope.</param>
        public static SlackScope RegisterScope(string name, string description) {
            if (Lookup.ContainsKey(name)) throw new ArgumentException("A scope with the specified name \"" + name + "\" has already been registered.", "name");
            SlackScope scope = new SlackScope(name, description);
            Lookup.Add(scope.Name, scope);
            return scope;
        }

        /// <summary>
        /// Attempts to get a scope with the specified <code>name</code>.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        /// <returns>Gets a scope matching the specified <code>name</code>, or <code>null</code> if not found-</returns>
        public static SlackScope GetScope(string name) {
            SlackScope scope;
            return Lookup.TryGetValue(name, out scope) ? scope : null;
        }

        /// <summary>
        /// Gets whether the scope is a known scope.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        /// <returns>Returns <code>true</code> if the specified <code>name</code> matches a known
        /// scope, otherwise <code>false</code>.</returns>
        public static bool ScopeExists(string name) {
            return Lookup.ContainsKey(name);
        }

        #endregion

        #region Operators

        /// <summary>
        /// Adding two instances of <code>SlackScope</code> will result in a
        /// <code>SlackScopeCollection</code> containing both scopes.
        /// </summary>
        /// <param name="left">The left scope.</param>
        /// <param name="right">The right scope.</param>
        public static SlackScopeCollection operator +(SlackScope left, SlackScope right) {
            return new SlackScopeCollection(left, right);
        }

        #endregion

    }

}