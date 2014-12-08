using Skybrud.Social.Facebook.Endpoints.Raw;
using Skybrud.Social.Facebook.Objects;
using Skybrud.Social.Facebook.Responses;

namespace Skybrud.Social.Facebook.Endpoints {
    
    public class FacebookAppsEndpoint {

        /// <summary>
        /// A reference to the Facebook service.
        /// </summary>
        public FacebookService Service { get; private set; }

        /// <summary>
        /// A reference to the raw endpoint.
        /// </summary>
        public FacebookAppsRawEndpoint Raw {
            get { return Service.Client.Apps; }
        }

        internal FacebookAppsEndpoint(FacebookService service) {
            Service = service;
        }

        #region Methods

        /// <summary>
        /// Gets information about the current app by calling the <var>/app</var> method. This requires an app access token.
        /// </summary>
        public FacebookResponse<FacebookApp> GetApp() {
            return FacebookHelpers.ParseResponse(Raw.GetApp("app"), FacebookApp.Parse);
        }

        /// <summary>
        /// Gets information about the specified app.
        /// </summary>
        /// <param name="id">The ID of the app.</param>
        public FacebookResponse<FacebookApp> GetApp(string id) {
            return FacebookHelpers.ParseResponse(Raw.GetApp(id), FacebookApp.Parse);
        }

        #endregion

    }

}
