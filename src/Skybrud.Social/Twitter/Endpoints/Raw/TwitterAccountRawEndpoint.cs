using Skybrud.Social.Http;
using Skybrud.Social.Twitter.OAuth;

namespace Skybrud.Social.Twitter.Endpoints.Raw {
    
    public class TwitterAccountRawEndpoint {

        public TwitterOAuthClient Client { get; private set; }

        internal TwitterAccountRawEndpoint(TwitterOAuthClient client) {
            Client = client;
        }

        #region Account
        
        public SocialHttpResponse VerifyCredentials() {
            return Client.DoHttpGetRequest("https://api.twitter.com/1.1/account/verify_credentials.json");
        }

        #endregion

    }

}