using System;
using System.Collections.Specialized;
using Skybrud.Social.Facebook.OAuth;
using Skybrud.Social.Facebook.Options;

namespace Skybrud.Social.Facebook.Endpoints.Raw {
    
    public class FacebookMethodsRawEndpoint {

        public FacebookOAuthClient Client { get; private set; }

        internal FacebookMethodsRawEndpoint(FacebookOAuthClient client) {
            Client = client;
        }
        
        /// <summary>
        /// Gets information about accounts associated with the current user by calling the <var>/me/accounts</var> method. This call requires a user access token.
        /// </summary>
        /// <returns>The raw JSON response from the API.</returns>
        public string Accounts() {
            
            // Declare the query string
            NameValueCollection query = new NameValueCollection();
            if (!String.IsNullOrWhiteSpace(Client.AccessToken)) query.Add("access_token", Client.AccessToken);
            
            // Make the call to the API
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://graph.facebook.com/me/accounts?access_token", query);
        
        }

        /// <summary>
        /// Gets information about the specified app.
        /// </summary>
        /// <param name="identifier">The identifier of the app. Can either be "app" or the ID of the app.</param>
        /// <returns>The raw JSON response from the API.</returns>
        public string App(string identifier = "app") {

            // Declare the query string
            NameValueCollection query = new NameValueCollection();
            if (!String.IsNullOrWhiteSpace(Client.AccessToken)) query.Add("access_token", Client.AccessToken);

            // Make the call to the API
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://graph.facebook.com/" + identifier, query);
        
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
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://graph.facebook.com/debug_token", query);
        
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
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://graph.facebook.com/" + identifier + "/events", query);
        
        }
        
        /// <summary>
        /// Gets the feed of the specified user or page.
        /// </summary>
        /// <param name="identifier">The ID or name of the user/page.</param>
        /// <param name="limit">The maximum amount of entries to return.</param>
        /// <returns>The raw JSON response from the API.</returns>
        public string GetFeed(string identifier, int limit = 0) {
            return GetFeed(identifier, new FacebookFeedOptions { Limit = limit });
        }

        /// <summary>
        /// Gets the feed of the specified user or page.
        /// </summary>
        /// <param name="identifier">The ID or name of the user/page.</param>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>The raw JSON response from the API.</returns>
        public string GetFeed(string identifier, FacebookFeedOptions options) {

            // Declare the query string
            NameValueCollection query = new NameValueCollection();
            if (!String.IsNullOrWhiteSpace(Client.AccessToken)) query.Add("access_token", Client.AccessToken);
            if (options.Limit > 0) query.Add("limit", options.Limit + "");
            if (options.Since > 0) query.Add("since", options.Since + "");
            if (options.Until > 0) query.Add("until", options.Until + "");

            // Make the call to the API
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://graph.facebook.com/" + identifier + "/feed", query);

        }

        /// <summary>
        /// Gets the feed of the specified URL. This method can be used for paging purposes. 
        /// </summary>
        /// <param name="url">The raw URL to call.</param>
        /// <returns>The raw JSON response from the API.</returns>
        public string GetFeedFromUrl(string url) {
            if (url == null) throw new ArgumentNullException("url");
            if (!url.StartsWith("https://graph.facebook.com/")) throw new ArgumentException("Invalid URL", "url");
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString(url);
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
            NameValueCollection query = new NameValueCollection();
            if (!String.IsNullOrWhiteSpace(Client.AccessToken)) query.Add("access_token", Client.AccessToken);
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://graph.facebook.com/" + identifier, query);
        }

    }

}
