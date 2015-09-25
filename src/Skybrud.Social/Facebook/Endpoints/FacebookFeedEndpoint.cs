using System;
using Skybrud.Social.Facebook.Endpoints.Raw;
using Skybrud.Social.Facebook.Options.Feed;
using Skybrud.Social.Facebook.Responses.Feed;

namespace Skybrud.Social.Facebook.Endpoints {

    /// <summary>
    /// Class (endpoint) with methods related to the feed of a user or a page.
    /// </summary>
    public class FacebookFeedEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Facebook service.
        /// </summary>
        public FacebookService Service { get; private set; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public FacebookFeedRawEndpoint Raw {
            get { return Service.Client.Feed; }
        }

        #endregion

        #region Constructors

        internal FacebookFeedEndpoint(FacebookService service) {
            Service = service;
        }

        #endregion

        #region Methods
        
        /// <summary>
        /// Gets a list of entries from the feed of the user or page with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The ID or name of the user/page.</param>
        /// <param name="options">The options for the call to the API.</param>
        [Obsolete("Use method overload.")]
        public FacebookFeedResponse GetFeed(string identifier, FacebookFeedOptions options) {
            // TODO: Remove in v1.0
            return FacebookFeedResponse.ParseResponse(Raw.GetFeed(identifier, options));
        }

        /// <summary>
        /// Gets a list of entries from the feed of the user or page with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The ID or name of the user/page.</param>
        public FacebookFeedResponse GetFeed(string identifier) {
            return GetFeed(new FacebookGetFeedOptions(identifier));
        }

        /// <summary>
        /// Gets a list of entries from the feed of the user or page with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The ID or name of the user/page.</param>
        /// <param name="limit">The maximum amount of events to return.</param>
        public FacebookFeedResponse GetFeed(string identifier, int limit) {
            return GetFeed(new FacebookGetFeedOptions(identifier, limit));
        }

        /// <summary>
        /// Gets a list of entries from the feed of the user or page matching the specified <code>options</code>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        public FacebookFeedResponse GetFeed(FacebookGetFeedOptions options) {
            return FacebookFeedResponse.ParseResponse(Raw.GetFeed(options));
        }

        #endregion

    }

}