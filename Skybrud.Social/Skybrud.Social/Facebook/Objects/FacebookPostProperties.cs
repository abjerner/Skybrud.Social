using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects {
    
    public class FacebookPostProperties {

        public string Name { get; internal set; }
        public string Text { get; internal set; }
        public string Href { get; internal set; }

        public static FacebookPostProperties Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookPostProperties {
                Name = obj.GetString("name"),
                Text = obj.GetString("text"),
                Href = obj.GetString("href")
            };
        }

        public static FacebookPostProperties[] ParseMultiple(JsonArray array) {
            return array == null ? new FacebookPostProperties[0] : array.ParseMultiple(Parse);
        }

    }

}