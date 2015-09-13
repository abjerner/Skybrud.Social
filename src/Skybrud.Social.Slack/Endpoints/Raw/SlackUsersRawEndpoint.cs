using Skybrud.Social.Http;
using Skybrud.Social.Slack.OAuth;

namespace Skybrud.Social.Slack.Endpoints.Raw {

    /// <summary>
    /// Raw implementation of the users endpoint.
    /// </summary>
    public class SlackUsersRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent OAuth client.
        /// </summary>
        public SlackOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal SlackUsersRawEndpoint(SlackOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about a team member.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <see>
        ///     <cref>https://api.slack.com/methods/users.info</cref>
        /// </see>
        public SocialHttpResponse GetInfo(string userId) {
            return Client.DoAuthenticatedGetRequest("https://slack.com/api/users.info?user=" + userId);
        }

        /// <summary>
        /// Gets a list of all users in the team. This includes deleted/deactivated users.
        /// </summary>
        /// <see>
        ///     <cref>https://api.slack.com/methods/users.list</cref>
        /// </see>
        public SocialHttpResponse GetList() {
            return Client.DoAuthenticatedGetRequest("https://slack.com/api/users.list");
        }

        /// <summary>
        /// Gets a list of all users in the team. This includes deleted/deactivated users.
        /// </summary>
        /// <param name="presence">Specifies whether presence data should be included in the output.</param>
        /// <see>
        ///     <cref>https://api.slack.com/methods/users.list</cref>
        /// </see>
        public SocialHttpResponse GetList(bool presence) {
            return Client.DoAuthenticatedGetRequest("https://slack.com/api/users.list" + (presence ? "?presence=1" : ""));
        }

        #endregion

    }

}