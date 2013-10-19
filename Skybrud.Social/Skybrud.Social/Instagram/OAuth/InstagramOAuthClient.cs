using System;
using System.Web;
using Skybrud.Social.Instagram.Endpoints.Raw;

namespace Skybrud.Social.Instagram.OAuth {

    /// <summary>
    /// Class for handling the raw communication with the Instagram API as well
    /// as any OAuth 2.0 communication/authentication.
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
        /// The ID of the app/client.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// The secret of the app/client.
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// The return URI of your application.
        /// </summary>
        public string ReturnUri { get; set; }

        /// <summary>
        /// The access token.
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
        /// Initializes an OAuth client with the specified access token. Using this initializer,
        /// the client will have no information about your app.
        /// </summary>
        /// <param name="accessToken">A valid access token.</param>
        public InstagramOAuthClient(string accessToken) {
            AccessToken = accessToken;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified app ID and app secret.
        /// </summary>
        /// <param name="appId">The ID of the app.</param>
        /// <param name="appSecret">The secret of the app.</param>
        public InstagramOAuthClient(long appId, string appSecret) {
            ClientId = appId + "";
            ClientSecret = appSecret;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified app ID, app secret and return URI.
        /// </summary>
        /// <param name="appId">The ID of the app.</param>
        /// <param name="appSecret">The secret of the app.</param>
        /// <param name="returnUri">The return URI of the app.</param>
        public InstagramOAuthClient(long appId, string appSecret, string returnUri) {
            ClientId = appId + "";
            ClientSecret = appSecret;
            ReturnUri = returnUri;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified app ID and app secret.
        /// </summary>
        /// <param name="appId">The ID of the app.</param>
        /// <param name="appSecret">The secret of the app.</param>
        public InstagramOAuthClient(string appId, string appSecret) {
            ClientId = appId;
            ClientSecret = appSecret;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified app ID, app secret and return URI.
        /// </summary>
        /// <param name="appId">The ID of the app.</param>
        /// <param name="appSecret">The secret of the app.</param>
        /// <param name="returnUri">The return URI of the app.</param>
        public InstagramOAuthClient(string appId, string appSecret, string returnUri) {
            ClientId = appId;
            ClientSecret = appSecret;
            ReturnUri = returnUri;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets an authorization URL using the specified <var>state</var>.
        /// This URL will only make your application request a basic scope.
        /// </summary>
        /// <param name="state">A unique state for the request.</param>
        public string GetAuthorizationUrl(string state) {
            return GetAuthorizationUrl(state, InstagramScope.Basic);
        }

        /// <summary>
        /// Gets an authorization URL using the specified <var>state</var> and
        /// request the specified <var>scope</var>.
        /// </summary>
        /// <param name="state">A unique state for the request.</param>
        /// <param name="scope">The scope of your application.</param>
        public string GetAuthorizationUrl(string state, InstagramScope scope) {
            return String.Format(
                "https://api.instagram.com/oauth/authorize/?client_id={0}&redirect_uri={1}&response_type=code&state={2}&scope={3}",
                HttpUtility.UrlEncode(ClientId),
                HttpUtility.UrlEncode(ClientSecret),
                HttpUtility.UrlEncode(state),
                HttpUtility.UrlEncode(scope.ToString().Replace(", ", "+").ToLower())
            );
        }

        #endregion

    }

}
