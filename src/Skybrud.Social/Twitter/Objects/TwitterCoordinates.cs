using Skybrud.Social.Json;

namespace Skybrud.Social.Twitter.Objects {

    public class TwitterCoordinates : SocialJsonObject {

        #region Properties

        public double Latitude { get; private set; }

        public double Longitude { get; private set; }

        #endregion
        
        #region Constructors

        private TwitterCoordinates(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static TwitterCoordinates Parse(JsonObject obj) {
            if (obj == null) return null;
            return new TwitterCoordinates(obj) {
                Latitude = obj.GetArray("coordinates").GetDouble(1),
                Longitude = obj.GetArray("coordinates").GetDouble(0)
            };
        }

        public static TwitterCoordinates Parse(JsonArray array) {
            if (array == null) return null;
            return new TwitterCoordinates(null) {
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