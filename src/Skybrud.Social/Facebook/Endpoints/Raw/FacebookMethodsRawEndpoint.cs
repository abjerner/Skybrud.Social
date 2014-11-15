using System;
using System.Collections.Specialized;
using System.Globalization;
using Skybrud.Social.Facebook.OAuth;
using Skybrud.Social.Facebook.Options;

namespace Skybrud.Social.Facebook.Endpoints.Raw {

    public class FacebookMethodsRawEndpoint {

        public FacebookOAuthClient Client { get; private set; }

        internal FacebookMethodsRawEndpoint(FacebookOAuthClient client) {
            Client = client;
        }

        /// <summary>
        /// Gets debug information about the specified access token.
        /// </summary>
        /// <param name="accessToken">The access token to debug.</param>
        /// <returns>The raw JSON response from the API.</returns>
        public string DebugToken(string accessToken) {
            
            // Declare the query string
            NameValueCollection query = new NameValueCollection {
                { "input_token", accessToken },
                { "access_token", Client.AccessToken }
            };

            // Make the call to the API
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://graph.facebook.com/v1.0/debug_token", query);
        
        }

        /// <summary>
        /// Gets information about accounts associated with the current user by calling the <var>/me/accounts</var> method. This call requires a user access token.
        /// </summary>
        /// <returns>The raw JSON response from the API.</returns>
        public string GetAccounts() {

            // Declare the query string
            NameValueCollection query = new NameValueCollection();
            if (!String.IsNullOrWhiteSpace(Client.AccessToken)) query.Add("access_token", Client.AccessToken);

            // Make the call to the API
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://graph.facebook.com/v1.0/me/accounts?access_token", query);

        }

        /// <summary>
        /// Gets information about the specified app.
        /// </summary>
        /// <param name="identifier">The identifier of the app. Can either be "app" or the ID of the app.</param>
        /// <returns>The raw JSON response from the API.</returns>
        public string GetApp(string identifier = "app") {

            // Declare the query string
            NameValueCollection query = new NameValueCollection();
            if (!String.IsNullOrWhiteSpace(Client.AccessToken)) query.Add("access_token", Client.AccessToken);

            // Make the call to the API
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://graph.facebook.com/v1.0/" + identifier, query);

        }

        /// <summary>
        /// Gets the events of the specified user or page.
        /// </summary>
        /// <param name="identifier">The ID or name of the user/page.</param>
        /// <param name="limit">The maximum amount of events to return.</param>
        /// <returns>The raw JSON response from the API.</returns>
        public string GetEvents(string identifier, int limit = 0) {
            
            // Declare the query string
            NameValueCollection query = new NameValueCollection();
            if (!String.IsNullOrWhiteSpace(Client.AccessToken)) query.Add("access_token", Client.AccessToken);
            if (limit > 0) query.Add("limit", limit + "");

            // Make the call to the API
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://graph.facebook.com/v1.0/" + identifier + "/events", query);
        
        }
        
        /// <summary>
        /// Gets the feed of the specified user or page.
        /// </summary>
        /// <param name="identifier">The ID or name of the user/page.</param>
        /// <param name="limit">The maximum amount of entries to return.</param>
        /// <returns>The raw JSON response from the API.</returns>
        public string GetFeed(string identifier, int limit = 0) {
            return GetFeed(identifier, new FacebookPagingOptions { Limit = limit });
        }

        /// <summary>
        /// Gets the feed of the specified user or page.
        /// </summary>
        /// <param name="identifier">The ID or name of the user/page.</param>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>The raw JSON response from the API.</returns>
        public string GetFeed(string identifier, FacebookPagingOptions options) {

            // Declare the query string
            NameValueCollection query = new NameValueCollection();
            if (!String.IsNullOrWhiteSpace(Client.AccessToken)) query.Add("access_token", Client.AccessToken);
            if (options != null && options.Limit > 0) query.Add("limit", options.Limit + "");
            if (options != null && options.Since > 0) query.Add("since", options.Since + "");
            if (options != null && options.Until > 0) query.Add("until", options.Until + "");

            // Make the call to the API
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://graph.facebook.com/v1.0/" + identifier + "/feed", query);

        }

        /// <summary>
        /// Gets the feed of the specified URL. This method can be used for paging purposes. 
        /// </summary>
        /// <param name="url">The raw URL to call.</param>
        /// <returns>The raw JSON response from the API.</returns>
        public string GetFeedFromUrl(string url) {
            if (url == null) throw new ArgumentNullException("url");
            if (!url.StartsWith("https://graph.facebook.com/v1.0/")) throw new ArgumentException("Invalid URL", "url");
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString(url);
        }

        /// <summary>
        /// Gets a link with the specified ID.
        /// </summary>
        /// <param name="linkId">The ID of the link.</param>
        public string GetLink(string linkId) {

            // Construct the query string
            NameValueCollection query = new NameValueCollection {
                {"access_token", Client.AccessToken}
            };

            // Make the call to the API
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://graph.facebook.com/v1.0/" + linkId, query);

        }
        
        /// <summary>
        /// Gets information about the current user by calling the <var>/me</var> method. This call requires a user access token.
        /// </summary>
        /// <returns>The raw JSON response from the API.</returns>
        public string Me() {
            return GetObject("me");
        }

