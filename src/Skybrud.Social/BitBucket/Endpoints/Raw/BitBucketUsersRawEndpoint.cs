using Skybrud.Social.BitBucket.OAuth;

namespace Skybrud.Social.BitBucket.Endpoints.Raw {
    
    public class BitBucketUsersRawEndpoint {

        #region Properties

        public BitBucketOAuthClient Client { get; private set; }

        #endregion

        #region Constructor

        public BitBucketUsersRawEndpoint(BitBucketOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        public SocialHttpResponse GetProfile(string username) {
            return Client.DoHttpGetRequest("https://bitbucket.org/api/1.0/users/" + username);
        }

        public SocialHttpResponse GetRepositories(string username) {
            return Client.DoHttpGetRequest("https://bitbucket.org/api/2.0/repositories/" + username);
        }

        #endregion

    }

}
