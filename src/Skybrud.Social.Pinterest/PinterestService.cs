using System;
using Skybrud.Social.Pinterest.Endpoints;
using Skybrud.Social.Pinterest.OAuth;

namespace Skybrud.Social.Pinterest {

    /// <summary>
    /// Service implementation of the Pinterest API.
    /// </summary>
    public class PinterestService {

        #region Properties

        /// <summary>
        /// Gets a reference to the internal OAuth client.
        /// </summary>
        public PinterestOAuthClient Client { get; private set; }

        /// <summary>
        /// Gets a reference to the users endpoint.
        /// </summary>
        public PinterestUsersEndpoint Users { get; private set; }

        #endregion

        #region Constructors

        private PinterestService(PinterestOAuthClient client) {
            Client = client;
            Users = new PinterestUsersEndpoint(this);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Initialize a new service instance from the specified OAuth client.
        /// </summary>
        /// <param name="client">The OAuth client.</param>
        public static PinterestService CreateFromOAuthClient(PinterestOAuthClient client) {

            // This should never be null
            if (client == null) throw new ArgumentNullException("client");

            // Initialize the service
            return new PinterestService(client);

        }

        /// <summary>
        /// Initializes a new service instance from the specific OAuth 2 access token.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        public static PinterestService CreateFromAccessToken(string accessToken) {
            return CreateFromOAuthClient(new PinterestOAuthClient {
                AccessToken = accessToken
            });
        }

        #endregion

    }

}