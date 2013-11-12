using Skybrud.Social.BitBucket.OAuth;

namespace Skybrud.Social.BitBucket.Endpoints.Raw {
    
    public class BitBucketUsersRawEndpoint {

        public BitBucketOAuthClient Client { get; private set; }

        public BitBucketUsersRawEndpoint(BitBucketOAuthClient client) {
            Client = client;
        }
        
        public string GetProfile(string account) {
            return Client.DoHttpRequestAsString("GET", "https://bitbucket.org/api/1.0/users/" + account);
        }
    
    }

}
