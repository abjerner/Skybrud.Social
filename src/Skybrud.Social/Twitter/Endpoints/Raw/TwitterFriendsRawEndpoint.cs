using System.Collections.Specialized;
using System.Globalization;
using System.Net;
using Skybrud.Social.Twitter.Enums;
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
        /// Gets a list of friends for a given user using the default options.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        public string GetListFromUserId(long userId) {
            return GetListFromUserId(userId, null);
        }

        /// <summary>
        /// Gets a list of friends for a given user using the default options.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="options">The options for the call.</param>
        public string GetListFromUserId(long userId, TwitterFriendsListOptions options) {

            // Define the query string
            NameValueCollection query = new NameValueCollection {
                {"user_id", userId.ToString(CultureInfo.InvariantCulture)}
            };

            // Update the query string with the specified options
            if (options != null) options.UpdateNameValueCollection(query);

            // Make the call to the API
            return Client.DoHttpRequestAsString("GET", "https://api.twitter.com/1.1/friends/list.json", query);

        }

        /// <summary>
        /// Gets a list of friends for a given user using the default options.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        public string GetListFromScreenName(string screenName) {
            return GetListFromScreenName(screenName, null);
        }

        /// <summary>
        /// Gets a list of friends for a given user using the specified options.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <param name="options">The options for the call.</param>
        public string GetListFromScreenName(string screenName, TwitterFriendsListOptions options) {

            // Define the query string
            NameValueCollection query = new NameValueCollection {
                {"screen_name", screenName}
            };

            // Update the query string with the specified options
            if (options != null) options.UpdateNameValueCollection(query);

            // Make the call to the API
            return Client.DoHttpRequestAsString("GET", "https://api.twitter.com/1.1/friends/list.json", query);

        }

        #endregion

    }

}
