using Skybrud.Social.Http;
using Skybrud.Social.Twitter.OAuth;
using Skybrud.Social.Twitter.Options;

namespace Skybrud.Social.Twitter.Endpoints.Raw {
    
    public class TwitterGeoRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the OAuth 1.0a client.
        /// </summary>
        public TwitterOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal TwitterGeoRawEndpoint(TwitterOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets the raw API response for a place with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the place.</param>
        /// <see>
        ///     <cref>https://dev.twitter.com/docs/api/1.1/get/geo/id/:place_id</cref>
        /// </see>
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
        /// <see>
        ///     <cref>https://dev.twitter.com/docs/api/1.1/get/geo/reverse_geocode</cref>
        /// </see>
        public SocialHttpResponse ReverseGeocode(double latitude, double longitude) {
            return ReverseGeocode(new TwitterReverseGeocodeOptions {
                Latitude = latitude,
                Longitude = longitude
            });
        }

        /// <summary>
        /// Given a latitude and a longitude, searches for up to 20 places that can be used as
        /// a <var>place_id</var> when updating a status. This request is an informative call
        /// and will deliver generalized results about geography.
        /// </summary>
        /// <param name="options">The options used when making the call to the API.</param>
        /// <see>
        ///     <cref>https://dev.twitter.com/docs/api/1.1/get/geo/reverse_geocode</cref>
        /// </see>
        public SocialHttpResponse ReverseGeocode(TwitterReverseGeocodeOptions options) {
            return Client.DoHttpGetRequest("https://api.twitter.com/1.1/geo/reverse_geocode.json", options);
        }

        #endregion

    }

}