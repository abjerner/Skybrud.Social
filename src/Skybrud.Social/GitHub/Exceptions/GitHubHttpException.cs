using System.Net;
using Skybrud.Social.Http;

namespace Skybrud.Social.GitHub.Exceptions {

    public class GitHubHttpException : GitHubException {

        #region Properties

        public SocialHttpResponse Response { get; private set; }

        public HttpStatusCode StatusCode {
            get { return Response.StatusCode; }
        }

        public string DocumentationUrl { get; private set; }

        #endregion

        #region Constructors

        public GitHubHttpException(SocialHttpResponse response) : base("Invalid response received from the GitHub API (Status: " + ((int) response.StatusCode) + ")") {
            Response = response;
        }

        public GitHubHttpException(SocialHttpResponse response, string message)
            : base(message) {
            Response = response;
        }

        public GitHubHttpException(SocialHttpResponse response, string message, string documentationUrl) : base(message) {
            Response = response;
            DocumentationUrl = documentationUrl;
        }

        #endregion

    }

}