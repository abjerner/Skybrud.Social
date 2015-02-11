using Skybrud.Social.Twitter.Endpoints.Raw;
using Skybrud.Social.Twitter.Options;
using Skybrud.Social.Twitter.Responses;

namespace Skybrud.Social.Twitter.Endpoints {
    
    public class TwitterFriendsEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Twitter service.
        /// </summary>
        public TwitterService Service { get; private set; }

        /// <summary>
        /// Gets a reference to the raw friends endpoint.
        /// </summary>
        public TwitterFriendsRawEndpoint Raw {
            get { return Service.Client.Friends; }
        }

        #endregion

        #region Constructors

        internal TwitterFriendsEndpoint(TwitterService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a list of IDs representing the friends of a given user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        public TwitterIdsResponse GetIds(long userId) {
            return TwitterIdsResponse.ParseResponse(Raw.GetIds(userId));
        }

        /// <summary>
        /// Gets a list of IDs representing the friends of a given user.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        public TwitterIdsResponse GetIds(string screenName) {
            return TwitterIdsResponse.ParseResponse(Raw.GetIds(screenName));
        }

        /// <summary>
        /// Gets a list of IDs representing the friends of a given user.
        /// </summary>
        /// <param name="options">The options for the call.</param>
        public TwitterIdsResponse GetIds(TwitterFriendsIdsOptions options) {
            return TwitterIdsResponse.ParseResponse(Raw.GetIds(options));
        }

        /// <summary>
        /// Gets a list of friends for a given user using the default options.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        public TwitterUserListResponse GetList(long userId) {
            return TwitterUserListResponse.ParseResponse(Raw.GetList(userId));
        }

        /// <summary>
        /// Gets a list of friends for a given user using the default options.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        public TwitterUserListResponse GetList(string screenName) {
            return TwitterUserListResponse.ParseResponse(Raw.GetList(screenName));
        }

        /// <summary>
        /// Gets a list of friends for a given user using the specified options.
        /// </summary>
        /// <param name="options">The options for the call.</param>
        public TwitterUserListResponse GetList(TwitterFriendsListOptions options) {
            return TwitterUserListResponse.ParseResponse(Raw.GetList(options));
        }

        #endregion

    }

}