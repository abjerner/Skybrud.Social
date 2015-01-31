using Skybrud.Social.BitBucket.Endpoints.Raw;
using Skybrud.Social.OAuth;

namespace Skybrud.Social.BitBucket.OAuth {
    
    /// <summary>
    /// Class for handling the communication with the BitBucket API. The class has methods for handling OAuth logins
    /// using a three-legged approach as well as logic for calling the methods decribed in the BitBucket API (not all
    /// has been implemented yet).
    /// </summary>
    public class BitBucketOAuthClient : OAuthClient {

        #region Properties

        /// <summary>
        /// Gets a reference to the raw user endpoint.
        /// </summary>
        public BitBucketUserRawEndpoint User { get; private set; }

        /// <summary>
        /// Gets a reference to the raw users endpoint.
        /// </summary>
        public BitBucketUsersRawEndpoint Users { get; private set; }

        /// <summary>
        /// Gets a reference to the raw repositories endpoint.
        /// </summary>
        public BitBucketRepositoriesRawEndpoint Repositories { get; private set; }

        #endregion

        #region Constructors

        public BitBucketOAuthClient() : this(null, null, null, null, null) { }

        public BitBucketOAuthClient(string consumerKey, string consumerSecret) : this(consumerKey, consumerSecret, null, null, null) { }

        public BitBucketOAuthClient(string consumerKey, string consumerSecret, string token, string tokenSecret) : this(consumerKey, consumerSecret, token, tokenSecret, null) { }

        public BitBucketOAuthClient(string consumerKey, string consumerSecret, string token, string tokenSecret, string callback) {
        
            // Common properties
            ConsumerKey = consumerKey;
            ConsumerSecret = consumerSecret;
            Token = token;
            TokenSecret = tokenSecret;
            Callback = callback;

            // Specific to BitBucket
            RequestTokenUrl = "https://bitbucket.org/api/1.0/oauth/request_token";
            AuthorizeUrl = "https://bitbucket.org/api/1.0/oauth/authenticate";
            AccessTokenUrl = "https://bitbucket.org/api/1.0/oauth/access_token";

            // Endpoints
            User = new BitBucketUserRawEndpoint(this);
            Users = new BitBucketUsersRawEndpoint(this);
            Repositories = new BitBucketRepositoriesRawEndpoint(this);

        }

        #endregion

    }

}