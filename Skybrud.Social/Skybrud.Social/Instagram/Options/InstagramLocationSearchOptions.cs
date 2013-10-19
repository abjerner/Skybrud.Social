namespace Skybrud.Social.Instagram.Options {
    
    public class InstagramLocationSearchOptions {
        
        /// <summary>
        /// Latitude of the center search coordinate. If used, <var>Longitude</var> is required.
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude of the center search coordinate. If used, <var>Latitude</var> is required.
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
    
    }

}