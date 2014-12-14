using Skybrud.Social.Facebook.OAuth;
using Skybrud.Social.Http;

namespace Skybrud.Social.Facebook.Endpoints.Raw {
    
    public class FacebookLinksRawEndpoint {

        #region Properties

        public FacebookOAuthClient Client { get; private set; }

        #endregion

        #region Constructor

        internal FacebookLinksRawEndpoint(FacebookOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets a link with the specified ID.
        /// </summary>
        /// <param name="linkId">The ID of the link.</param>
        public SocialHttpResponse GetLink(string linkId) {
            return Client.DoAuthenticatedGetRequest("/" + linkId);
        }

        #endregion

    }

}