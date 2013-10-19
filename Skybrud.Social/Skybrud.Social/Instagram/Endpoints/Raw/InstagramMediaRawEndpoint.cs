using System.Collections.Specialized;
using System.Globalization;
using Skybrud.Social.Instagram.OAuth;
using Skybrud.Social.Instagram.Options;

namespace Skybrud.Social.Instagram.Endpoints.Raw {
    
    public class InstagramMediaRawEndpoint {

        #region Properties

        public InstagramOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal InstagramMediaRawEndpoint(InstagramOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Search for media in a given area. The default time span is set to 5 days. Can return mix of image
        /// and video types.
        /// </summary>
        /// <param name="latitude">The latitude of the point.</param>
        /// <param name="longitude">The longitude of the point.</param>
        public string Search(double latitude, double longitude) {
            return Search(new InstagramLocationSearchOptions {
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
        public string Search(double latitude, double longitude, int distance) {
            return Search(new InstagramLocationSearchOptions {
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
        public string Search(InstagramLocationSearchOptions options) {

            // Declare the query string
            NameValueCollection qs = new NameValueCollection {
                {"access_token", Client.AccessToken},
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

        #endregion

    }

}
