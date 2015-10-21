using System;
using System.Collections.Specialized;
using System.Net;
using Skybrud.Social.Box.Endpoints.Raw;
using Skybrud.Social.Box.Responses.Authentication;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.Box.OAuth {
    
    public class BoxOAuthClient {

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

        public BoxFoldersRawEndpoint Folders { get; private set; }

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes an OAuth client with empty information.
        /// </summary>
        public BoxOAuthClient() {
            Folders = new BoxFoldersRawEndpoint(this);
        }

        /// <summary>
        /// Initializes an OAuth client with the specified access token.
        /// </summary>
        /// <param name="accessToken">A valid access token.</param>
        public BoxOAuthClient(string accessToken) : this() {
            AccessToken = accessToken;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified client ID and client secret.
        /// </summary>
        /// <param name="clientId">The ID of the client.</param>
        /// <param name="clientSecret">The secret of the client.</param>
        public BoxOAuthClient(long clientId, string clientSecret) : this() {
            ClientId = clientId + "";
            ClientSecret = clientSecret;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified client ID, client secret and return URI.
        /// </summary>
        /// <param name="clientId">The ID of the client.</param>
        /// <param name="clientSecret">The secret of the client.</param>
        /// <param name="redirectUri">The redirect URI of the client.</param>
        public BoxOAuthClient(long clientId, string clientSecret, string redirectUri) : this() {
            ClientId = clientId + "";
            ClientSecret = clientSecret;
            RedirectUri = redirectUri;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified client ID and client secret.
        /// </summary>
        /// <param name="clientId">The ID of the client.</param>
        /// <param name="clientSecret">The secret of the client.</param>
        public BoxOAuthClient(string clientId, string clientSecret) : this() {
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified client ID, client secret and return URI.
        /// </summary>
        /// <param name="clientId">The ID of the client.</param>
        /// <param name="clientSecret">The secret of the client.</param>
        /// <param name="redirectUri">The redirect URI of the client.</param>
        public BoxOAuthClient(string clientId, string clientSecret, string redirectUri) : this() {
            ClientId = clientId;
            ClientSecret = clientSecret;
            RedirectUri = redirectUri;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Generates the authorization URL using the specified state and scope.
        /// </summary>
        /// <param name="state">The state to send to the Box.com OAuth login page.</param>
        /// <returns>Returns an authorization URL based on the specified <code>state</code>.</returns>
        /// <see>
        ///     <cref>https://box-content.readme.io/docs/oauth-20</cref>
        /// </see>
        public string GetAuthorizationUrl(string state) {

            // Initialize the query string
            NameValueCollection query = new NameValueCollection {
                {"response_type", "code"},
                {"client_id", ClientId},
                {"redirect_uri", RedirectUri},
                {"state", state}
            };

            // Construct the authorization URL
            return "https://app.box.com/api/oauth2/authorize?" + SocialUtils.NameValueCollectionToQueryString(query);
        
        }
        
        /// <summary>
        /// Exchanges the specified authorization code for an access token.
        /// </summary>
        /// <param name="authCode">The authorization code received from the Box.com OAuth dialog.</param>
        /// <returns>Returns an access token based on the specified <code>authCode</code>.</returns>
        public BoxTokenResponse GetAccessTokenFromAuthCode(string authCode) {

            // Initialize the POST data
            NameValueCollection data = new NameValueCollection {
                {"code", authCode},
                {"grant_type", "authorization_code"},
                {"client_id", ClientId},
                {"client_secret", ClientSecret},
                {"redirect_uri", RedirectUri}
            };

            // Make the call to the API
            HttpWebResponse response = SocialUtils.DoHttpPostRequest("https://app.box.com/api/oauth2/token", null, data);

            // Wrap the native response class
            SocialHttpResponse social = SocialHttpResponse.GetFromWebResponse(response);

            // Parse the response
            return BoxTokenResponse.ParseResponse(social);

        }

        /// <summary>
        /// Gets a new access token from the specified <code>refreshToken</code>.
        /// </summary>
        /// <param name="refreshToken">The refresh token of the user.</param>
        /// <returns>Returns an access token based on the specified <code>refreshToken</code>.</returns>
        public BoxTokenResponse GetAccessTokenFromRefreshToken(string refreshToken) {

            // Initialize the POST data
            NameValueCollection data = new NameValueCollection {
                {"grant_type", "refresh_token"},
                {"refresh_token", refreshToken },
                {"client_id", ClientId},
                {"client_secret", ClientSecret}
            };

            // Make the call to the API
            HttpWebResponse response = SocialUtils.DoHttpPostRequest("https://app.box.com/api/oauth2/token", null, data);

            // Wrap the native response class
            SocialHttpResponse social = SocialHttpResponse.GetFromWebResponse(response);

            // Parse the response
            return BoxTokenResponse.ParseResponse(social);

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
        /// <param name="options">The options for the call to the API.</param>
        public SocialHttpResponse DoAuthenticatedGetRequest(string url, IGetOptions options) {
            return DoAuthenticatedGetRequest(url, options == null ? null : options.GetQueryString());
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