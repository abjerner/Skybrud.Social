using Skybrud.Social.Facebook.Endpoints.Raw;
using Skybrud.Social.Facebook.Options.Feed;
using Skybrud.Social.Facebook.Responses.Feed;

namespace Skybrud.Social.Facebook.Endpoints {
    
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
        public FacebookFeedResponse GetEvents(string identifier) {
            return GetEvents(identifier, new FacebookFeedOptions());
        }

        /// <summary>
        /// Gets a list of entries from the feed of the user or page with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The ID or name of the user/page.</param>
        /// <param name="limit">The maximum amount of events to return.</param>
        public FacebookFeedResponse GetEvents(string identifier, int limit) {
            return GetEvents(identifier, new FacebookFeedOptions {
                Limit = limit
            });
        }

        /// <summary>
        /// Gets a list of entries from the feed of the user or page with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The ID or name of the user/page.</param>
        /// <param name="options">The options for the call to the API.</param>
        public FacebookFeedResponse GetEvents(string identifier, FacebookFeedOptions options) {
            return FacebookFeedResponse.ParseResponse(Raw.GetFeed(identifier, options));
        }

        #endregion

    }

}