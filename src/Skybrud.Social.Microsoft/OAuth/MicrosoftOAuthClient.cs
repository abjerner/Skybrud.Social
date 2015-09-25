using System;
using System.Collections.Specialized;
using System.Net;
using Skybrud.Social.Http;
using Skybrud.Social.Microsoft.Responses.Authentication;
using Skybrud.Social.Microsoft.Scopes;
using Skybrud.Social.Microsoft.WindowsLive.Endpoints.Raw;

namespace Skybrud.Social.Microsoft.OAuth {
    
    public class MicrosoftOAuthClient {

        #region Properties

        #region OAuth

        /// <summary>
        /// Gets or sets the client ID.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the client secret.
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

        /// <summary>
        /// Gets a reference to the raw Windows Live endpoint.
        /// </summary>
        public WindowsLiveRawEndpoint WindowsLive { get; private set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes an OAuth client with empty information.
        /// </summary>
        public MicrosoftOAuthClient() {
            WindowsLive = new WindowsLiveRawEndpoint(this);
        }

        /// <summary>
        /// Initializes an OAuth client with the specified access token.
        /// </summary>
        /// <param name="accessToken">A valid access token.</param>
        public MicrosoftOAuthClient(string accessToken) : this() {
            AccessToken = accessToken;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified client ID and client secret.
        /// </summary>
        /// <param name="clientId">The ID of the client.</param>
        /// <param name="clientSecret">The secret of the client.</param>
        public MicrosoftOAuthClient(long clientId, string clientSecret) : this() {
            ClientId = clientId + "";
            ClientSecret = clientSecret;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified client ID, client secret and return URI.
        /// </summary>
        /// <param name="clientId">The ID of the client.</param>
        /// <param name="clientSecret">The secret of the client.</param>
        /// <param name="redirectUri">The redirect URI of the client.</param>
        public MicrosoftOAuthClient(long clientId, string clientSecret, string redirectUri) : this() {
            ClientId = clientId + "";
            ClientSecret = clientSecret;
            RedirectUri = redirectUri;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified client ID and client secret.
        /// </summary>
        /// <param name="clientId">The ID of the client.</param>
        /// <param name="clientSecret">The secret of the client.</param>
        public MicrosoftOAuthClient(string clientId, string clientSecret) : this() {
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified client ID, client secret and return URI.
        /// </summary>
        /// <param name="clientId">The ID of the client.</param>
        /// <param name="clientSecret">The secret of the client.</param>
        /// <param name="redirectUri">The redirect URI of the client.</param>
        public MicrosoftOAuthClient(string clientId, string clientSecret, string redirectUri) : this() {
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
        public string GetAuthorizationUrl(string state, MicrosoftScopeCollection scope) {
            return GetAuthorizationUrl(state, scope.ToString());
        }

        /// <summary>
        /// Generates the authorization URL using the specified state and scope.
        /// </summary>
        /// <param name="state">The state to send to the Microsoft OAuth login page.</param>
        /// <param name="scope">The scope of the application.</param>
        /// <returns>Returns an authorization URL based on <code>state</code> and <code>scope</code>.</returns>
        public string GetAuthorizationUrl(string state, params string[] scope) {
            return String.Format(
                "https://login.live.com/oauth20_authorize.srf?client_id={0}&scope={1}&response_type=code&redirect_uri={2}&state={3}",
                ClientId,
                String.Join(" ", scope),
                RedirectUri,
                state
            );
        }

        /// <summary>
        /// Exchanges the specified authorization code for a refresh token and an access token.
        /// </summary>
        /// <param name="authCode">The authorization code received from the Microsoft OAuth dialog.</param>
        /// <returns>Returns an access token based on the specified <code>authCode</code>.</returns>
        public MicrosoftTokenResponse GetAccessTokenFromAuthCode(string authCode) {

            // Initialize the POST data
            NameValueCollection data = new NameValueCollection {
                {"client_id", ClientId},
                {"redirect_uri", RedirectUri},
                {"client_secret", ClientSecret},
                {"code", authCode },
                {"grant_type", "authorization_code"}
            };

            // Make the call to the API
            HttpWebResponse response = SocialUtils.DoHttpPostRequest("https://login.live.com/oauth20_token.srf", null, data);

            // Wrap the native response class
            SocialHttpResponse social = SocialHttpResponse.GetFromWebResponse(response);

            // Parse the response
            return MicrosoftTokenResponse.ParseResponse(social);

        }

        /// <summary>
        /// Gets a new access token from the specified <code>refreshToken</code>.
        /// </summary>
        /// <param name="refreshToken">The refresh token of the user.</param>
        /// <returns>Returns an access token based on the specified <code>refreshToken</code>.</returns>
        public MicrosoftTokenResponse GetAccessTokenFromRefreshToken(string refreshToken) {

            // Initialize the POST data
            NameValueCollection data = new NameValueCollection {
                {"client_id", ClientId},
                {"redirect_uri", RedirectUri},
                {"client_secret", ClientSecret},
                {"refresh_token", refreshToken },
                {"grant_type", "refresh_token"}
            };

            // Make the call to the API
            HttpWebResponse response = SocialUtils.DoHttpPostRequest("https://login.live.com/oauth20_token.srf", null, data);

            // Wrap the native response class
            SocialHttpResponse social = SocialHttpResponse.GetFromWebResponse(response);

            // Parse the response
            return MicrosoftTokenResponse.ParseResponse(social);

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

            // Initialize a new SocialQueryString if NULL
            if (query == null) query = new SocialQueryString();

            // Append the access token to the query string if present in the client and not already
            // specified in the query string
            if (!query.ContainsKey("access_token") && !String.IsNullOrWhiteSpace(AccessToken)) {
                query.Add("access_token", AccessToken);
            }

            // Configure the request
            SocialHttpRequest request = new SocialHttpRequest {
                Method = "GET",
                Url = url,
                QueryString = query
            };

            // Set headers of the request

            // Make a call to the API
            return request.GetResponse();

        }

        #endregion

    }

}