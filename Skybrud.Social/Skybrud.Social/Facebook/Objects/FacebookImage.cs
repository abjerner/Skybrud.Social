using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects {
    
    public class FacebookImage {

        public int Width;
        public int Height;
        public string Source;

        public static FacebookImage Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookImage {
                Width = obj.GetInt("width"),
                Height = obj.GetInt("height"),
                Source = obj.GetString("source")
            };
        }

        public static FacebookImage[] ParseMultiple(JsonArray array) {
            return array == null ? new FacebookImage[0] : array.ParseMultiple(Parse);
        }

    }

}