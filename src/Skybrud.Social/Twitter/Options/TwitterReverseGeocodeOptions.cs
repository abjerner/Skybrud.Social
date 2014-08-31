using Skybrud.Social.Twitter.Enums;

namespace Skybrud.Social.Twitter.Options {

    public class TwitterReverseGeocodeOptions {

        #region Properties

        /// <summary>
        /// A hint on the "region" in which to search. If a number, then this is a radius in meters,
        /// but it can also take a string that is suffixed with ft to specify feet. If this is not
        /// passed in, then it is assumed to be 0m. If coming from a device, in practice, this value
        /// is whatever accuracy the device has measuring its location (whether it be coming from a
        /// GPS, WiFi triangulation, etc.).
        /// </summary>
        public string Accurary { get; set; }

        /// <summary>
        /// This is the minimal granularity of place types to return and must be one of: <var>poi</var>,
        /// <var>neighborhood</var>, <var>city</var>, <var>admin</var> or <var>country</var>. If no
        /// granularity is provided for the request <var>neighborhood</var> is assumed. Setting this to
        /// <var>city</var>, for example, will find places which have a type of <var>city</var>,
        /// <var>admin</var> or <var>country</var>.
        /// </summary>
        public TwitterGranularity Granularity { get; set; }

        /// <summary>
        /// A hint as to the number of results to return. This does not guarantee that the number of
        /// results returned will equal max_results, but instead informs how many "nearby" results to
        /// return. Ideally, only pass in the number of places you intend to display to the user here.
        /// </summary>
        public int MaxResults { get; set; }

        #endregion

        #region Constructors

        public TwitterReverseGeocodeOptions() {
            // default constructor
        }

        public TwitterReverseGeocodeOptions(string accurary = "0m", TwitterGranularity granularity = TwitterGranularity.Neighborhood, int maxResults = 0) {
            Accurary = accurary;
            Granularity = granularity;
            MaxResults = maxResults;
        }

        #endregion

        #region Methods

        public TwitterReverseGeocodeOptions SetAccuraryInMeters(int meters) {
            Accurary = meters + "m";
            return this;
        }

        public TwitterReverseGeocodeOptions SetAccuraryInFeet(int feet) {
            Accurary = feet + "ft";
            return this;
        }

        #endregion

    }

}
