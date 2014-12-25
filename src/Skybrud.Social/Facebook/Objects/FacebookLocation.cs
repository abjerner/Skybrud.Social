using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects {
    
    public class FacebookLocation : SocialJsonObject {

        #region Properties

        /// <summary>
        /// Gets the country of the location.
        /// </summary>
        public string Country { get; private set; }

        /// <summary>
        /// Gets the city of the location.
        /// </summary>
        public string City { get; private set; }

        /// <summary>
        /// Gets the latitude of the location.
        /// </summary>
        public double Latitude { get; private set; }

        /// <summary>
        /// Gets the longitude of the location.
        /// </summary>
        public double Longitude { get; private set; }

        /// <summary>
        /// Gets the zip code of the location.
        /// </summary>
        public string Zip { get; private set; }

        /// <summary>
        /// Gets the state of the location.
        /// </summary>
        public string State { get; private set; }

        /// <summary>
        /// Gets the street of the location.
        /// </summary>
        public string Street { get; private set; }

        #endregion

        #region Constructors

        private FacebookLocation(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static FacebookLocation Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookLocation(obj) {
                Country = obj.GetString("country"),
                City = obj.GetString("city"),
                Latitude = obj.GetDouble("latitude"),
                Longitude = obj.GetDouble("longitude"),
                Zip = obj.GetString("zip"),
                State = obj.GetString("state"),
                Street = obj.GetString("street")
            };

        }

        #endregion

    }

}