using System.Collections.Specialized;
using Skybrud.Social.Facebook.OAuth;

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
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://graph.facebook.com/me/accounts?access_token=" + Client.AccessToken);
        }

        /// <summary>
        /// Gets information about the specified app.
        /// </summary>
        /// <param name="identifier">The identifier of the app. Can either be "app" or the ID of the app.</param>
        /// <returns>The raw JSON response from the API.</returns>
        public string App(string identifier = "app") {
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://graph.facebook.com/" + identifier + "?access_token=" + Client.AccessToken);
        }

        /// <summary>
        /// Gets debug information about the specified access token.
        /// </summary>
        /// <param name="accessToken">The access token to debug.</param>
        /// <returns>The raw JSON response from the API.</returns>
        public string DebugToken(string accessToken) {
            NameValueCollection query = new NameValueCollection {
                { "input_token", accessToken },
                { "access_token", Client.AccessToken }
            };
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://graph.facebook.com/debug_token", query);
        }

        /// <summary>
        /// Gets the events of the specified user or page.
        /// </summary>
        /// <param name="identifier">The ID or name of the user/page.</param>
        /// <param name="limit">The maximum amount of events to return.</param>
        /// <returns>The raw JSON response from the API.</returns>
        public string Events(string identifier, int limit = 0) {
            NameValueCollection query = new NameValueCollection { { "access_token", Client.AccessToken } };
            if (limit > 0) query.Add("limit", limit + "");
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://graph.facebook.com/" + identifier + "/events", query);
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
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://graph.facebook.com/" + identifier + "?access_token=" + Client.AccessToken);
        }

    }

}
