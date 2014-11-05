using Skybrud.Social.GitHub.Endpoints.Raw;
using Skybrud.Social.GitHub.Options;
using Skybrud.Social.GitHub.Responses;

namespace Skybrud.Social.GitHub.Endpoints {
    
    public class GitHubRepositoriesEndpoint {

        #region Properties

        /// <summary>
        /// A reference to the GitHub service.
        /// </summary>
        public GitHubService Service { get; private set; }

        /// <summary>
        /// A reference to the raw endpoint.
        /// </summary>
        public GitHubRepositoriesRawEndpoint Raw {
            get { return Service.Client.Repositories; }
        }

        #endregion

        #region Constructors

        internal GitHubRepositoriesEndpoint(GitHubService service) {
            Service = service;
        }

        #endregion

        #region Methods

        public GitHubCommitsResponse GetCommits(string owner, string repository) {
            return GitHubCommitsResponse.ParseResponse(Raw.GetCommits(owner, repository));
        }

        public GitHubCommitsResponse GetCommits(string owner, string repository, GitHubGetCommitOptions options) {
            return GitHubCommitsResponse.ParseResponse(Raw.GetCommits(owner, repository, options));
        }

        public GitHubRepositoryResponse GetRepository(string owner, string repository) {
            return GitHubRepositoryResponse.ParseResponse(Raw.GetRepository(owner, repository));
        }

        #endregion
    
    }

}
