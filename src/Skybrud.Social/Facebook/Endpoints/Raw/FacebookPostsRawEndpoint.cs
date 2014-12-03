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
            return Client.DoAuthenticatedGetRequest("/" + id);
        }
        
        /// <summary>
        /// Gets the posts of the specified page or user.
        /// </summary>
        /// <param name="identifier">The identifier (ID or name) of the page or user.</param>
        /// <param name="options">The options for the call to the API.</param>
        public SocialHttpResponse GetPosts(string identifier, FacebookPostsOptions options) {
            return Client.DoAuthenticatedGetRequest("/" + identifier + "/posts", options);
        }

        #endregion

    }

}
