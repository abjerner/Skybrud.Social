using Skybrud.Social.GitHub.Endpoints.Raw;
using Skybrud.Social.GitHub.Responses;

namespace Skybrud.Social.GitHub.Endpoints {
    
    public class GitHubUserEndpoint {

        #region Properties

        /// <summary>
        /// A reference to the GitHub service.
        /// </summary>
        public GitHubService Service { get; private set; }

        /// <summary>
        /// A reference to the raw endpoint.
        /// </summary>
        public GitHubUserRawEndpoint Raw {
            get { return Service.Client.User; }
        }

        #endregion

        #region Constructors

        internal GitHubUserEndpoint(GitHubService service) {
            Service = service;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about thr authenticated user.
        /// </summary>
        public GitHubUserResponse GetUser() {
            return GitHubUserResponse.ParseResponse(Raw.GetUser());
        }

        public GitHubEmailsResponse GetEmails() {
            return GitHubEmailsResponse.ParseResponse(Raw.GetEmails());
        }

        /// <summary>
        /// Gets a list of users following the authenticated user.
        /// </summary>
        public GitHubUsersResponse GetFollowers() {
            return GitHubUsersResponse.ParseResponse(Raw.GetFollowers());
        }

        /// <summary>
        /// Gets a list of users the authenticated user is following.
        /// </summary>
        public GitHubUsersResponse GetFollowing() {
            return GitHubUsersResponse.ParseResponse(Raw.GetFollowing());
        }

        /// <summary>
        /// Gets whether the authenticated user follows the specified username.
        /// </summary>
        /// <param name="username">The username to check.</param>
        public GitHubFollowingResponse IsFollowing(string username) {
            return GitHubFollowingResponse.ParseResponse(Raw.IsFollowing(username));
        }
        
        /// <summary>
        /// Gets a list of repositories of the authenticated user.
        /// </summary>
        public GitHubRepositoriesResponse GetRepositories() {
            return GitHubRepositoriesResponse.ParseResponse(Raw.GetRepositories());
        }

        #endregion
    
    }

}
