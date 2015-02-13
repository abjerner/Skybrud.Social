using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;
using Skybrud.Social.Twitter.Enums;

namespace Skybrud.Social.Twitter.Options {

    public class TwitterReverseGeocodeOptions : IGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the latitude to search around. This parameter will be ignored unless it is inside the range
        /// -90.0 to +90.0 (North is positive) inclusive. It will  also be ignored if there isn't a corresponding
        /// <code>long</code> parameter.
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude to search around. The valid ranges for longitude is -180.0 to +180.0 (East is
        /// positive) inclusive. This parameter will be ignored if outside that range, if it is not a number, if
        /// <code>geo_enabled</code> is disabled, or if there not a corresponding <code>lat</code> parameter.
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// A hint on the "region" in which to search. If a number, then this is a radius in meters, but it can also
        /// take a string that is suffixed with ft to specify feet. If this is not passed in, then it is assumed to be
        /// <code>0m</code>. If coming from a device, in practice, this value is whatever accuracy the device has
        /// measuring its location (whether it be coming from a GPS, WiFi triangulation, etc.).
        /// </summary>
        public string Accurary { get; set; }

        /// <summary>
        /// This is the minimal granularity of place types to return and must be one of: <code>poi</code>,
        /// <code>neighborhood</code>, <code>city</code>, <code>admin</code> or <code>country</code>. If no granularity
        /// is provided for the request <code>neighborhood</code> is assumed. Setting this to <code>city</code>, for
        /// example, will find places which have a type of <code>city</code>, <code>admin</code> or
        /// <code>country</code>.
        /// </summary>
        public TwitterGranularity Granularity { get; set; }

        /// <summary>
        /// A hint as to the number of results to return. This does not guarantee that the number of results returned
        /// will equal max_results, but instead informs how many "nearby" results to return. Ideally, only pass in the
        /// number of places you intend to display to the user here.
        /// </summary>
        public int MaxResults { get; set; }

        #endregion

        #region Constructors

        public TwitterReverseGeocodeOptions() { }

        public TwitterReverseGeocodeOptions(string accurary = "0m", TwitterGranularity granularity = TwitterGranularity.Neighborhood, int maxResults = 0) {
            Accurary = accurary;
            Granularity = granularity;
            MaxResults = maxResults;
        }

        #endregion

        #region Member methods

        public TwitterReverseGeocodeOptions SetAccuraryInMeters(int meters) {
            Accurary = meters + "m";
            return this;
        }

        public TwitterReverseGeocodeOptions SetAccuraryInFeet(int feet) {
            Accurary = feet + "ft";
            return this;
        }

        public SocialQueryString GetQueryString() {

            // Initialize the query string
            SocialQueryString query = new SocialQueryString();

            // Set required parameters
            query.Set("lat", Latitude);
            query.Set("long", Longitude);

            // Set optional parameters
            if (Accurary != null && Accurary != "0m") query.Set("accuracy", Accurary);
            if (Granularity != default(TwitterGranularity)) query.Set("granularity", Granularity.ToString().ToLower());
            if (MaxResults > 0) query.Set("max_results", MaxResults);

            return query;

        }

        #endregion
    
    }

}