using System;

namespace Skybrud.Social.GitHub.Exceptions {
    
    /// <summary>
    /// Describes a basic exception returned by the GitHub API.
    /// </summary>
    public class GitHubException : Exception {

        public GitHubException(string message) : base(message) { }

    }

}
