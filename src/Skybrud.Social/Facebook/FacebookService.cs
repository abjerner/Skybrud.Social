using System;
using Skybrud.Social.Facebook.Endpoints;
using Skybrud.Social.Facebook.OAuth;

namespace Skybrud.Social.Facebook {

    public class FacebookService {

        #region Properties

        /// <summary>
        /// The internal OAuth client for communication with the Facebook API.
        /// </summary>
        public FacebookOAuthClient Client { get; private set; }

        public FacebookMethodsEndpoint Methods { get; private set; }
        public FacebookPhotosEndpoint Photos { get; private set; }
        public FacebookPostsEndpoint Posts { get; private set; }

        #endregion

        #region Constructor(s)

        private FacebookService() {
            Methods = new FacebookMethodsEndpoint(this);
            Photos = new FacebookPhotosEndpoint(this);
            Posts = new FacebookPostsEndpoint(this);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Initialize a new service instance from the specified access token. Internally a new OAuth client will be
        /// initialized from the access token.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        public static FacebookService CreateFromAccessToken(string accessToken) {
            return new FacebookService {
                Client = new FacebookOAuthClient(accessToken)
            };
        }

        /// <summary>
        /// Initialize a new service instance from the specified OAuth client.
        /// </summary>
        /// <param name="client">The OAuth client.</param>
        public static FacebookService CreateFromOAuthClient(FacebookOAuthClient client) {

            // This should never be null
            if (client == null) throw new ArgumentNullException("client");

            // Initialize the service
            FacebookService service = new FacebookService {
                Client = client
            };

            // Set the endpoints etc.
            service.Methods = new FacebookMethodsEndpoint(service);

            // Return the service
            return service;
        
        }

        #endregion

    }

}
