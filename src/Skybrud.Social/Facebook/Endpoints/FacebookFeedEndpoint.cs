using Skybrud.Social.Facebook.Collections;
using Skybrud.Social.Facebook.Endpoints.Raw;
using Skybrud.Social.Facebook.Options;
using Skybrud.Social.Facebook.Responses;

namespace Skybrud.Social.Facebook.Endpoints {
    
    public class FacebookFeedEndpoint {

        #region Properties

        /// <summary>
        /// A reference to the Facebook service.
        /// </summary>
        public FacebookService Service { get; private set; }

        /// <summary>
        /// A reference to the raw endpoint.
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
        /// Gets the events of the specified user or page.
        /// </summary>
        /// <param name="identifier">The ID or name of the user/page.</param>
        public FacebookResponse<FacebookFeedCollection> GetEvents(string identifier) {
            return GetEvents(identifier, new FacebookFeedOptions());
        }

        /// <summary>
        /// Gets the events of the specified user or page.
        /// </summary>
        /// <param name="identifier">The ID or name of the user/page.</param>
        /// <param name="limit">The maximum amount of events to return.</param>
        public FacebookResponse<FacebookFeedCollection> GetEvents(string identifier, int limit) {
            return GetEvents(identifier, new FacebookFeedOptions {
                Limit = limit
            });
        }

        /// <summary>
        /// Gets the events of the specified user or page.
        /// </summary>
        /// <param name="identifier">The ID or name of the user/page.</param>
        /// <param name="options">The options for the call to the API.</param>
        public FacebookResponse<FacebookFeedCollection> GetEvents(string identifier, FacebookFeedOptions options) {
            return FacebookHelpers.ParseResponse(Raw.GetFeed(identifier, options), FacebookFeedCollection.Parse);
        }

        #endregion

    }

}
