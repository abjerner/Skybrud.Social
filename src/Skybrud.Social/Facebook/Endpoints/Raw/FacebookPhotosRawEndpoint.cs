using Skybrud.Social.Facebook.OAuth;
using Skybrud.Social.Facebook.Options;
using Skybrud.Social.Http;

namespace Skybrud.Social.Facebook.Endpoints.Raw {
    
    public class FacebookPhotosRawEndpoint {

        #region Properties

        public FacebookOAuthClient Client { get; private set; }

        #endregion

        #region Constructor

        internal FacebookPhotosRawEndpoint(FacebookOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods
        
        /// <summary>
        /// Gets information about a photo with the specified <code>id</code>
        /// </summary>
        /// <param name="id">The ID of the photo.</param>
        public SocialHttpResponse GetPhoto(long id) {
            return Client.DoAuthenticatedGetRequest("https://graph.facebook.com/v1.0/" + id);
        }
        
        /// <summary>
        /// Gets the photos of the specified album, page or user.
        /// </summary>
        /// <param name="identifier">The ID or name.</param>
        /// <param name="options">The options for the call to the API.</param>
        public SocialHttpResponse GetPhotos(string identifier, FacebookPhotosOptions options) {
            return Client.DoAuthenticatedGetRequest("https://graph.facebook.com/v1.0/" + identifier + "/photos", options);
        }

        #endregion

    }

}
