using System;
using System.Collections.Specialized;
using System.Web;
using Skybrud.Social.Facebook.Endpoints.Raw;

namespace Skybrud.Social.Facebook.OAuth {

    /// <summary>
    /// Class for handling the raw communication with the Facebook API as well as any OAUth 2.0 communication.
    /// </summary>
    public class FacebookOAuthClient {

        private FacebookMethodsRawEndpoint _methods;

        #region Properties

        /// <summary>
        /// The ID of the app.
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// The secret of the app.
        /// </summary>
        public string AppSecret { get; set; }

        /// <summary>
        /// The redirect URI of your application.
        /// </summary>
        [Obsolete("Use \"RedirectUri\" instead to follow Facebook lingo.")]
        public string ReturnUri {
            get { return RedirectUri; }
            set { RedirectUri = value; }
        }

        /// <summary>
        /// The redirect URI of your application.
        /// </summary>
        public string RedirectUri { get; set; }

        /// <summary>
        /// The access token.
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets a reference to the methods endpoint.
        /// </summary>
        public FacebookMethodsRawEndpoint Methods {
            get { return _methods ?? (_methods = new FacebookMethodsRawEndpoint(this)); }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes an OAuth client with empty information.
        /// </summary>
        public FacebookOAuthClient() {
            // default constructor
        }

        /// <summary>
        /// Initializes an OAuth client with the specified access token. Using this initializer,
        /// the client will have no information about your app.
        /// </summary>
        /// <param name="accessToken">A valid access token.</param>
        public FacebookOAuthClient(string accessToken) {
            AccessToken = accessToken;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified app ID and app secret.
        /// </summary>
        /// <param name="appId">The ID of the app.</param>
        /// <param name="appSecret">The secret of the app.</param>
        public FacebookOAuthClient(long appId, string appSecret) {
            AppId = appId + "";
            AppSecret = appSecret;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified app ID, app secret and return URI.
        /// </summary>
        /// <param name="appId">The ID of the app.</param>
        /// <param name="appSecret">The secret of the app.</param>
        /// <param name="redirectUri">The redirect URI of the app.</param>
        public FacebookOAuthClient(long appId, string appSecret, string redirectUri) {
            AppId = appId + "";
            AppSecret = appSecret;
            RedirectUri = redirectUri;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified app ID and app secret.
        /// </summary>
        /// <param name="appId">The ID of the app.</param>
        /// <param name="appSecret">The secret of the app.</param>
        public FacebookOAuthClient(string appId, string appSecret) {
            AppId = appId;
            AppSecret = appSecret;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified app ID, app secret and return URI.
        /// </summary>
        /// <param name="appId">The ID of the app.</param>
        /// <param name="appSecret">The secret of the app.</param>
        /// <param name="redirectUri">The redirect URI of the app.</param>
        public FacebookOAuthClient(string appId, string appSecret, string redirectUri) {
            AppId = appId;
            AppSecret = appSecret;
            RedirectUri = redirectUri;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Generates the authorization URL using the specified state and scope.
        /// </summary>
        /// <param name="state">The state to send to Facebook's OAuth login page.</param>
        /// <param name="scope">The scope of the application.</param>
        public string GetAuthorizationUrl(string state, FacebookScopeCollection scope) {
            return GetAuthorizationUrl(state, scope.ToString());
        }

        /// <summary>
        /// Generates the authorization URL using the specified state and scope.
        /// </summary>
        /// <param name="state">The state to send to Facebook's OAuth login page.</param>
        /// <param name="scope">The scope of the application.</param>
        public string GetAuthorizationUrl(string state, params string[] scope) {
            return String.Format(
                "https://www.facebook.com/dialog/oauth?client_id={0}&redirect_uri={1}&state={2}&scope={3}",
                AppId,
                RedirectUri,
                state,
                String.Join(",", scope)
            );
        }

        /// <summary>
        /// Exchanges the specified authorization code for a user access token.
        /// </summary>
        /// <param name="authCode">The authorization code received from the Facebook OAuth dialog.</param>
        public string GetAccessTokenFromAuthCode(string authCode) {

            // Initialize the query string
            NameValueCollection query = new NameValueCollection {
                {"client_id", AppId},
                {"redirect_uri", RedirectUri},
                {"client_secret", AppSecret},
                {"code", authCode }
            };
            
            // Make the call to the API
            string contents = SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://graph.facebook.com/oauth/access_token", query);

            // Parse the contents
            NameValueCollection response = HttpUtility.ParseQueryString(contents);

            // Get the access token
            return response["access_token"];

        }

        /// <summary>
        /// Attempts to renew the specified user access token. The current access token must be valid.
        /// </summary>
        /// <param name="currentToken">The current access token.</param>
        public string RenewAccessToken(string currentToken) {

            // Initialize the query string
            NameValueCollection query = new NameValueCollection {
                {"grant_type", "fb_exchange_token"},
                {"client_id", AppId},
                {"client_secret", AppSecret},
                {"fb_exchange_token", currentToken }
            };

            // Make the call to the API
            string contents = SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://graph.facebook.com/oauth/access_token", query);

            // Parse the contents
            NameValueCollection response = HttpUtility.ParseQueryString(contents);

            // Get the access token
            return response["access_token"];

        }

        /// <summary>
        /// Gets an app access token for for the application. An app id and app secret must be present.
        /// </summary>
        public string GetAppAccessToken() {

            // Initialize the query string
            NameValueCollection query = new NameValueCollection {
                {"client_id", AppId},
                {"client_secret", AppSecret},
                {"grant_type", "client_credentials"}
            };

            // Make the call to the API
            string contents = SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://graph.facebook.com/oauth/access_token", query);

            // Parse the contents
            NameValueCollection response = HttpUtility.ParseQueryString(contents);

            // Get the access token
            return response["access_token"];

        }

        #endregion

    }

}
