using System.Net;
using Skybrud.Social.GitHub.Endpoints.Raw;
using Skybrud.Social.GitHub.Exceptions;
using Skybrud.Social.GitHub.Objects;

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

        public GitHubUser GetUser() {

            HttpStatusCode status;

            // Get the raw data from the API
            string contents = Raw.GetUser(out status);

            // Validate the response
            if (status != HttpStatusCode.OK) {
                throw new GitHubHttpException(status);
            }

            // Parse the response
            return GitHubUser.ParseJson(contents);

        }

        #endregion
    
    }

}
