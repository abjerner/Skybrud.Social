using System;
using System.Collections.Specialized;
using System.Globalization;
using Skybrud.Social.Instagram.OAuth;
using Skybrud.Social.Instagram.Objects;

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

        /// <summary>
        /// Gets information about a location with the specified ID.
        /// </summary>
        /// <param name="locationId">The ID of the location.</param>
        public string GetLocation(int locationId) {
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://api.instagram.com/v1/locations/" + locationId + "?access_token=" + Client.AccessToken);
        }

        /// <summary>
        /// Get a list of recent media objects from a given location.
        /// </summary>
        /// <param name="location">The location.</param>
        public string GetRecentMedia(InstagramLocation location) {
            
            if (location == null) throw new ArgumentNullException("location");
            
            // TODO: Add support for MIN_TIMESTAMP parameter
            // TODO: Add support for MIN_ID parameter
            // TODO: Add support for MAX_ID parameter
            // TODO: Add support for MAX_TIMESTAMP parameter
            
            return GetRecentMedia(location.Id);
        
        }

        /// <summary>
        /// Get a list of recent media objects from a given location.
        /// </summary>
        /// <param name="locationId">The ID of the location.</param>
        public string GetRecentMedia(int locationId) {

            // Declare the query string
            NameValueCollection qs = new NameValueCollection {
                {"access_token", Client.AccessToken}
            };
           
            // TODO: Add support for MIN_TIMESTAMP parameter
            // TODO: Add support for MIN_ID parameter
            // TODO: Add support for MAX_ID parameter
            // TODO: Add support for MAX_TIMESTAMP parameter

            // Perform the call to the API
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://api.instagram.com/v1/locations/" + locationId + "/media/recent", qs);

        }

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
                {"access_token", Client.AccessToken},
                {"lat", latitude.ToString(CultureInfo.InvariantCulture)},
                {"lng", longitude.ToString(CultureInfo.InvariantCulture)},
                {"distance", distance + ""}
            };

            // Perform the call to the API
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://api.instagram.com/v1/locations/search", qs);

        }

        #endregion

    }

}
