using Skybrud.Social.Facebook.OAuth;

namespace Skybrud.Social.Facebook.Endpoints.Raw {
    
    public class FacebookMethodsRawEndpoint {

        public FacebookOAuthClient Client { get; private set; }

        internal FacebookMethodsRawEndpoint(FacebookOAuthClient client) {
            Client = client;
        }

        public string Me() {
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://graph.facebook.com/me?access_token=" + Client.AccessToken);
        }

    }

}
