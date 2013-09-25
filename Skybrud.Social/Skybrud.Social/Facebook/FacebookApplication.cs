using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using Skybrud.Social.Facebook.Exceptions;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook {

    public class FacebookApplication {

        public string AppId;
        public string AppSecret;
        public string ReturnUri;

        public FacebookApplication() {
            // default constructor
        }

        public FacebookApplication(long appId, string appSecret) {
            AppId = appId + "";
            AppSecret = appSecret;
        }

        public FacebookApplication(long appId, string appSecret, string returnUri) {
            AppId = appId + "";
            AppSecret = appSecret;
            ReturnUri = returnUri;
        }

        public FacebookApplication(string appId, string appSecret) {
            AppId = appId;
            AppSecret = appSecret;
        }

        public FacebookApplication(string appId, string appSecret, string returnUri) {
            AppId = appId;
            AppSecret = appSecret;
            ReturnUri = returnUri;
        }

        /// <summary>
        /// Gets the login URL for the application.
        /// </summary>
        [Obsolete("Use method GetAuthorizationUrl() instead")]
        public string GetUserLoginUrl() {
            return GetAuthorizationUrl(Guid.NewGuid().ToString(), new string[0]);
        }

        /// <summary>
        /// Gets the login URL for the application using the specified <var>state</var> and <var>scope</var>.
        /// </summary>
        /// <param name="state">The state of identifying the current user.</param>
        /// <param name="scope">The scrope AKA the privileges the user should accept.</param>
        /// <see cref="https://developers.facebook.com/docs/facebook-login/login-flow-for-web-no-jssdk/#login" />
        [Obsolete("Use method GetAuthorizationUrl() instead")]
        public string GetUserLoginUrl(string state, params string[] scope) {
            return GetAuthorizationUrl(state, scope);
        }

        /// <summary>
        /// Generates the authorization URL using the specified state and scope.
        /// </summary>
        /// <param name="state">The state to send to Facebook's OAuth login page.</param>
        /// <param name="scope">The scope of the application.</param>
        /// <see cref="https://developers.facebook.com/docs/facebook-login/login-flow-for-web-no-jssdk/#login" />
        public string GetAuthorizationUrl(string state, FacebookScope scope) {
            return GetAuthorizationUrl(state, scope.Name);
        }

        /// <summary>
        /// Generates the authorization URL using the specified state and scope.
        /// </summary>
        /// <param name="state">The state to send to Facebook's OAuth login page.</param>
        /// <param name="scope">The scope of the application.</param>
        /// <see cref="https://developers.facebook.com/docs/facebook-login/login-flow-for-web-no-jssdk/#login" />
        public string GetAuthorizationUrl(string state, FacebookScopeCollection scope) {
            return GetAuthorizationUrl(state, scope.ToString());
        }

        /// <summary>
        /// Generates the authorization URL using the specified state and scope.
        /// </summary>
        /// <param name="state">The state to send to Facebook's OAuth login page.</param>
        /// <param name="scope">The scope of the application.</param>
        /// <see cref="https://developers.facebook.com/docs/facebook-login/login-flow-for-web-no-jssdk/#login" />
        public string GetAuthorizationUrl(string state, params string[] scope) {
            return String.Format(
                "https://www.facebook.com/dialog/oauth?client_id={0}&redirect_uri={1}&state={2}&scope={3}",
                AppId,
                ReturnUri,
                state,
                String.Join(",", scope)
            );
        }

        /// <summary>
        /// Exchanges the specified authorization code for an access token.
        /// </summary>
        /// <param name="code">The authorization code received from the Facebook login dialog.</param>
        public string GetUserAccessTokenFromCode(string code) {
            
            // Calculate the login URL
            string url = String.Format(
                "https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&client_secret={2}&code={3}",
                AppId,
                ReturnUri,
                AppSecret,
                code
            );

            // Downloaded the page
            string contents = SocialUtils.DoHttpGetRequestAndGetBodyAsString(url);

            // Parse the contents
            NameValueCollection query = HttpUtility.ParseQueryString(contents);

            // Get the access token
            return query["access_token"];
        
        }

        /// <summary>
        /// Attempts to renew the specified access token. The current access token must be valid.
        /// </summary>
        /// <param name="currentToken">The current access token.</param>
        public string RenewUserAccessToken(string currentToken) {
            
            // Calculate the URL
            string url = String.Format(
                "https://graph.facebook.com/oauth/access_token?grant_type=fb_exchange_token&client_id={0}&client_secret={1}&fb_exchange_token={2}",
                AppId,
                AppSecret,
                currentToken
            );

            // Downloaded the page
            string contents = SocialUtils.DoHttpGetRequestAndGetBodyAsString(url);

            // Parse the contents
            NameValueCollection query = HttpUtility.ParseQueryString(contents);

            // Get the access token
            return query["access_token"];
        
        }

        public string GetAppAccessToken() {

            // TODO: Cleanup?

            // Generate the URL
            string url = String.Format(
                "https://graph.facebook.com/oauth/access_token?client_id={0}&client_secret={1}&grant_type=client_credentials",
                AppId,
                AppSecret
            );

            // Initialize the request
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);

            // Set the method
            request.Method = "GET";

            try {

                // Get the response
                HttpWebResponse rsp = (HttpWebResponse)request.GetResponse();

                // Read the content
                StreamReader reader = new StreamReader(rsp.GetResponseStream());
                string contents = reader.ReadToEnd();

                NameValueCollection nvc = HttpUtility.ParseQueryString(contents);
                return nvc["access_token"];

            } catch (WebException ex) {

                // Read the content
                StreamReader reader = new StreamReader(ex.Response.GetResponseStream());
                string contents = reader.ReadToEnd();

                // Throw the exception
                throw JsonConverter.ParseObject(contents).GetObject("error", FacebookException.Parse);

            }

        }

    }

}
