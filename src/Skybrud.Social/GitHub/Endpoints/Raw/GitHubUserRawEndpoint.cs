using System.Net;
using Skybrud.Social.GitHub.OAuth;

namespace Skybrud.Social.GitHub.Endpoints.Raw {
    
    public class GitHubUserRawEndpoint {

        #region Properties

        public GitHubOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal GitHubUserRawEndpoint(GitHubOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        public string GetUser() {
            HttpStatusCode statusCode;
            return GetUser(out statusCode);
        }
        
        public string GetUser(out HttpStatusCode statusCode) {
            return Client.DoAuthenticatedGetRequest("https://api.github.com/user", null, out statusCode);
        }

        #endregion

    }

}
