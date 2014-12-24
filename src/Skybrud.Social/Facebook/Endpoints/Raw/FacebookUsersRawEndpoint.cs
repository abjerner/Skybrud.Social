using Skybrud.Social.Facebook.OAuth;
using Skybrud.Social.Http;

namespace Skybrud.Social.Facebook.Endpoints.Raw {
    
    public class FacebookUsersRawEndpoint {

        #region Properties

        public FacebookOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal FacebookUsersRawEndpoint(FacebookOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        public SocialHttpResponse GetUser(string identifier) {
            return Client.DoAuthenticatedGetRequest("/" + identifier);
        }

        #endregion

    }

}