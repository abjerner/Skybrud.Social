using System;
using Skybrud.Social.GitHub.Scopes;

namespace Skybrud.Social.GitHub {

    /// <summary>
    /// Class representing a scope of the GitHub API.
    /// </summary>
    public class GitHubScope {

        // TODO: Move to the "Skybrud.Social.GitHub.Scopes" namespace for v1.0

        #region Constants
        
        /// <summary>
        /// Grants read-only access to public information (includes public user profile info,
        /// public repository info, and gists).
        /// </summary>
        [Obsolete("Use GitHubScopes.Default instead.")]
        public static readonly GitHubScope Default = GitHubScopes.Default;

        /// <summary>
        /// Grants read/write access to profile info only. Note that this scope includes
        /// <code>user:email</code> and <code>user:follow</code>.
        /// </summary>
        [Obsolete("Use GitHubScopes.User instead.")]
        public static readonly GitHubScope User = GitHubScopes.User;

        /// <summary>
        /// Grants read access to a user’s email addresses.
        /// </summary>
        [Obsolete("Use GitHubScopes.UserEmail instead.")]
        public static readonly GitHubScope UserEmail = GitHubScopes.UserEmail;

        /// <summary>
        /// Grants access to follow or unfollow other users.
        /// </summary>
        [Obsolete("Use GitHubScopes.UserFollow instead.")]
        public static readonly GitHubScope UserFollow = GitHubScopes.UserFollow;

        /// <summary>
        /// Grants read/write access to code, commit statuses, and deployment statuses for public
        /// repositories and organizations.
        /// </summary>
        [Obsolete("Use GitHubScopes.PublicRepo instead.")]
        public static readonly GitHubScope PublicRepo = GitHubScopes.PublicRepo;

        /// <summary>
        /// Grants read/write access to code, commit statuses, and deployment statuses for public
        /// and private repositories and organizations.
        /// </summary>
        [Obsolete("Use GitHubScopes.Repo instead.")]
        public static readonly GitHubScope Repo = GitHubScopes.Repo;

        /// <summary>
        /// Grants read/write access to public and private repository commit statuses. This scope
        /// is only necessary to grant other users or services access to private repository commit
        /// statuses without granting access to the code.
        /// </summary>
        [Obsolete("Use GitHubScopes.RepoStatus instead.")]
        public static readonly GitHubScope RepoStatus = GitHubScopes.RepoStatus;

        /// <summary>
        /// Grants access to delete adminable repositories.
        /// </summary>
        [Obsolete("Use GitHubScopes.DeleteRepo instead.")]
        public static readonly GitHubScope DeleteRepo = GitHubScopes.DeleteRepo;

        /// <summary>
        /// Grants read access to a user’s notifications. <code>repo</code> also provides this access.
        /// </summary>
        [Obsolete("Use GitHubScopes.Notifications instead.")]
        public static readonly GitHubScope Notifications = GitHubScopes.Notifications;

        /// <summary>
        /// Grants write access to gists.
        /// </summary>
        [Obsolete("Use GitHubScopes.Gist instead.")]
        public static readonly GitHubScope Gist = GitHubScopes.Gist;

        #endregion

        #region Properties

        // The name of the scope
        public string Name { get; private set; }

        // The name of the scope
        public string Description { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default and private constructor.
        /// </summary>
        /// <param name="name">The name of the scope.</param>
        /// <param name="description">The description of the scope.</param>
        internal GitHubScope(string name, string description = null) {
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
        /// Adding two instance of FacebookScope will result in a FacebookScopeCollection containing both scopes.
        /// </summary>
        /// <param name="left">The left scope.</param>
        /// <param name="right">The right scope.</param>
        public static GitHubScopeCollection operator +(GitHubScope left, GitHubScope right) {
            return new GitHubScopeCollection(left, right);
        }

        #endregion

    }

}