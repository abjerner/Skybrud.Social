using System;
using Skybrud.Social.Facebook.Endpoints.Raw;
using Skybrud.Social.Facebook.Options.Apps;
using Skybrud.Social.Facebook.Responses.Apps;

namespace Skybrud.Social.Facebook.Endpoints {

    /// <summary>
    /// Class representing the implementation of the accounts endpoint.
    /// </summary>
    public class FacebookAppsEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Facebook service.
        /// </summary>
        public FacebookService Service { get; private set; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public FacebookAppsRawEndpoint Raw {
            get { return Service.Client.Apps; }
        }

        #endregion

        #region Constructors

        internal FacebookAppsEndpoint(FacebookService service) {
            Service = service;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about the current app by calling the <code>/app</code> method. This requires an app access
        /// token.
        /// </summary>
        public FacebookAppResponse GetApp() {
            return GetApp("app");
        }

        /// <summary>
        /// Gets information about the specified app.
        /// </summary>
        /// <param name="id">The ID of the app.</param>
        public FacebookAppResponse GetApp(string id) {
            return FacebookAppResponse.ParseResponse(Raw.GetApp(id));
        }

        /// <summary>
        /// Gets information about the app matching the specified <code>options</code>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        public FacebookAppResponse GetApp(FacebookGetAppOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            return FacebookAppResponse.ParseResponse(Raw.GetApp(options));
        }

        #endregion

    }

}