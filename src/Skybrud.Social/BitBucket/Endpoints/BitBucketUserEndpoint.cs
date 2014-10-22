using System.Net;
using Skybrud.Social.BitBucket.Endpoints.Raw;
using Skybrud.Social.BitBucket.Exceptions;
using Skybrud.Social.BitBucket.Responses;

namespace Skybrud.Social.BitBucket.Endpoints {
    
    public class BitBucketUserEndpoint {

        #region Properties

        public BitBucketService Service { get; private set; }

        /// <summary>
        /// The implementation of the endpoint for getting the raw server response.
        /// </summary>
        public BitBucketUserRawEndpoint Raw {
            get { return Service.Client.User; }
        }

        #endregion

        #region Constructor

        internal BitBucketUserEndpoint(BitBucketService service) {
            Service = service;
        }

        #endregion

        #region Methods

        public BitBucketCurrentUserResponse GetInfo() {

            // Make the call to the API
            SocialHttpResponse response = Raw.GetInfo();

            // Validate the response
            if (response.StatusCode != HttpStatusCode.OK) {
                throw new BitBucketHttpException(response.StatusCode);
            }

            // Parse the response
            return BitBucketCurrentUserResponse.ParseJson(response.GetBodyAsString());

        }

        public BitBucketCurrentUserRepositoriesResponse GetRepositories() {

            // Make the call to the API
            SocialHttpResponse response = Raw.GetRepositories();

            // Validate the response
            if (response.StatusCode != HttpStatusCode.OK) {
                throw new BitBucketHttpException(response.StatusCode);
            }

            // Parse the response
            return BitBucketCurrentUserRepositoriesResponse.ParseJsonArray(response.GetBodyAsString());

        }

        #endregion

    }

}
