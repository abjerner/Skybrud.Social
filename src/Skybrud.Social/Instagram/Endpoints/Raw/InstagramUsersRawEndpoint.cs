using Skybrud.Social.Http;
using Skybrud.Social.Instagram.OAuth;
using Skybrud.Social.Instagram.Options.Users;

namespace Skybrud.Social.Instagram.Endpoints.Raw {

    /// <see cref="http://instagram.com/developer/endpoints/users/"/>
    public class InstagramUsersRawEndpoint {

        #region Properties

        public InstagramOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal InstagramUsersRawEndpoint(InstagramOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods
        
        /// <summary>
        /// Gets information about a user by the specified ID.
        /// </summary>
        /// <param name="identifier">The identifier of the user.</param>
        public SocialHttpResponse GetUser(string identifier) {
            return Client.DoAuthenticatedGetRequest("https://api.instagram.com/v1/users/" + identifier + "/");
        }
        
        /// <summary>
        /// Get the most recent media published by a user.
        /// </summary>
        /// <param name="identifier">The identifier of the user.</param>
        /// <param name="options">The search options with any optional parameters.</param>
        /// <returns>Returns the raw JSON response from the API.</returns>
        public SocialHttpResponse GetRecentMedia(string identifier, InstagramUserRecentMediaOptions options) {
            return Client.DoAuthenticatedGetRequest("https://api.instagram.com/v1/users/" + identifier + "/media/recent/", options);
        }

        // TODO: Implement /users/self/media/liked
        /// <summary>
        /// Get the authenticated users current liked media. Takes a "Count" and "MAX_LIKE_ID"
        /// </summary>
        /// <param name="options">The search options with any optional parameters.</param>
        /// <returns>Returns the raw JSON response from the API.</returns>
        public SocialHttpResponse GetLiked(InstagramUserLikedMediaOptions options)
        {
            return Client.DoAuthenticatedGetRequest("https://api.instagram.com/v1/users/self/media/liked", options);
        }

        /// <summary>
        /// Search for a user by name.
        /// </summary>
        /// <param name="query">A query string.</param>
        public SocialHttpResponse Search(string query) {
            return Search(new InstagramUserSearchOptions {
                Query = query
            });
        }
        
        /// <summary>
        /// Search for a user by name.
        /// </summary>
        /// <param name="query">A query string.</param>
        /// <param name="count">The maximum amount of users to return.</param>
        public SocialHttpResponse Search(string query, int count) {
            return Search(new InstagramUserSearchOptions {
                Query = query,
                Count = count
            });
        }
        
        /// <summary>
        /// Search for a user by name.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        public SocialHttpResponse Search(InstagramUserSearchOptions options) {
            return Client.DoAuthenticatedGetRequest("https://api.instagram.com/v1/users/search", options);
        }

        #endregion

    }

}