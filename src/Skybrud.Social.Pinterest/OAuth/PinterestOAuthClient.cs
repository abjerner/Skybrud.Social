using System;
using System.Collections.Specialized;
using System.Net;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;
using Skybrud.Social.Pinterest.Endpoints.Raw;
using Skybrud.Social.Pinterest.Responses.Authentication;
using Skybrud.Social.Pinterest.Scopes;

namespace Skybrud.Social.Pinterest.OAuth {
    
    public class PinterestOAuthClient {

        #region Properties

        #region OAuth

        /// <summary>
        /// Gets or sets the client ID (Pinterest calls this the app ID). 
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the client secret (Pinterest calls this the app secret). 
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets the redirect URI.
        /// </summary>
        public string RedirectUri { get; set; }

        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        public string AccessToken { get; set; }

        #endregion

        #region Endpoints

        public PinterestUsersRawEndpoint Users { get; private set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes an OAuth client with empty information.
        /// </summary>
        public PinterestOAuthClient() {
            Users = new PinterestUsersRawEndpoint(this);
        }

        /// <summary>
        /// Initializes an OAuth client with the specified access token.
        /// </summary>
        /// <param name="accessToken">A valid access token.</param>
        public PinterestOAuthClient(string accessToken) : this() {
            AccessToken = accessToken;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified client ID and client secret.
        /// </summary>
        /// <param name="clientId">The ID of the client.</param>
        /// <param name="clientSecret">The secret of the client.</param>
        public PinterestOAuthClient(long clientId, string clientSecret) : this() {
            ClientId = clientId + "";
            ClientSecret = clientSecret;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified client ID, client secret and return URI.
        /// </summary>
        /// <param name="clientId">The ID of the client.</param>
        /// <param name="clientSecret">The secret of the client.</param>
        /// <param name="redirectUri">The redirect URI of the client.</param>
        public PinterestOAuthClient(long clientId, string clientSecret, string redirectUri) : this() {
            ClientId = clientId + "";
            ClientSecret = clientSecret;
            RedirectUri = redirectUri;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified client ID and client secret.
        /// </summary>
        /// <param name="clientId">The ID of the client.</param>
        /// <param name="clientSecret">The secret of the client.</param>
        public PinterestOAuthClient(string clientId, string clientSecret) : this() {
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified client ID, client secret and return URI.
        /// </summary>
        /// <param name="clientId">The ID of the client.</param>
        /// <param name="clientSecret">The secret of the client.</param>
        /// <param name="redirectUri">The redirect URI of the client.</param>
        public PinterestOAuthClient(string clientId, string clientSecret, string redirectUri) : this() {
            ClientId = clientId;
            ClientSecret = clientSecret;
            RedirectUri = redirectUri;
        }

        #endregion


        #region Methods

        /// <summary>
        /// Generates the authorization URL using the specified state and scope.
        /// </summary>
        /// <param name="state">The state to send to the Microsoft OAuth login page.</param>
        /// <param name="scope">The scope of the application.</param>
        /// <returns>Returns an authorization URL based on <code>state</code> and <code>scope</code>.</returns>
        public string GetAuthorizationUrl(string state, PinterestScopeCollection scope) {
            return GetAuthorizationUrl(state, scope.ToString());
        }

        /// <summary>
        /// Generates the authorization URL using the specified state and scope.
        /// </summary>
        /// <param name="state">The state to send to the Pinterest OAuth login page.</param>
        /// <param name="scope">The scope of the application.</param>
        /// <returns>Returns an authorization URL based on <code>state</code> and <code>scope</code>.</returns>
        public string GetAuthorizationUrl(string state, params string[] scope) {
            return String.Format(
                "https://api.pinterest.com/oauth/?client_id={0}&scope={1}&response_type=code&redirect_uri={2}&state={3}",
                ClientId,
                String.Join(" ", scope),
                RedirectUri,
                state
            );
        }

        /// <summary>
        /// Exchanges the specified authorization code for a refresh token and an access token.
        /// </summary>
        /// <param name="authCode">The authorization code received from the Pinterest OAuth dialog.</param>
        /// <returns>Returns an access token based on the specified <code>authCode</code>.</returns>
        public PinterestTokenResponse GetAccessTokenFromAuthCode(string authCode) {

            // Initialize the POST data
            NameValueCollection data = new NameValueCollection {
                {"client_id", ClientId},
                {"client_secret", ClientSecret},
                {"code", authCode },
                {"grant_type", "authorization_code"}
            };

            // Make the call to the API
            HttpWebResponse response = SocialUtils.DoHttpPostRequest("https://api.pinterest.com/v1/oauth/token", null, data);

            // Wrap the native response class
            SocialHttpResponse social = SocialHttpResponse.GetFromWebResponse(response);

            // Parse the response
            return PinterestTokenResponse.ParseResponse(social);

        }

        /// <summary>
        /// Makes an authenticated GET request to the specified URL.
        /// </summary>
        /// <param name="url">The URL to call.</param>
        public SocialHttpResponse DoAuthenticatedGetRequest(string url) {
            return DoAuthenticatedGetRequest(url, default(SocialQueryString));
        }

        /// <summary>
        /// Makes an authenticated GET request to the specified URL.
        /// </summary>
        /// <param name="url">The URL to call.</param>
        /// <param name="options">The options for the call to the API.</param>
        public SocialHttpResponse DoAuthenticatedGetRequest(string url, IGetOptions options) {
            SocialQueryString query = options == null ? null : options.GetQueryString();
            return DoAuthenticatedGetRequest(url, query);
        }

        /// <summary>
        /// Makes an authenticated GET request to the specified URL.
        /// </summary>
        /// <param name="url">The URL to call.</param>
        /// <param name="query">The query string for the call.</param>
        public SocialHttpResponse DoAuthenticatedGetRequest(string url, SocialQueryString query) {

            // Initialize a new SocialQueryString if NULL
            if (query == null) query = new SocialQueryString();
            
            // Configure the request
            SocialHttpRequest request = new SocialHttpRequest {
                Method = "GET",
                Url = url,
                QueryString = query
            };

            // Add an authorization header with the access token
            if (!query.ContainsKey("access_token") && !String.IsNullOrWhiteSpace(AccessToken)) {
                request.Headers.Authorization = "Bearer " + AccessToken;
            }

            // Set headers of the request

            // Make a call to the API
            return request.GetResponse();

        }

        #endregion

    }

}