        /// <summary>
        /// Gets an object (user, post, photo or similar) with the specified <var>identifier</var>.
        /// </summary>
        /// <param name="identifier">The identifier of the object.</param>
        public string GetObject(long identifier) {
            return GetObject(identifier + "");
        }

        /// <summary>
        /// Gets an object (user, post, photo or similar) with the specified <var>identifier</var>.
        /// </summary>
        /// <param name="identifier">The identifier of the object.</param>
        public string GetObject(string identifier) {

            // Declare the query string
            NameValueCollection query = new NameValueCollection();
            if (!String.IsNullOrWhiteSpace(Client.AccessToken)) query.Add("access_token", Client.AccessToken);

            // Make the call to the API
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://graph.facebook.com/v1.0/" + identifier, query);
        
        }
        
        /// <summary>
        /// Gets the posts by the specified user or page.
        /// </summary>
        /// <param name="identifier">The ID or name of the user/page.</param>
        /// <param name="limit">The maximum amount of posts to return.</param>
        /// <returns>The raw JSON response from the API.</returns>
        public string GetPosts(string identifier, int limit = 0) {

            // Declare the query string
            NameValueCollection query = new NameValueCollection();
            if (!String.IsNullOrWhiteSpace(Client.AccessToken)) query.Add("access_token", Client.AccessToken);
            if (limit > 0) query.Add("limit", limit + "");

            // Make the call to the API
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://graph.facebook.com/v1.0/" + identifier + "/posts", query);
        
        }

        public string GetPosts(string identifier, FacebookPagingOptions options) {

            // Declare the query string
            NameValueCollection query = new NameValueCollection();
            if (!String.IsNullOrWhiteSpace(Client.AccessToken)) query.Add("access_token", Client.AccessToken);
            if (options != null && options.Limit > 0) query.Add("limit", options.Limit + "");
            if (options != null && options.Since > 0) query.Add("since", options.Since + "");
            if (options != null && options.Until > 0) query.Add("until", options.Until + "");

            // Make the call to the API
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://graph.facebook.com/v1.0/" + identifier + "/posts", query);
        
        }

        /// <summary>
        /// Gets a status message with the specified ID.
        /// </summary>
        /// <param name="statusMessageId">The ID of the status message.</param>
        public string GetStatusMessage(string statusMessageId) {

            // Construct the query string
            NameValueCollection query = new NameValueCollection {
                {"access_token", Client.AccessToken}
            };

            // Make the call to the API
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://graph.facebook.com/v1.0/" + statusMessageId, query);

        }

        #region Post link

        /// <summary>
        /// Posts a link with the specified options to the feed of the authenticated user.
        /// </summary>
        /// <param name="options">The options for the link.</param>
        public string PostLink(FacebookPostLinkOptions options) {
            return PostLink("me", options);
        }

        /// <summary>
        /// Posts a link with the specified options.
        /// </summary>
        /// <param name="identifier">The identifier of the user, page or similar.</param>
        /// <param name="options">The options for the link.</param>
        public string PostLink(long identifier, FacebookPostLinkOptions options) {
            return PostLink(identifier.ToString(CultureInfo.InvariantCulture), options);
        }

        /// <summary>
        /// Posts a link with the specified options.
        /// </summary>
        /// <param name="identifier">The identifier of user, page or similar.</param>
        /// <param name="options">The options for the link.</param>
        public string PostLink(string identifier, FacebookPostLinkOptions options) {

            // Construct the query string
            NameValueCollection query = new NameValueCollection();
            if (!String.IsNullOrWhiteSpace(options.Link)) query.Add("link", options.Link);
            if (!String.IsNullOrWhiteSpace(options.Description)) query.Add("description", options.Description);
            if (!String.IsNullOrWhiteSpace(options.Message)) query.Add("message", options.Message);
            if (!String.IsNullOrWhiteSpace(options.Name)) query.Add("name", options.Name);
            if (!String.IsNullOrWhiteSpace(options.Caption)) query.Add("caption", options.Caption);
            query.Add("access_token", Client.AccessToken);

            // Make the call to the API
            return SocialUtils.DoHttpPostRequestAndGetBodyAsString("https://graph.facebook.com/v1.0/" + identifier + "/feed", query);

        }

        #endregion

        #region Post status message

        /// <summary>
        /// Posts a status message to the wall of the authenticated user.
        /// </summary>
        /// <param name="message">The text of the status message.</param>
        public string PostStatusMessage(string message) {
            return PostStatusMessage("me", message);
        }

        /// <summary>
        /// Posts a status message to the wall of specified <var>identifier</var>.
        /// </summary>
        /// <param name="identifier">The identifier of the user, page or similar.</param>
        /// <param name="message">The text of the status message.</param>
        public string PostStatusMessage(long identifier, string message) {
            return PostStatusMessage(identifier.ToString(CultureInfo.InvariantCulture), message);
        }

        /// <summary>
        /// Posts a status message to the wall of specified <var>identifier</var>.
        /// </summary>
        /// <param name="identifier">The identifier of the user, page or similar.</param>
        /// <param name="message">The text of the status message.</param>
        public string PostStatusMessage(string identifier, string message) {

            // Construct the query string
            NameValueCollection query = new NameValueCollection {
                {"message", message},
                {"access_token", Client.AccessToken}
            };

            // Make the call to the API
            return SocialUtils.DoHttpPostRequestAndGetBodyAsString("https://graph.facebook.com/v1.0/" + identifier + "/feed", query);

        }

        #endregion

    }

}
