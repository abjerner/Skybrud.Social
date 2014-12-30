using Skybrud.Social.Facebook.Collections;
using Skybrud.Social.Facebook.Endpoints.Raw;
using Skybrud.Social.Facebook.Objects;
using Skybrud.Social.Facebook.Options;
using Skybrud.Social.Facebook.Options.Albums;
using Skybrud.Social.Facebook.Responses;
using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Endpoints {
    
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
        public FacebookResponse<FacebookAlbum> GetAlbum(string id) {
            return FacebookHelpers.ParseResponse(Raw.GetAlbum(id), FacebookAlbum.Parse);
        }

        /// <summary>
        /// Gets a list of albums of the user or page with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The ID or name of the page or user.</param>
        public FacebookResponse<FacebookAlbumsCollection> GetAlbums(string identifier) {
            return GetAlbums(identifier, new FacebookAlbumsOptions());
        }

        /// <summary>
        /// Gets a list of albums of the user or page with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The ID or name of the page or user.</param>
        /// <param name="limit">The maximum amount of albums to return.</param>
        public FacebookResponse<FacebookAlbumsCollection> GetAlbums(string identifier, int limit) {
            return GetAlbums(identifier, new FacebookAlbumsOptions {
                Limit = limit
            });
        }

        /// <summary>
        /// Gets a list of albums of the user or page with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The ID or name of the page or user.</param>
        /// <param name="options">The options for the call to the API.</param>
        public FacebookResponse<FacebookAlbumsCollection> GetAlbums(string identifier, FacebookAlbumsOptions options) {
            return FacebookHelpers.ParseResponse(Raw.GetAlbums(identifier, options), FacebookAlbumsCollection.Parse);
        }

        /// <summary>
        /// Creates a new album for the page or user with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The identifier (ID or name) of the page or user.</param>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>Returns the ID of the created album.</returns>
        public string PostAlbum(string identifier, FacebookPostAlbumOptions options) {

            // Make the call to the API
            SocialHttpResponse response = Raw.PostAlbum(identifier, options);

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();

            // Validate the response
            FacebookResponse.ValidateResponse(response, obj);

            // Get the ID of the created link
            return obj.GetString("id");

        }

        #endregion

    }

}