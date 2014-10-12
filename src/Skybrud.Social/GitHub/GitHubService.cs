using System;
using System.Net;
using Skybrud.Social.GitHub.Endpoints;
using Skybrud.Social.GitHub.OAuth;

namespace Skybrud.Social.GitHub {

    public class GitHubService {

        #region Properties

        /// <summary>
        /// The internal OAuth client for communication with the GitHub API.
        /// </summary>
        public GitHubOAuthClient Client { get; private set; }

        public GitHubRepositoriesEndpoint Repositories { get; private set; }

        public GitHubUserEndpoint User { get; private set; }

        public GitHubUsersEndpoint Users { get; private set; }

        #endregion

        #region Constructor(s)

        private GitHubService(GitHubOAuthClient client) {
            Client = client;
            Repositories = new GitHubRepositoriesEndpoint(this);
            User = new GitHubUserEndpoint(this);
            Users = new GitHubUsersEndpoint(this);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Initialize a new service instance from the specified OAuth client.
        /// </summary>
        /// <param name="client">The OAuth client.</param>
        public static GitHubService CreateFromOAuthClient(GitHubOAuthClient client) {

            // This should never be null
            if (client == null) throw new ArgumentNullException("client");

            // Initialize the service
            return new GitHubService(client);

        }

        /// <summary>
        /// Initializes a new service instance from the specifie OAuth 2 access
        /// token.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        public static GitHubService CreateFromAccessToken(string accessToken) {
            return CreateFromOAuthClient(new GitHubOAuthClient {
                AccessToken = accessToken
            });
        }

        /// <summary>
        /// Initializes a new service instance from the specified username and
        /// password using basic authentication in the HTTP protocol. Using
        /// this approach is specific to the GitGub API and not a part of
        /// OAuth 2.
        /// </summary>
        /// <param name="username">The username of the user on GitHub.com</param>
        /// <param name="password">The password of the user on GitHub.com</param>
        public static GitHubService CreateFromCredentials(string username, string password) {
            return CreateFromOAuthClient(new GitHubOAuthClient {
                Credentials = new NetworkCredential(username, password)
            });
        }

        /// <summary>
        /// Initializes a new service instance from the specified credentials
        /// using basic authentication in the HTTP protocol. Using this
        /// approach is specific to the GitGub API and not a part of OAuth 2.
        /// </summary>
        /// <param name="credentials">The credentials of the user on GitHub.com</param>
        public static GitHubService CreateFromCredentials(NetworkCredential credentials) {
            return CreateFromOAuthClient(new GitHubOAuthClient {
                Credentials = credentials
            });
        }

        #endregion
    
    }

}
