using Skybrud.Social.BitBucket.OAuth;

namespace Skybrud.Social.BitBucket.Endpoints.Raw {
    
    public class BitBucketUserRawEndpoint {

        #region Properties

        public BitBucketOAuthClient Client { get; private set; }

        #endregion

        #region Constructor

        public BitBucketUserRawEndpoint(BitBucketOAuthClient client) {
            Client = client;
        }

        #endregion
        
        #region Methods
        
        /// <summary>
        /// Gets information about the authenticated user.
        /// </summary>
        public SocialHttpResponse GetInfo() {
            return Client.DoHttpGetRequest("https://bitbucket.org/api/1.0/user");
        }

        public SocialHttpResponse GetRepositories() {
            return Client.DoHttpGetRequest("https://bitbucket.org/api/1.0/user/repositories/");
        }

        #endregion

    }

}
