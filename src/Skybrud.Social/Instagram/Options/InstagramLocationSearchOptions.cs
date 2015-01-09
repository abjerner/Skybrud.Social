using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social.Instagram.Options {
    
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