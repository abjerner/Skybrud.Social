using Skybrud.Social.Http;
using Skybrud.Social.Twitter.OAuth;
using Skybrud.Social.Twitter.Options.Favorites;

namespace Skybrud.Social.Twitter.Endpoints.Raw {
    
    /// <summary>
    /// Raw implementation of the favorites endpoint.
    /// </summary>
    public class TwitterFavoritesRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the OAuth 1.0a client.
        /// </summary>
        public TwitterOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal TwitterFavoritesRawEndpoint(TwitterOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a list of favorites of the authenticated user.
        /// </summary>
        /// <see>
        ///     <cref>https://dev.twitter.com/rest/reference/get/favorites/list</cref>
        /// </see>
        public SocialHttpResponse GetFavorites() {
            return GetFavorites(default(TwitterGetFavoritesOptions));
        }

        /// <summary>
        /// Gets a list of favorites of the user with the specified <code>userId</code>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <see>
        ///     <cref>https://dev.twitter.com/rest/reference/get/favorites/list</cref>
        /// </see>
        public SocialHttpResponse GetFavorites(long userId) {
            return GetFavorites(new TwitterGetFavoritesOptions {
                UserId = userId
            });
        }

        /// <summary>
        /// Gets a list of favorites of the user with the specified <code>screenName</code>.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <see>
        ///     <cref>https://dev.twitter.com/rest/reference/get/favorites/list</cref>
        /// </see>
        public SocialHttpResponse GetFavorites(string screenName) {
            return GetFavorites(new TwitterGetFavoritesOptions {
                ScreenName = screenName
            });
        }

        /// <summary>
        /// Gets a list of favorites based on the specified <code>options</code>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <see>
        ///     <cref>https://dev.twitter.com/rest/reference/get/favorites/list</cref>
        /// </see>
        public SocialHttpResponse GetFavorites(TwitterGetFavoritesOptions options) {
            return Client.DoHttpGetRequest("https://api.twitter.com/1.1/favorites/list.json", options);
        }

        /// <summary>
        /// Favorites the status message with the specified <code>statusId</code> as the authenticating user.
        /// </summary>
        /// <param name="statusId">The ID of the status message.</param>
        /// <see>
        ///     <cref>https://dev.twitter.com/rest/reference/post/favorites/create</cref>
        /// </see>
        public SocialHttpResponse Create(long statusId) {

            // Declare the query string
            SocialQueryString query = new SocialQueryString();
            query.Add("id", statusId);

            // Make the call to the API
            return Client.DoHttpGetRequest("https://api.twitter.com/1.1/favorites/create.json", query);

        }

        /// <summary>
        /// Un-favorites the status message with the specified <code>statusId</code> as the authenticating user.
        /// </summary>
        /// <param name="statusId">The ID of the status message.</param>
        /// <see>
        ///     <cref>https://dev.twitter.com/rest/reference/post/favorites/destroy</cref>
        /// </see>
        public SocialHttpResponse Destroy(long statusId) {

            // Declare the query string
            SocialQueryString query = new SocialQueryString();
            query.Add("id", statusId);

            // Make the call to the API
            return Client.DoHttpGetRequest("https://api.twitter.com/1.1/favorites/destroy.json", query);

        }

        #endregion

    }

}