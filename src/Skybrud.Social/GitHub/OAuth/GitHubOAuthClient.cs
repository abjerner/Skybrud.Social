using System;
using System.Collections.Specialized;
using System.IO;
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

        public GitHubRepositoriesRawEndpoint Repositories { get; private set; }
        public GitHubUserRawEndpoint User { get; private set; }
        public GitHubUsersRawEndpoint Users { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes an OAuth client with empty information.
        /// </summary>
        public GitHubOAuthClient() {
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

        public string DoAuthenticatedGetRequest(string url) {
            return DoAuthenticatedGetRequest(url, null);
        }

        public string DoAuthenticatedGetRequest(string url, NameValueCollection query) {
            HttpStatusCode statusCode;
            return DoAuthenticatedGetRequest(url, query, out statusCode);
        }

        public string DoAuthenticatedGetRequest(string url, NameValueCollection query, out HttpStatusCode statusCode) {

            // Throw an exception if the URL is empty
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");

            // Initialize a new query string if not specified
            if (query == null) query = new NameValueCollection();

            // Append the access token to the query string
            //query.Add("access_token", AccessToken);

            // Convert the query string to ... string
            string queryString = SocialUtils.NameValueCollectionToQueryString(query);

            // Append the query string to the URL
            url += url.Contains("?") ? "&" + queryString : "?" + queryString;

            // Initialize a new HTTP request
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);

            // GitHub requires a user agent - see https://developer.github.com/v3/#user-agent-required
            request.UserAgent = "Skybrud.Social";

            request.Headers.Add("Authorization: token " + AccessToken);

            // Get the HTTP response
            HttpWebResponse response;
            try {
                response = (HttpWebResponse) request.GetResponse();
            } catch (WebException ex) {
                response = (HttpWebResponse) ex.Response;
            }
                
            // Get the HTTP status code
            statusCode = response.StatusCode;

            // Read the response body
            using (Stream rs = response.GetResponseStream()) {
                if (rs == null) return null;
                using (StreamReader sr = new StreamReader(rs)) {
                    return sr.ReadToEnd();
                }
            }

        }

        #endregion

    }

}
