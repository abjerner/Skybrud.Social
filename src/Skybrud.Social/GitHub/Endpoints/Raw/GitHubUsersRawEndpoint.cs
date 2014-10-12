using System.Net;
using Skybrud.Social.GitHub.OAuth;

namespace Skybrud.Social.GitHub.Endpoints.Raw {
    
    public class GitHubUsersRawEndpoint {

        #region Properties

        public GitHubOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal GitHubUsersRawEndpoint(GitHubOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        public string GetUser(string username) {
            HttpStatusCode statusCode;
            return GetUser(username, out statusCode);
        }
        
        public string GetUser(string username, out HttpStatusCode statusCode) {
            return Client.DoAuthenticatedGetRequest("https://api.github.com/users/" + username, null, out statusCode);
        }

        #endregion

    }

}
