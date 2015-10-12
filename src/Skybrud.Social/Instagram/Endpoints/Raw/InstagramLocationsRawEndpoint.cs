using System;
using Skybrud.Social.Http;
using Skybrud.Social.Instagram.OAuth;
using Skybrud.Social.Instagram.Objects;
using Skybrud.Social.Instagram.Options.Locations;

namespace Skybrud.Social.Instagram.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw implementation of the locations endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/locations/</cref>
    /// </see>
    public class InstagramLocationsRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Instagram OAuth client.
        /// </summary>
        public InstagramOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal InstagramLocationsRawEndpoint(InstagramOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about a location with the specified <code>locationId</code>.
        /// </summary>
        /// <param name="locationId">The ID of the location.</param>
        /// <returns>Returns an instance of <code>SocialHttpResponse</code> representing the response from the Instagram API.</returns>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/locations/#get_locations</cref>
        /// </see>
        public SocialHttpResponse GetLocation(int locationId) {
            return Client.DoAuthenticatedGetRequest("https://api.instagram.com/v1/locations/" + locationId);
        }

        /// <summary>
        /// Gets a list of recent media from the specified <code>location</code>.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <returns>Returns an instance of <code>SocialHttpResponse</code> representing the response from the Instagram API.</returns>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/locations/#get_locations_media_recent</cref>
        /// </see>
        public SocialHttpResponse GetRecentMedia(InstagramLocation location) {
            if (location == null) throw new ArgumentNullException("location");
            return GetRecentMedia(location.Id, null);
        }

        /// <summary>
        /// Gets a list of recent media from the specified <code>location</code>.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>Returns an instance of <code>SocialHttpResponse</code> representing the response from the Instagram API.</returns>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/locations/#get_locations_media_recent</cref>
        /// </see>
        public SocialHttpResponse GetRecentMedia(InstagramLocation location, InstagramLocationRecentMediaOptions options) {
            if (location == null) throw new ArgumentNullException("location");
            return GetRecentMedia(location.Id, options);
        }

        /// <summary>
        /// Gets a list of recent media from a location with the specified <code>locationId</code>.
        /// </summary>
        /// <param name="locationId">The ID of the location.</param>
        /// <returns>Returns an instance of <code>SocialHttpResponse</code> representing the response from the Instagram API.</returns>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/locations/#get_locations_media_recent</cref>
        /// </see>
        public SocialHttpResponse GetRecentMedia(int locationId) {
            return GetRecentMedia(locationId, null);
        }

        /// <summary>
        /// Gets a list of recent media from a location with the specified <code>locationId</code>.
        /// </summary>
        /// <param name="locationId">The ID of the location.</param>
        /// <param name="options">The options for the search.</param>
        /// <returns>Returns an instance of <code>SocialHttpResponse</code> representing the response from the Instagram API.</returns>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/locations/#get_locations_media_recent</cref>
        /// </see>
        public SocialHttpResponse GetRecentMedia(int locationId, InstagramLocationRecentMediaOptions options) {
            return Client.DoAuthenticatedGetRequest("https://api.instagram.com/v1/locations/" + locationId + "/media/recent", options);
        }

        /// <summary>
        /// Gets a list of locations with a geographic coordinate within a 1000 meters of the
        /// specified <code>latitude</code> and <code>longitude</code>.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <returns>Returns an instance of <code>SocialHttpResponse</code> representing the response from the Instagram API.</returns>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/locations/#get_locations_search</cref>
        /// </see>
        public SocialHttpResponse Search(double latitude, double longitude) {
            return Search(new InstagramLocationSearchOptions {
                Latitude = latitude,
                Longitude = longitude
            });
        }

        /// <summary>
        /// Gets a list of locations with a geographic coordinate within <code>distance</code>
        /// meters of the specified <code>latitude</code> and <code>longitude</code>.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="distance">The distance is meters (max: 5000m)</param>
        /// <returns>Returns an instance of <code>SocialHttpResponse</code> representing the response from the Instagram API.</returns>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/locations/#get_locations_search</cref>
        /// </see>
        public SocialHttpResponse Search(double latitude, double longitude, int distance) {
            return Search(new InstagramLocationSearchOptions {
                Latitude = latitude,
                Longitude = longitude,
                Distance = distance
            });
        }

        /// <summary>
        /// Gets a list of locations with a geographic coordinate within the radius as described in the specified <code>options</code>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>Returns an instance of <code>SocialHttpResponse</code> representing the response from the Instagram API.</returns>
        /// <see>
        ///     <cref>https://instagram.com/developer/endpoints/locations/#get_locations_search</cref>
        /// </see>
        public SocialHttpResponse Search(InstagramLocationSearchOptions options) {
            return Client.DoAuthenticatedGetRequest("https://api.instagram.com/v1/locations/search", options);
        }

        #endregion

    }

}