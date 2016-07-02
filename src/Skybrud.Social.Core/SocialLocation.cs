using Skybrud.Social.Interfaces;

namespace Skybrud.Social {

    /// <summary>
    /// Class representing a location identified by latitude and longitude.
    /// </summary>
    public class SocialLocation : ILocation {

        #region Properties

        /// <summary>
        /// Gets the latitude of the location. The latitude specifies the north-south position of a
        /// point on the Earth's surface.
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Gets the longitude of the location. The longitude specifies the east-west position of a
        /// point on the Earth's surface.
        /// </summary>
        public double Longitude { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a location with default latitude and longitude.
        /// </summary>
        public SocialLocation() { }

        /// <summary>
        /// Initializes a location with the specified <code>latitude</code> and <code>longitude</code>.
        /// </summary>
        /// <param name="latitude">The latitude of the location.</param>
        /// <param name="longitude">The longitude of the location.</param>
        public SocialLocation(double latitude, double longitude) {
            Latitude = latitude;
            Longitude = longitude;
        }

        #endregion

    }

}
