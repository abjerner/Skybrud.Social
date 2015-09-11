using Skybrud.Social.Microsoft.OAuth;
using Skybrud.Social.Microsoft.Responses.Authentication;
using Skybrud.Social.Microsoft.WindowsLive.Endpoints;
using System;

namespace Skybrud.Social.Microsoft {

    /// <summary>
    /// Service implementation of the various Microsoft APIs.
    /// </summary>
    public class MicrosoftService {

        #region Properties

        /// <summary>
        /// Gets a reference to the internal OAuth client.
        /// </summary>
        public MicrosoftOAuthClient Client { get; private set; }

        /// <summary>
        /// Gets a reference to the Windows Live endpoint.
        /// </summary>
        public WindowsLiveEndpoint WindowsLive { get; private set; }

        #endregion

        #region Constructors

        private MicrosoftService(MicrosoftOAuthClient client) {
            Client = client;
            WindowsLive = new WindowsLiveEndpoint(this);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Initialize a new service instance from the specified OAuth client.
        /// </summary>
        /// <param name="client">The OAuth client.</param>
        public static MicrosoftService CreateFromOAuthClient(MicrosoftOAuthClient client) {

            // This should never be null
            if (client == null) throw new ArgumentNullException("client");

            // Initialize the service
            return new MicrosoftService(client);

        }

        /// <summary>
        /// Initializes a new service instance from the specifie OAuth 2 access
        /// token.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        public static MicrosoftService CreateFromAccessToken(string accessToken) {
            return CreateFromOAuthClient(new MicrosoftOAuthClient {
                AccessToken = accessToken
            });
        }

        /// <summary>
        /// Initializes a new instance based on the specified refresh token.
        /// </summary>
        /// <param name="clientId">The client ID.</param>
        /// <param name="clientSecret">The client secret.</param>
        /// <param name="refreshToken">The refresh token of the user.</param>
        public static MicrosoftService CreateFromRefreshToken(string clientId, string clientSecret, string refreshToken) {

            // Initialize a new OAuth client
            MicrosoftOAuthClient client = new MicrosoftOAuthClient(clientId, clientSecret);

            // Get an access token from the refresh token.
            MicrosoftTokenResponse response = client.GetAccessTokenFromRefreshToken(refreshToken);

            // Update the OAuth client with the access token
            client.AccessToken = response.Body.AccessToken;

            // Initialize a new service instance
            return new MicrosoftService(client);

        }

        #endregion

    }

}