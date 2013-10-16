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
        /// Gets information about the current user by calling the <var>/me</var> method. This call requires a user access token.
        /// </summary>
        /// <returns>The raw JSON response from the API.</returns>
        public string Me() {
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://graph.facebook.com/me?access_token=" + Client.AccessToken);
        }

    }

}
