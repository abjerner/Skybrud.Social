using System.Net;
using Skybrud.Social.BitBucket.Endpoints.Raw;
using Skybrud.Social.BitBucket.Exceptions;
using Skybrud.Social.BitBucket.Responses;
using Skybrud.Social.Http;

namespace Skybrud.Social.BitBucket.Endpoints {
    
    public class BitBucketUsersEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the BitBucket service.
        /// </summary>
        public BitBucketService Service { get; private set; }

        /// <summary>
        /// Gets a reference to the raw users endpoint.
        /// </summary>
        public BitBucketUsersRawEndpoint Raw {
            get { return Service.Client.Users; }
        }

        #endregion

        #region Constructors

        internal BitBucketUsersEndpoint(BitBucketService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        public BitBucketUserResponse GetProfile(string username) {

            // Make the call to the API
            SocialHttpResponse response = Raw.GetProfile(username);

            // Validate the response
            if (response.StatusCode != HttpStatusCode.OK) {
                throw new BitBucketException(response);
            }

            // Parse the response
            return BitBucketUserResponse.ParseJson(response.GetBodyAsString());

        }
        
        public BitBucketRepositoriesResponse GetRepositories(string username) {

            // Make the call to the API
            SocialHttpResponse response = Raw.GetRepositories(username);

            // Validate the response
            if (response.StatusCode != HttpStatusCode.OK) {
                throw new BitBucketException(response);
            }

            // Parse the response
            return BitBucketRepositoriesResponse.ParseJson(response.GetBodyAsString());

        }

        #endregion
    
    }

}