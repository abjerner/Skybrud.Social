using Skybrud.Social.BitBucket.Endpoints.Raw;
using Skybrud.Social.BitBucket.Responses.Users;

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

        /// <summary>
        /// Gets information about the user with the specified <code>username</code>.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        public BitBucketUserResponse GetInfo(string username) {
            return BitBucketUserResponse.ParseResponse(Raw.GetInfo(username));
        }

        #endregion
    
    }

}