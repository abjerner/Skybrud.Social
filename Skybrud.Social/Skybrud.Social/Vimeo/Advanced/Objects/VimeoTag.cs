using Skybrud.Social.Json;

namespace Skybrud.Social.Vimeo.Advanced.Objects {
    
    public class VimeoTag {
        
        public int Author { get; private set; }
        public int Id { get; private set; }
        public string Normalized { get; private set; }
        public string Url { get; private set; }
        public string Content { get; private set; }

        public static VimeoTag[] Parse(JsonArray array) {
            return array == null ? new VimeoTag[0] : array.ParseMultiple(Parse);
        }

        public static VimeoTag Parse(JsonObject obj) {
            if (obj == null) return null;
            return new VimeoTag {
                Id = obj.GetInt("id"),
                Author = obj.GetInt("author"),
                Normalized = obj.GetString("normalized"),
                Url = obj.GetString("url"),
                Content = obj.GetString("_content")
            };
        }

    }

}