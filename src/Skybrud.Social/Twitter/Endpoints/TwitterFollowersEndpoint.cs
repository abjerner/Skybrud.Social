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
        public TwitterIdsResponse GetIds(long userId) {
            return GetIds(userId, null);
        }

        /// <summary>
        /// Gets a list of IDs representing the friends of a given user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="options">The options for the call.</param>
        public TwitterIdsResponse GetIds(long userId, TwitterFollowersIdsOptions options) {
            return TwitterIdsResponse.ParseResponse(Raw.GetIds(userId, options));
        }

        /// <summary>
        /// Gets a list of IDs representing the friends of a given user.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        public TwitterIdsResponse GetIds(string screenName) {
            return GetIds(screenName, null);
        }

        /// <summary>
        /// Gets a list of IDs representing the friends of a given user.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <param name="options">The options for the call.</param>
        public TwitterIdsResponse GetIds(string screenName, TwitterFollowersIdsOptions options) {
            return TwitterIdsResponse.ParseResponse(Raw.GetIds(screenName, options));
        }

        /// <summary>
        /// Gets a list of friends for a given user using the default options.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        public TwitterUserListResponse GetList(long userId) {
            return GetList(userId, null);
        }

        /// <summary>
        /// Gets a list of friends for a given user using the default options.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="options">The options for the call.</param>
        public TwitterUserListResponse GetList(long userId, TwitterFollowersListOptions options) {
            return TwitterUserListResponse.ParseResponse(Raw.GetList(userId, options));
        }

        /// <summary>
        /// Gets a list of friends for a given user using the default options.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        public TwitterUserListResponse GetList(string screenName) {
            return GetList(screenName, null);
        }

        /// <summary>
        /// Gets a list of friends for a given user using the specified options.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <param name="options">The options for the call.</param>
        public TwitterUserListResponse GetList(string screenName, TwitterFollowersListOptions options) {
            return TwitterUserListResponse.ParseResponse(Raw.GetList(screenName, options));
        }

        #endregion

    }

}