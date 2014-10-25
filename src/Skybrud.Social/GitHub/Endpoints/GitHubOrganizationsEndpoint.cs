using Skybrud.Social.GitHub.Endpoints.Raw;
using Skybrud.Social.GitHub.Responses;

namespace Skybrud.Social.GitHub.Endpoints {
    
    public class GitHubOrganizationsEndpoint {

        #region Properties

        /// <summary>
        /// A reference to the GitHub service.
        /// </summary>
        public GitHubService Service { get; private set; }

        /// <summary>
        /// A reference to the raw endpoint.
        /// </summary>
        public GitHubOrganizationsRawEndpoint Raw {
            get { return Service.Client.Organizations; }
        }

        #endregion

        #region Constructors

        internal GitHubOrganizationsEndpoint(GitHubService service) {
            Service = service;
        }

        #endregion

        #region Methods

        public GitHubOrganizationResponse GetOrganization(string org) {
            return GitHubOrganizationResponse.ParseResponse(Raw.GetOrganization(org));
        }

        #endregion
    
    }

}
