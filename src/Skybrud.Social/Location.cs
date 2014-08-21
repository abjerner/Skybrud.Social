using Skybrud.Social.Interfaces;

namespace Skybrud.Social {

    public class Location : ILocation {

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

        public Location() {
            // Default constructor
        }

        public Location(double latitude, double longitude) {
            Latitude = latitude;
            Longitude = longitude;
        }

        #endregion

    }

}
