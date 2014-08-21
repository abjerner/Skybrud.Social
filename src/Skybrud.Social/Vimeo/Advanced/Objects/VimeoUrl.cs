using Skybrud.Social.Interfaces;
using Skybrud.Social.Json;

namespace Skybrud.Social.Vimeo.Advanced.Objects {

    public class VimeoUrl : SocialJsonObject {

        public string Type { get; private set; }
        public string Content { get; private set; }

        public static VimeoUrl[] Parse(JsonArray array) {
            return array == null ? new VimeoUrl[0] : array.ParseMultiple(Parse);
        }

        public static VimeoUrl Parse(JsonObject obj) {
            if (obj == null) return null;
            return new VimeoUrl {
                JsonObject = obj,
                Type = obj.GetString("type"),
                Content = obj.GetString("_content")
            };
        }

    }

}