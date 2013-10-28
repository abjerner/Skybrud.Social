using System;
using Skybrud.Social.Facebook.Endpoints;
using Skybrud.Social.Facebook.OAuth;
using Skybrud.Social.Facebook.Responses;

namespace Skybrud.Social.Facebook {

    public class FacebookService {

        #region Properties

        /// <summary>
        /// The internal OAuth client for communication with the Facebook API.
        /// </summary>
        public FacebookOAuthClient Client { get; private set; }

        public FacebookMethodsEndpoint Methods { get; private set; }

        [Obsolete("Use Client.AccessToken instead.")]
        public string AccessToken {
            get { return Client == null ? null : Client.AccessToken; }
        }

        #endregion

        #region Constructor(s)

        private FacebookService() {
            Methods = new FacebookMethodsEndpoint(this);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Initialize a new service instance from the specified access token. Internally a new OAuth client will be
        /// initialized from the access token.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        public static FacebookService CreateFromAccessToken(string accessToken) {
            return new FacebookService {
                Client = new FacebookOAuthClient(accessToken)
            };
        }

        /// <summary>
        /// Initialize a new service instance from the specified OAuth client.
        /// </summary>
        /// <param name="client">The OAuth client.</param>
        public static FacebookService CreateFromOAuthClient(FacebookOAuthClient client) {

            // This should never be null
            if (client == null) throw new ArgumentNullException("client");

            // Initialize the service
            FacebookService service = new FacebookService {
                Client = client
            };

            // Set the endpoints etc.
            service.Methods = new FacebookMethodsEndpoint(service);

            // Return the service
            return service;
        
        }

        #endregion

        #region Obsolete

        #region Accounts

        /// <summary>
        /// Gets information about accounts associated with the current user by calling the <var>/me/accounts</var> method. This call requires a user access token.
        /// </summary>
        /// <returns>The raw JSON response from the API.</returns>
        [Obsolete("Use Client.Methods.GetAccounts() or Methods.Raw.GetAccounts() instead")]
        public string GetAccountsAsRawJson() {
            return Methods.Raw.GetAccounts();
        }

        /// <summary>
        /// Gets information about accounts associated with the current user by calling the <var>/me/accounts</var> method. This call requires a user access token.
        /// </summary>
        [Obsolete("Use Methods.GetAccounts() instead")]
        public FacebookAccountsResponse Accounts() {
            return Methods.GetAccounts();
        }

        #endregion

        #region Debug token

        /// <summary>
        /// Gets debug information about the specified access token.
        /// </summary>
        /// <param name="accessToken">The access token to debug.</param>
        [Obsolete("Use Client.Methods.DebugToken() or Methods.Raw.DebugToken() instead")]
        public string DebugTokenAsRawJson(string accessToken) {
            return Methods.Raw.DebugToken(accessToken);
        }

        /// <summary>
        /// Gets debug information about the access token used for accessing the Graph API.
        /// </summary>
        [Obsolete("Use Methods.DebugToken() instead")]
        public FacebookDebugTokenResponse DebugToken() {
            return Methods.DebugToken();
        }

        /// <summary>
        /// Gets debug information about the specified access token.
        /// </summary>
        /// <param name="accessToken">The access token to debug.</param>
        [Obsolete("Use Methods.DebugToken() instead")]
        public FacebookDebugTokenResponse DebugToken(string accessToken) {
            return Methods.DebugToken(accessToken);
        }

        #endregion

        #region Me

        /// <summary>
        /// Gets information about the current user by calling the <var>/me</var> method. This call requires a user access token.
        /// </summary>
        /// <returns>The raw JSON response from the API.</returns>
        [Obsolete("Use Client.Methods.Me() or Methods.Raw.Me() instead.")]
        public string GetMeAsRawJson() {
            return Methods.Raw.Me();
        }
        
        /// <summary>
        /// Gets information about the current user by calling the <var>/me</var> method. This call requires a user access token.
        /// </summary>
        [Obsolete("Use Methods.Me() instead")]
        public FacebookMeResponse Me() {
            return Methods.Me();
        }

        #endregion

        #region App

        /// <summary>
        /// Gets information about the specified app.
        /// </summary>
        /// <returns>The raw JSON response from the API.</returns>
        [Obsolete("Use Client.Methods.GetApp() or Methods.Raw.GetApp() instead.")]
        public string GetAppAsRawJson(string identifier = "app") {
            return Methods.Raw.GetApp(identifier);
        }

        /// <summary>
        /// Gets information about an application with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the application.</param>
        [Obsolete("Use Methods.GetApp() instead")]
        public FacebookAppResponse GetApp(long id) {
            return Methods.GetApp(id);
        }

        /// <summary>
        /// Gets information about the current app by calling the
        /// <var>/app</var> method. This requires an app access token.
        /// </summary>
        [Obsolete("Use Methods.GetApp() instead")]
        public FacebookAppResponse GetApp() {
            return Methods.GetApp();
        }

        #endregion

        #region Events

