using Skybrud.Social.Facebook.Endpoints.Raw;
using Skybrud.Social.Facebook.Options.Comments;
using Skybrud.Social.Facebook.Responses.Comments;

namespace Skybrud.Social.Facebook.Endpoints {
    
    public class FacebookCommentsEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Facebook service.
        /// </summary>
        public FacebookService Service { get; private set; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public FacebookCommentsRawEndpoint Raw {
            get { return Service.Client.Comments; }
        }

        #endregion

        #region Constructors

        internal FacebookCommentsEndpoint(FacebookService service) {
            Service = service;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about the comment with specified <code>id</code>.
        /// </summary>
        /// <param name="id">The ID of the comment.</param>
        public FacebookCommentResponse GetComment(string id) {
            return FacebookCommentResponse.ParseResponse(Raw.GetComment(id));
        }

        /// <summary>
        /// Gets a list of comments for an object with the specified <code>id</code>.
        /// </summary>
        /// <param name="id">The ID of the object.</param>
        public FacebookCommentsResponse GetComments(string id) {
            return GetComments(id, new FacebookCommentsOptions());
        }

        /// <summary>
        /// Gets a list of comments for an object with the specified <code>id</code>.
        /// </summary>
        /// <param name="id">The ID of the object.</param>
        /// <param name="limit">The maximum amount of comments to return.</param>
        public FacebookCommentsResponse GetComments(string id, int limit) {
            return GetComments(id, new FacebookCommentsOptions {
                Limit = limit
            });
        }

        /// <summary>
        /// Gets a list of comments for an object with the specified <code>id</code>.
        /// </summary>
        /// <param name="id">The ID of the object.</param>
        /// <param name="options">The options for the call to the API.</param>
        /// <see>
        ///     <cref>https://developers.facebook.com/docs/graph-api/reference/v2.2/object/comments#read</cref>
        /// </see>
        public FacebookCommentsResponse GetComments(string id, FacebookCommentsOptions options) {
            return FacebookCommentsResponse.ParseResponse(Raw.GetComments(id, options));
        }

        #endregion

    }

}