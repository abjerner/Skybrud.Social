using System.Net;
using Skybrud.Social.BitBucket.Endpoints.Raw;
using Skybrud.Social.BitBucket.Exceptions;
using Skybrud.Social.BitBucket.Responses;

namespace Skybrud.Social.BitBucket.Endpoints {
    
    public class BitBucketUsersEndpoint {

        public BitBucketService Service { get; private set; }

        /// <summary>
        /// The implementation of the endpoint for getting the raw server response.
        /// </summary>
        public BitBucketUsersRawEndpoint Raw {
            get { return Service.Client.Users; }
        }

        internal BitBucketUsersEndpoint(BitBucketService service) {
            Service = service;
        }

        public BitBucketUserResponse GetProfile(string accountName) {

            HttpStatusCode status;

            // Get the raw data from the API
            string contents = Raw.GetProfile(accountName, out status);

            // Validate the response
            if (status != HttpStatusCode.OK) {
                throw new BitBucketHttpException(status);
            }

            // Parse the response
            return BitBucketUserResponse.ParseJson(contents);
        
        }
    
    }

}
