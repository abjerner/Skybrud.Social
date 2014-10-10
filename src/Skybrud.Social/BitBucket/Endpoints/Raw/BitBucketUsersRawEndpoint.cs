using System.Net;
using Skybrud.Social.BitBucket.OAuth;

namespace Skybrud.Social.BitBucket.Endpoints.Raw {
    
    public class BitBucketUsersRawEndpoint {

        public BitBucketOAuthClient Client { get; private set; }

        public BitBucketUsersRawEndpoint(BitBucketOAuthClient client) {
            Client = client;
        }

        #region GetProfile

        public string GetProfile(string account) {
            HttpStatusCode statusCode;
            return GetProfile(account, out statusCode);
        }

        public string GetProfile(string account, out HttpStatusCode statusCode) {
            return Client.DoHttpRequestAsString("GET", "https://bitbucket.org/api/1.0/users/" + account, null, null, out statusCode);
        }

        #endregion

        #region GetRepositories

        public string GetRepositories(string username) {
            HttpStatusCode statusCode;
            return GetProfile(username, out statusCode);
        }

        public string GetRepositories(string username, out HttpStatusCode statusCode) {
            return Client.DoHttpRequestAsString("GET", "https://bitbucket.org/api/2.0/repositories/" + username, null, null, out statusCode);
        }

        #endregion


        

    }

}
