using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.Instagram.Options.Locations {
    
    /// <summary>
    /// Class representing the options for for getting a list of locations within a given radius.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/endpoints/locations/#get_locations_search</cref>
    /// </see>
    public class InstagramLocationSearchOptions : IGetOptions {

        #region Properties

        /// <summary>
        /// Required: Gets or sets the latitude.
        /// </summary>
        public double Latitude { get; set; }
        
        /// <summary>
        /// Required: Gets or sets the longitude.
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// Optional: Gets or sets the search distance in meters. If not specified (eg. if zero), the default value of
        /// the Instagram API will be used. The default distance is 1000 meters, while the maximum distance is 5000
        /// meters.
        /// </summary>
        public int Distance { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Gets an instance of <code>SocialQueryString</code> representing the GET parameters.
        /// </summary>
        public SocialQueryString GetQueryString() {
            SocialQueryString qs = new SocialQueryString();
            qs.Add("lat", Latitude);
            qs.Add("lng", Longitude);
            if (Distance > 0) qs.Add("distance", Distance);
            return qs;
        }

        #endregion

    }

}