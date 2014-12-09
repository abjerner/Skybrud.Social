using Skybrud.Social.Facebook.OAuth;
using Skybrud.Social.Facebook.Options;
using Skybrud.Social.Http;

namespace Skybrud.Social.Facebook.Endpoints.Raw {
    
    public class FacebookFeedRawEndpoint {

        #region Properties

        public FacebookOAuthClient Client { get; private set; }

        #endregion

        #region Constructor

        internal FacebookFeedRawEndpoint(FacebookOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the feed of the specified user or page.
        /// </summary>
        /// <param name="identifier">The ID or name of the user/page.</param>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>The raw JSON response from the API.</returns>
        public SocialHttpResponse GetFeed(string identifier, FacebookFeedOptions options) {

            // Declare the query string
            SocialQueryString query = new SocialQueryString();
            if (options != null && options.Limit > 0) query.Set("limit", options.Limit);
            if (options != null && options.Since > 0) query.Set("since", options.Since);
            if (options != null && options.Until > 0) query.Set("until", options.Until);

            // Make the call to the API
            return Client.DoAuthenticatedGetRequest("/" + identifier + "/feed", query);

        }

        #endregion

    }

}