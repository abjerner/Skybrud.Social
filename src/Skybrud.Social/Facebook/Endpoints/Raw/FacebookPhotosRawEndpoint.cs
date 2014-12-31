using Skybrud.Social.Facebook.OAuth;
using Skybrud.Social.Facebook.Options;
using Skybrud.Social.Facebook.Options.Photos;
using Skybrud.Social.Http;

namespace Skybrud.Social.Facebook.Endpoints.Raw {
    
    public class FacebookPhotosRawEndpoint {

        #region Properties

        public FacebookOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal FacebookPhotosRawEndpoint(FacebookOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods
        
        /// <summary>
        /// Gets information about the photo with the specified <code>photoId</code>
        /// </summary>
        /// <param name="photoId">The ID of the photo.</param>
        public SocialHttpResponse GetPhoto(string photoId) {
            return Client.DoAuthenticatedGetRequest("/" + photoId);
        }

        /// <summary>
        /// Gets a list of photos of the album, user or page with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The ID or name.</param>
        /// <param name="options">The options for the call to the API.</param>
        public SocialHttpResponse GetPhotos(string identifier, FacebookPhotosOptions options) {
            return Client.DoAuthenticatedGetRequest("/" + identifier + "/photos", options);
        }

        /// <summary>
        /// Posts a new photo to the feed of the user with the specified <code>identifier</code>.
        /// </summary>
        /// <param name="identifier">The ID of the user.</param>
        /// <param name="options">The options for the call to the API.</param>
        public SocialHttpResponse PostPhoto(string identifier, FacebookPostUserPhotoOptions options) {
            return Client.DoAuthenticatedPostRequest("/" + identifier + "/photos", options);
        }

        #endregion

    }

}