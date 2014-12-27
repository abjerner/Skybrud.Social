using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects.Events {

    public class FacebookEventVenue : SocialJsonObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the user or page.
        /// </summary>
        public string Id { get; private set; }

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
        public double? Latitude { get; private set; }

        /// <summary>
        /// Gets the longitude of the location.
        /// </summary>
        public double? Longitude { get; private set; }

        /// <summary>
        /// Gets the name of the venue.
        /// </summary>
        public string Name { get; private set; }

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

        private FacebookEventVenue(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static FacebookEventVenue Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookEventVenue(obj) {
                Id = obj.GetString("id"),
                Country = obj.GetString("country"),
                City = obj.GetString("city"),
                Latitude = obj.HasValue("latitude") ? obj.GetDouble("latitude") : (double?) null,
                Longitude = obj.HasValue("longitude") ? obj.GetDouble("longitude") : (double?) null,
                Name = obj.GetString("name"),
                Zip = obj.GetString("zip"),
                State = obj.GetString("state"),
                Street = obj.GetString("street")
            };

        }

        #endregion

    }

}