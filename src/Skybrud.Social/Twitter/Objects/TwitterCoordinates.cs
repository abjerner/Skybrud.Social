using Skybrud.Social.Interfaces;
using Skybrud.Social.Json;

namespace Skybrud.Social.Twitter.Objects {

    public class TwitterCoordinates : SocialJsonObject {

        #region Properties

        public double Latitude { get; internal set; }
        public double Longitude { get; internal set; }

        #endregion
        
        #region Constructor(s)

        private TwitterCoordinates() {
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
        /// Loads an object from the JSON file at the specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public static TwitterCoordinates LoadJson(string path) {
            return JsonObject.LoadJson(path, Parse);
        }

        public static TwitterCoordinates Parse(JsonObject obj) {
            if (obj == null) return null;
            return new TwitterCoordinates {
                JsonObject = obj,
                Latitude = obj.GetArray("coordinates").GetDouble(1),
                Longitude = obj.GetArray("coordinates").GetDouble(0)
            };
        }

        public static TwitterCoordinates Parse(JsonArray array) {
            if (array == null) return null;
            return new TwitterCoordinates {
                Latitude = array.GetDouble(1),
                Longitude = array.GetDouble(0)
            };
        }

        public static TwitterCoordinates[] ParseMultiple(JsonArray array) {
            if (array == null) return new TwitterCoordinates[0];
            TwitterCoordinates[] temp = new TwitterCoordinates[array.Length];
            for (int i = 0; i < array.Length; i++) {
                temp[i] = Parse(array.GetArray(i));
            }
            return temp;
        }

        #endregion

    }

}
