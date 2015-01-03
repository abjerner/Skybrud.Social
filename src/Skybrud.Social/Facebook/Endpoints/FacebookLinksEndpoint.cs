using Skybrud.Social.Facebook.Endpoints.Raw;
using Skybrud.Social.Facebook.Options.Links;
using Skybrud.Social.Facebook.Responses.Links;

namespace Skybrud.Social.Facebook.Endpoints {
    
    public class FacebookLinksEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Facebook service.
        /// </summary>
        public FacebookService Service { get; private set; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public FacebookLinksRawEndpoint Raw {
            get { return Service.Client.Links; }
        }

        #endregion

        #region Constructors

        internal FacebookLinksEndpoint(FacebookService service) {
            Service = service;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about the link with the specified <code>id</code>.
        /// </summary>
        /// <param name="id">The ID of the link.</param>
        public FacebookLinkResponse GetLink(string id) {
            return FacebookLinkResponse.ParseResponse(Raw.GetLink(id));
        }

        /// <summary>
        /// Gets a list of links of the user or page with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The ID or name of the page or user.</param>
        public FacebookLinksResponse GetLinks(string identifier) {
            return GetLinks(identifier, new FacebookLinksOptions());
        }

        /// <summary>
        /// Gets a list of links of the user or page with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The ID or name of the page or user.</param>
        /// <param name="limit">The maximum amount of links to return.</param>
        public FacebookLinksResponse GetLinks(string identifier, int limit) {
            return GetLinks(identifier, new FacebookLinksOptions {
                Limit = limit
            });
        }

        /// <summary>
        /// Gets a list of links of the user or page with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The ID or name of the page or user.</param>
        /// <param name="options">The options for the call to the API.</param>
        public FacebookLinksResponse GetLinks(string identifier, FacebookLinksOptions options) {
            return FacebookLinksResponse.ParseResponse(Raw.GetLinks(identifier, options));
        }

        /// <summary>
        /// Posts a link with the specified options to the feed of the authenticated user. If
        /// successful, the ID of the created post is returned.
        /// </summary>
        /// <param name="options">The options for the link.</param>
        public FacebookPostLinkResponse PostLink(FacebookPostLinkOptions options) {
            return PostLink("me", options);
        }

        /// <summary>
        /// Posts a link with the specified options. If successful, the ID of the created post is returned.
        /// </summary>
        /// <param name="identifier">The identifier of the user, page or similar.</param>
        /// <param name="options">The options for the link.</param>
        public FacebookPostLinkResponse PostLink(string identifier, FacebookPostLinkOptions options) {
            return FacebookPostLinkResponse.ParseResponse(Raw.PostLink(identifier, options));
        }

        #endregion

    }

}