using Skybrud.Social.Http;
using Skybrud.Social.Instagram.OAuth;
using Skybrud.Social.Instagram.Options;

namespace Skybrud.Social.Instagram.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw implementation of the media endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/media/</cref>
    /// </see>
    public class InstagramMediaRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Instagram OAuth client.
        /// </summary>
        public InstagramOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal InstagramMediaRawEndpoint(InstagramOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about a media object.
        /// </summary>
        /// <param name="mediaId">The ID of the media.</param>
        /// <returns>Returns an instance of <code>SocialHttpResponse</code> representing the response from the Instagram API.</returns>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/media/#get_media</cref>
        /// </see>
        public SocialHttpResponse GetMedia(string mediaId) {
            return Client.DoAuthenticatedGetRequest("https://api.instagram.com/v1/media/" + mediaId);
        }

        // TODO: Implement http://instagram.com/developer/endpoints/media/#get_media_by_shortcode

        /// <summary>
        /// Search for media in a given area. The default time span is set to 5 days. Can return mix of image
        /// and video types.
        /// </summary>
        /// <param name="latitude">The latitude of the point.</param>
        /// <param name="longitude">The longitude of the point.</param>
        /// <returns>Returns an instance of <code>SocialHttpResponse</code> representing the response from the Instagram API.</returns>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/media/#get_media_search</cref>
        /// </see>
        public SocialHttpResponse Search(double latitude, double longitude) {
            return Search(new InstagramRecentMediaSearchOptions {
                Latitude = latitude,
                Longitude = longitude
            });
        }

        /// <summary>
        /// Search for media in a given area. The default time span is set to 5 days. Can return mix of image
        /// and video types.
        /// </summary>
        /// <param name="latitude">The latitude of the point.</param>
        /// <param name="longitude">The longitude of the point.</param>
        /// <param name="distance">The distance/radius in meters. The API allows a maximum radius of 5000 meters.</param>
        /// <returns>Returns an instance of <code>SocialHttpResponse</code> representing the response from the Instagram API.</returns>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/media/#get_media_search</cref>
        /// </see>
        public SocialHttpResponse Search(double latitude, double longitude, int distance) {
            return Search(new InstagramRecentMediaSearchOptions {
                Latitude = latitude,
                Longitude = longitude,
                Distance = distance
            });
        }

        /// <summary>
        /// Search for media in a given area. The default time span is set to 5 days. The time span must not
        /// exceed 7 days. Defaults time stamps cover the last 5 days. Can return mix of image and video types.
        /// </summary>
        /// <param name="options">The search options.</param>
        /// <returns>Returns an instance of <code>SocialHttpResponse</code> representing the response from the Instagram API.</returns>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/media/#get_media_search</cref>
        /// </see>
        public SocialHttpResponse Search(InstagramRecentMediaSearchOptions options) {
            return Client.DoAuthenticatedGetRequest("https://api.instagram.com/v1/media/search", options);
        }

        // TODO: Implement http://instagram.com/developer/endpoints/media/#get_media_popular

        #endregion

    }

}