using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.Instagram.Options {

    /// <summary>
    /// Class representing the search options for a given location specified by latitude and longitude.
    /// </summary>
    public class InstagramRecentMediaSearchOptions : IGetOptions {
        
        /// <summary>
        /// Latitude of the center search coordinate. If used, <code>Longitude</code> is required.
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude of the center search coordinate. If used, <code>Latitude</code> is required.
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// Default is 1km (distance=1000), max distance is 5km.
        /// </summary>
        public int Distance { get; set; }

        /// <summary>
        /// A unix timestamp. All media returned will be taken later than this timestamp.
        /// </summary>
        public int MinTimestamp { get; set; }

        /// <summary>
        /// A unix timestamp. All media returned will be taken earlier than this timestamp.
        /// </summary>
        public int MaxTimestamp { get; set; }

        /// <summary>
        /// Gets an instance of <code>SocialQueryString</code> representing the GET parameters.
        /// </summary>
        public SocialQueryString GetQueryString() {

            // Declare the query string
            SocialQueryString qs = new SocialQueryString();
            qs.Add("lat", Latitude);
            qs.Add("lng", Longitude);

            // Optinal options
            if (Distance > 0) qs.Add("distance", Distance);
            if (MinTimestamp > 0) qs.Add("min_timestamp", MinTimestamp);
            if (MaxTimestamp > 0) qs.Add("max_timestamp", MaxTimestamp);

            return qs;

        }
    
    }

}