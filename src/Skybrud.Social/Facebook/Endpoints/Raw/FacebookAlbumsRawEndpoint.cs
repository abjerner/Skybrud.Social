using Skybrud.Social.Facebook.OAuth;
using Skybrud.Social.Facebook.Options;
using Skybrud.Social.Http;

namespace Skybrud.Social.Facebook.Endpoints.Raw {
    
    public class FacebookAlbumsRawEndpoint {

        #region Properties

        public FacebookOAuthClient Client { get; private set; }

        #endregion

        #region Constructor

        internal FacebookAlbumsRawEndpoint(FacebookOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about the album with the specified <code>id</code>
        /// </summary>
        /// <param name="id">The ID of the album.</param>
        public SocialHttpResponse GetAlbum(string id) {
            return Client.DoAuthenticatedGetRequest("/" + id);
        }

        /// <summary>
        /// Gets the albums of the specified page or user.
        /// </summary>
        /// <param name="identifier">The identifier (ID or name) of the page or user.</param>
        /// <param name="options">The options for the call to the API.</param>
        public SocialHttpResponse GetAlbums(string identifier, FacebookAlbumsOptions options) {
            return Client.DoAuthenticatedGetRequest("/" + identifier + "/albums", options);
        }

        #endregion

    }

}