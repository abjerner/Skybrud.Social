using Skybrud.Social.Interfaces;
using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Objects {
    
    /// <summary>
    /// Class representing the location of where a media (image or video) was taken. Some media may not have a location.
    /// </summary>
    public class InstagramLocation : SocialJsonObject, ILocation {

        #region Properties

        /// <summary>
        /// Gets the ID of the location.
        /// </summary>
        public long Id { get; private set; }

        /// <summary>
        /// The name of the location.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the latitude of the location. The latitude specifies the north-south position of a
        /// point on the Earth's surface.
        /// </summary>
        public double Latitude { get; private set; }

        /// <summary>
        /// Gets the longitude of the location. The longitude specifies the east-west position of a
        /// point on the Earth's surface.
        /// </summary>
        public double Longitude { get; private set; }

        #endregion

        #region Constructors

        private InstagramLocation(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Loads a location from the JSON file at the specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public static InstagramLocation LoadJson(string path) {
            return JsonObject.LoadJson(path, Parse);
        }

        /// <summary>
        /// Gets a location from the specified JSON string.
        /// </summary>
        /// <param name="json">The JSON string representation of the object.</param>
        public static InstagramLocation ParseJson(string json) {
            return JsonObject.ParseJson(json, Parse);
        }

        /// <summary>
        /// Gets a location from the specified <var>JsonObject</var>.
        /// </summary>
        /// <param name="obj">The instance of <var>JsonObject</var> to parse.</param>
        public static InstagramLocation Parse(JsonObject obj) {
            if (obj == null) return null;
            return new InstagramLocation(obj) {
                Id = obj.GetInt64("id"),
                Name = obj.GetString("name"),
                Latitude = obj.GetDouble("latitude"),
                Longitude = obj.GetDouble("longitude")
            };
        }

        #endregion

    }

}
