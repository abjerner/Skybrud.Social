using Skybrud.Social.BitBucket.Endpoints.Raw;
using Skybrud.Social.BitBucket.Responses.User;

namespace Skybrud.Social.BitBucket.Endpoints {
    
    public class BitBucketUserEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the BitBucket service.
        /// </summary>
        public BitBucketService Service { get; private set; }

        /// <summary>
        /// Gets a reference to the raw user endpoint.
        /// </summary>
        public BitBucketUserRawEndpoint Raw {
            get { return Service.Client.User; }
        }

        #endregion

        #region Constructors

        internal BitBucketUserEndpoint(BitBucketService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about the authenticated user.
        /// </summary>
        public BitBucketCurrentUserResponse GetInfo() {
            return BitBucketCurrentUserResponse.ParseResponse(Raw.GetInfo());
        }

        /// <summary>
        /// Gets a list of repositories of the authenticated user.
        /// </summary>
        public BitBucketCurrentUserRepositoriesResponse GetRepositories() {
            return BitBucketCurrentUserRepositoriesResponse.ParseResponse(Raw.GetRepositories());
        }

        #endregion

    }

}