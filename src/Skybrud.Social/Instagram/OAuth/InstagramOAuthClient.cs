using System;
using System.Collections.Specialized;
using System.Net;
using Skybrud.Social.Http;
using Skybrud.Social.Instagram.Endpoints.Raw;
using Skybrud.Social.Instagram.Responses;
using Skybrud.Social.Instagram.Scopes;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.Instagram.OAuth {

    /// <summary>
    /// Class for handling the raw communication with the Instagram API as well as any OAuth 2.0
    /// communication/authentication.
    /// </summary>
    public class InstagramOAuthClient {

        #region Private fields

        private InstagramLocationsRawEndpoint _locations;
        private InstagramMediaRawEndpoint _media;
        private InstagramRelationshipsRawEndpoint _relationships;
        private InstagramTagsRawEndpoint _tags;
        private InstagramUsersRawEndpoint _users;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the ID of the app/client.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the secret of the app/client.
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets the redirect URI of your application.
        /// </summary>
        [Obsolete("Use \"RedirectUri\" instead to follow Instagram lingo.")]
        public string ReturnUri {
            get { return RedirectUri; }
            set { RedirectUri = value; }
        }

        /// <summary>
        /// Gets or sets the redirect URI of your application.
        /// </summary>
        public string RedirectUri { get; set; }

        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets a reference to the locations endpoint.
        /// </summary>
        public InstagramLocationsRawEndpoint Locations {
            get { return _locations ?? (_locations = new InstagramLocationsRawEndpoint(this)); }
        }

        /// <summary>
        /// Gets a reference to the media endpoint.
        /// </summary>
        public InstagramMediaRawEndpoint Media {
            get { return _media ?? (_media = new InstagramMediaRawEndpoint(this)); }
        }

        /// <summary>
        /// Gets a reference to the relationships endpoint.
        /// </summary>
        public InstagramRelationshipsRawEndpoint Relationships {
            get { return _relationships ?? (_relationships = new InstagramRelationshipsRawEndpoint(this)); }
        }

        /// <summary>
        /// Gets a reference to the tags endpoint.
        /// </summary>
        public InstagramTagsRawEndpoint Tags {
            get { return _tags ?? (_tags = new InstagramTagsRawEndpoint(this)); }
        }

        /// <summary>
        /// Gets a reference to the users endpoint.
        /// </summary>
        public InstagramUsersRawEndpoint Users {
            get { return _users ?? (_users = new InstagramUsersRawEndpoint(this)); }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes an OAuth client with empty information.
        /// </summary>
        public InstagramOAuthClient() {
            // default constructor
        }

        /// <summary>
        /// Initializes an OAuth client with the specified <code>accessToken</code>. Using this initializer, the client
        /// will have no information about your app.
        /// </summary>
        /// <param name="accessToken">A valid access token.</param>
        public InstagramOAuthClient(string accessToken) {
            AccessToken = accessToken;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified <code>clientId</code> and <code>clientSecret</code>.
        /// </summary>
        /// <param name="clientId">The ID of the client/app.</param>
        /// <param name="clientSecret">The secret of the client/app.</param>
        public InstagramOAuthClient(long clientId, string clientSecret) {
            // TODO: Remove for v1.0 (user constructor overload with string parameters instead)
            ClientId = clientId + "";
            ClientSecret = clientSecret;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified <code>clientId</code>, <code>clientSecret</code> and <code>redirectUri</code>.
        /// </summary>
        /// <param name="clientId">The ID of the client/app.</param>
        /// <param name="clientSecret">The secret of the client/app.</param>
        /// <param name="redirectUri">The return URI of the client/app.</param>
        public InstagramOAuthClient(long clientId, string clientSecret, string redirectUri) {
            // TODO: Remove for v1.0 (user constructor overload with string parameters instead)
            ClientId = clientId + "";
            ClientSecret = clientSecret;
            RedirectUri = redirectUri;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified <code>clientId</code> and <code>clientSecret</code>.
        /// </summary>
        /// <param name="clientId">The ID of the client/app.</param>
        /// <param name="clientSecret">The secret of the client/app.</param>
        public InstagramOAuthClient(string clientId, string clientSecret) {
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified <code>clientId</code>, <code>clientSecret</code> and <code>redirectUri</code>.
        /// </summary>
        /// <param name="clientId">The ID of the client/app.</param>
        /// <param name="clientSecret">The secret of the client/app.</param>
        /// <param name="redirectUri">The return URI of the client/app.</param>
        public InstagramOAuthClient(string clientId, string clientSecret, string redirectUri) {
            ClientId = clientId;
            ClientSecret = clientSecret;
            RedirectUri = redirectUri;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets an authorization URL using the specified <code>state</code>. This URL will only make your application
        /// request a basic scope.
        /// </summary>
        /// <param name="state">A unique state for the request.</param>
        public string GetAuthorizationUrl(string state) {
            return GetAuthorizationUrl(state, InstagramScopes.Basic);
        }

        /// <summary>
        /// Gets an authorization URL using the specified <var>state</var> and request the specified <code>scope</code>.
        /// </summary>
        /// <param name="state">A unique state for the request.</param>
        /// <param name="scope">The scope of your application.</param>
        [Obsolete("Use method overloads instead.")]
        public string GetAuthorizationUrl(string state, InstagramScope scope) {
            // TODO: Remove in v1.0
            return GetAuthorizationUrl(state, scope.ToString().Replace(", ", " ").ToLower());
        }

        /// <summary>
        /// Gets an authorization URL using the specified <var>state</var> and request the specified <code>scope</code>.
        /// </summary>
        /// <param name="state">A unique state for the request.</param>
        /// <param name="scope">The scope of your application.</param>
        public string GetAuthorizationUrl(string state, InstagramScopeCollection scope) {
            return GetAuthorizationUrl(state, scope.ToString());
        }

        /// <summary>
        /// Gets an authorization URL using the specified <var>state</var> and request the specified <code>scope</code>.
        /// </summary>
        /// <param name="state">A unique state for the request.</param>
        /// <param name="scope">The scope of your application.</param>
        public string GetAuthorizationUrl(string state, params string[] scope) {

            // Do we have a valid "state" ?
            if (String.IsNullOrWhiteSpace(state)) {
                throw new ArgumentNullException("state", "A valid state should be specified as it is part of the security of OAuth 2.0.");
            }

            // Construct the query string
            NameValueCollection query = new NameValueCollection {
                {"client_id", ClientId},
                {"redirect_uri", RedirectUri},
                {"response_type", "code"},
                {"state", state}
            };

            // Append the scope (if specified)
            if (scope != null && scope.Length > 0) {
                query.Add("scope", String.Join(" ", scope));
            }

            // Construct thr authorization URL
            return "https://api.instagram.com/oauth/authorize/?" + SocialUtils.NameValueCollectionToQueryString(query);

        }

        /// <summary>
        /// Makes a call to the Instagram API to exchange the specified <code>authCode</code> for an access token.
        /// </summary>
        /// <param name="authCode">The authorization code obtained from an OAuth 2.0 login flow.</param>
        /// <returns>Returns an instance of <code>InstagramAccessTokenResponse</code> representing the response from the server.</returns>
        public InstagramAccessTokenResponse GetAccessTokenFromAuthCode(string authCode) {
        
            // Initialize collection with POST data
            NameValueCollection parameters = new NameValueCollection {
                {"client_id", ClientId},
                {"client_secret", ClientSecret},
                {"grant_type", "authorization_code"},
                {"redirect_uri", RedirectUri},
                {"code", authCode }
            };

            // Make the call to the API
            HttpWebResponse response = SocialUtils.DoHttpPostRequest("https://api.instagram.com/oauth/access_token", null, parameters);

            // Wrap the native response class
            SocialHttpResponse social = SocialHttpResponse.GetFromWebResponse(response);

            // Parse the response
            return InstagramAccessTokenResponse.ParseResponse(social);

        }

        /// <summary>
        /// Makes an authenticated GET request to the specified URL. If an access token has been
        /// specified for this client, that access token will be added to the query string.
        /// Similar if a client ID has been specified instead of an access token, that client ID
        /// will be added to the query string. However some endpoint methods may require an access
        /// token, and a client ID will therefore not be sufficient for such methods.
        /// </summary>
        /// <param name="url">The URL to call.</param>
        public SocialHttpResponse DoAuthenticatedGetRequest(string url) {
            return DoAuthenticatedGetRequest(url, new NameValueCollection());
        }

        /// <summary>
        /// Makes an authenticated GET request to the specified URL. If an access token has been
        /// specified for this client, that access token will be added to the query string.
        /// Similar if a client ID has been specified instead of an access token, that client ID
        /// will be added to the query string. However some endpoint methods may require an access
        /// token, and a client ID will therefore not be sufficient for such methods.
        /// </summary>
        /// <param name="url">The URL to call.</param>
        /// <param name="query">The query string for the call.</param>
        public SocialHttpResponse DoAuthenticatedGetRequest(string url, NameValueCollection query) {
            return DoAuthenticatedGetRequest(url, new SocialQueryString(query));
        }

        /// <summary>
        /// Makes an authenticated GET request to the specified URL. If an access token has been
        /// specified for this client, that access token will be added to the query string.
        /// Similar if a client ID has been specified instead of an access token, that client ID
        /// will be added to the query string. However some endpoint methods may require an access
        /// token, and a client ID will therefore not be sufficient for such methods.
        /// </summary>
        /// <param name="url">The URL to call.</param>
        /// <param name="query">The query string for the call.</param>
        public SocialHttpResponse DoAuthenticatedGetRequest(string url, IGetOptions query) {
            return DoAuthenticatedGetRequest(url, query == null ? null : query.GetQueryString());
        }

        /// <summary>
        /// Makes an authenticated GET request to the specified URL. If an access token has been
        /// specified for this client, that access token will be added to the query string.
        /// Similar if a client ID has been specified instead of an access token, that client ID
        /// will be added to the query string. However some endpoint methods may require an access
        /// token, and a client ID will therefore not be sufficient for such methods.
        /// </summary>
        /// <param name="url">The URL to call.</param>
        /// <param name="query">The query string for the call.</param>
        public SocialHttpResponse DoAuthenticatedGetRequest(string url, SocialQueryString query) {

            // Throw an exception if the URL is empty
            if (String.IsNullOrWhiteSpace(url)) throw new ArgumentNullException("url");

            // Initialize a new instance of SocialQueryString if the one specified is NULL
            if (query == null) query = new SocialQueryString();

            // Append either the access token or the client ID to the query string
            if (!String.IsNullOrWhiteSpace(AccessToken)) {
                query.Add("access_token", AccessToken);
            } else if (!String.IsNullOrWhiteSpace(ClientId)) {
                query.Add("client_id", ClientId);
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