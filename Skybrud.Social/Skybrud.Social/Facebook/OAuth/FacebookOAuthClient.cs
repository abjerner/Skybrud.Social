using Skybrud.Social.Facebook.Endpoints.Raw;

namespace Skybrud.Social.Facebook.OAuth {

    /// <summary>
    /// Class for handling the raw communication with the Facebook API as well as any OAUth 2.0 communication.
    /// </summary>
    public class FacebookOAuthClient {

        private FacebookMethodsRawEndpoint _methods;

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
        /// The return URI of your application.
        /// </summary>
        public string ReturnUri { get; set; }

        /// <summary>
        /// The access token.
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets a reference to the methods endpoint.
        /// </summary>
        public FacebookMethodsRawEndpoint Methods {
            get { return _methods ?? (_methods = new FacebookMethodsRawEndpoint(this)); }
        }

        #endregion

        /// <summary>
        /// Initializes an OAuth client with empty information.
        /// </summary>
        public FacebookOAuthClient() {
            // default constructor
        }

        /// <summary>
        /// Initializes an OAuth client with the specified access token. Using this initializer,
        /// the client will have no information about your app.
        /// </summary>
        /// <param name="accessToken">A valid access token.</param>
        public FacebookOAuthClient(string accessToken) {
            AccessToken = accessToken;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified app ID and app secret.
        /// </summary>
        /// <param name="appId">The ID of the app.</param>
        /// <param name="appSecret">The secret of the app.</param>
        public FacebookOAuthClient(long appId, string appSecret) {
            AppId = appId + "";
            AppSecret = appSecret;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified app ID, app secret and return URI.
        /// </summary>
        /// <param name="appId">The ID of the app.</param>
        /// <param name="appSecret">The secret of the app.</param>
        /// <param name="returnUri">The return URI of the app.</param>
        public FacebookOAuthClient(long appId, string appSecret, string returnUri) {
            AppId = appId + "";
            AppSecret = appSecret;
            ReturnUri = returnUri;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified app ID and app secret.
        /// </summary>
        /// <param name="appId">The ID of the app.</param>
        /// <param name="appSecret">The secret of the app.</param>
        public FacebookOAuthClient(string appId, string appSecret) {
            AppId = appId;
            AppSecret = appSecret;
        }

        /// <summary>
        /// Initializes an OAuth client with the specified app ID, app secret and return URI.
        /// </summary>
        /// <param name="appId">The ID of the app.</param>
        /// <param name="appSecret">The secret of the app.</param>
        /// <param name="returnUri">The return URI of the app.</param>
        public FacebookOAuthClient(string appId, string appSecret, string returnUri) {
            AppId = appId;
            AppSecret = appSecret;
            ReturnUri = returnUri;
        }

    }

}
