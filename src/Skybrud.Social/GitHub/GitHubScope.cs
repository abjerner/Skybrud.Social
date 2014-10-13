namespace Skybrud.Social.GitHub {

    public class GitHubScope {

        #region Constants
        
        /// <summary>
        /// Grants read-only access to public information (includes public user profile info,
        /// public repository info, and gists).
        /// </summary>
        public static readonly GitHubScope Default = new GitHubScope(
            "",
            "Grants read-only access to public information (includes public user profile info, " +
            "public repository info, and gists)."
        );

        /// <summary>
        /// Grants read/write access to profile info only. Note that this scope includes
        /// <code>user:email</code> and <code>user:follow</code>.
        /// </summary>
        public static readonly GitHubScope User = new GitHubScope(
            "user",
            "Grants read/write access to profile info only. Note that this scope includes user:email and user:follow."
        );

        /// <summary>
        /// Grants read access to a user’s email addresses.
        /// </summary>
        public static readonly GitHubScope UserEmail = new GitHubScope(
            "user:email",
            "Grants read access to a user’s email addresses."
        );

        /// <summary>
        /// Grants access to follow or unfollow other users.
        /// </summary>
        public static readonly GitHubScope UserFollow = new GitHubScope(
            "user:follow",
            "Grants access to follow or unfollow other users."
        );

        /// <summary>
        /// Grants read/write access to code, commit statuses, and deployment statuses for public
        /// repositories and organizations.
        /// </summary>
        public static readonly GitHubScope PublicRepo = new GitHubScope(
            "public_repo",
            "Grants read/write access to code, commit statuses, and deployment statuses for " +
            "public repositories and organizations."
        );

        /// <summary>
        /// Grants read/write access to code, commit statuses, and deployment statuses for public
        /// and private repositories and organizations.
        /// </summary>
        public static readonly GitHubScope Repo = new GitHubScope(
            "repo",
            "Grants read/write access to code, commit statuses, and deployment statuses for " +
            "public and private repositories and organizations."
        );

        // TODO: Add scope "repo_deployment"

        /// <summary>
        /// Grants read/write access to public and private repository commit statuses. This scope
        /// is only necessary to grant other users or services access to private repository commit
        /// statuses without granting access to the code.
        /// </summary>
        public static readonly GitHubScope RepoStatus = new GitHubScope(
            "repo:status",
            "Grants read/write access to public and private repository commit statuses. This " +
            "scope is only necessary to grant other users or services access to private " +
            "repository commit statuses without granting access to the code."
        );

        /// <summary>
        /// Grants access to delete adminable repositories.
        /// </summary>
        public static readonly GitHubScope DeleteRepo = new GitHubScope(
            "delete_repo",
            "Grants access to delete adminable repositories."
        );

        /// <summary>
        /// Grants read access to a user’s notifications. <code>repo</code> also provides this access.
        /// </summary>
        public static readonly GitHubScope Notifications = new GitHubScope(
            "notifications",
            "Grants read access to a user’s notifications. repo also provides this access."
        );

        /// <summary>
        /// Grants write access to gists.
        /// </summary>
        public static readonly GitHubScope Gist = new GitHubScope(
            "gist",
            "Grants write access to gists."
        );

        // TODO: Add scope "read:repo_hook"
        // TODO: Add scope "write:repo_hook"
        // TODO: Add scope "admin:repo_hook"
        // TODO: Add scope "read:org"
        // TODO: Add scope "write:org"
        // TODO: Add scope "admin:org"
        // TODO: Add scope "read:public_key"
        // TODO: Add scope "write:public_key"
        // TODO: Add scope "admin:public_key"

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