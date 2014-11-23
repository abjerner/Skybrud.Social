using Skybrud.Social.Facebook.OAuth;
using Skybrud.Social.Facebook.Options;
using Skybrud.Social.Http;

namespace Skybrud.Social.Facebook.Endpoints.Raw {
    
    public class FacebookCommentsRawEndpoint {

        #region Properties

        public FacebookOAuthClient Client { get; private set; }

        #endregion

        #region Constructor

        internal FacebookCommentsRawEndpoint(FacebookOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about a comment with specified <code>id</code>.
        /// </summary>
        /// <param name="id">The ID of the comment.</param>
        public SocialHttpResponse GetComment(string id) {
            return Client.DoAuthenticatedGetRequest("https://graph.facebook.com/v1.0/" + id);
        }

        /// <summary>
        /// Gets a list of all comments for an object with the specified <code>id</code>.
        /// </summary>
        /// <param name="id">The ID of the object.</param>
        /// <param name="options">The options for the call to the API.</param>
        /// <see>
        ///     <cref>https://developers.facebook.com/docs/graph-api/reference/v2.2/object/comments#read</cref>
        /// </see>
        public SocialHttpResponse GetComments(string id, FacebookCommentsOptions options) {
            return Client.DoAuthenticatedGetRequest("https://graph.facebook.com/v1.0/" + id + "/comments", options);
        }

        #endregion

    }

}