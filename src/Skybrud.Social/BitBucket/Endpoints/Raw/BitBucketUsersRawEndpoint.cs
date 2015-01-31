using Skybrud.Social.BitBucket.OAuth;
using Skybrud.Social.Http;

namespace Skybrud.Social.BitBucket.Endpoints.Raw {
    
    public class BitBucketUsersRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the BitBucket OAuth client.
        /// </summary>
        public BitBucketOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        public BitBucketUsersRawEndpoint(BitBucketOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        public SocialHttpResponse GetProfile(string username) {
            return Client.DoHttpGetRequest("https://bitbucket.org/api/1.0/users/" + username);
        }

        public SocialHttpResponse GetRepositories(string username) {
            return Client.DoHttpGetRequest("https://bitbucket.org/api/2.0/repositories/" + username);
        }

        #endregion

    }

}