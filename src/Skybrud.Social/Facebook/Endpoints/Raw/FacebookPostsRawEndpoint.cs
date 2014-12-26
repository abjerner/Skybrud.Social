using Skybrud.Social.Facebook.OAuth;
using Skybrud.Social.Facebook.Options;
using Skybrud.Social.Http;

namespace Skybrud.Social.Facebook.Endpoints.Raw {
    
    public class FacebookPostsRawEndpoint {

        #region Properties

        public FacebookOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal FacebookPostsRawEndpoint(FacebookOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods
        
        /// <summary>
        /// Gets information about the post with the specified <code>postId</code>
        /// </summary>
        /// <param name="postId">The ID of the photo.</param>
        public SocialHttpResponse GetPost(string postId) {
            return Client.DoAuthenticatedGetRequest("/" + postId);
        }

        /// <summary>
        /// Gets a list of posts of the user or page with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The identifier (ID or name) of the page or user.</param>
        /// <param name="options">The options for the call to the API.</param>
        public SocialHttpResponse GetPosts(string identifier, FacebookPostsOptions options) {
            return Client.DoAuthenticatedGetRequest("/" + identifier + "/posts", options);
        }

        #endregion

    }

}