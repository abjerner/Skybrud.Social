using System;
using System.Collections.Specialized;
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
            // make constructor private
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
            FacebookService service =  new FacebookService {
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
            return Methods.Raw.Accounts();
        }

        /// <summary>
        /// Gets information about accounts associated with the current user by calling the <var>/me/accounts</var> method. This call requires a user access token.
        /// </summary>
        [Obsolete("Use Methods.Accounts() instead")]
        public FacebookAccountsResponse Accounts() {
            return Methods.Accounts();
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

        #endregion

        #region App

        /// <summary>
        /// Gets information about the specified app.
        /// </summary>
        /// <returns>The raw JSON response from the API.</returns>
        public string GetAppAsRawJson(string identifier = "app") {
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://graph.facebook.com/" + identifier + "?access_token=" + AccessToken);
        }

        /// <summary>
        /// Gets information about an application with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the application.</param>
        public FacebookAppResponse GetApp(long id) {
            return FacebookAppResponse.ParseJson(GetAppAsRawJson(id + ""));
        }
        
        /// <summary>
        /// Gets information about the specified app by calling the <var>/app</var> method.
        /// </summary>
        public FacebookAppResponse GetApp() {
            return FacebookAppResponse.ParseJson(GetAppAsRawJson("app"));
        }

        #endregion

        #region Events

        /// <summary>
        /// Gets the events of the specified user or page.
        /// </summary>
        /// <param name="identifier">The ID or name of the user/page.</param>
        /// <param name="limit">The maximum amount of events to return.</param>
        /// <returns>The raw JSON response from the API.</returns>
        public string GetEventsAsRawJson(string identifier, int limit = 0) {
            NameValueCollection query = new NameValueCollection { { "access_token", AccessToken } };
            if (limit > 0) query.Add("limit", limit + "");
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://graph.facebook.com/" + identifier + "/events", query);
        }

        /// <summary>
        /// Gets the events of the specified user or page.
        /// </summary>
        /// <param name="id">The ID of the user/page.</param>
        /// <param name="limit">The maximum amount of events to return.</param>
        public FacebookEventsResponse GetEvents(long id, int limit = 0) {
            return GetEvents(id + "", limit);
        }

        /// <summary>
        /// Gets the events of the specified user or page.
        /// </summary>
        /// <param name="name">The name of the user/page.</param>
        /// <param name="limit">The maximum amount of events to return.</param>
        public FacebookEventsResponse GetEvents(string name, int limit = 0) {
            return FacebookEventsResponse.ParseJson(GetEventsAsRawJson(name, limit));
        }

        #endregion

        #region Feed

        /// <summary>
        /// Gets the feed of the specified user or page.
        /// </summary>
        /// <param name="identifier">The ID or name of the user/page.</param>
        /// <param name="limit">The maximum amount of entries to return.</param>
        /// <returns>The raw JSON response from the API.</returns>
        public string GetFeedAsRawJson(string identifier, int limit = 0) {
            NameValueCollection query = new NameValueCollection {{"access_token", AccessToken}};
            if (limit > 0) query.Add("limit", limit + "");
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://graph.facebook.com/" + identifier + "/feed", query);
        }

        /// <summary>
        /// Gets the feed of the specified user or page.
        /// </summary>
        /// <param name="id">The ID of the user/page.</param>
        /// <param name="limit">The maximum amount of entries to return.</param>
        public FacebookFeedResponse GetFeed(long id, int limit = 0) {
            return GetFeed(id + "", limit);
        }

        /// <summary>
        /// Gets the feed of the specified user or page.
        /// </summary>
        /// <param name="name">The name of the user/page.</param>
        /// <param name="limit">The maximum amount of entries to return.</param>
        public FacebookFeedResponse GetFeed(string name, int limit = 0) {
            return FacebookFeedResponse.ParseJson(GetFeedAsRawJson(name, limit));
        }

        #endregion

        #region Photos

        /// <summary>
        /// Gets the photos of the specified album, page or user.
        /// </summary>
        /// <param name="identifier">The ID or name.</param>
        /// <param name="limit">The maximum amount of photos to return.</param>
        /// <returns>The raw JSON response from the API.</returns>
        public string GetPhotosAsRawJson(string identifier, int limit = 0) {
            NameValueCollection query = new NameValueCollection { { "access_token", AccessToken } };
            if (limit > 0) query.Add("limit", limit + "");
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://graph.facebook.com/" + identifier + "/photos", query);
        }

        /// <summary>
        /// Gets the photos of the specified album, page or user.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <param name="limit">The maximum amount of photos to return.</param>
        public FacebookPhotosResponse GetPhotos(long id, int limit = 0) {
            return GetPhotos(id + "", limit);
        }

        public FacebookPhotosResponse GetPhotos(string name, int limit) {
            return FacebookPhotosResponse.ParseJson(GetPhotosAsRawJson(name, limit));
        }

        #endregion

        #region Posts

        /// <summary>
        /// Gets the posts by the specified user or page.
        /// </summary>
        /// <param name="identifier">The ID or name of the user/page.</param>
        /// <param name="limit">The maximum amount of posts to return.</param>
        /// <returns>The raw JSON response from the API.</returns>
        public string GetPostsAsRawJson(string identifier, int limit = 0) {
            NameValueCollection query = new NameValueCollection { { "access_token", AccessToken } };
            if (limit > 0) query.Add("limit", limit + "");
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://graph.facebook.com/" + identifier + "/posts", query);
        }

        /// <summary>
        /// Gets the posts by the specified user or page.
        /// </summary>
        /// <param name="id">The ID of the user/page.</param>
        /// <param name="limit">The maximum amount of posts to return.</param>
        public FacebookPostsResponse GetPosts(long id, int limit = 0) {
            return GetPosts(id + "", limit);
        }

        /// <summary>
        /// Gets the posts by the specified user or page.
        /// </summary>
        /// <param name="name">The name of the user/page.</param>
        /// <param name="limit">The maximum amount of posts to return.</param>
        public FacebookPostsResponse GetPosts(string name, int limit = 0) {
            return FacebookPostsResponse.ParseJson(GetPostsAsRawJson(name, limit));
        }

        #endregion

    }

}
