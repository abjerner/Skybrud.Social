using Skybrud.Social.Json;

namespace Skybrud.Social.Vimeo.Advanced.Objects {
    
    public class VimeoThumbnail : SocialJsonObject {

        #region Properties

        public int Width { get; private set; }
        public int Height { get; private set; }
        public string Url { get; private set; }

        #endregion

        #region Constructors

        private VimeoThumbnail(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static VimeoThumbnail Parse(JsonObject obj) {
            if (obj == null) return null;
            return new VimeoThumbnail(obj) {
                Width = obj.GetInt("width"),
                Height = obj.GetInt("height"),
                Url = obj.GetString("_content")
            };
        }

        #endregion

    }

}
