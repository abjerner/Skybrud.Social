using Skybrud.Social.Facebook.Collections;
using Skybrud.Social.Facebook.Endpoints.Raw;
using Skybrud.Social.Facebook.Objects;
using Skybrud.Social.Facebook.Options;
using Skybrud.Social.Facebook.Responses;

namespace Skybrud.Social.Facebook.Endpoints {
    
    public class FacebookCommentsEndpoint {

        /// <summary>
        /// A reference to the Facebook service.
        /// </summary>
        public FacebookService Service { get; private set; }

        /// <summary>
        /// A reference to the raw endpoint.
        /// </summary>
        public FacebookCommentsRawEndpoint Raw {
            get { return Service.Client.Comments; }
        }

        internal FacebookCommentsEndpoint(FacebookService service) {
            Service = service;
        }

        #region Methods

        /// <summary>
        /// Gets information about a comment with specified <code>id</code>.
        /// </summary>
        /// <param name="id">The ID of the comment.</param>
        public FacebookResponse<FacebookComment> GetComment(string id) {
            return FacebookHelpers.ParseResponse(Raw.GetComment(id), FacebookComment.Parse);
        }

        /// <summary>
        /// Gets a list of all comments for an object with the specified <code>id</code>.
        /// </summary>
        /// <param name="id">The ID of the object.</param>
        public FacebookResponse<FacebookCommentsCollection> GetComments(string id) {
            return GetComments(id, new FacebookCommentsOptions());
        }

        /// <summary>
        /// Gets a list of all comments for an object with the specified <code>id</code>.
        /// </summary>
        /// <param name="id">The ID of the object.</param>
        /// <param name="limit">The maximum amount of comments to return.</param>
        public FacebookResponse<FacebookCommentsCollection> GetComments(string id, int limit) {
            return GetComments(id, new FacebookCommentsOptions {
                Limit = limit
            });
        }

        /// <summary>
        /// Gets a list of all comments for an object with the specified <code>id</code>.
        /// </summary>
        /// <param name="id">The ID of the object.</param>
        /// <param name="options">The options for the call to the API.</param>
        /// <see>
        ///     <cref>https://developers.facebook.com/docs/graph-api/reference/v2.2/object/comments#read</cref>
        /// </see>
        public FacebookResponse<FacebookCommentsCollection> GetComments(string id, FacebookCommentsOptions options) {
            return FacebookHelpers.ParseResponse(Raw.GetComments(id, options), FacebookCommentsCollection.Parse);
        }

        #endregion

    }

}
