using Skybrud.Social.Facebook.Endpoints.Raw;
using Skybrud.Social.Facebook.Objects;
using Skybrud.Social.Facebook.Options;
using Skybrud.Social.Facebook.Responses;
using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Endpoints {
    
    public class FacebookLinksEndpoint {

        #region Properties

        /// <summary>
        /// A reference to the Facebook service.
        /// </summary>
        public FacebookService Service { get; private set; }

        /// <summary>
        /// A reference to the raw endpoint.
        /// </summary>
        public FacebookLinksRawEndpoint Raw {
            get { return Service.Client.Links; }
        }

        #endregion

        #region Constructor

        internal FacebookLinksEndpoint(FacebookService service) {
            Service = service;
        }

        #endregion

        #region Methods

        public FacebookResponse<FacebookLink> GetLink(string id) {
            return FacebookHelpers.ParseResponse(Raw.GetLink(id), FacebookLink.Parse);
        }

        // TODO: Implement GetLinks method

        /// <summary>
        /// Posts a link with the specified options to the feed of the authenticated user. If
        /// successful, the ID of the created post is returned.
        /// </summary>
        /// <param name="options">The options for the link.</param>
        /// <returns>Returns the ID of the created link.</returns>
        public string PostLink(FacebookPostLinkOptions options) {
            return PostLink("me", options);
        }

        /// <summary>
        /// Posts a link with the specified options. If successful, the ID of the created post is returned.
        /// </summary>
        /// <param name="identifier">The identifier of the user, page or similar.</param>
        /// <param name="options">The options for the link.</param>
        /// <returns>Returns the ID of the created link.</returns>
        public string PostLink(string identifier, FacebookPostLinkOptions options) {

            // Make the call to the API
            SocialHttpResponse response = Raw.PostLink(identifier, options);

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();

            // Validate the response
            FacebookResponse.ValidateResponse(response, obj);

            // Get the ID of the created link
            return obj.GetString("id");

        }

        #endregion

    }

}
