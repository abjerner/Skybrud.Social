using Skybrud.Social.Facebook.OAuth;
using Skybrud.Social.Http;

namespace Skybrud.Social.Facebook.Endpoints.Raw {
    
    public class FacebookPagesRawEndpoint {

        #region Properties

        public FacebookOAuthClient Client { get; private set; }

        #endregion

        #region Constructor

        internal FacebookPagesRawEndpoint(FacebookOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods
        
        /// <summary>
        /// Gets information about a post with the specified <code>id</code>
        /// </summary>
        /// <param name="id">The ID of the photo.</param>
        public SocialHttpResponse GetPage(string id) {
            return Client.DoAuthenticatedGetRequest("/" + id);
        }

        #endregion

    }

}
