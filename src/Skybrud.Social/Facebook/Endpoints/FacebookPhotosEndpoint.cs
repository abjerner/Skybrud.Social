using Skybrud.Social.Facebook.Endpoints.Raw;
using Skybrud.Social.Facebook.Options;
using Skybrud.Social.Facebook.Responses;

namespace Skybrud.Social.Facebook.Endpoints {
    
    public class FacebookPhotosEndpoint {

        /// <summary>
        /// A reference to the Facebook service.
        /// </summary>
        public FacebookService Service { get; private set; }

        /// <summary>
        /// A reference to the raw endpoint.
        /// </summary>
        public FacebookPhotosRawEndpoint Raw {
            get { return Service.Client.Photos; }
        }

        internal FacebookPhotosEndpoint(FacebookService service) {
            Service = service;
        }

        #region Methods

        /// <summary>
        /// Gets the photos of the specified album, page or user.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <param name="limit">The maximum amount of photos to return.</param>
        public FacebookPhotosResponse GetPhotos(long id, int limit = 0) {
            return GetPhotos(id + "", limit);
        }
        
        /// <summary>
        /// Gets the photos of the specified album, page or user.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <param name="options">The options for the call to the API.</param>
        public FacebookPhotosResponse GetPhotos(long id, FacebookPhotosOptions options) {
            return GetPhotos(id + "", options);
        }
        
        /// <summary>
        /// Gets the photos of the specified album, page or user.
        /// </summary>
        /// <param name="identifier">The ID or name of the album, page or user.</param>
        /// <param name="limit">The maximum amount of photos to return.</param>
        public FacebookPhotosResponse GetPhotos(string identifier, int limit = 0) {
            return GetPhotos(identifier, new FacebookPhotosOptions {
                Limit = limit
            });
        }
        
        /// <summary>
        /// Gets the photos of the specified album, page or user.
        /// </summary>
        /// <param name="identifier">The ID or name of the album, page or user.</param>
        /// <param name="options">The options for the call to the API.</param>
        public FacebookPhotosResponse GetPhotos(string identifier, FacebookPhotosOptions options) {
            return FacebookPhotosResponse.ParseJson(Raw.GetPhotos(identifier, options));
        }

        #endregion

    }

}
