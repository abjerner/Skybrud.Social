using System.Net;
using Skybrud.Social.BitBucket.OAuth;

namespace Skybrud.Social.BitBucket.Endpoints.Raw {
    
    public class BitBucketUserRawEndpoint {

        public BitBucketOAuthClient Client { get; private set; }

        public BitBucketUserRawEndpoint(BitBucketOAuthClient client) {
            Client = client;
        }
        
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

    }

}
