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

        #region GetInfo

        public BitBucketCurrentUserResponse GetInfo() {

            HttpStatusCode status;

            // Get the raw data from the API
            string contents = Raw.GetInfo(out status);

            // Validate the response
            if (status != HttpStatusCode.OK) {
                throw new BitBucketHttpException(status);
            }

            // Parse the response
            return BitBucketCurrentUserResponse.ParseJson(contents);

        }

        #endregion

        #region GetRepositories

        public BitBucketRepositoriesResponse GetRepositories() {

            HttpStatusCode status;

            // Get the raw data from the API
            string contents = Raw.GetRepositories(out status);

            // Validate the response
            if (status != HttpStatusCode.OK) {
                throw new BitBucketHttpException(status);
            }

            // Parse the response
            return BitBucketRepositoriesResponse.ParseJsonArray(contents);

        }

        #endregion

    }

}
