using System;

namespace Skybrud.Social.GitHub {
    
    [Flags]
    public enum GitHubScope {
        
        /// <summary>
        /// Public read-only access (includes public user profile info, public repo info, and gists).
        /// </summary>
        Default = 0,

        /// <summary>
        /// Read/write access to profile info only. Note: this scope includes user:email and user:follow.
        /// </summary>
        User = 1,

        /// <summary>
        /// Read access to a user’s email addresses.
        /// </summary>
        UserEmail = 2,

        /// <summary>
        /// Access to follow or unfollow other users.
        /// </summary>
        UserFollow = 4,

        /// <summary>
        /// Read/write access to public repos and organizations.
        /// </summary>
        PublicRepo = 8,

        /// <summary>
        /// Read/write access to public and private repos and organizations.
        /// </summary>
        Repo = 16, 

        /// <summary>
        /// Read/write access to public and private repository commit statuses. This scope is only necessary to grant
        /// other users or services access to private repository commit statuses without granting access to the code.
        /// The repo and public_repo scopes already include access to commit status for private and public
        /// repositories respectively.
        /// </summary>
        RepoStatus = 32,

        /// <summary>
        /// Delete access to adminable repositories.
        /// </summary>
        DeleteRepo = 64,

        /// <summary>
        /// Read access to a user’s notifications. repo is accepted too.
        /// </summary>
        Notifications = 128,

        /// <summary>
        /// Write access to gists.
        /// </summary>
        Gist = 256

    }

}