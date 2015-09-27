using System;
using Skybrud.Social.Facebook.OAuth;
using Skybrud.Social.Facebook.Options.Apps;
using Skybrud.Social.Http;

namespace Skybrud.Social.Facebook.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw implementation of the apps endpoint.
    /// </summary>
    public class FacebookAppsRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference of the OAuth client.
        /// </summary>
        public FacebookOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal FacebookAppsRawEndpoint(FacebookOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about the app with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The identifier of the app. Can either be "app" or the ID of the app.</param>
        /// <returns>The raw JSON response from the API.</returns>
        public SocialHttpResponse GetApp(string identifier) {
            return Client.DoAuthenticatedGetRequest("/" + identifier);
        }

        /// <summary>
        /// Gets information about the app matching the specified <code>options</code>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>The raw JSON response from the API.</returns>
        public SocialHttpResponse GetApp(FacebookGetAppOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            return Client.DoAuthenticatedGetRequest("/" + options.Identifier, options);
        }

        #endregion

    }

}