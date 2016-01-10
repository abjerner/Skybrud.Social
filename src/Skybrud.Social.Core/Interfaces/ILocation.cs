namespace Skybrud.Social.Interfaces {

    /// <summary>
    /// Class representing a location based on a latitude and longitude.
    /// </summary>
    public interface ILocation {

        /// <summary>
        /// Gets the latitude of the location. The latitude specifies the north-south position of a
        /// point on the Earth's surface.
        /// </summary>
        double Latitude { get; }

        /// <summary>
        /// Gets the longitude of the location. The longitude specifies the east-west position of a
        /// point on the Earth's surface.
        /// </summary>
        double Longitude { get; }

    }

}
