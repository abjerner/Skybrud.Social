using System;
using Skybrud.Social.Facebook.OAuth;
using Skybrud.Social.Facebook.Options.Comments;
using Skybrud.Social.Http;

namespace Skybrud.Social.Facebook.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw implementation of the comments endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://developers.facebook.com/docs/graph-api/reference/v2.5/object/comments</cref>
    /// </see>
    public class FacebookCommentsRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the OAuth client.
        /// </summary>
        public FacebookOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal FacebookCommentsRawEndpoint(FacebookOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about the comment with specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The identifier (ID) of the comment.</param>
        public SocialHttpResponse GetComment(string identifier) {
            return GetComment(new FacebookGetCommentOptions(identifier));
        }

        /// <summary>
        /// Gets information about the comment matching the specified <code>options</code>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        public SocialHttpResponse GetComment(FacebookGetCommentOptions options) {
            return Client.DoAuthenticatedGetRequest("/" + options.Identifier, options);
        }

        /// <summary>
        /// Gets a list of comments for an object with the specified <code>id</code>.
        /// </summary>
        /// <param name="id">The ID of the object.</param>
        /// <param name="options">The options for the call to the API.</param>
        [Obsolete("Use method overload instead.")]
        public SocialHttpResponse GetComments(string id, FacebookCommentsOptions options) {
            return Client.DoAuthenticatedGetRequest("/" + id + "/comments", options);
        }

        /// <summary>
        /// Gets a list of comments for an object with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The identifier of the parent object.</param>
        public SocialHttpResponse GetComments(string identifier) {
            return GetComments(new FacebookGetCommentsOptions(identifier));
        }

        /// <summary>
        /// Gets a list of comments for an object with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The identifier of the parent object.</param>
        /// <param name="limit">The maximum amount of comments to be returned per page.</param>
        public SocialHttpResponse GetComments(string identifier, int limit) {
            return GetComments(new FacebookGetCommentsOptions(identifier, limit));
        }

        /// <summary>
        /// Gets a list of comments for an object matching the specified <code>options</code>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        public SocialHttpResponse GetComments(FacebookGetCommentsOptions options) {
            if (options == null) throw new ArgumentException("options");
            return Client.DoAuthenticatedGetRequest("/" + options.Identifier + "/comments", options);
        }

        #endregion

    }

}