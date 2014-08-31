using Skybrud.Social.Interfaces;
using Skybrud.Social.Json;

namespace Skybrud.Social.Vimeo.Advanced.Objects {
    
    public class VimeoThumbnail : SocialJsonObject {

        public int Width { get; private set; }
        public int Height { get; private set; }
        public string Url { get; private set; }

        public static VimeoThumbnail[] Parse(JsonArray array) {
            return array == null ? new VimeoThumbnail[0] : array.ParseMultiple(Parse);
        }

        public static VimeoThumbnail Parse(JsonObject obj) {
            if (obj == null) return null;
            return new VimeoThumbnail {
                JsonObject = obj,
                Width = obj.GetInt("width"),
                Height = obj.GetInt("height"),
                Url = obj.GetString("_content")
            };
        }

    }

}
