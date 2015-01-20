using Skybrud.Social.Instagram.Endpoints.Raw;
using Skybrud.Social.Instagram.Options;
using Skybrud.Social.Instagram.Responses;

namespace Skybrud.Social.Instagram.Endpoints {
    
    public class InstagramMediaEndpoint {

        #region Properties

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
        public InstagramMediaResponse GetMedia(string mediaId) {
            return InstagramMediaResponse.ParseResponse(Raw.GetMedia(mediaId));
        }
        
        /// <summary>
        /// Search for media in a given area. The default time span is set to 5 days. Can return mix of image
        /// and video types.
        /// </summary>
        /// <param name="latitude">The latitude of the point.</param>
        /// <param name="longitude">The longitude of the point.</param>
        public InstagramRecentMediaResponse Search(double latitude, double longitude) {
            return InstagramRecentMediaResponse.ParseJson(Raw.Search(latitude, longitude).Body);
        }

        /// <summary>
        /// Search for media in a given area. The default time span is set to 5 days. Can return mix of image
        /// and video types.
        /// </summary>
        /// <param name="latitude">The latitude of the point.</param>
        /// <param name="longitude">The longitude of the point.</param>
        /// <param name="distance">The distance/radius in meters. The API allows a maximum radius of 5000 meters.</param>
        public InstagramRecentMediaResponse Search(double latitude, double longitude, int distance) {
            return InstagramRecentMediaResponse.ParseJson(Raw.Search(latitude, longitude, distance).Body);
        }

        /// <summary>
        /// Search for media in a given area. The default time span is set to 5 days. The time span must not
        /// exceed 7 days. Defaults time stamps cover the last 5 days. Can return mix of image and video types.
        /// </summary>
        /// <param name="options">The search options.</param>
        public InstagramRecentMediaResponse Search(InstagramRecentMediaSearchOptions options) {
            return InstagramRecentMediaResponse.ParseJson(Raw.Search(options).Body);
        }

        #endregion

    }

}
