using Skybrud.Social.Facebook.OAuth;
using Skybrud.Social.Facebook.Options;
using Skybrud.Social.Facebook.Options.Feed;
using Skybrud.Social.Http;

namespace Skybrud.Social.Facebook.Endpoints.Raw {
    
    public class FacebookFeedRawEndpoint {

        #region Properties

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
        public SocialHttpResponse GetFeed(string identifier, FacebookFeedOptions options) {
            return Client.DoAuthenticatedGetRequest("/" + identifier + "/feed", options);
        }

        #endregion

    }

}