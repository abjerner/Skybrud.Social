using System.Collections.Specialized;
using System.Globalization;
using Skybrud.Social.Twitter.Endpoints.Raw;
using Skybrud.Social.Twitter.Options;
using Skybrud.Social.Twitter.Responses;

namespace Skybrud.Social.Twitter.Endpoints {
    
    public class TwitterFriendsEndpoint {

        #region Properties

        /// <summary>
        /// A reference to the Twitter service.
        /// </summary>
        public TwitterService Service { get; private set; }

        /// <summary>
        /// A reference to the raw endpoint.
        /// </summary>
        public TwitterFriendsRawEndpoint Raw {
            get { return Service.Client.Friends; }
        }

        #endregion

        #region Constructor(s)

        internal TwitterFriendsEndpoint(TwitterService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a list of friends for a given user using the default options.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        public TwitterFriendsListResponse GetListFromUserId(long userId) {
            return GetListFromUserId(userId, null);
        }

        /// <summary>
        /// Gets a list of friends for a given user using the default options.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="options">The options for the call.</param>
        public TwitterFriendsListResponse GetListFromUserId(long userId, TwitterFriendsListOptions options) {
            return TwitterFriendsListResponse.ParseJson(Raw.GetListFromUserId(userId, options));
        }

        /// <summary>
        /// Gets a list of friends for a given user using the default options.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        public TwitterFriendsListResponse GetListFromScreenName(string screenName) {
            return GetListFromScreenName(screenName, null);
        }

        /// <summary>
        /// Gets a list of friends for a given user using the specified options.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <param name="options">The options for the call.</param>
        public TwitterFriendsListResponse GetListFromScreenName(string screenName, TwitterFriendsListOptions options) {
            return TwitterFriendsListResponse.ParseJson(Raw.GetListFromScreenName(screenName, options));
        }

        #endregion

    }

}