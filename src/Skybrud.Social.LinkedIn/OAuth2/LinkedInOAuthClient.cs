using System;
using System.Collections.Specialized;
using Skybrud.Social.LinkedIn.Interfaces;

namespace Skybrud.Social.LinkedIn.OAuth2 {
    
    public class LinkedInOAuthClient : ILinkedInOAuthClient {

        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }
        public string RedirectUri { get; set; }
        public string AccessToken { get; set; }

        // Methods
        public LinkedInAccessTokenResponse GetAccessTokenFromAuthCode(string code) {

            // Declare the query string
            NameValueCollection query = new NameValueCollection {
            {"grant_type", "authorization_code"},
            {"code", code},
            {"redirect_uri", RedirectUri},
            {"client_id", ApiKey},
            {"client_secret", ApiSecret}
        };

            // Make the request and get the response body
            string response = SocialUtils.DoHttpPostRequestAndGetBodyAsString("https://www.linkedin.com/uas/oauth2/accessToken", query);

            // Parse the response and return the access token
            return LinkedInAccessTokenResponse.Parse(response);

        }

        /// <summary>
        /// Generates the authorization URL using the specified state and scope.
        /// </summary>
        /// <param name="state">The state to send to LinkedIn's OAuth login page.</param>
        /// <param name="scope">The scope of the application.</param>
        /// <returns>Returns an authorization URL based on <code>state</code> and <code>scope</code>.</returns>
        public string GetAuthorizationUrl(string state, params string[] scope) {
            return GetAuthorizationUrl(state, String.Join(",", scope));
        }

        public string GetAuthorizationUrl(string state, string scope = null) {
            NameValueCollection query = new NameValueCollection();
            query.Add("response_type", "code");
            query.Add("client_id", ApiKey);
            query.Add("state", state);
            query.Add("scope", scope ?? "");
            query.Add("redirect_uri", RedirectUri);
            return ("https://www.linkedin.com/uas/oauth2/authorization?" + SocialUtils.NameValueCollectionToQueryString(query, true));
        }

        #region Methods from interface ILinkedInOAuthClient

        public string GetBasicProfile() {
            return GetBasicProfile(LinkedInConstants.BasicProfileDefaultFields);
        }

        public string GetBasicProfile(params string[] fields) {
            // Declare the base URL
            string url = String.Format(
                "{0}{1}",
                "https://api.linkedin.com/v1/people/~",
                (fields.Length == 0) ? "" : (":(" + String.Join(",", fields) + ")")
            );

            // Declare the query string
            NameValueCollection query = new NameValueCollection {
                {"oauth2_access_token", AccessToken}
            };

            // Make the request and return the response body
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString(url, query);
        }

        public string GetGroupPosts(long groupId) {
            return GetGroupPosts(groupId, LinkedInConstants.GroupPostsDefaultFields);
        }

        public string GetGroupPosts(long groupId, string[] fields) {

            // Declare the base URL
            string url = String.Format(
                "{0}{1}",
                "https://api.linkedin.com/v1/groups/" + groupId + "/posts",
                (fields.Length == 0) ? "" : (":(" + String.Join(",", fields) + ")")
            );

            // Declare the query string
            NameValueCollection query = new NameValueCollection {
                {"oauth2_access_token", AccessToken}
            };

            // Make the request and return the response body
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString(url, query);

        }

        #endregion

    }

}
