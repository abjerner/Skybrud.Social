using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Objects {
    
    /// <summary>
    /// Class representing the location of where a media (image or video) was taken. Some media may not have a location.
    /// </summary>
    public class InstagramLocation {

        #region Properties

        /// <summary>
        /// Gets the internal JsonObject the object was created from.
        /// </summary>
        public JsonObject JsonObject { get; private set; }

        /// <summary>
        /// Gets the ID of the location.
        /// </summary>
        public int Id { get; private set; }

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

        #region Constructor(s)

        private InstagramLocation() {
            // Hide default constructor
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a JSON string representing the object.
        /// </summary>
        public string ToJson() {
            return JsonObject == null ? null : JsonObject.ToJson();
        }

        /// <summary>
        /// Saves the object to a JSON file at the specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to save the file.</param>
        public void SaveJson(string path) {
            if (JsonObject != null) JsonObject.SaveJson(path);
        }

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
            return new InstagramLocation {
                JsonObject = obj,
                Id = obj.GetInt("id"),
                Name = obj.GetString("name"),
                Latitude = obj.GetDouble("latitude"),
                Longitude = obj.GetDouble("longitude")
            };
        }

        /// <summary>
        /// Gets an array of locations from the specified <var>JsonArray</var>.
        /// </summary>
        /// <param name="array">The instance of <var>JsonArray</var> to parse.</param>
        public static InstagramLocation[] ParseMultiple(JsonArray array) {
            return array == null ? new InstagramLocation[0] : array.ParseMultiple(Parse);
        }

        #endregion

    }

}
