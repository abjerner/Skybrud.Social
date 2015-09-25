using System;
using Skybrud.Social.Facebook.OAuth;
using Skybrud.Social.Facebook.Options.Posts;
using Skybrud.Social.Http;

namespace Skybrud.Social.Facebook.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw implementation of the posts endpoint.
    /// </summary>
    public class FacebookPostsRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference of the OAuth client.
        /// </summary>
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
        /// Gets information about the post matching the specified <code>options</code>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        public SocialHttpResponse GetPost(FacebookGetPostOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            return Client.DoAuthenticatedGetRequest("/" + options.Identifier, options);
        }

        /// <summary>
        /// Gets a list of posts of the user or page with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The identifier (ID or name) of the page or user.</param>
        /// <param name="options">The options for the call to the API.</param>
        [Obsolete("Use method overload.")]
        public SocialHttpResponse GetPosts(string identifier, FacebookPostsOptions options) {
            // TODO: Remove in v1.0
            return Client.DoAuthenticatedGetRequest("/" + identifier + "/posts", options);
        }

        /// <summary>
        /// Gets a list of posts of the user or page matching the specified <code>options</code>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        public SocialHttpResponse GetPosts(FacebookGetPostsOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            return Client.DoAuthenticatedGetRequest("/" + options.Identifier + "/posts", options);
        }

        #endregion

    }

}