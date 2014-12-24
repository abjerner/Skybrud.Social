using Skybrud.Social.Facebook.Collections;
using Skybrud.Social.Facebook.Endpoints.Raw;
using Skybrud.Social.Facebook.Objects;
using Skybrud.Social.Facebook.Options;
using Skybrud.Social.Facebook.Responses;

namespace Skybrud.Social.Facebook.Endpoints {
    
    public class FacebookAlbumsEndpoint {

        #region Properties

        /// <summary>
        /// A reference to the Facebook service.
        /// </summary>
        public FacebookService Service { get; private set; }

        /// <summary>
        /// A reference to the raw endpoint.
        /// </summary>
        public FacebookAlbumsRawEndpoint Raw {
            get { return Service.Client.Albums; }
        }

        #endregion

        #region Constructors

        internal FacebookAlbumsEndpoint(FacebookService service) {
            Service = service;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about the album with the specified <code>id</code>.
        /// </summary>
        /// <param name="id">The ID of the album.</param>
        public FacebookResponse<FacebookAlbum> GetLink(string id) {
            return FacebookHelpers.ParseResponse(Raw.GetAlbum(id), FacebookAlbum.Parse);
        }

        /// <summary>
        /// Gets the albums of the specified page or user.
        /// </summary>
        /// <param name="identifier">The ID or name of the page or user.</param>
        public FacebookResponse<FacebookAlbumsCollection> GetLinks(string identifier) {
            return GetLinks(identifier, new FacebookAlbumsOptions());
        }

        /// <summary>
        /// Gets the albums of the specified page or user.
        /// </summary>
        /// <param name="identifier">The ID or name of the page or user.</param>
        /// <param name="limit">The maximum amount of albums to return.</param>
        public FacebookResponse<FacebookAlbumsCollection> GetLinks(string identifier, int limit) {
            return GetLinks(identifier, new FacebookAlbumsOptions {
                Limit = limit
            });
        }

        /// <summary>
        /// Gets the albums of the specified page or user.
        /// </summary>
        /// <param name="identifier">The ID or name of the page or user.</param>
        /// <param name="options">The options for the call to the API.</param>
        public FacebookResponse<FacebookAlbumsCollection> GetLinks(string identifier, FacebookAlbumsOptions options) {
            return FacebookHelpers.ParseResponse(Raw.GetAlbums(identifier, options), FacebookAlbumsCollection.Parse);
        }

        #endregion

    }

}
