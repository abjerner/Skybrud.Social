using Skybrud.Social.Http;
using Skybrud.Social.Twitter.OAuth;
using Skybrud.Social.Twitter.Options;

namespace Skybrud.Social.Twitter.Endpoints.Raw {

    public class TwitterFriendsRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the OAuth 1.0a client.
        /// </summary>
        public TwitterOAuthClient Client { get; private set; }

        #endregion

        #region Constructor
        
        internal TwitterFriendsRawEndpoint(TwitterOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets a list of IDs representing the friends of a given user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        public SocialHttpResponse GetIds(long userId) {
            return GetIds(new TwitterFriendsIdsOptions {
                UserId = userId
            });
        }

        /// <summary>
        /// Gets a list of IDs representing the friends of a given user.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        public SocialHttpResponse GetIds(string screenName) {
            return GetIds(new TwitterFriendsIdsOptions {
                ScreenName = screenName
            });
        }

        /// <summary>
        /// Gets a list of IDs representing the friends of a given user.
        /// </summary>
        /// <param name="options">The options for the call.</param>
        public SocialHttpResponse GetIds(TwitterFriendsIdsOptions options) {
            return Client.DoHttpGetRequest("https://api.twitter.com/1.1/friends/ids.json", options);
        }

        /// <summary>
        /// Gets a list of friends for a given user using the default options.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        public SocialHttpResponse GetList(long userId) {
            return GetList(new TwitterFriendsListOptions {
                UserId = userId
            });
        }

        /// <summary>
        /// Gets a list of friends for a given user using the default options.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        public SocialHttpResponse GetList(string screenName) {
            return GetList(new TwitterFriendsListOptions {
                ScreenName = screenName
            });
        }

        /// <summary>
        /// Gets a list of friends for a given user using the specified options.
        /// </summary>
        /// <param name="options">The options for the call.</param>
        public SocialHttpResponse GetList(TwitterFriendsListOptions options) {
            return Client.DoHttpGetRequest("https://api.twitter.com/1.1/friends/list.json", options);
        }

        #endregion

    }

}