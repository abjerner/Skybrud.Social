using System.Net;
using Skybrud.Social.BitBucket.OAuth;

namespace Skybrud.Social.BitBucket.Endpoints.Raw {
    
    public class BitBucketUsersRawEndpoint {

        public BitBucketOAuthClient Client { get; private set; }

        public BitBucketUsersRawEndpoint(BitBucketOAuthClient client) {
            Client = client;
        }

        public string GetProfile(string account) {
            HttpStatusCode statusCode;
            return GetProfile(account, out statusCode);
        }

        public string GetProfile(string account, out HttpStatusCode statusCode) {
            return Client.DoHttpRequestAsString("GET", "https://bitbucket.org/api/1.0/users/" + account, null, null, out statusCode);
        }
    
    }

}
