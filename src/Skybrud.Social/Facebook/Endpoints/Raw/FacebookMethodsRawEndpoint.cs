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
        public string GetObject(string identifier) {

            // Declare the query string
            NameValueCollection query = new NameValueCollection();
            if (!String.IsNullOrWhiteSpace(Client.AccessToken)) query.Add("access_token", Client.AccessToken);

            // Make the call to the API
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://graph.facebook.com/v1.0/" + identifier, query);
        
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
