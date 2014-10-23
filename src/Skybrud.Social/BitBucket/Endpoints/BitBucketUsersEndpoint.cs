using System.Net;
using Skybrud.Social.BitBucket.Endpoints.Raw;
using Skybrud.Social.BitBucket.Exceptions;
using Skybrud.Social.BitBucket.Responses;

namespace Skybrud.Social.BitBucket.Endpoints {
    
    public class BitBucketUsersEndpoint {

        #region Properties

        public BitBucketService Service { get; private set; }

        /// <summary>
        /// The implementation of the endpoint for getting the raw server response.
        /// </summary>
        public BitBucketUsersRawEndpoint Raw {
            get { return Service.Client.Users; }
        }

        #endregion

        #region Constructor

        internal BitBucketUsersEndpoint(BitBucketService service) {
            Service = service;
        }

        #endregion

        #region Methods

        public BitBucketUserResponse GetProfile(string username) {

            // Make the call to the API
            SocialHttpResponse response = Raw.GetProfile(username);

            // Validate the response
            if (response.StatusCode != HttpStatusCode.OK) {
                throw new BitBucketHttpException(response.StatusCode);
            }

            // Parse the response
            return BitBucketUserResponse.ParseJson(response.GetBodyAsString());

        }
        
        public BitBucketRepositoriesResponse GetRepositories(string username) {

            // Make the call to the API
            SocialHttpResponse response = Raw.GetRepositories(username);

            // Validate the response
            if (response.StatusCode != HttpStatusCode.OK) {
                throw new BitBucketHttpException(response.StatusCode);
            }

            // Parse the response
            return BitBucketRepositoriesResponse.ParseJson(response.GetBodyAsString());

        }

        #endregion
    
    }

}
