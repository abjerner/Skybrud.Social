using System;
using System.Collections.Specialized;
using System.Net;
using System.Web;
using Skybrud.Social.Facebook.Endpoints.Raw;
using Skybrud.Social.Facebook.Options;
using Skybrud.Social.Http;

namespace Skybrud.Social.Facebook.OAuth {

    /// <summary>
    /// Class for handling the raw communication with the Facebook API as well as any OAUth 2.0 communication.
    /// </summary>
    public class FacebookOAuthClient {
        
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
        /// Gets a reference to the accounts endpoint.
        /// </summary>
        public FacebookAccountsRawEndpoint Accounts { get; private set; }

        /// <summary>
        /// Gets a reference to the comments endpoint.
        /// </summary>
        public FacebookCommentsRawEndpoint Comments { get; private set; }

        /// <summary>
        /// Gets a reference to the events endpoint.
        /// </summary>
        public FacebookEventsRawEndpoint Events { get; private set; }

        /// <summary>
        /// Gets a reference to the likes endpoint.
        /// </summary>
        public FacebookLikesRawEndpoint Likes { get; private set; }

        /// <summary>
        /// Gets a reference to the methods endpoint.
        /// </summary>
        public FacebookMethodsRawEndpoint Methods { get; private set; }

        /// <summary>
        /// Gets a reference to the pages endpoint.
        /// </summary>
        public FacebookPagesRawEndpoint Pages { get; private set; }

        /// <summary>
        /// Gets a reference to the photos endpoint.
        /// </summary>
        public FacebookPhotosRawEndpoint Photos { get; private set; }

        /// <summary>
        /// Gets a reference to the posts endpoint.
        /// </summary>
        public FacebookPostsRawEndpoint Posts { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes an OAuth client with empty information.
        /// </summary>
        public FacebookOAuthClient() {
            Accounts = new FacebookAccountsRawEndpoint(this);
            Comments = new FacebookCommentsRawEndpoint(this);
            Events = new FacebookEventsRawEndpoint(this);
            Likes = new FacebookLikesRawEndpoint(this);
            Methods = new FacebookMethodsRawEndpoint(this);
            Pages = new FacebookPagesRawEndpoint(this);
            Photos = new FacebookPhotosRawEndpoint(this);
            Posts = new FacebookPostsRawEndpoint(this);
        }

        /// <summary>
        /// Initializes an OAuth client with the specified access token. Using this initializer,
        /// the client will have no information about your app.
        /// </summary>
        /// <param name="accessToken">A valid access token.</param>
        public FacebookOAuthClient(string accessToken) : this() {
            AccessToken = accessToken;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified app ID and app secret.
        /// </summary>
        /// <param name="appId">The ID of the app.</param>
        /// <param name="appSecret">The secret of the app.</param>
        public FacebookOAuthClient(long appId, string appSecret) : this() {
            AppId = appId + "";
            AppSecret = appSecret;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified app ID, app secret and return URI.
        /// </summary>
        /// <param name="appId">The ID of the app.</param>
        /// <param name="appSecret">The secret of the app.</param>
        /// <param name="redirectUri">The redirect URI of the app.</param>
        public FacebookOAuthClient(long appId, string appSecret, string redirectUri) : this() {
            AppId = appId + "";
            AppSecret = appSecret;
            RedirectUri = redirectUri;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified app ID and app secret.
        /// </summary>
        /// <param name="appId">The ID of the app.</param>
        /// <param name="appSecret">The secret of the app.</param>
        public FacebookOAuthClient(string appId, string appSecret) : this() {
            AppId = appId;
            AppSecret = appSecret;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified app ID, app secret and return URI.
        /// </summary>
        /// <param name="appId">The ID of the app.</param>
        /// <param name="appSecret">The secret of the app.</param>
        /// <param name="redirectUri">The redirect URI of the app.</param>
        public FacebookOAuthClient(string appId, string appSecret, string redirectUri) : this() {
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

        /// <summary>
        /// Makes a GET request to the Facebook API. If the <code>AccessToken</code> property has
        /// been specified, the access token will be appended to the query string.
        /// </summary>
        /// <param name="url">The URL to call.</param>
        public SocialHttpResponse DoAuthenticatedGetRequest(string url) {
            return DoAuthenticatedGetRequest(url, (SocialQueryString) null);
        }

        /// <summary>
        /// Makes a GET request to the Facebook API. If the <code>AccessToken</code> property has
        /// been specified, the access token will be appended to the query string.
        /// </summary>
        /// <param name="url">The URL to call.</param>
        /// <param name="query">The query string of the request.</param>
        public SocialHttpResponse DoAuthenticatedGetRequest(string url, NameValueCollection query) {
            return DoAuthenticatedGetRequest(url, new SocialQueryString(query));
        }

        /// <summary>
        /// Makes a GET request to the Facebook API. If the <code>AccessToken</code> property has
        /// been specified, the access token will be appended to the query string.
        /// </summary>
        /// <param name="url">The URL to call.</param>
        /// <param name="options">The options of the request.</param>
        public SocialHttpResponse DoAuthenticatedGetRequest(string url, IFacebookOptions options) {
            return DoAuthenticatedGetRequest(url, options == null ? null : options.GetQuery());
        }

        /// <summary>
        /// Makes a GET request to the Facebook API. If the <code>AccessToken</code> property has
        /// been specified, the access token will be appended to the query string.
        /// </summary>
        /// <param name="url">The URL to call.</param>
        /// <param name="query">The query string of the request.</param>
        public SocialHttpResponse DoAuthenticatedGetRequest(string url, SocialQueryString query) {

            // Throw an exception if the URL is empty
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");

            // Initialize a new instance of SocialQueryString if the one specified is NULL
            if (query == null) query = new SocialQueryString();

            // Append the access token to the query string if present in the client and not already
            // specified in the query string
            if (!query.ContainsKey("access_token") && !String.IsNullOrWhiteSpace(AccessToken)) {
                // TODO: Can the access token be specified using an authorization header?
                query.Add("access_token", AccessToken);
            }

            // Append the query string to the URL
            if (!query.IsEmpty) url += (url.Contains("?") ? "&" : "?") + query;

            // Initialize a new HTTP request
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);

            // Get the HTTP response
            try {
                return SocialHttpResponse.GetFromWebResponse(request.GetResponse() as HttpWebResponse);
            } catch (WebException ex) {
                if (ex.Status != WebExceptionStatus.ProtocolError) throw;
                return SocialHttpResponse.GetFromWebResponse(ex.Response as HttpWebResponse);
            }

        }

        #endregion

    }

}
