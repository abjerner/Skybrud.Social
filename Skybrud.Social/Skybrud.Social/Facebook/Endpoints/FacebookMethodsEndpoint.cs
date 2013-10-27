using Skybrud.Social.Facebook.Endpoints.Raw;
using Skybrud.Social.Facebook.Objects;
using Skybrud.Social.Facebook.Options;
using Skybrud.Social.Facebook.Responses;

namespace Skybrud.Social.Facebook.Endpoints {
    
    public class FacebookMethodsEndpoint {

        /// <summary>
        /// A reference to the Facebook service.
        /// </summary>
        public FacebookService Service { get; private set; }

        /// <summary>
        /// A reference to the raw endpoint.
        /// </summary>
        public FacebookMethodsRawEndpoint Raw {
            get { return Service.Client.Methods; }
        }

        internal FacebookMethodsEndpoint(FacebookService service) {
            Service = service;
        }

        /// <summary>
        /// Gets information about accounts associated with the current user by calling the <var>/me/accounts</var> method. This call requires a user access token.
        /// </summary>
        public FacebookAccountsResponse Accounts() {
            return FacebookAccountsResponse.ParseJson(Raw.Accounts());
        }

        /// <summary>
        /// Gets information about the specified app.
        /// </summary>
        /// <param name="id">The ID of the app.</param>
        public FacebookAppResponse App(long id) {
            return FacebookAppResponse.ParseJson(Raw.App(id + ""));
        }

        /// <summary>
        /// Gets information about the current app by calling the <var>/app</var> method. This requires an app access token.
        /// </summary>
        public FacebookAppResponse App() {
            return FacebookAppResponse.ParseJson(Raw.App("app"));
        }

        /// <summary>
        /// Gets debug information about the access token used for accessing the Graph API.
        /// </summary>
        public FacebookDebugTokenResponse DebugToken() {
            return DebugToken(Service.Client.AccessToken);
        }

        /// <summary>
        /// Gets debug information about the specified access token.
        /// </summary>
        /// <param name="accessToken">The access token to debug.</param>
        public FacebookDebugTokenResponse DebugToken(string accessToken) {
            return FacebookDebugTokenResponse.ParseJson(Raw.DebugToken(accessToken));
        }

        /// <summary>
        /// Gets the events of the specified user or page.
        /// </summary>
        /// <param name="id">The ID of the user/page.</param>
        /// <param name="limit">The maximum amount of events to return.</param>
        public FacebookEventsResponse GetEvents(long id, int limit = 0) {
            return GetEvents(id + "", limit);
        }

        #region Get feed

        /// <summary>
        /// Gets the events of the specified user or page.
        /// </summary>
        /// <param name="identifier">The ID or name of the user/page.</param>
        /// <param name="limit">The maximum amount of events to return.</param>
        public FacebookEventsResponse GetEvents(string identifier, int limit = 0) {
            return FacebookEventsResponse.ParseJson(Raw.GetFeed(identifier, limit));
        }

        /// <summary>
        /// Gets the feed of the specified user or page.
        /// </summary>
        /// <param name="identifier">The ID of the user/page.</param>
        /// <param name="limit">The maximum amount of entries to return.</param>
        public FacebookFeedResponse GetFeed(long identifier, int limit = 0) {
            return FacebookFeedResponse.ParseJson(Raw.GetFeed(identifier + "", limit));
        }

        /// <summary>
        /// Gets the feed of the specified user or page.
        /// </summary>
        /// <param name="identifier">The ID or name of the user/page.</param>
        /// <param name="limit">The maximum amount of entries to return.</param>
        public FacebookFeedResponse GetFeed(string identifier, int limit = 0) {
            return FacebookFeedResponse.ParseJson(Raw.GetFeed(identifier, limit));
        }

        /// <summary>
        /// Gets the feed of the specified user or page.
        /// </summary>
        /// <param name="identifier">The ID of the user/page.</param>
        /// <param name="options">The options for the call to the API.</param>
        public FacebookFeedResponse GetFeed(long identifier, FacebookFeedOptions options) {
            return FacebookFeedResponse.ParseJson(Raw.GetFeed(identifier + "", options));
        }

        /// <summary>
        /// Gets the feed of the specified user or page.
        /// </summary>
        /// <param name="identifier">The ID or name of the user/page.</param>
        /// <param name="options">The options for the call to the API.</param>
        public FacebookFeedResponse GetFeed(string identifier, FacebookFeedOptions options) {
            return FacebookFeedResponse.ParseJson(Raw.GetFeed(identifier, options));
        }

        /// <summary>
        /// Gets the feed of the specified URL. This method can be used for paging purposes. 
        /// </summary>
        /// <param name="url">The raw URL to call.</param>
        /// <returns>The raw JSON response from the API.</returns>
        public FacebookFeedResponse GetFeedFromUrl(string url) {
            return FacebookFeedResponse.ParseJson(Raw.GetFeedFromUrl(url));
        }

        #endregion

        /// <summary>
        /// Gets information about a user with the specified <var>identifier</var>.
        /// </summary>
        /// <param name="identifier">The ID or username of the user.</param>
        public FacebookUser GetUser(long identifier) {
            return GetUser(identifier + "");
        }

        /// <summary>
        /// Gets information about a user with the specified <var>identifier</var>.
        /// </summary>
        /// <param name="identifier">The ID or username of the user.</param>
        public FacebookUser GetUser(string identifier) {
            return FacebookUser.ParseJson(Raw.GetObject(identifier));
        }

        /// <summary>
        /// Gets information about the current user by calling the <var>/me</var> method. This call requires a user access token.
        /// </summary>
        public FacebookMeResponse Me() {
            return FacebookMeResponse.ParseJson(Raw.GetObject("me"));
        }
    
    }

}
