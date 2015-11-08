using System;
using Skybrud.Social.Facebook.Endpoints.Raw;
using Skybrud.Social.Facebook.Options.Comments;
using Skybrud.Social.Facebook.Responses.Comments;

namespace Skybrud.Social.Facebook.Endpoints {

    /// <summary>
    /// Class representing the implementation of the comments endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://developers.facebook.com/docs/graph-api/reference/v2.5/object/comments</cref>
    /// </see>
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
        /// Gets information about the comment with specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The identifier (ID) of the comment.</param>
        public FacebookCommentResponse GetComment(string identifier) {
            return FacebookCommentResponse.ParseResponse(Raw.GetComment(identifier));
        }

        /// <summary>
        /// Gets information about the comment matching the specified <code>options</code>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        public FacebookCommentResponse GetComment(FacebookGetCommentOptions options) {
            return FacebookCommentResponse.ParseResponse(Raw.GetComment(options));
        }
        
        /// <summary>
        /// Gets a list of comments for an object with the specified <code>id</code>.
        /// </summary>
        /// <param name="id">The ID of the object.</param>
        /// <param name="options">The options for the call to the API.</param>
        [Obsolete("Use method overload instead.")]
        public FacebookCommentsResponse GetComments(string id, FacebookCommentsOptions options) {
            return FacebookCommentsResponse.ParseResponse(Raw.GetComments(id, options));
        }

        /// <summary>
        /// Gets a list of comments for an object with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The identifier of the parent object.</param>
        public FacebookCommentsResponse GetComments(string identifier) {
            return FacebookCommentsResponse.ParseResponse(Raw.GetComments(identifier));
        }

        /// <summary>
        /// Gets a list of comments for an object with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The identifier of the parent object.</param>
        /// <param name="limit">The maximum amount of comments to be returned per page.</param>
        public FacebookCommentsResponse GetComments(string identifier, int limit) {
            return FacebookCommentsResponse.ParseResponse(Raw.GetComments(identifier, limit));
        }

        /// <summary>
        /// Gets a list of comments for an object matching the specified <code>options</code>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        public FacebookCommentsResponse GetComments(FacebookGetCommentsOptions options) {
            if (options == null) throw new ArgumentException("options");
            return FacebookCommentsResponse.ParseResponse(Raw.GetComments(options));
        }

        #endregion

    }

}