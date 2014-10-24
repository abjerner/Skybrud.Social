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

        public SocialHttpResponse GetUser() {
            return Client.DoAuthenticatedGetRequest("https://api.github.com/user");
        }

        public SocialHttpResponse GetEmails() {
            return Client.DoAuthenticatedGetRequest("https://api.github.com/user/emails");
        }

        public SocialHttpResponse GetFollowers() {
            return Client.DoAuthenticatedGetRequest("https://api.github.com/user/followers");
        }

        public SocialHttpResponse GetFollowing() {
            return Client.DoAuthenticatedGetRequest("https://api.github.com/user/followers");
        }

        public SocialHttpResponse IsFollowing(string username) {
            return Client.DoAuthenticatedGetRequest("https://api.github.com/user/following/" + username);
        }

        public SocialHttpResponse GetRepositories() {
            return Client.DoAuthenticatedGetRequest("https://api.github.com/user/repos");
        }

        public SocialHttpResponse GetOrganizations() {
            return Client.DoAuthenticatedGetRequest("https://api.github.com/user/orgs");
        }

        #endregion

    }

}
