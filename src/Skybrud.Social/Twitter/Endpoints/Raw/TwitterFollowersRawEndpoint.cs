using Skybrud.Social.Http;
using Skybrud.Social.Twitter.OAuth;
using Skybrud.Social.Twitter.Options;

namespace Skybrud.Social.Twitter.Endpoints.Raw {

    public class TwitterFollowersRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the OAuth 1.0a client.
        /// </summary>
        public TwitterOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal TwitterFollowersRawEndpoint(TwitterOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Membmer methods

        /// <summary>
        /// Gets a list of IDs representing the followers of a given user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        public SocialHttpResponse GetIds(long userId) {
            return GetIds(new TwitterFollowersIdsOptions {
                UserId = userId
            });
        }

        /// <summary>
        /// Gets a list of IDs representing the followers of a given user.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        public SocialHttpResponse GetIds(string screenName) {
            return GetIds(new TwitterFollowersIdsOptions {
                ScreenName = screenName
            });
        }

        /// <summary>
        /// Gets a list of IDs representing the followers of a given user.
        /// </summary>
        /// <param name="options">The options for the call.</param>
        public SocialHttpResponse GetIds(TwitterFollowersIdsOptions options) {
            return Client.DoHttpGetRequest("https://api.twitter.com/1.1/followers/ids.json", options);
        }

        /// <summary>
        /// Gets a list of followers for a given user using the default options.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        public SocialHttpResponse GetList(long userId) {
            return GetList(new TwitterFollowersListOptions {
                UserId = userId
            });
        }

        /// <summary>
        /// Gets a list of followers for a given user using the default options.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        public SocialHttpResponse GetList(string screenName) {
            return GetList(new TwitterFollowersListOptions {
                ScreenName = screenName
            });
        }

        /// <summary>
        /// Gets a list of followers for a given user using the specified options.
        /// </summary>
        /// <param name="options">The options for the call.</param>
        public SocialHttpResponse GetList(TwitterFollowersListOptions options) {
            return Client.DoHttpGetRequest("https://api.twitter.com/1.1/followers/list.json", options);
        }

        #endregion

    }

}