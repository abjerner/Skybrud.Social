using System;
using Skybrud.Social.Box.Endpoints;
using Skybrud.Social.Box.OAuth;
using Skybrud.Social.Box.Responses.Authentication;

namespace Skybrud.Social.Box {

    /// <summary>
    /// Service implementation of the Box.com API.
    /// </summary>
    public class BoxService {

        #region Properties

        /// <summary>
        /// Gets a reference to the internal OAuth client.
        /// </summary>
        public BoxOAuthClient Client { get; private set; }

        /// <summary>
        /// Gets a reference to the folders endpoint.
        /// </summary>
        public BoxFoldersEndpoint Folders { get; private set; }

        #endregion

        #region Constructors

        private BoxService(BoxOAuthClient client) {
            Client = client;
            Folders = new BoxFoldersEndpoint(this);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Initialize a new service instance from the specified OAuth client.
        /// </summary>
        /// <param name="client">The OAuth client.</param>
        public static BoxService CreateFromOAuthClient(BoxOAuthClient client) {

            // This should never be null
            if (client == null) throw new ArgumentNullException("client");

            // Initialize the service
            return new BoxService(client);

        }

        /// <summary>
        /// Initializes a new service instance from the specifie OAuth 2 access
        /// token.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        public static BoxService CreateFromAccessToken(string accessToken) {
            return CreateFromOAuthClient(new BoxOAuthClient {
                AccessToken = accessToken
            });
        }

        /// <summary>
        /// Initializes a new instance based on the specified refresh token.
        /// </summary>
        /// <param name="clientId">The client ID.</param>
        /// <param name="clientSecret">The client secret.</param>
        /// <param name="refreshToken">The refresh token of the user.</param>
        public static BoxService CreateFromRefreshToken(string clientId, string clientSecret, string refreshToken) {

            // Initialize a new OAuth client
            BoxOAuthClient client = new BoxOAuthClient(clientId, clientSecret);

            // Get an access token from the refresh token.
            BoxTokenResponse response = client.GetAccessTokenFromRefreshToken(refreshToken);

            // Update the OAuth client with the access token
            client.AccessToken = response.Body.AccessToken;

            // Initialize a new service instance
            return new BoxService(client);

        }

        #endregion

    }

}