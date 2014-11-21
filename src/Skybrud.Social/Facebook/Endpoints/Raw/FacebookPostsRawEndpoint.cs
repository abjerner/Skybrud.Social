using Skybrud.Social.Facebook.OAuth;
using Skybrud.Social.Facebook.Options;
using Skybrud.Social.Http;

namespace Skybrud.Social.Facebook.Endpoints.Raw {
    
    public class FacebookPostsRawEndpoint {

        #region Properties

        public FacebookOAuthClient Client { get; private set; }

        #endregion

        #region Constructor

        internal FacebookPostsRawEndpoint(FacebookOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods
        
        /// <summary>
        /// Gets information about a post with the specified <code>id</code>
        /// </summary>
        /// <param name="id">The ID of the photo.</param>
        public SocialHttpResponse GetPost(string id) {
            return Client.DoAuthenticatedGetRequest("https://graph.facebook.com/v1.0/" + id);
        }
        
        /// <summary>
        /// Gets the posts of the specified page or user.
        /// </summary>
        /// <param name="identifier">The identifier (ID or name) of the page or user.</param>
        /// <param name="options">The options for the call to the API.</param>
        public SocialHttpResponse GetPosts(string identifier, FacebookPostsOptions options) {

            // Declare the query string
            SocialQueryString query = new SocialQueryString();
            if (options != null && options.Limit > 0) query.Add("limit", options.Limit);
            if (options != null && options.Since > 0) query.Add("since", options.Since);
            if (options != null && options.Until > 0) query.Add("until", options.Until);

            // Make the call to the API
            return Client.DoAuthenticatedGetRequest("https://graph.facebook.com/v1.0/" + identifier + "/posts", query);

        }

        #endregion

    }

}
