using System;
using System.Collections.Specialized;
using System.Net;
using System.Web;
using Skybrud.Social.GitHub.Endpoints.Raw;

namespace Skybrud.Social.GitHub.OAuth {

    public class GitHubOAuthClient {

        #region Properties

        /// <summary>
        /// The ID of the client.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// The secret of the client.
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// The redirect URI of your application.
        /// </summary>
        public string RedirectUri { get; set; }

        /// <summary>
        /// The access token.
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// The GitHub API support basic authentication, so even though this is
        /// not a part of OAuth, the <var>GitHubOAuthClient</var> will handle
        /// basic authentication as well.
        /// </summary>
        public NetworkCredential Credentials { get; set; }

        /// <summary>
        /// Gets a reference to the raw organizations endpoint.
        /// </summary>
        public GitHubOrganizationsRawEndpoint Organizations { get; private set; }
        public GitHubRepositoriesRawEndpoint Repositories { get; private set; }
        public GitHubUserRawEndpoint User { get; private set; }
        public GitHubUsersRawEndpoint Users { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes an OAuth client with empty information.
        /// </summary>
        public GitHubOAuthClient() {
            Organizations = new GitHubOrganizationsRawEndpoint(this);
            Repositories = new GitHubRepositoriesRawEndpoint(this);
            User = new GitHubUserRawEndpoint(this);
            Users = new GitHubUsersRawEndpoint(this);
        }

        /// <summary>
        /// Initializes an OAuth client with the specified access token. Using this initializer,
        /// the client will have no information about your app.
        /// </summary>
        /// <param name="accessToken">A valid access token.</param>
        public GitHubOAuthClient(string accessToken) : this() {
            AccessToken = accessToken;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified client ID and client secret.
        /// </summary>
        /// <param name="clientId">The ID of the client.</param>
        /// <param name="clientSecret">The secret of the client.</param>
        public GitHubOAuthClient(string clientId, string clientSecret) : this() {
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified client ID, client secret and redirect URI.
        /// </summary>
        /// <param name="clientId">The ID of the client.</param>
        /// <param name="clientSecret">The secret of the client.</param>
        /// <param name="redirectUri">The redirect URI of the client.</param>
        public GitHubOAuthClient(string clientId, string clientSecret, string redirectUri) : this() {
            ClientId = clientId;
            ClientSecret = clientSecret;
            RedirectUri = redirectUri;
        }

        #endregion

        #region Methods

        public string GetAuthorizationUrl(string state, GitHubScopeCollection scopes) {

            // Initialize the query string
            NameValueCollection nvc = new NameValueCollection { { "client_id", ClientId } };

            // Add the redirect URI if specified
            if (!String.IsNullOrWhiteSpace(RedirectUri)) nvc.Add("redirect_uri", RedirectUri);

            // Add the state if specified
            if (!String.IsNullOrWhiteSpace(state)) nvc.Add("state", state);

            // Get the scope list
            string scope = (scopes == null ? "" : scopes.ToString());
            if (!String.IsNullOrWhiteSpace(scope)) nvc.Add("scope", scope);

            // Generate the URL
            return "https://github.com/login/oauth/authorize?" + SocialUtils.NameValueCollectionToQueryString(nvc);

        }

        /// <summary>
        /// Exchanges the specified authorization code for a user access token.
        /// </summary>
        /// <param name="authCode">The authorization code received from the GitHub OAuth dialog.</param>
        public GitHubOAuthAccessTokenResponse GetAccessTokenFromAuthCode(string authCode) {

            NameValueCollection parameters = new NameValueCollection {
                {"client_id", ClientId},
                {"client_secret", ClientSecret},
                {"code", authCode }
            };

            // Add the redirect URI (if specified)
            if (!String.IsNullOrWhiteSpace(RedirectUri)) parameters.Add("redirect_uri", RedirectUri);

            // Get the response from the server
            string contents = SocialUtils.DoHttpPostRequestAndGetBodyAsString("https://github.com/login/oauth/access_token", null, parameters);

            // Parse the contents
            NameValueCollection response = HttpUtility.ParseQueryString(contents);

            // Return the response
            return GitHubOAuthAccessTokenResponse.Parse(response);

        }

        internal string GenerateAbsoluteUrl(string relative) {
            return GenerateAbsoluteUrl(relative, null);
        }

        internal string GenerateAbsoluteUrl(string relative, NameValueCollection query) {

            if (query == null) query = new NameValueCollection();

            string url = "https://api.github.com";
            if (Credentials != null) {
                url = "https://" + Credentials.UserName + ":" + Credentials.Password + "@api.github.com";
            } else if (AccessToken != null) {
                query.Add("access_token", AccessToken);
            }

            // Add the relative URL
            url += relative;

            // Append the query string (if not empty)
            if (query.Count > 0) url += "?" + SocialUtils.NameValueCollectionToQueryString(query);

            // Now return the URL
            return url;

        }

        public SocialHttpResponse DoAuthenticatedGetRequest(string url) {
            return DoAuthenticatedGetRequest(url, (SocialQueryString)null);
        }

        public SocialHttpResponse DoAuthenticatedGetRequest(string url, NameValueCollection query) {
            return DoAuthenticatedGetRequest(url, new SocialQueryString(query));
        }

        public SocialHttpResponse DoAuthenticatedGetRequest(string url, SocialQueryString query) {

            // Throw an exception if the URL is empty
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");

            // Append the query string to the URL
            if (query != null && !query.IsEmpty) url += (url.Contains("?") ? "&" : "?") + query;

            // Initialize a new HTTP request
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);

            // GitHub requires a user agent - see https://developer.github.com/v3/#user-agent-required
            request.UserAgent = "Skybrud.Social";

            // Add an authorization header with the access token
            request.Headers.Add("Authorization: token " + AccessToken);

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
