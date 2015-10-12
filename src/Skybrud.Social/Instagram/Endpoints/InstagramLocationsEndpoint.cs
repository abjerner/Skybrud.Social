using System;
using Skybrud.Social.Instagram.Endpoints.Raw;
using Skybrud.Social.Instagram.Objects;
using Skybrud.Social.Instagram.Options.Locations;
using Skybrud.Social.Instagram.Responses;

namespace Skybrud.Social.Instagram.Endpoints {

    /// <summary>
    /// Class representing the implementation of the locations endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/locations/</cref>
    /// </see>
    public class InstagramLocationsEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Instagram service.
        /// </summary>
        public InstagramService Service { get; private set; }

        /// <summary>
        /// A reference to the raw endpoint.
        /// </summary>
        public InstagramLocationsRawEndpoint Raw {
            get { return Service.Client.Locations; }
        }

        #endregion

        #region Constructors

        internal InstagramLocationsEndpoint(InstagramService service) {
            Service = service;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about a location with the specified ID. If a location isn't found, an exception will be thrown.
        /// </summary>
        /// <param name="locationId">The ID of the location.</param>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/locations/#get_locations</cref>
        /// </see>
        public InstagramLocationResponse GetLocation(int locationId) {
            return InstagramLocationResponse.ParseResponse(Raw.GetLocation(locationId));
        }

        /// <summary>
        /// Get a list of recent media objects from a given location.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/locations/#get_locations_media_recent</cref>
        /// </see>
        public InstagramLocationRecentMediaResponse GetRecentMedia(InstagramLocation location) {
            if (location == null) throw new ArgumentNullException("location");
            return GetRecentMedia(location.Id);
        }

        /// <summary>
        /// Get a list of recent media objects from a given location.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <param name="options">The options for the search.</param>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/locations/#get_locations_media_recent</cref>
        /// </see>
        public InstagramLocationRecentMediaResponse GetRecentMedia(InstagramLocation location, InstagramLocationRecentMediaOptions options) {
            if (location == null) throw new ArgumentNullException("location");
            return GetRecentMedia(location.Id, options);
        }

        /// <summary>
        /// Get a list of recent media objects from a given location.
        /// </summary>
        /// <param name="locationId">The ID of the location.</param>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/locations/#get_locations_media_recent</cref>
        /// </see>
        public InstagramLocationRecentMediaResponse GetRecentMedia(int locationId) {
            return InstagramLocationRecentMediaResponse.ParseResponse(Raw.GetRecentMedia(locationId));
        }

        /// <summary>
        /// Get a list of recent media objects from a given location.
        /// </summary>
        /// <param name="locationId">The ID of the location.</param>
        /// <param name="options">The options for the search.</param>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/locations/#get_locations_media_recent</cref>
        /// </see>
        public InstagramLocationRecentMediaResponse GetRecentMedia(int locationId, InstagramLocationRecentMediaOptions options) {
            return InstagramLocationRecentMediaResponse.ParseResponse(Raw.GetRecentMedia(locationId, options));
        }

        /// <summary>
        /// Search for a location by geographic coordinate within a 1000 meters.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/locations/#get_locations_search</cref>
        /// </see>
        public InstagramLocationsResponse Search(double latitude, double longitude) {
            return InstagramLocationsResponse.ParseResponse(Raw.Search(latitude, longitude));
        }

        /// <summary>
        /// Search for a location by geographic coordinate.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="distance">The distance is meters (max: 5000m)</param>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/locations/#get_locations_search</cref>
        /// </see>
        public InstagramLocationsResponse Search(double latitude, double longitude, int distance) {
            return InstagramLocationsResponse.ParseResponse(Raw.Search(latitude, longitude, distance));
        }

        /// <summary>
        /// Search for a location by geographic coordinate.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/locations/#get_locations_search</cref>
        /// </see>
        public InstagramLocationsResponse Search(InstagramLocationSearchOptions options) {
            return InstagramLocationsResponse.ParseResponse(Raw.Search(options));
        }

        #endregion

    }

}