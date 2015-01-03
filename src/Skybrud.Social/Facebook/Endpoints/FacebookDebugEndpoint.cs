using Skybrud.Social.Facebook.Endpoints.Raw;
using Skybrud.Social.Facebook.Responses.Debug;

namespace Skybrud.Social.Facebook.Endpoints {
    
    public class FacebookDebugEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Facebook service.
        /// </summary>
        public FacebookService Service { get; private set; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public FacebookDebugRawEndpoint Raw {
            get { return Service.Client.Debug; }
        }

        #endregion

        #region Constructors

        internal FacebookDebugEndpoint(FacebookService service) {
            Service = service;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets debug information about the access token used for accessing the Graph API.
        /// </summary>
        public FacebookDebugTokenResponse DebugToken() {
            return DebugToken(Service.Client.AccessToken);
        }

        /// <summary>
        /// Gets debug information about the specified access token.
        /// </summary>
        /// <param name="accessToken">The access token to debug.</param>
        public FacebookDebugTokenResponse DebugToken(string accessToken) {
            return FacebookDebugTokenResponse.ParseResponse(Raw.DebugToken(accessToken));
        }

        #endregion

    }

}