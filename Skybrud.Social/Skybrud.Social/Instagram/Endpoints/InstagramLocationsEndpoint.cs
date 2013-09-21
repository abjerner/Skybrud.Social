using System;
using System.Collections.Specialized;
using System.Globalization;
using Skybrud.Social.Instagram.Objects;
using Skybrud.Social.Instagram.Responses;
using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Endpoints {
    
    public class InstagramLocationsEndpoint {

        protected InstagramService Service;

        internal InstagramLocationsEndpoint(InstagramService service) {
            Service = service;
        }

        /// <summary>
        /// Gets information about a location with the specified ID. If a location isn't found, an exception will be thrown.
        /// </summary>
        /// <param name="locationId">The ID of the location.</param>
        public string GetLocationAsRawJson(int locationId) {

            // Declare the query string
            NameValueCollection qs = new NameValueCollection {
                {"access_token", Service.AccessToken}
            };

            // Perform the call to the API
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://api.instagram.com/v1/locations/" + locationId, qs);

        }

        /// <summary>
        /// Gets information about a location with the specified ID. If a location isn't found, an exception will be thrown.
        /// </summary>
        /// <param name="locationId">The ID of the location.</param>
        public InstagramLocation GetLocation(int locationId) {

            // Parse the server response
            JsonObject obj = JsonConverter.ParseObject(GetLocationAsRawJson(locationId));

            // Validate the response
            InstagramResponse.ValidateResponse(obj);

            // Return the location
            return obj.GetObject("data", InstagramLocation.Parse);

        }

        /// <summary>
        /// Get a list of recent media objects from a given location.
        /// </summary>
        /// <param name="location">The location.</param>
        public string GetRecentMediaAsRawJson(InstagramLocation location) {
            if (location == null) throw new ArgumentNullException("location");
            return GetRecentMediaAsRawJson(location.Id);
        }
        
        /// <summary>
        /// Get a list of recent media objects from a given location.
        /// </summary>
        /// <param name="locationId">The ID of the location.</param>
        public string GetRecentMediaAsRawJson(int locationId) {

            // Declare the query string
            NameValueCollection qs = new NameValueCollection {
                {"access_token", Service.AccessToken}
            };

            // Perform the call to the API
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://api.instagram.com/v1/locations/" + locationId + "/media/recent", qs);

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
            return InstagramRecentMediaResponse.ParseJson(GetRecentMediaAsRawJson(locationId));
        }




        /// <summary>
        /// Search for a location by geographic coordinate within a 1000 meters.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        public string SearchAsRawJson(double latitude, double longitude) {
            return SearchAsRawJson(latitude, longitude, 1000);
        }

        /// <summary>
        /// Search for a location by geographic coordinate.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="distance">The distance is menters (max: 5000m)</param>
        public string SearchAsRawJson(double latitude, double longitude, int distance) {

            // Declare the query string
            NameValueCollection qs = new NameValueCollection {
                {"access_token", Service.AccessToken},
                {"lat", latitude.ToString(CultureInfo.InvariantCulture)},
                {"lng", longitude.ToString(CultureInfo.InvariantCulture)},
                {"distance", distance + ""}
            };

            // Perform the call to the API
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://api.instagram.com/v1/locations/search", qs);

        }

        /// <summary>
        /// Search for a location by geographic coordinate within a 1000 meters.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        public InstagramLocationsResponse Search(double latitude, double longitude) {
            return InstagramLocationsResponse.ParseJson(SearchAsRawJson(latitude, longitude));
        }

        /// <summary>
        /// Search for a location by geographic coordinate.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="distance">The distance is menters (max: 5000m)</param>
        public InstagramLocationsResponse Search(double latitude, double longitude, int distance) {
            return InstagramLocationsResponse.ParseJson(SearchAsRawJson(latitude, longitude, distance));
        }
    
    }

}
