using Skybrud.Social.BitBucket.OAuth;
using Skybrud.Social.Http;

namespace Skybrud.Social.BitBucket.Endpoints.Raw {
    
    public class BitBucketUserRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the BitBucket OAuth client.
        /// </summary>
        public BitBucketOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        public BitBucketUserRawEndpoint(BitBucketOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about the authenticated user.
        /// </summary>
        public SocialHttpResponse GetInfo() {
            return Client.DoHttpGetRequest("https://bitbucket.org/api/1.0/user");
        }

        /// <summary>
        /// Gets a list of repositories of the authenticated user.
        /// </summary>
        public SocialHttpResponse GetRepositories() {
            return Client.DoHttpGetRequest("https://bitbucket.org/api/1.0/user/repositories/");
        }

        #endregion

    }

}