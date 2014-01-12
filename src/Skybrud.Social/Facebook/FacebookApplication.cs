using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using Skybrud.Social.Facebook.Exceptions;
using Skybrud.Social.Facebook.OAuth;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook {

    [Obsolete("Use class FacebookOAuthClient instead")]
    public class FacebookApplication {

        public FacebookOAuthClient Client { get; private set; }

        public string AppId {
            get { return Client.AppId; }
            set { Client.AppId = value; }
        }

        public string AppSecret {
            get { return Client.AppSecret; }
            set { Client.AppSecret = value; }
        }

        public string ReturnUri {
            get { return Client.ReturnUri; }
            set { Client.ReturnUri = value; }
        }

        public FacebookApplication() {
            Client = new FacebookOAuthClient();
        }

        public FacebookApplication(long appId, string appSecret) {
            Client = new FacebookOAuthClient {
                AppId = appId + "",
                AppSecret = appSecret
            };
        }

        public FacebookApplication(long appId, string appSecret, string returnUri) {
            Client = new FacebookOAuthClient {
                AppId = appId + "",
                AppSecret = appSecret,
                ReturnUri = returnUri
            };
        }

        public FacebookApplication(string appId, string appSecret) {
            Client = new FacebookOAuthClient {
                AppId = appId,
                AppSecret = appSecret
            };
        }

        public FacebookApplication(string appId, string appSecret, string returnUri) {
            Client = new FacebookOAuthClient {
                AppId = appId,
                AppSecret = appSecret,
                ReturnUri = returnUri
            };
        }

        /// <summary>
        /// Gets the login URL for the application.
        /// </summary>
        [Obsolete("Use method GetAuthorizationUrl() instead")]
        public string GetUserLoginUrl() {
            return Client.GetAuthorizationUrl(Guid.NewGuid().ToString(), new string[0]);
        }

        /// <summary>
        /// Gets the login URL for the application using the specified <var>state</var> and <var>scope</var>.
        /// </summary>
        /// <param name="state">The state of identifying the current user.</param>
        /// <param name="scope">The scrope AKA the privileges the user should accept.</param>
        /// <see cref="https://developers.facebook.com/docs/facebook-login/login-flow-for-web-no-jssdk/#login" />
        [Obsolete("Use method GetAuthorizationUrl() instead")]
        public string GetUserLoginUrl(string state, params string[] scope) {
            return Client.GetAuthorizationUrl(state, scope);
        }

        /// <summary>
        /// Generates the authorization URL using the specified state and scope.
        /// </summary>
        /// <param name="state">The state to send to Facebook's OAuth login page.</param>
        /// <param name="scope">The scope of the application.</param>
        /// <see cref="https://developers.facebook.com/docs/facebook-login/login-flow-for-web-no-jssdk/#login" />
        public string GetAuthorizationUrl(string state, FacebookScope scope) {
            return Client.GetAuthorizationUrl(state, scope.Name);
        }

        /// <summary>
        /// Generates the authorization URL using the specified state and scope.
        /// </summary>
        /// <param name="state">The state to send to Facebook's OAuth login page.</param>
        /// <param name="scope">The scope of the application.</param>
        /// <see cref="https://developers.facebook.com/docs/facebook-login/login-flow-for-web-no-jssdk/#login" />
        public string GetAuthorizationUrl(string state, FacebookScopeCollection scope) {
            return Client.GetAuthorizationUrl(state, scope.ToString());
        }

        /// <summary>
        /// Generates the authorization URL using the specified state and scope.
        /// </summary>
        /// <param name="state">The state to send to Facebook's OAuth login page.</param>
        /// <param name="scope">The scope of the application.</param>
        /// <see cref="https://developers.facebook.com/docs/facebook-login/login-flow-for-web-no-jssdk/#login" />
        public string GetAuthorizationUrl(string state, params string[] scope) {
            return Client.GetAuthorizationUrl(state, scope);
        }

        /// <summary>
        /// Exchanges the specified authorization code for a user access token.
        /// </summary>
        /// <param name="code">The authorization code received from the Facebook login dialog.</param>
        public string GetUserAccessTokenFromCode(string code) {
            return Client.GetAccessTokenFromAuthCode(code);
        }

        /// <summary>
        /// Attempts to renew the specified user access token. The current access token must be valid.
        /// </summary>
        /// <param name="currentToken">The current access token.</param>
        public string RenewUserAccessToken(string currentToken) {
            return Client.RenewAccessToken(currentToken);
        }

        public string GetAppAccessToken() {
            return Client.GetAppAccessToken();
        }

    }

}
