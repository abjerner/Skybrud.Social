using System;
using Skybrud.Social.Facebook.OAuth;
using Skybrud.Social.Facebook.Options.Feed;
using Skybrud.Social.Http;

namespace Skybrud.Social.Facebook.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw implementation of the feed endpoint.
    /// </summary>
    public class FacebookFeedRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference of the OAuth client.
        /// </summary>
        public FacebookOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal FacebookFeedRawEndpoint(FacebookOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets a list of entries from the feed of the user or page with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The ID or name of the user/page.</param>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>The raw JSON response from the API.</returns>
        [Obsolete("Use method overload.")]
        public SocialHttpResponse GetFeed(string identifier, FacebookFeedOptions options) {
            // TODO: Remove in v1.0
            return Client.DoAuthenticatedGetRequest("/" + identifier + "/feed", options);
        }
        
        /// <summary>
        /// Gets a list of entries from the feed of the user or page matching the specified <code>options</code>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        public SocialHttpResponse GetFeed(FacebookGetFeedOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            return Client.DoAuthenticatedGetRequest("/" + options.Identifier + "/feed", options);
        }

        #endregion

    }

}