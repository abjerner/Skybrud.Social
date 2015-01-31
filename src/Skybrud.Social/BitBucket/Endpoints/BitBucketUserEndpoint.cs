using System.Net;
using Skybrud.Social.BitBucket.Endpoints.Raw;
using Skybrud.Social.BitBucket.Exceptions;
using Skybrud.Social.BitBucket.Responses;
using Skybrud.Social.Http;

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

        public BitBucketCurrentUserRepositoriesResponse GetRepositories() {

            // Make the call to the API
            SocialHttpResponse response = Raw.GetRepositories();

            // Validate the response
            if (response.StatusCode != HttpStatusCode.OK) {
                throw new BitBucketException(response);
            }

            // Parse the response
            return BitBucketCurrentUserRepositoriesResponse.ParseJsonArray(response.GetBodyAsString());

        }

        #endregion

    }

}