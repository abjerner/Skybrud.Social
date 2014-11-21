using Skybrud.Social.Facebook.Collections;
using Skybrud.Social.Facebook.Endpoints.Raw;
using Skybrud.Social.Facebook.Objects;
using Skybrud.Social.Facebook.Options;
using Skybrud.Social.Facebook.Responses;

namespace Skybrud.Social.Facebook.Endpoints {
    
    public class FacebookPostsEndpoint {

        /// <summary>
        /// A reference to the Facebook service.
        /// </summary>
        public FacebookService Service { get; private set; }

        /// <summary>
        /// A reference to the raw endpoint.
        /// </summary>
        public FacebookPostsRawEndpoint Raw {
            get { return Service.Client.Posts; }
        }

        internal FacebookPostsEndpoint(FacebookService service) {
            Service = service;
        }

        #region Methods

        /// <summary>
        /// Gets information about a photo with the specified <code>id</code>.
        /// </summary>
        /// <param name="id">The ID of the photo.</param>
        public FacebookResponse<FacebookPost> GetPost(string id) {
            return FacebookHelpers.ParseResponse(Raw.GetPost(id), FacebookPost.Parse);
        }

        /// <summary>
        /// Gets the posts of the specified page or user.
        /// </summary>
        /// <param name="identifier">The identifier of the page or user.</param>
        /// <param name="limit">The maximum amount of photos to return.</param>
        public FacebookResponse<FacebookPostsCollection> GetPosts(long identifier, int limit = 0) {
            return GetPosts(identifier + "", limit);
        }
        
        /// <summary>
        /// Gets the photos of the specified page or user.
        /// </summary>
        /// <param name="identifier">The identifier of the page or user.</param>
        /// <param name="options">The options for the call to the API.</param>
        public FacebookResponse<FacebookPostsCollection> GetPosts(long identifier, FacebookPostsOptions options) {
            return GetPosts(identifier + "", options);
        }
        
        /// <summary>
        /// Gets the photos of the specified page or user.
        /// </summary>
        /// <param name="identifier">The identifier (ID or name) of the page or user.</param>
        /// <param name="limit">The maximum amount of photos to return.</param>
        public FacebookResponse<FacebookPostsCollection> GetPosts(string identifier, int limit = 0) {
            return GetPosts(identifier, new FacebookPostsOptions {
                Limit = limit
            });
        }
        
        /// <summary>
        /// Gets the photos of the specified album, page or user.
        /// </summary>
        /// <param name="identifier">The identifier (ID or name) of the page or user.</param>
        /// <param name="options">The options for the call to the API.</param>
        public FacebookResponse<FacebookPostsCollection> GetPosts(string identifier, FacebookPostsOptions options) {
            return FacebookHelpers.ParseResponse(Raw.GetPosts(identifier, options), FacebookPostsCollection.Parse);
        }

        #endregion

    }

}
