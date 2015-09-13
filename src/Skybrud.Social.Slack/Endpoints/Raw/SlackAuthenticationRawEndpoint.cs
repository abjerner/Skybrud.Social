using Skybrud.Social.Http;
using Skybrud.Social.Slack.OAuth;

namespace Skybrud.Social.Slack.Endpoints.Raw {

    /// <summary>
    /// Raw implementation of the authentication endpoint.
    /// </summary>
    public class SlackAuthenticationRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent OAuth client.
        /// </summary>
        public SlackOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal SlackAuthenticationRawEndpoint(SlackOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Checks authentication and tells you who you are.
        /// </summary>
        public SocialHttpResponse GetTest() {
            return Client.DoAuthenticatedGetRequest("https://slack.com/api/auth.test");
        }

        #endregion

    }

}