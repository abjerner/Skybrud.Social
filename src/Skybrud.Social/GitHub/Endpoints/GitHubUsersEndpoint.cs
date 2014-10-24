using Skybrud.Social.GitHub.Endpoints.Raw;
using Skybrud.Social.GitHub.Responses;

namespace Skybrud.Social.GitHub.Endpoints {
    
    public class GitHubUsersEndpoint {

        #region Properties

        /// <summary>
        /// A reference to the GitHub service.
        /// </summary>
        public GitHubService Service { get; private set; }

        /// <summary>
        /// A reference to the raw endpoint.
        /// </summary>
        public GitHubUsersRawEndpoint Raw {
            get { return Service.Client.Users; }
        }

        #endregion

        #region Constructors

        internal GitHubUsersEndpoint(GitHubService service) {
            Service = service;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about a user with the specified <code>username</code>.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        public GitHubUserResponse GetUser(string username) {
            return GitHubUserResponse.ParseResponse(Raw.GetUser(username));
        }

        /// <summary>
        /// Gets a list of repositories of a user with the specified <code>username</code>.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        public GitHubRepositoriesResponse GetRepositories(string username) {
            return GitHubRepositoriesResponse.ParseResponse(Raw.GetRepositories(username));
        }

        /// <summary>
        /// Gets a list of organizations the specified user is a part of.
        /// </summary>
        /// <returns></returns>
        public GitHubOrganizationsResponse GetOrganizations(string username) {
            return GitHubOrganizationsResponse.ParseResponse(Raw.GetOrganizations(username));
        }

        #endregion
    
    }

}
