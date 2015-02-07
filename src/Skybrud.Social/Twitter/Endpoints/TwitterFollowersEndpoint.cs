using Skybrud.Social.Twitter.Endpoints.Raw;
using Skybrud.Social.Twitter.Options;
using Skybrud.Social.Twitter.Responses;

namespace Skybrud.Social.Twitter.Endpoints {
    
    public class TwitterFollowersEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Twitter service.
        /// </summary>
        public TwitterService Service { get; private set; }

        /// <summary>
        /// Gets a reference to the raw followers endpoint.
        /// </summary>
        public TwitterFollowersRawEndpoint Raw {
            get { return Service.Client.Followers; }
        }

        #endregion

        #region Constructors

        internal TwitterFollowersEndpoint(TwitterService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a list of IDs representing the friends of a given user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        public TwitterIdsResponse GetIdsFromUserId(long userId) {
            return GetIdsFromUserId(userId, null);
        }

        /// <summary>
        /// Gets a list of IDs representing the friends of a given user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="options">The options for the call.</param>
        public TwitterIdsResponse GetIdsFromUserId(long userId, TwitterFollowersIdsOptions options) {
            return TwitterIdsResponse.ParseResponse(Raw.GetIdsFromUserId(userId, options));
        }

        /// <summary>
        /// Gets a list of IDs representing the friends of a given user.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        public TwitterIdsResponse GetIdsFromScreenName(string screenName) {
            return GetIdsFromScreenName(screenName, null);
        }

        /// <summary>
        /// Gets a list of IDs representing the friends of a given user.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <param name="options">The options for the call.</param>
        public TwitterIdsResponse GetIdsFromScreenName(string screenName, TwitterFollowersIdsOptions options) {
            return TwitterIdsResponse.ParseResponse(Raw.GetIdsFromScreenName(screenName, options));
        }

        /// <summary>
        /// Gets a list of friends for a given user using the default options.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        public TwitterUserListResponse GetListFromUserId(long userId) {
            return GetListFromUserId(userId, null);
        }

        /// <summary>
        /// Gets a list of friends for a given user using the default options.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="options">The options for the call.</param>
        public TwitterUserListResponse GetListFromUserId(long userId, TwitterFollowersListOptions options) {
            return TwitterUserListResponse.ParseJson(Raw.GetListFromUserId(userId, options).Body);
        }

        /// <summary>
        /// Gets a list of friends for a given user using the default options.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        public TwitterUserListResponse GetListFromScreenName(string screenName) {
            return GetListFromScreenName(screenName, null);
        }

        /// <summary>
        /// Gets a list of friends for a given user using the specified options.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <param name="options">The options for the call.</param>
        public TwitterUserListResponse GetListFromScreenName(string screenName, TwitterFollowersListOptions options) {
            return TwitterUserListResponse.ParseJson(Raw.GetListFromScreenName(screenName, options).Body);
        }

        #endregion

    }

}