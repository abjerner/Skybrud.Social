using System;
using System.Collections.Specialized;
using System.Net;
using Skybrud.Social.Http;
using Skybrud.Social.Slack.Endpoints.Raw;
using Skybrud.Social.Slack.Responses.Authentication;
using Skybrud.Social.Slack.Scopes;

namespace Skybrud.Social.Slack.OAuth {

    /// <summary>
    /// Class for handling the raw communication with the Slack API as well as any OAuth 2.0 communication.
    /// </summary>
    public class SlackOAuthClient {

        #region Properties

        #region OAuth

        /// <summary>
        /// Gets or sets the ID of the client.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the secret of the client.
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets the redirect URI of your client.
        /// </summary>
        public string RedirectUri { get; set; }

        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        public string AccessToken { get; set; }

        #endregion

        #region Endpoints

        /// <summary>
        /// Gets a reference to the raw authentication endpoint.
        /// </summary>
        public SlackAuthenticationRawEndpoint Authentication { get; private set; }

        /// <summary>
        /// Gets a reference to the raw users endpoint.
        /// </summary>
        public SlackUsersRawEndpoint Users { get; private set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes an OAuth client with empty information.
        /// </summary>
        public SlackOAuthClient() {
            Authentication = new SlackAuthenticationRawEndpoint(this);
            Users = new SlackUsersRawEndpoint(this);
        }

        /// <summary>
        /// Initializes an OAuth client with the specified access token.
        /// </summary>
        /// <param name="accessToken">A valid access token.</param>
        public SlackOAuthClient(string accessToken) : this() {
            AccessToken = accessToken;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified client ID and client secret.
        /// </summary>
        /// <param name="clientId">The ID of the client.</param>
        /// <param name="clientSecret">The secret of the client.</param>
        public SlackOAuthClient(long clientId, string clientSecret) : this() {
            ClientId = clientId + "";
            ClientSecret = clientSecret;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified client ID, client secret and return URI.
        /// </summary>
        /// <param name="clientId">The ID of the client.</param>
        /// <param name="clientSecret">The secret of the client.</param>
        /// <param name="redirectUri">The redirect URI of the client.</param>
        public SlackOAuthClient(long clientId, string clientSecret, string redirectUri) : this() {
            ClientId = clientId + "";
            ClientSecret = clientSecret;
            RedirectUri = redirectUri;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified client ID and client secret.
        /// </summary>
        /// <param name="clientId">The ID of the client.</param>
        /// <param name="clientSecret">The secret of the client.</param>
        public SlackOAuthClient(string clientId, string clientSecret) : this() {
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified client ID, client secret and return URI.
        /// </summary>
        /// <param name="clientId">The ID of the client.</param>
        /// <param name="clientSecret">The secret of the client.</param>
        /// <param name="redirectUri">The redirect URI of the client.</param>
        public SlackOAuthClient(string clientId, string clientSecret, string redirectUri) : this() {
            ClientId = clientId;
            ClientSecret = clientSecret;
            RedirectUri = redirectUri;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets an authorization URL using the specified <code>state</code>. This URL will only make your application
        /// request a basic scope.
        /// </summary>
        /// <param name="state">A unique state for the request.</param>
        public string GetAuthorizationUrl(string state) {
            return String.Format(
                "https://slack.com/oauth/authorize?client_id={0}&redirect_uri={1}&state={2}",
                SocialUtils.UrlEncode(ClientId),
                SocialUtils.UrlEncode(RedirectUri),
                SocialUtils.UrlEncode(state)
            );
        }

        /// <summary>
        /// Gets an authorization URL using the specified <code>state</code>. This URL will only make your application
        /// request a basic scope.
        /// </summary>
        /// <param name="state">A unique state for the request.</param>
        /// <param name="scope">The scope of the application.</param>
        public string GetAuthorizationUrl(string state, SlackScopeCollection scope) {
            if (String.IsNullOrWhiteSpace(state)) throw new ArgumentNullException("state");
            if (scope == null) throw new ArgumentNullException("scope");
            return String.Format(
                "https://slack.com/oauth/authorize?client_id={0}&redirect_uri={1}&state={2}&scope={3}",
                SocialUtils.UrlEncode(ClientId),
                SocialUtils.UrlEncode(RedirectUri),
                SocialUtils.UrlEncode(state),
                SocialUtils.UrlEncode(scope.ToString())
            );
        }

        /// <summary>
        /// Exchanges the specified authorization code for a refresh token and an access token.
        /// </summary>
        /// <param name="authCode">The authorization code received from the Slack OAuth dialog.</param>
        /// <returns>Returns an access token based on the specified <code>authCode</code>.</returns>
        public SlackTokenResponse GetAccessTokenFromAuthCode(string authCode) {

            // Initialize collection with POST data
            NameValueCollection parameters = new NameValueCollection {
                {"client_id", ClientId},
                {"client_secret", ClientSecret},
                {"redirect_uri", RedirectUri},
                {"code", authCode }
            };

            // Make the call to the API
            HttpWebResponse response = SocialUtils.DoHttpPostRequest("https://slack.com/api/oauth.access", null, parameters);

            // Wrap the native response class
            SocialHttpResponse social = SocialHttpResponse.GetFromWebResponse(response);

            // Parse the response
            return SlackTokenResponse.ParseResponse(social);

        }

        /// <summary>
        /// Makes an authenticated GET request to the specified URL. The access token is automatically appended to the query string.
        /// </summary>
        /// <param name="url">The URL to call.</param>
        public SocialHttpResponse DoAuthenticatedGetRequest(string url) {
            return DoAuthenticatedGetRequest(url, default(SocialQueryString));
        }

        /// <summary>
        /// Makes an authenticated GET request to the specified URL. The access token is automatically appended to the query string.
        /// </summary>
        /// <param name="url">The URL to call.</param>
        /// <param name="query">The query string for the call.</param>
        public SocialHttpResponse DoAuthenticatedGetRequest(string url, SocialQueryString query) {

            // Initialize a new NameValueCollection if NULL
            if (query == null) query = new SocialQueryString();

            // Append the access token to the query string if present in the client and not already
            // specified in the query string
            if (!query.ContainsKey("token") && !String.IsNullOrWhiteSpace(AccessToken)) {
                query.Add("token", AccessToken);
            }

            // Configure the request
            SocialHttpRequest request = new SocialHttpRequest {
                Method = "GET",
                Url = url,
                QueryString = query,
                UserAgent = "Skybrud.Social"
            };

            // Make a call to the API
            return request.GetResponse();

        }

        #endregion

    }

}