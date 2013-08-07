using System.Collections.Specialized;
using System.Globalization;
using Skybrud.Social.Instagram.Responses;

namespace Skybrud.Social.Instagram.Endpoints {
    
    public class InstagramMediaEndpoint {

        protected InstagramService Service;

        internal InstagramMediaEndpoint(InstagramService service) {
            Service = service;
        }

        /// <summary>
        /// Search for media in a given area. The default time span is set to 5 days. Can return mix of image
        /// and video types.
        /// </summary>
        /// <param name="latitude">The latitude of the point.</param>
        /// <param name="longitude">The longitude of the point.</param>
        public string SearchAsRawJson(double latitude, double longitude) {
            return SearchAsRawJson(new InstagramMediaSearchOptions {
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
        public string SearchAsRawJson(double latitude, double longitude, int distance) {
            return SearchAsRawJson(new InstagramMediaSearchOptions {
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
        public string SearchAsRawJson(InstagramMediaSearchOptions options) {

            // Declare the query string
            NameValueCollection qs = new NameValueCollection {
                {"access_token", Service.AccessToken},
                {"lat", options.Latitude.ToString(CultureInfo.InvariantCulture)},
                {"lng", options.Longitude.ToString(CultureInfo.InvariantCulture)}
            };

            // Optinal options
            if (options.Distance > 0) qs.Add("distance", options.Distance + "");
            if (options.MinTimestamp > 0) qs.Add("min_timestamp", options.MinTimestamp + "");
            if (options.MaxTimestamp > 0) qs.Add("max_timestamp", options.MaxTimestamp + "");

            // Perform the call to the API
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://api.instagram.com/v1/media/search", qs);

        }

        /// <summary>
        /// Search for media in a given area. The default time span is set to 5 days. Can return mix of image
        /// and video types.
        /// </summary>
        /// <param name="latitude">The latitude of the point.</param>
        /// <param name="longitude">The longitude of the point.</param>
        public InstagramMediaResponse Search(double latitude, double longitude) {
            return InstagramMediaResponse.ParseJson(SearchAsRawJson(latitude, longitude));
        }

        /// <summary>
        /// Search for media in a given area. The default time span is set to 5 days. Can return mix of image
        /// and video types.
        /// </summary>
        /// <param name="latitude">The latitude of the point.</param>
        /// <param name="longitude">The longitude of the point.</param>
        /// <param name="distance">The distance/radius in meters. The API allows a maximum radius of 5000 meters.</param>
        public InstagramMediaResponse Search(double latitude, double longitude, int distance) {
            return InstagramMediaResponse.ParseJson(SearchAsRawJson(latitude, longitude, distance));
        }

        /// <summary>
        /// Search for media in a given area. The default time span is set to 5 days. The time span must not
        /// exceed 7 days. Defaults time stamps cover the last 5 days. Can return mix of image and video types.
        /// </summary>
        /// <param name="options">The search options.</param>
        public InstagramMediaResponse Search(InstagramMediaSearchOptions options) {
            return InstagramMediaResponse.ParseJson(SearchAsRawJson(options));
        }
    
    }

}