        /// <summary>
        /// Gets the events of the specified user or page.
        /// </summary>
        /// <param name="identifier">The ID or name of the user/page.</param>
        /// <param name="limit">The maximum amount of events to return.</param>
        /// <returns>The raw JSON response from the API.</returns>
        [Obsolete("Use Client.Methods.GetEvents() or Methods.Raw.GetEvents() instead.")]
        public string GetEventsAsRawJson(string identifier, int limit = 0) {
            return Methods.Raw.GetEvents(identifier, limit);
        }

        /// <summary>
        /// Gets the events of the specified user or page.
        /// </summary>
        /// <param name="id">The ID of the user/page.</param>
        /// <param name="limit">The maximum amount of events to return.</param>
        [Obsolete("Use Client.Methods.GetEvents() or Methods.Raw.GetEvents() instead.")]
        public FacebookEventsResponse GetEvents(long id, int limit = 0) {
            return Methods.GetEvents(id + "", limit);
        }

        /// <summary>
        /// Gets the events of the specified user or page.
        /// </summary>
        /// <param name="name">The name of the user/page.</param>
        /// <param name="limit">The maximum amount of events to return.</param>
        [Obsolete("Use Methods.GetEvents() instead.")]
        public FacebookEventsResponse GetEvents(string name, int limit = 0) {
            return Methods.GetEvents(name, limit);
        }

        #endregion

        #region Feed

        /// <summary>
        /// Gets the feed of the specified user or page.
        /// </summary>
        /// <param name="identifier">The ID or name of the user/page.</param>
        /// <param name="limit">The maximum amount of entries to return.</param>
        /// <returns>The raw JSON response from the API.</returns>
        [Obsolete("Use Client.Methods.GetFeed() or Methods.Raw.GetFeed() instead.")]
        public string GetFeedAsRawJson(string identifier, int limit = 0) {
            return Client.Methods.GetFeed(identifier, limit);
        }

        /// <summary>
        /// Gets the feed of the specified user or page.
        /// </summary>
        /// <param name="id">The ID of the user/page.</param>
        /// <param name="limit">The maximum amount of entries to return.</param>
        [Obsolete("Use Client.Methods.GetFeed() or Methods.Raw.GetFeed() instead.")]
        public FacebookFeedResponse GetFeed(long id, int limit = 0) {
            return Methods.GetFeed(id + "", limit);
        }

        /// <summary>
        /// Gets the feed of the specified user or page.
        /// </summary>
        /// <param name="name">The name of the user/page.</param>
        /// <param name="limit">The maximum amount of entries to return.</param>
        [Obsolete("Use Methods.GetFeed() instead.")]
        public FacebookFeedResponse GetFeed(string name, int limit = 0) {
            return Methods.GetFeed(name, limit);
        }

        #endregion

        #region Photos

        /// <summary>
        /// Gets the photos of the specified album, page or user.
        /// </summary>
        /// <param name="identifier">The ID or name.</param>
        /// <param name="limit">The maximum amount of photos to return.</param>
        /// <returns>The raw JSON response from the API.</returns>
        [Obsolete("Use Client.Methods.GetPhotos() or Methods.Raw.GetPhotos() instead.")]
        public string GetPhotosAsRawJson(string identifier, int limit = 0) {
            return Client.Methods.GetPhotos(identifier, limit);
        }

        /// <summary>
        /// Gets the photos of the specified album, page or user.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <param name="limit">The maximum amount of photos to return.</param>
        [Obsolete("Use Methods.GetPhotos() instead.")]
        public FacebookPhotosResponse GetPhotos(long id, int limit = 0) {
            return GetPhotos(id + "", limit);
        }

        [Obsolete("Use Methods.GetPhotos() instead.")]
        public FacebookPhotosResponse GetPhotos(string name, int limit) {
            return FacebookPhotosResponse.ParseJson(Client.Methods.GetPhotos(name, limit));
        }

        #endregion

        #region Posts

        /// <summary>
        /// Gets the posts by the specified user or page.
        /// </summary>
        /// <param name="identifier">The ID or name of the user/page.</param>
        /// <param name="limit">The maximum amount of posts to return.</param>
        /// <returns>The raw JSON response from the API.</returns>
        [Obsolete("Use Client.Methods.GetPosts() or Methods.Raw.GetPosts() instead.")]
        public string GetPostsAsRawJson(string identifier, int limit = 0) {
            return Client.Methods.GetPosts(identifier, limit);
        }

        /// <summary>
        /// Gets the posts by the specified user or page.
        /// </summary>
        /// <param name="id">The ID of the user/page.</param>
        /// <param name="limit">The maximum amount of posts to return.</param>
        [Obsolete("Use Methods.GetPosts() instead.")]
        public FacebookPostsResponse GetPosts(long id, int limit = 0) {
            return Methods.GetPosts(id, limit);
        }

        /// <summary>
        /// Gets the posts by the specified user or page.
        /// </summary>
        /// <param name="name">The name of the user/page.</param>
        /// <param name="limit">The maximum amount of posts to return.</param>
        [Obsolete("Use Methods.GetPosts() instead.")]
        public FacebookPostsResponse GetPosts(string name, int limit = 0) {
            return Methods.GetPosts(name, limit);
        }

        #endregion

        #endregion

    }

}
