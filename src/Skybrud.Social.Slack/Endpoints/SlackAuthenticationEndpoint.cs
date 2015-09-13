using Skybrud.Social.Slack.Endpoints.Raw;
using Skybrud.Social.Slack.Responses.Authentication;

namespace Skybrud.Social.Slack.Endpoints {

    /// <summary>
    /// Implementation of the authentication endpoint.
    /// </summary>
    public class SlackAuthenticationEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Slack service.
        /// </summary>
        public SlackService Service { get; private set; }

        /// <summary>
        /// A reference to the raw endpoint.
        /// </summary>
        public SlackAuthenticationRawEndpoint Raw {
            get { return Service.Client.Authentication; }
        }

        #endregion

        #region Constructors

        internal SlackAuthenticationEndpoint(SlackService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Checks authentication and tells you who you are.
        /// </summary>
        public SlackAuthenticationTestResponse GetTest() {
            return SlackAuthenticationTestResponse.ParseResponse(Raw.GetTest());
        }

        #endregion

    }

}