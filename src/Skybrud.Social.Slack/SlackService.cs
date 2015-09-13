using System;
using Skybrud.Social.Slack.Endpoints;
using Skybrud.Social.Slack.OAuth;

namespace Skybrud.Social.Slack {
    
    /// <summary>
    /// Service implementation of the Slack API.
    /// </summary>
    public class SlackService {

        #region Properties

        /// <summary>
        /// The internal OAuth client for communication with the Slack API.
        /// </summary>
        public SlackOAuthClient Client { get; private set; }

        /// <summary>
        /// Gets a reference to the authentication endpoint.
        /// </summary>
        public SlackAuthenticationEndpoint Authentication { get; private set; }

        /// <summary>
        /// Gets a reference to the users endpoint.
        /// </summary>
        public SlackUsersEndpoint Users { get; private set; }

        #endregion

        #region Constructor(s)

        private SlackService(SlackOAuthClient client) {
            Client = client;
            Authentication = new SlackAuthenticationEndpoint(this);
            Users = new SlackUsersEndpoint(this);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Initialize a new service instance from the specified OAuth client.
        /// </summary>
        /// <param name="client">The OAuth client.</param>
        public static SlackService CreateFromOAuthClient(SlackOAuthClient client) {

            // This should never be null
            if (client == null) throw new ArgumentNullException("client");

            // Initialize the service
            return new SlackService(client);

        }

        /// <summary>
        /// Initializes a new service instance from the specifie OAuth 2 access token.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        public static SlackService CreateFromAccessToken(string accessToken) {
            return CreateFromOAuthClient(new SlackOAuthClient {
                AccessToken = accessToken
            });
        }

        #endregion

    }

}