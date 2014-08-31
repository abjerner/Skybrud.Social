using System;
using Skybrud.Social.Instagram.Endpoints.Raw;
using Skybrud.Social.Instagram.Objects;
using Skybrud.Social.Instagram.Responses;

namespace Skybrud.Social.Instagram.Endpoints {
    
    public class InstagramLocationsEndpoint {

        #region Properties

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
        public InstagramLocationResponse GetLocation(int locationId) {
            return InstagramLocationResponse.ParseJson(Raw.GetLocation(locationId));
        }
        
        /// <summary>
        /// Get a list of recent media objects from a given location.
        /// </summary>
        /// <param name="location">The location.</param>
        public InstagramRecentMediaResponse GetRecentMedia(InstagramLocation location) {
            if (location == null) throw new ArgumentNullException("location");
            return GetRecentMedia(location.Id);
        }

        /// <summary>
        /// Get a list of recent media objects from a given location.
        /// </summary>
        /// <param name="locationId">The ID of the location.</param>
        public InstagramRecentMediaResponse GetRecentMedia(int locationId) {
            return InstagramRecentMediaResponse.ParseJson(Raw.GetRecentMedia(locationId));
        }
        
        /// <summary>
        /// Search for a location by geographic coordinate within a 1000 meters.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        public InstagramLocationsResponse Search(double latitude, double longitude) {
            return InstagramLocationsResponse.ParseJson(Raw.Search(latitude, longitude));
        }

        /// <summary>
        /// Search for a location by geographic coordinate.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="distance">The distance is menters (max: 5000m)</param>
        public InstagramLocationsResponse Search(double latitude, double longitude, int distance) {
            return InstagramLocationsResponse.ParseJson(Raw.Search(latitude, longitude, distance));
        }

        #endregion

    }

}
