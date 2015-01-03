using Skybrud.Social.Facebook.Endpoints.Raw;
using Skybrud.Social.Facebook.Options.Photos;
using Skybrud.Social.Facebook.Responses.Photos;

namespace Skybrud.Social.Facebook.Endpoints {
    
    public class FacebookPhotosEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Facebook service.
        /// </summary>
        public FacebookService Service { get; private set; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public FacebookPhotosRawEndpoint Raw {
            get { return Service.Client.Photos; }
        }

        #endregion

        #region Constructors

        internal FacebookPhotosEndpoint(FacebookService service) {
            Service = service;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about the photo with the specified <code>id</code>.
        /// </summary>
        /// <param name="id">The ID of the photo.</param>
        public FacebookPhotoResponse GetPhoto(string id) {
            return FacebookPhotoResponse.ParseResponse(Raw.GetPhoto(id));
        }

        /// <summary>
        /// Gets a list of photos of the album, user or page with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The ID or name of the album, page or user.</param>
        public FacebookPhotosResponse GetPhotos(string identifier) {
            return GetPhotos(identifier, new FacebookPhotosOptions());
        }

        /// <summary>
        /// Gets a list of photos of the album, user or page with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The ID or name of the album, page or user.</param>
        /// <param name="limit">The maximum amount of photos to return.</param>
        public FacebookPhotosResponse GetPhotos(string identifier, int limit) {
            return GetPhotos(identifier, new FacebookPhotosOptions {
                Limit = limit
            });
        }

        /// <summary>
        /// Gets a list of photos of the album, user or page with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The ID or name of the album, page or user.</param>
        /// <param name="options">The options for the call to the API.</param>
        public FacebookPhotosResponse GetPhotos(string identifier, FacebookPhotosOptions options) {
            return FacebookPhotosResponse.ParseResponse(Raw.GetPhotos(identifier, options));
        }

        /// <summary>
        /// Posts a new photo to the feed of the user with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The ID of the user.</param>
        /// <param name="options">The options for the call to the API.</param>
        public FacebookPostPhotoResponse PostPhoto(string identifier, FacebookPostUserPhotoOptions options) {
            return FacebookPostPhotoResponse.ParseResponse(Raw.PostPhoto(identifier, options));
        }

        #endregion

    }

}