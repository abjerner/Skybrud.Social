using System.Collections.Specialized;
using System.Globalization;
using Skybrud.Social.Http;
using Skybrud.Social.Twitter.Attributes;
using Skybrud.Social.Twitter.Enums;
using Skybrud.Social.Twitter.OAuth;
using Skybrud.Social.Twitter.Options;

namespace Skybrud.Social.Twitter.Endpoints.Raw {
    
    public class TwitterGeoRawEndpoint {

        #region Properties

        public TwitterOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal TwitterGeoRawEndpoint(TwitterOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the raw API response for a place with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the place.</param>
        /// <see cref="https://dev.twitter.com/docs/api/1.1/get/geo/id/:place_id"/>
        /// <returns></returns>
        [TwitterMethod(rateLimited: true, rate: "15/user", authentication: TwitterAuthentication.UserContext)]
        public SocialHttpResponse GetPlace(string id) {
            return Client.DoHttpGetRequest("https://api.twitter.com/1.1/geo/id/" + id + ".json");
        }

        /// <summary>
        /// Given a latitude and a longitude, searches for up to 20 places that can be used as
        /// a <var>place_id</var> when updating a status. This request is an informative call
        /// and will deliver generalized results about geography.
        /// </summary>
        /// <param name="latitude">The latitude to search around. This parameter will be ignored
        /// unless it is inside the range -90.0 to +90.0 (North is positive) inclusive. It will
        /// also be ignored if there isn't a corresponding <var>long</var> parameter.</param>
        /// <param name="longitude">The longitude to search around. The valid ranges for longitude
        /// is -180.0 to +180.0 (East is positive) inclusive. This parameter will be ignored if
        /// outside that range, if it is not a number, if <var>geo_enabled</var> is disabled, or
        /// if there not a corresponding <var>lat</var> parameter.</param>
        /// <see cref="https://dev.twitter.com/docs/api/1.1/get/geo/reverse_geocode"/>
        [TwitterMethod(rateLimited: true, rate: "15/user", authentication: TwitterAuthentication.UserContext)]
        public SocialHttpResponse ReverseGeocode(double latitude, double longitude) {
            return ReverseGeocode(latitude, longitude, null);
        }

        /// <summary>
        /// Given a latitude and a longitude, searches for up to 20 places that can be used as
        /// a <var>place_id</var> when updating a status. This request is an informative call
        /// and will deliver generalized results about geography.
        /// </summary>
        /// <param name="latitude">The latitude to search around. This parameter will be ignored
        /// unless it is inside the range -90.0 to +90.0 (North is positive) inclusive. It will
        /// also be ignored if there isn't a corresponding <var>long</var> parameter.</param>
        /// <param name="longitude">The longitude to search around. The valid ranges for longitude
        /// is -180.0 to +180.0 (East is positive) inclusive. This parameter will be ignored if
        /// outside that range, if it is not a number, if <var>geo_enabled</var> is disabled, or
        /// if there not a corresponding <var>lat</var> parameter.</param>
        /// <param name="options">The options used when making the call to the API.</param>
        /// <see cref="https://dev.twitter.com/docs/api/1.1/get/geo/reverse_geocode"/>
        [TwitterMethod(rateLimited: true, rate: "15/user", authentication: TwitterAuthentication.UserContext)]
        public SocialHttpResponse ReverseGeocode(double latitude, double longitude, TwitterReverseGeocodeOptions options) {

            // Define the query string
            NameValueCollection qs = new NameValueCollection {
                {"lat", latitude.ToString(CultureInfo.InvariantCulture)},
                {"long", longitude.ToString(CultureInfo.InvariantCulture)}
            };

            // Add optional parameters
            if (options != null) {
                if (options.Accurary != null && options.Accurary != "0m") qs.Add("accuracy", options.Accurary);
                if (options.Granularity != default(TwitterGranularity)) qs.Add("granularity", options.Granularity.ToString().ToLower());
                if (options.MaxResults > 0) qs.Add("max_results", options.MaxResults + "");
            }

            // Make the call to the API
            return Client.DoHttpGetRequest("https://api.twitter.com/1.1/geo/reverse_geocode.json", qs);

        }

        #endregion

    }

}