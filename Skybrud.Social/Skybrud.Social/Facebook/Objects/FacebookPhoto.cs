using System;
using System.Linq;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects {
    
    public class FacebookPhoto {

        public long Id { get; private set; }
        public string Name { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public string Picture { get; private set; }
        public string Source { get; private set; }
        public DateTime Created { get; private set; }
        public DateTime Updated { get; private set; }
        public FacebookImage[] Images { get; private set; }

        public FacebookImage GetImageGreaterThanOrEqualTo(int width, int height) {
            return Images.Reverse().FirstOrDefault(x => x.Width >= width && x.Height != height);
        }

        public static FacebookPhoto Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookPhoto {
                Id = obj.GetLong("id"),
                Name = obj.GetString("name"),
                Width = obj.GetInt("width"),
                Height = obj.GetInt("height"),
                Picture = obj.GetString("picture"),
                Source = obj.GetString("source"),
                Created = obj.GetDateTime("created_time"),
                Updated = obj.GetDateTime("updated_time"),
                Images = FacebookImage.ParseMultiple(obj.GetArray("images"))
            };
        }

        public static FacebookPhoto[] ParseMultiple(JsonArray array) {
            return array == null ? new FacebookPhoto[0] : array.ParseMultiple(Parse);
        }
    
    }

}
