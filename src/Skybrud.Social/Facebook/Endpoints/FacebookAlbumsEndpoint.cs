using System;
using Skybrud.Social.Facebook.Endpoints.Raw;
using Skybrud.Social.Facebook.Options.Albums;
using Skybrud.Social.Facebook.Responses.Albums;

namespace Skybrud.Social.Facebook.Endpoints {

    /// <summary>
    /// Class representing the implementation of the albums endpoint.
    /// </summary>
    public class FacebookAlbumsEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Facebook service.
        /// </summary>
        public FacebookService Service { get; private set; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
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
        public FacebookAlbumResponse GetAlbum(string id) {
            return FacebookAlbumResponse.ParseResponse(Raw.GetAlbum(id));
        }
        
        /// <summary>
        /// Gets information about the album matching the specified <code>options</code>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        public FacebookAlbumResponse GetAlbum(FacebookGetAlbumOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            return FacebookAlbumResponse.ParseResponse(Raw.GetAlbum(options));
        }

        /// <summary>
        /// Gets a list of albums of the user or page with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The ID or name of the page or user.</param>
        public FacebookAlbumsResponse GetAlbums(string identifier) {
            return GetAlbums(new FacebookGetAlbumsOptions(identifier));
        }

        /// <summary>
        /// Gets a list of albums of the user or page with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The ID or name of the page or user.</param>
        /// <param name="limit">The maximum amount of albums to return.</param>
        public FacebookAlbumsResponse GetAlbums(string identifier, int limit) {
            return GetAlbums(new FacebookGetAlbumsOptions {
                Identifier = identifier,
                Limit = limit
            });
        }

        /// <summary>
        /// Gets a list of albums of the user or page matching the specified <code>options</code>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        public FacebookAlbumsResponse GetAlbums(FacebookGetAlbumsOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            return FacebookAlbumsResponse.ParseResponse(Raw.GetAlbums(options));
        }

        /// <summary>
        /// Gets a list of albums of the user or page with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The ID or name of the page or user.</param>
        /// <param name="options">The options for the call to the API.</param>
        [Obsolete("Use method overload instead.")]
        public FacebookAlbumsResponse GetAlbums(string identifier, FacebookAlbumsOptions options) {
            return FacebookAlbumsResponse.ParseResponse(Raw.GetAlbums(identifier, options));
        }

        /// <summary>
        /// Creates a new album for the page or user with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The identifier (ID or name) of the page or user.</param>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>Returns the ID of the created album.</returns>
        [Obsolete("Use method overload instead.")]
        public FacebookPostAlbumResponse PostAlbum(string identifier, FacebookPostAlbumOptions options) {
            return FacebookPostAlbumResponse.ParseResponse(Raw.PostAlbum(identifier, options));
        }

        /// <summary>
        /// Creates a new album for the page or user matching the specified <code>options</code>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        public FacebookPostAlbumResponse PostAlbum(FacebookPostAlbumOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            return FacebookPostAlbumResponse.ParseResponse(Raw.PostAlbum(options));
        }

        #endregion

    }

}