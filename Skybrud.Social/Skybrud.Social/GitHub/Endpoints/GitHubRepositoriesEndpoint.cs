using Skybrud.Social.GitHub.Endpoints.Raw;

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

        // TODO: Implement some methods

        #endregion
    
    }

}
