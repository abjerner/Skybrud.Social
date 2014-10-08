using System.Net;
using Skybrud.Social.BitBucket.OAuth;

namespace Skybrud.Social.BitBucket.Endpoints.Raw {
    
    public class BitBucketUserRawEndpoint {

        public BitBucketOAuthClient Client { get; private set; }

        public BitBucketUserRawEndpoint(BitBucketOAuthClient client) {
            Client = client;
        }
        
        #region GetInfo
        
        /// <summary>
        /// Gets information about the authenticated user.
        /// </summary>
        public string GetInfo() {
            HttpStatusCode statusCode;
            return GetInfo(out statusCode);
        }
        
        /// <summary>
        /// Gets information about the authenticated user.
        /// </summary>
        public string GetInfo(out HttpStatusCode statusCode) {
            return Client.DoHttpRequestAsString("GET", "https://bitbucket.org/api/1.0/user", null, null, out statusCode);
        }

        #endregion

        #region GetRepositories

        public string GetRepositories() {
            HttpStatusCode statusCode;
            return GetRepositories(out statusCode);
        }

        public string GetRepositories(out HttpStatusCode statusCode) {
            return Client.DoHttpRequestAsString("GET", "https://bitbucket.org/api/1.0/user/repositories/", null, null, out statusCode);
        }

        #endregion
    }

}
