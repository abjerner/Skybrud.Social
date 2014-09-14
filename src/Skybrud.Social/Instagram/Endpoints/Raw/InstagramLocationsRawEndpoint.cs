using System;
using System.Collections.Specialized;
using System.Globalization;
using Skybrud.Social.Instagram.OAuth;
using Skybrud.Social.Instagram.Objects;
using Skybrud.Social.Instagram.Options;

namespace Skybrud.Social.Instagram.Endpoints.Raw {
    
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

        #region GetLocation(...)

        /// <summary>
        /// Gets information about a location with the specified ID.
        /// </summary>
        /// <param name="locationId">The ID of the location.</param>
        public string GetLocation(int locationId) {
            return Client.DoAuthenticatedGetRequest("https://api.instagram.com/v1/locations/" + locationId);
        }

        #endregion

        #region GetRecentMedia(...)

        /// <summary>
        /// Get a list of recent media objects from a given location.
        /// </summary>
        /// <param name="location">The location.</param>
        public string GetRecentMedia(InstagramLocation location) {
            if (location == null) throw new ArgumentNullException("location");
            return GetRecentMedia(location.Id, null);
        }

        /// <summary>
        /// Get a list of recent media objects from a given location.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <param name="options">The options for the search.</param>
        public string GetRecentMedia(InstagramLocation location, InstagramLocationSearchOptions options) {
            if (location == null) throw new ArgumentNullException("location");
            return GetRecentMedia(location.Id, options);
        }

        /// <summary>
        /// Get a list of recent media objects from a given location.
        /// </summary>
        /// <param name="locationId">The ID of the location.</param>
        public string GetRecentMedia(int locationId) {
            return GetRecentMedia(locationId, null);
        }

        /// <summary>
        /// Get a list of recent media objects from a given location.
        /// </summary>
        /// <param name="locationId">The ID of the location.</param>
        /// <param name="options">The options for the search.</param>
        public string GetRecentMedia(int locationId, InstagramLocationSearchOptions options) {

            // Declare the query string
            NameValueCollection qs = new NameValueCollection();

            // Add any extra options
            if (options != null) {
                if (options.MinTimestamp > 0) qs.Add("min_timestamp", options.MinTimestamp.ToString(CultureInfo.InvariantCulture));
                if (options.MaxTimestamp > 0) qs.Add("max_timestamp", options.MaxTimestamp.ToString(CultureInfo.InvariantCulture));
                if (!String.IsNullOrWhiteSpace(options.MinId)) qs.Add("min_id", options.MinId);
                if (!String.IsNullOrWhiteSpace(options.MaxId)) qs.Add("max_id", options.MaxId);
            }

            // Perform the call to the API
            return Client.DoAuthenticatedGetRequest("https://api.instagram.com/v1/locations/" + locationId + "/media/recent", qs);

        }

        #endregion

        #region Search(...)

        /// <summary>
        /// Search for a location by geographic coordinate within a 1000 meters.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        public string Search(double latitude, double longitude) {
            return Search(latitude, longitude, 1000);
        }

        /// <summary>
        /// Search for a location by geographic coordinate.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="distance">The distance is menters (max: 5000m)</param>
        public string Search(double latitude, double longitude, int distance) {

            // Declare the query string
            NameValueCollection qs = new NameValueCollection {
                {"lat", latitude.ToString(CultureInfo.InvariantCulture)},
                {"lng", longitude.ToString(CultureInfo.InvariantCulture)},
                {"distance", distance.ToString(CultureInfo.InvariantCulture)}
            };

            // Perform the call to the API
            return Client.DoAuthenticatedGetRequest("https://api.instagram.com/v1/locations/search", qs);

        }

        #endregion

        #endregion

    }

}
