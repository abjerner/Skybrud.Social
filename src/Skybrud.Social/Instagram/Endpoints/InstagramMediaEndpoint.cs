using Skybrud.Social.Instagram.Endpoints.Raw;
using Skybrud.Social.Instagram.Options;
using Skybrud.Social.Instagram.Responses;

namespace Skybrud.Social.Instagram.Endpoints {

    /// <summary>
    /// Class representing the implementation of the media endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/media/</cref>
    /// </see>
    public class InstagramMediaEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Instagram service.
        /// </summary>
        public InstagramService Service { get; private set; }

        /// <summary>
        /// A reference to the raw endpoint.
        /// </summary>
        public InstagramMediaRawEndpoint Raw {
            get { return Service.Client.Media; }
        }

        #endregion

        #region Constructors

        internal InstagramMediaEndpoint(InstagramService service) {
            Service = service;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about a media object.
        /// </summary>
        /// <param name="mediaId">The ID of the media.</param>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/media/#get_media</cref>
        /// </see>
        public InstagramMediaResponse GetMedia(string mediaId) {
            return InstagramMediaResponse.ParseResponse(Raw.GetMedia(mediaId));
        }

        /// <summary>
        /// Search for media in a given area. The default time span is set to 5 days. Can return mix of image
        /// and video types.
        /// </summary>
        /// <param name="latitude">The latitude of the point.</param>
        /// <param name="longitude">The longitude of the point.</param>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/media/#get_media_search</cref>
        /// </see>
        public InstagramRecentMediaResponse Search(double latitude, double longitude) {
            return InstagramRecentMediaResponse.ParseResponse(Raw.Search(latitude, longitude));
        }

        /// <summary>
        /// Search for media in a given area. The default time span is set to 5 days. Can return mix of image
        /// and video types.
        /// </summary>
        /// <param name="latitude">The latitude of the point.</param>
        /// <param name="longitude">The longitude of the point.</param>
        /// <param name="distance">The distance/radius in meters. The API allows a maximum radius of 5000 meters.</param>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/media/#get_media_search</cref>
        /// </see>
        public InstagramRecentMediaResponse Search(double latitude, double longitude, int distance) {
            return InstagramRecentMediaResponse.ParseResponse(Raw.Search(latitude, longitude, distance));
        }

        /// <summary>
        /// Search for media in a given area. The default time span is set to 5 days. The time span must not
        /// exceed 7 days. Defaults time stamps cover the last 5 days. Can return mix of image and video types.
        /// </summary>
        /// <param name="options">The search options.</param>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/media/#get_media_search</cref>
        /// </see>
        public InstagramRecentMediaResponse Search(InstagramRecentMediaSearchOptions options) {
            return InstagramRecentMediaResponse.ParseResponse(Raw.Search(options));
        }

        #endregion

    }

}