using Skybrud.Social.Facebook.Endpoints.Raw;
using Skybrud.Social.Facebook.Responses.Debug;

namespace Skybrud.Social.Facebook.Endpoints {

    /// <summary>
    /// Class representing the implementation of the debug endpoint.
    /// </summary>
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
        /// <returns>Returns an instance of <code>FacebookDebugTokenResponse</code> with information about the current
        /// access token.</returns>
        public FacebookDebugTokenResponse DebugToken() {
            return DebugToken(Service.Client.AccessToken);
        }

        /// <summary>
        /// Gets debug information about the specified <code>accessToken</code>.
        /// </summary>
        /// <param name="accessToken">The access token to debug.</param>
        /// <returns>Returns an instance of <code>FacebookDebugTokenResponse</code> with information about the
        /// specified <code>accessToken</code>.</returns>
        public FacebookDebugTokenResponse DebugToken(string accessToken) {
            return FacebookDebugTokenResponse.ParseResponse(Raw.DebugToken(accessToken));
        }

        #endregion

    }

}