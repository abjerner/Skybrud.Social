using System.Net;
using Skybrud.Social.Twitter.OAuth;

namespace Skybrud.Social.Twitter.Endpoints.Raw {
    
    public class TwitterAccountRawEndpoint {

        public TwitterOAuthClient Client { get; private set; }

        internal TwitterAccountRawEndpoint(TwitterOAuthClient client) {
            Client = client;
        }

        #region Account

        public string VerifyCredentials() {
            HttpStatusCode status;
            return VerifyCredentials(out status);
        }

        public string VerifyCredentials(out HttpStatusCode status) {
            return Client.DoHttpRequestAsString("GET", "https://api.twitter.com/1.1/account/verify_credentials.json", null, null, out status);
        }

        #endregion

    }

}
