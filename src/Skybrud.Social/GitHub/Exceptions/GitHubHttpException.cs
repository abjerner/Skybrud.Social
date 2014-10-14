using System.Net;

namespace Skybrud.Social.GitHub.Exceptions {
    
    public class GitHubHttpException : GitHubException {

        public HttpStatusCode StatusCode { get; private set; }

        public GitHubHttpException(HttpStatusCode status) : base("Invalid response received from the GitHub API (Status: " + ((int) status) + ")") {

            StatusCode = status;

        }

    }

}
