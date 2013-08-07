using System;
using System.Collections.Specialized;
using Skybrud.Social.Facebook.Objects;
using Skybrud.Social.Facebook.Responses;

namespace Skybrud.Social.Facebook {

    public class FacebookService {

        public string AccessToken { get; private set; }

        private FacebookService() {
            // make constructor private
        }

        public static FacebookService CreateFromAccessToken(string accessToken) {
            return new FacebookService {
                AccessToken = accessToken
            };
        }

        #region Accounts

        /// <summary>
        /// Gets information about accounts associated with the current user by calling the <var>/me/accounts</var> method. This call requires a user access token.
        /// </summary>
        /// <returns>The raw JSON response from the API.</returns>
        public string GetAccountsAsRawJson() {
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://graph.facebook.com/me/accounts?access_token=" + AccessToken);
        }

        /// <summary>
        /// Gets information about accounts associated with the current user by calling the <var>/me/accounts</var> method. This call requires a user access token.
        /// </summary>
        public FacebookAccountsResponse Accounts() {
            return FacebookAccountsResponse.ParseJson(GetAccountsAsRawJson());
        }

        #endregion

        #region Debug token

        /// <summary>
        /// Gets debug information about the specified access token.
        /// </summary>
        /// <param name="accessToken">The access token to debug.</param>
        /// <returns></returns>
        public string DebugTokenAsRawJson(string accessToken) {
            NameValueCollection query = new NameValueCollection {
                { "input_token", accessToken },
                { "access_token", AccessToken }
            };
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://graph.facebook.com/debug_token", query);
        }

        /// <summary>
        /// Gets debug information about the access token used for accessing the Graph API.
        /// </summary>
        public FacebookDebugTokenResponse DebugToken() {
            return DebugToken(AccessToken);
        }

        /// <summary>
        /// Gets debug information about the specified access token.
        /// </summary>
        /// <param name="accessToken">The access token to debug.</param>
        public FacebookDebugTokenResponse DebugToken(string accessToken) {
            return FacebookDebugTokenResponse.ParseJson(DebugTokenAsRawJson(accessToken));
        }

        #endregion

        #region Me

        /// <summary>
        /// Gets information about the current user by calling the <var>/me</var> method. This call requires a user access token.
        /// </summary>
        /// <returns>The raw JSON response from the API.</returns>
        public string GetMeAsRawJson() {
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://graph.facebook.com/me?access_token=" + AccessToken);
        }
        
        /// <summary>
        /// Gets information about the current user by calling the <var>/me</var> method. This call requires a user access token.
        /// </summary>
        public FacebookMeResponse Me() {
            return FacebookMeResponse.ParseJson(GetMeAsRawJson());
        }

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
