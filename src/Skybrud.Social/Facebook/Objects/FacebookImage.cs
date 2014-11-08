using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects {
    
    public class FacebookImage : SocialJsonObject {

        public int Width { get; private set; }
        public int Height { get; private set; }
        public string Source { get; private set; }
        
        #region Constructors

        private FacebookImage(JsonObject obj) : base(obj) { }

        #endregion

        public static FacebookImage Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookImage(obj) {
                Width = obj.GetInt32("width"),
                Height = obj.GetInt32("height"),
                Source = obj.GetString("source")
            };
        }

    }

}