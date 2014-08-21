using System.Collections.Specialized;
using Skybrud.Social.Instagram.OAuth;
using Skybrud.Social.Instagram.Options;

namespace Skybrud.Social.Instagram.Endpoints.Raw {
    
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
        /// Gets information about the authenticated user.
        /// </summary>
        public string GetSelf() {
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://api.instagram.com/v1/users/self/?access_token=" + Client.AccessToken);
        }

        /// <summary>
        /// Gets information about a user by the specified ID.
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        public string GetUser(long id) {
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://api.instagram.com/v1/users/" + id + "/?access_token=" + Client.AccessToken);
        }

        /// <summary>
        /// Get the most recent media published by the authenticated user.
        /// </summary>
        /// <returns>Returns the raw JSON response from the API.</returns>
        public string GetRecentMedia() {
            return GetRecentMedia("self", null);
        }

        /// <summary>
        /// Get the most recent media published by the authenticated user.
        /// </summary>
        /// <param name="options">The search options with any optional parameters.</param>
        /// <returns>Returns the raw JSON response from the API.</returns>
        public string GetRecentMedia(InstagramMediaSearchOptions options) {
            return GetRecentMedia("self", options);
        }

        /// <summary>
        /// Get the most recent media published by a user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="count">Count of media to return.</param>
        /// <returns>Returns the raw JSON response from the API.</returns>
        public string GetRecentMedia(long userId, int count = 0) {
            return GetRecentMedia(userId + "", new InstagramMediaSearchOptions {
                Count = count
            });
        }

        /// <summary>
        /// Get the most recent media published by a user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="options">The search options with any optional parameters.</param>
        /// <returns>Returns the raw JSON response from the API.</returns>
        public string GetRecentMedia(long userId, InstagramMediaSearchOptions options) {
            return GetRecentMedia(userId + "", options);
        }

        /// <summary>
        /// Get the most recent media published by a user.
        /// </summary>
        /// <param name="identifier">The identifier of the user.</param>
        /// <param name="options">The search options with any optional parameters.</param>
        /// <returns>Returns the raw JSON response from the API.</returns>
        public string GetRecentMedia(string identifier, InstagramMediaSearchOptions options) {

            // Declare the query string
            NameValueCollection qs = new NameValueCollection { { "access_token", Client.AccessToken } };
            
            // Add any optional parameters
            if (options != null) {
                if (options.Count > 0) qs.Add("count", options.Count + "");
                if (options.MinId != null) qs.Add("min_id", options.MinId + "");
                if (options.MaxId != null) qs.Add("max_id", options.MaxId + "");
            }

            // Perform the call to the API
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://api.instagram.com/v1/users/" + identifier + "/media/recent/", qs);

        }

        // TODO: Implement /users/self/media/liked

        /// <summary>
        /// Search for a user by name.
        /// </summary>
        /// <param name="query">A query string.</param>
        /// <param name="count">Number of users to return.</param>
        public string Search(string query, int count = 0) {

            // Declare the query string
            NameValueCollection qs = new NameValueCollection {
                {"access_token", Client.AccessToken},
                {"q", query}
            };

            // Optional
            if (count > 0) qs.Add("count", count + "");

            // Perform the call to the API
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://api.instagram.com/v1/users/search", qs);

        }

        #endregion

    }

}
