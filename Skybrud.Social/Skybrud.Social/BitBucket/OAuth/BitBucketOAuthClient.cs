using Skybrud.Social.BitBucket.Endpoints.Raw;
using Skybrud.Social.OAuth;

namespace Skybrud.Social.BitBucket.OAuth {
    
    /// <summary>
    /// Class for handling the communication with the BitBucket API. The class ha
    /// methods for handling OAuth logins using a three-legged approach as well
    /// as logic for calling the methods decribed in the BitBucket API (not all
    /// has been implemented yet).
    /// </summary>
    public class BitBucketOAuthClient : OAuthClient {

        public BitBucketUserRawEndpoint User { get; private set; }
        
        public BitBucketOAuthClient() : this(null, null, null, null, null) {
            // Call overloaded constructor
        }

        public BitBucketOAuthClient(string consumerKey, string consumerSecret) : this(consumerKey, consumerSecret, null, null, null) {
            // Call overloaded constructor
        }

        public BitBucketOAuthClient(string consumerKey, string consumerSecret, string token, string tokenSecret) : this(consumerKey, consumerSecret, token, tokenSecret, null) {
            // Call overloaded constructor
        }

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

        }

    }

}
