using Skybrud.Social.Json;
using Skybrud.Social.Twitter.Endpoints.Raw;
using Skybrud.Social.Twitter.Objects;
using Skybrud.Social.Twitter.Options;
using Skybrud.Social.Twitter.Responses;

namespace Skybrud.Social.Twitter.Endpoints {

    public class TwitterGeoEndpoint {

        /// <summary>
        /// A reference to the Twitter service.
        /// </summary>
        public TwitterService Service { get; private set; }

        /// <summary>
        /// A reference to the raw endpoint.
        /// </summary>
        public TwitterGeoRawEndpoint Raw {
            get { return Service.Client.Geo; }
        }

        internal TwitterGeoEndpoint(TwitterService service) {
            Service = service;
        }
        
        /// <summary>
        /// Gets information about a place with with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the place.</param>
        /// <see cref="https://dev.twitter.com/docs/api/1.1/get/geo/id/:place_id"/>
        public TwitterPlace GetPlace(string id) {
            return JsonObject.ParseJson(Raw.GetPlace(id).Body, TwitterPlace.Parse);
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
        public TwitterReverseGeocodeResponse ReverseGeocode(double latitude, double longitude) {
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
        public TwitterReverseGeocodeResponse ReverseGeocode(double latitude, double longitude, TwitterReverseGeocodeOptions options) {
            return TwitterReverseGeocodeResponse.ParseJson(Raw.ReverseGeocode(latitude, longitude, options).Body);
        }

    }

}