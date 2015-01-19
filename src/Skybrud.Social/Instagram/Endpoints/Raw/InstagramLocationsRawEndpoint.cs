using System;
using Skybrud.Social.Http;
using Skybrud.Social.Instagram.OAuth;
using Skybrud.Social.Instagram.Objects;
using Skybrud.Social.Instagram.Options.Locations;

namespace Skybrud.Social.Instagram.Endpoints.Raw {

    /// <see cref="http://instagram.com/developer/endpoints/locations/"/>
    public class InstagramLocationsRawEndpoint {

        #region Properties

        public InstagramOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal InstagramLocationsRawEndpoint(InstagramOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about a location with the specified ID.
        /// </summary>
        /// <param name="locationId">The ID of the location.</param>
        /// <see cref="http://instagram.com/developer/endpoints/locations/#get_locations"/>
        public SocialHttpResponse GetLocation(int locationId) {
            return Client.DoAuthenticatedGetRequest("https://api.instagram.com/v1/locations/" + locationId);
        }

        /// <summary>
        /// Get a list of recent media objects from a given location.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <see cref="http://instagram.com/developer/endpoints/locations/#get_locations_media_recent"/>
        public SocialHttpResponse GetRecentMedia(InstagramLocation location) {
            if (location == null) throw new ArgumentNullException("location");
            return GetRecentMedia(location.Id, null);
        }

        /// <summary>
        /// Get a list of recent media objects from a given location.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <param name="options">The options for the search.</param>
        /// <see cref="http://instagram.com/developer/endpoints/locations/#get_locations_media_recent"/>
        public SocialHttpResponse GetRecentMedia(InstagramLocation location, InstagramLocationRecentMediaOptions options) {
            if (location == null) throw new ArgumentNullException("location");
            return GetRecentMedia(location.Id, options);
        }

        /// <summary>
        /// Get a list of recent media objects from a given location.
        /// </summary>
        /// <param name="locationId">The ID of the location.</param>
        /// <see cref="http://instagram.com/developer/endpoints/locations/#get_locations_media_recent"/>
        public SocialHttpResponse GetRecentMedia(int locationId) {
            return GetRecentMedia(locationId, null);
        }

        /// <summary>
        /// Get a list of recent media objects from a given location.
        /// </summary>
        /// <param name="locationId">The ID of the location.</param>
        /// <param name="options">The options for the search.</param>
        public SocialHttpResponse GetRecentMedia(int locationId, InstagramLocationRecentMediaOptions options) {
            return Client.DoAuthenticatedGetRequest("https://api.instagram.com/v1/locations/" + locationId + "/media/recent", options);
        }

        /// <summary>
        /// Search for a location by geographic coordinate within a 1000 meters.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <see cref="http://instagram.com/developer/endpoints/locations/#get_locations_search"/>
        public SocialHttpResponse Search(double latitude, double longitude) {
            return Search(new InstagramLocationSearchOptions {
                Latitude = latitude,
                Longitude = longitude
            });
        }

        /// <summary>
        /// Search for a location by geographic coordinate.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="distance">The distance is menters (max: 5000m)</param>
        /// <see cref="http://instagram.com/developer/endpoints/locations/#get_locations_search"/>
        public SocialHttpResponse Search(double latitude, double longitude, int distance) {
            return Search(new InstagramLocationSearchOptions {
                Latitude = latitude,
                Longitude = longitude,
                Distance = distance
            });
        }

        /// <summary>
        /// Search for a location by geographic coordinate.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <see cref="http://instagram.com/developer/endpoints/locations/#get_locations_search"/>
        public SocialHttpResponse Search(InstagramLocationSearchOptions options) {
            return Client.DoAuthenticatedGetRequest("https://api.instagram.com/v1/locations/search", options);
        }

        #endregion

    }

}