using Skybrud.Social.Slack.Endpoints.Raw;
using Skybrud.Social.Slack.Responses.Users;

namespace Skybrud.Social.Slack.Endpoints {

    /// <summary>
    /// Implementation of the users endpoint.
    /// </summary>
    public class SlackUsersEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Slack service.
        /// </summary>
        public SlackService Service { get; private set; }

        /// <summary>
        /// A reference to the raw endpoint.
        /// </summary>
        public SlackUsersRawEndpoint Raw {
            get { return Service.Client.Users; }
        }

        #endregion

        #region Constructors

        internal SlackUsersEndpoint(SlackService service) {
            Service = service;
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
        public SlackGetUserInfoResponse GetInfo(string userId) {
            return SlackGetUserInfoResponse.ParseResponse(Raw.GetInfo(userId));
        }

        /// <summary>
        /// Gets a list of all users in the team. This includes deleted/deactivated users.
        /// </summary>
        /// <see>
        ///     <cref>https://api.slack.com/methods/users.list</cref>
        /// </see>
        public SlackGetUserListResponse GetList() {
            return SlackGetUserListResponse.ParseResponse(Raw.GetList());
        }

        /// <summary>
        /// Gets a list of all users in the team. This includes deleted/deactivated users.
        /// </summary>
        /// <param name="presence">Specifies whether presence data should be included in the output.</param>
        /// <see>
        ///     <cref>https://api.slack.com/methods/users.list</cref>
        /// </see>
        public SlackGetUserListResponse GetUsers(bool presence) {
            return SlackGetUserListResponse.ParseResponse(Raw.GetList(presence));
        }

        #endregion

    }

}