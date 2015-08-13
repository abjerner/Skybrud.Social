using System;
using Skybrud.Social.Facebook.Endpoints.Raw;
using Skybrud.Social.Facebook.Options.Photos;
using Skybrud.Social.Facebook.Responses.Photos;

namespace Skybrud.Social.Facebook.Endpoints {

    /// <summary>
    /// Class representing the implementation of the photos endpoint.
    /// </summary>
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
        /// Gets information about the photo matching the specified <code>options</code>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        public FacebookPhotoResponse GetPhoto(FacebookGetPhotoOptions options) {
            return FacebookPhotoResponse.ParseResponse(Raw.GetPhoto(options));
        }

        /// <summary>
        /// Gets a list of photos of the album, user or page with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The ID or name of the album, page or user.</param>
        public FacebookPhotosResponse GetPhotos(string identifier) {
            return GetPhotos(new FacebookGetPhotosOptions(identifier));
        }

        /// <summary>
        /// Gets a list of photos of the album, user or page with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The ID or name of the album, page or user.</param>
        /// <param name="limit">The maximum amount of photos to return.</param>
        public FacebookPhotosResponse GetPhotos(string identifier, int limit) {
            return GetPhotos(new FacebookGetPhotosOptions {
                Identifier = identifier,
                Limit = limit
            });
        }

        /// <summary>
        /// Gets a list of photos of the album, user or page with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The ID or name of the album, page or user.</param>
        /// <param name="options">The options for the call to the API.</param>
        [Obsolete("Use method overload instead.")]
        public FacebookPhotosResponse GetPhotos(string identifier, FacebookPhotosOptions options) {
            return FacebookPhotosResponse.ParseResponse(Raw.GetPhotos(identifier, options));
        }
        
        /// <summary>
        /// Gets a list of photos of the album, user or page matching the specified <code>options</code>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        public FacebookPhotosResponse GetPhotos(FacebookGetPhotosOptions options) {
            return FacebookPhotosResponse.ParseResponse(Raw.GetPhotos(options));
        }

        /// <summary>
        /// Posts a new photo to the feed of the user with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The ID of the user.</param>
        /// <param name="options">The options for the call to the API.</param>
        [Obsolete("Use method overload instead.")]
        public FacebookPostPhotoResponse PostPhoto(string identifier, FacebookPostUserPhotoOptions options) {
            return FacebookPostPhotoResponse.ParseResponse(Raw.PostPhoto(identifier, options));
        }

        /// <summary>
        /// Posts a new photo to the feed of the user with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        public FacebookPostPhotoResponse PostPhoto(FacebookPostUserPhotoOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            return FacebookPostPhotoResponse.ParseResponse(Raw.PostPhoto(options));
        }

        #endregion

    }

}