using Skybrud.Social.Facebook.OAuth;
using Skybrud.Social.Facebook.Options;
using Skybrud.Social.Facebook.Options.Links;
using Skybrud.Social.Http;

namespace Skybrud.Social.Facebook.Endpoints.Raw {
    
    public class FacebookLinksRawEndpoint {

        #region Properties

        public FacebookOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal FacebookLinksRawEndpoint(FacebookOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about the link with the specified <code>linkId</code>.
        /// </summary>
        /// <param name="linkId">The ID of the link.</param>
        public SocialHttpResponse GetLink(string linkId) {
            return Client.DoAuthenticatedGetRequest("/" + linkId);
        }

        /// <summary>
        /// Gets a list of links of the user or page with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The ID or name.</param>
        /// <param name="options">The options for the call to the API.</param>
        public SocialHttpResponse GetLinks(string identifier, FacebookLinksOptions options) {
            return Client.DoAuthenticatedGetRequest("/" + identifier + "/links", options);
        }

        /// <summary>
        /// Posts a link with the specified options.
        /// </summary>
        /// <param name="identifier">The identifier of user, page or similar.</param>
        /// <param name="options">The options for the link.</param>
        public SocialHttpResponse PostLink(string identifier, FacebookPostLinkOptions options) {
            return Client.DoAuthenticatedPostRequest("/" + identifier + "/feed", options);
        }

        #endregion

    }

}