using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using Skybrud.Social.Facebook.Endpoints.Raw;
using Skybrud.Social.Facebook.Responses.Authentication;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.Facebook.OAuth {

    /// <summary>
    /// Class for handling the raw communication with the Facebook API as well as any OAuth 2.0 communication.
    /// </summary>
    public class FacebookOAuthClient {
        
        #region Properties

        #region OAuth

        /// <summary>
        /// Gets or sets the ID of the app.
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// Gets or sets the secret of the app.
        /// </summary>
        public string AppSecret { get; set; }
        
        /// <summary>
        /// Gets or sets the redirect URI of your application.
        /// </summary>
        public string RedirectUri { get; set; }

        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        public string AccessToken { get; set; }

        #endregion

        /// <summary>
        /// Gets or sets the version of the Facebook Graph API to be used. Defaults to <code>v2.2</code>.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the locale of the client.
        /// </summary>
        public string Locale { get; set; }

        #region Endpoints

        /// <summary>
        /// Gets a reference to the accounts endpoint.
        /// </summary>
        public FacebookAccountsRawEndpoint Accounts { get; private set; }

        /// <summary>
        /// Gets a reference to the albums endpoint.
        /// </summary>
        public FacebookAlbumsRawEndpoint Albums { get; private set; }

        /// <summary>
        /// Gets a reference to the apps endpoint.
        /// </summary>
        public FacebookAppsRawEndpoint Apps { get; private set; }

        /// <summary>
        /// Gets a reference to the debug endpoint.
        /// </summary>
        public FacebookDebugRawEndpoint Debug { get; private set; }

        /// <summary>
        /// Gets a reference to the comments endpoint.
        /// </summary>
        public FacebookCommentsRawEndpoint Comments { get; private set; }

        /// <summary>
        /// Gets a reference to the events endpoint.
        /// </summary>
        public FacebookEventsRawEndpoint Events { get; private set; }

        /// <summary>
        /// Gets a reference to the feed endpoint.
        /// </summary>
        public FacebookFeedRawEndpoint Feed { get; private set; }

        /// <summary>
        /// Gets a reference to the likes endpoint.
        /// </summary>
        public FacebookLikesRawEndpoint Likes { get; private set; }

        /// <summary>
        /// Gets a reference to the links endpoint.
        /// </summary>
        public FacebookLinksRawEndpoint Links { get; private set; }

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

        /// <summary>
        /// Gets a reference to the posts endpoint.
        /// </summary>
        public FacebookUsersRawEndpoint Users { get; private set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes an OAuth client with empty information.
        /// </summary>
        public FacebookOAuthClient() {
            Version = "v2.5";
            Accounts = new FacebookAccountsRawEndpoint(this);
            Apps = new FacebookAppsRawEndpoint(this);
            Debug = new FacebookDebugRawEndpoint(this);
            Comments = new FacebookCommentsRawEndpoint(this);
            Events = new FacebookEventsRawEndpoint(this);
            Feed = new FacebookFeedRawEndpoint(this);
            Likes = new FacebookLikesRawEndpoint(this);
            Links = new FacebookLinksRawEndpoint(this);
            Pages = new FacebookPagesRawEndpoint(this);
            Photos = new FacebookPhotosRawEndpoint(this);
            Posts = new FacebookPostsRawEndpoint(this);
            Users = new FacebookUsersRawEndpoint(this);
            Albums = new FacebookAlbumsRawEndpoint(this);
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
        /// <returns>Returns an authorization URL based on <code>state</code> and <code>scope</code>.</returns>
        public string GetAuthorizationUrl(string state, FacebookScopeCollection scope) {
            return GetAuthorizationUrl(state, scope.ToString());
        }

        /// <summary>
        /// Generates the authorization URL using the specified state and scope.
        /// </summary>
        /// <param name="state">The state to send to Facebook's OAuth login page.</param>
        /// <param name="scope">The scope of the application.</param>
        /// <returns>Returns an authorization URL based on <code>state</code> and <code>scope</code>.</returns>
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
        /// <returns>Returns an access token based on the specified <code>authCode</code>.</returns>
        public string GetAccessTokenFromAuthCode(string authCode) {

            // TODO: Remove for v1.0

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
            NameValueCollection response = SocialUtils.ParseQueryString(contents);

            // Get the access token
            return response["access_token"];

        }

        /// <summary>
        /// Exchanges the specified authorization code for a refresh token and an access token. This method currently
        /// serves as an alternative to the <code>GetAccessTokenFromAuthCode</code> as it will return an instance of
        /// <code>FacebookTokenResponse</code> representing the entire response from the Facebook Graph API rather than
        /// string holding the access token. This method will be the default approach for Skybrud.Social v1.0.
        /// </summary>
        /// <param name="authCode">The authorization code received from the Pinterest OAuth dialog.</param>
        /// <returns>Returns an access token based on the specified <code>authCode</code>.</returns>
        public FacebookTokenResponse GetAccessTokenFromAuthCodeAlt(string authCode) {

            // TODO: Rename to "GetAccessTokenFromAuthCode" for v1.0

            // Initialize the query string
            NameValueCollection query = new NameValueCollection {
                {"client_id", AppId},
                {"redirect_uri", RedirectUri},
                {"client_secret", AppSecret},
                {"code", authCode }
            };

            // Make the call to the API
            HttpWebResponse response = SocialUtils.DoHttpGetRequest("https://graph.facebook.com/oauth/access_token", query);

            // Wrap the native response class
            SocialHttpResponse social = SocialHttpResponse.GetFromWebResponse(response);

            // Parse the response
            return FacebookTokenResponse.ParseResponse(social);

        }

        /// <summary>
        /// Attempts to renew the specified user access token. The current access token must be valid.
        /// </summary>
        /// <param name="currentToken">The current access token.</param>
        /// <returns>Returns the new access token.</returns>
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

            // TODO: Add some validation

            // Parse the contents
            NameValueCollection response = SocialUtils.ParseQueryString(contents);

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
            NameValueCollection response = SocialUtils.ParseQueryString(contents);

            // Get the access token
            return response["access_token"];

        }

        /// <summary>
        /// Makes a GET request to the Facebook API. If the <code>AccessToken</code> property has
        /// been specified, the access token will be appended to the query string.
        /// </summary>
        /// <param name="url">The URL to call.</param>
        /// <returns>Returns an instance of <code>SocialHttpResponse</code> wrapping the response from the Facebook Graph API.</returns>
        public SocialHttpResponse DoAuthenticatedGetRequest(string url) {
            return DoAuthenticatedGetRequest(url, (SocialQueryString) null);
        }

        /// <summary>
        /// Makes a GET request to the Facebook API. If the <code>AccessToken</code> property has
        /// been specified, the access token will be appended to the query string.
        /// </summary>
        /// <param name="url">The URL to call.</param>
        /// <param name="query">The query string of the request.</param>
        /// <returns>Returns an instance of <code>SocialHttpResponse</code> wrapping the response from the Facebook Graph API.</returns>
        public SocialHttpResponse DoAuthenticatedGetRequest(string url, NameValueCollection query) {
            return DoAuthenticatedGetRequest(url, new SocialQueryString(query));
        }

        /// <summary>
        /// Makes a GET request to the Facebook API. If the <code>AccessToken</code> property has
        /// been specified, the access token will be appended to the query string.
        /// </summary>
        /// <param name="url">The URL to call.</param>
        /// <param name="options">The options of the request.</param>
        /// <returns>Returns an instance of <code>SocialHttpResponse</code> wrapping the response from the Facebook Graph API.</returns>
        public SocialHttpResponse DoAuthenticatedGetRequest(string url, IGetOptions options) {
            return DoAuthenticatedGetRequest(url, options == null ? null : options.GetQueryString());
        }

        /// <summary>
        /// Makes a GET request to the Facebook API. If the <code>AccessToken</code> property has
        /// been specified, the access token will be appended to the query string.
        /// </summary>
        /// <param name="url">The URL to call.</param>
        /// <param name="query">The query string of the request.</param>
        /// <returns>Returns an instance of <code>SocialHttpResponse</code> wrapping the response from the Facebook Graph API.</returns>
        public SocialHttpResponse DoAuthenticatedGetRequest(string url, SocialQueryString query) {

            // Throw an exception if the URL is empty
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");

            // Append the HTTP scheme and API version if not already specified.
            if (url.StartsWith("/")) {
                url = "https://graph.facebook.com" + (String.IsNullOrWhiteSpace(Version) ? "" : "/" + Version) + url;
            }

            // Initialize a new instance of SocialQueryString if the one specified is NULL
            if (query == null) query = new SocialQueryString();

            // Append the access token to the query string if present in the client and not already
            // specified in the query string
            if (!query.ContainsKey("access_token") && !String.IsNullOrWhiteSpace(AccessToken)) {
                query.Add("access_token", AccessToken);
            }

            // Append the locale to the query string if present in the client and not already
            // specified in the query string
            if (!query.ContainsKey("locale") && !String.IsNullOrWhiteSpace(Locale)) {
                query.Add("locale", Locale);
            }

            // Append the query string to the URL
            if (!query.IsEmpty) url += (url.Contains("?") ? "&" : "?") + query;

            // Initialize a new HTTP request
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            // Get the HTTP response
            try {
                return SocialHttpResponse.GetFromWebResponse(request.GetResponse() as HttpWebResponse);
            } catch (WebException ex) {
                if (ex.Status != WebExceptionStatus.ProtocolError) throw;
                return SocialHttpResponse.GetFromWebResponse(ex.Response as HttpWebResponse);
            }

        }

        /// <summary>
        /// Makes a POST request to the Facebook API. If the <code>AccessToken</code> property has
        /// been specified, the access token will be appended to the query string.
        /// </summary>
        /// <param name="url">The URL to call.</param>
        /// <param name="options">The options of the request.</param>
        /// <returns>Returns an instance of <code>SocialHttpResponse</code> wrapping the response from the Facebook Graph API.</returns>
        public SocialHttpResponse DoAuthenticatedPostRequest(string url, IPostOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            return DoAuthenticatedPostRequest(url, options.GetQueryString(), options.GetPostData(), options.IsMultipart);
        }

        /// <summary>
        /// Makes a POST request to the Facebook API. If the <code>AccessToken</code> property has
        /// been specified, the access token will be appended to the query string.
        /// </summary>
        /// <param name="url">The URL to call.</param>
        /// <param name="query">The query string of the request.</param>
        /// <param name="postData">The POST data.</param>
        /// <param name="isMultipart">If <code>true</code>, the content type of the request will be <code>multipart/form-data</code>, otherwise <code>application/x-www-form-urlencoded</code>.</param>
        /// <returns>Returns an instance of <code>SocialHttpResponse</code> wrapping the response from the Facebook Graph API.</returns>
        public SocialHttpResponse DoAuthenticatedPostRequest(string url, SocialQueryString query, SocialPostData postData, bool isMultipart) {

            // Throw an exception if the URL is empty
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");

            // Append the HTTP scheme and API version if not already specified.
            if (url.StartsWith("/")) {
                url = "https://graph.facebook.com" + (String.IsNullOrWhiteSpace(Version) ? "" : "/" + Version) + url;
            }

            // Initialize a new instance of SocialQueryString if the one specified is NULL
            if (query == null) query = new SocialQueryString();

            // Append the access token to the query string if present in the client and not already
            // specified in the query string
            if (!query.ContainsKey("access_token") && !String.IsNullOrWhiteSpace(AccessToken)) {
                query.Add("access_token", AccessToken);
            }

            // Append the query string to the URL
            if (!query.IsEmpty) url += (url.Contains("?") ? "&" : "?") + query;

            // Initialize a new HTTP request
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);

            // Set the HTTP method
            request.Method = "POST";

            // Write the POST data to the request stream
            if (postData != null && postData.Count > 0) {
                if (isMultipart) {
                    string boundary = Guid.NewGuid().ToString().Replace("-", "");
                    request.ContentType = "multipart/form-data; boundary=" + boundary;
                    using (Stream stream = request.GetRequestStream()) {
                        postData.WriteMultipartFormData(stream, boundary);
                    }
                } else {
                    string dataString = postData.ToString();
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = dataString.Length;
                    using (Stream stream = request.GetRequestStream()) {
                        stream.Write(Encoding.UTF8.GetBytes(dataString), 0, dataString.Length);
                    }
                }
            }

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