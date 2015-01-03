using Skybrud.Social.Facebook.OAuth;
using Skybrud.Social.Facebook.Options;
using Skybrud.Social.Facebook.Options.Likes;
using Skybrud.Social.Http;

namespace Skybrud.Social.Facebook.Endpoints.Raw {
    
    public class FacebookLikesRawEndpoint {

        #region Properties

        public FacebookOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal FacebookLikesRawEndpoint(FacebookOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets a list of likes for an object with the specified <code>id</code>.
        /// </summary>
        /// <param name="id">The ID of the object.</param>
        /// <param name="options">The options for the call to the API.</param>
        /// <see>
        ///     <cref>https://developers.facebook.com/docs/graph-api/reference/v2.2/object/likes#read</cref>
        /// </see>
        public SocialHttpResponse GetLikes(string id, FacebookLikesOptions options) {
            return Client.DoAuthenticatedGetRequest("/" + id + "/likes", options);
        }

        #endregion

    }

}