using Skybrud.Social.Interfaces;
using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Objects {
    
    public class InstagramMediaSummary : SocialJsonObject {

        #region Properties

        public string Url { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        #endregion

        #region Constructors

        internal InstagramMediaSummary() {
            // Hide default constructor
        }

        #endregion

        #region Static methods

        public static InstagramMediaSummary Parse(JsonObject obj) {
            if (obj == null) return new InstagramMediaSummary();
            return new InstagramMediaSummary {
                JsonObject = obj,
                Url = obj.GetString("url"),
                Width = obj.GetInt("width"),
                Height = obj.GetInt("height")
            };
        }

        #endregion

    }

}