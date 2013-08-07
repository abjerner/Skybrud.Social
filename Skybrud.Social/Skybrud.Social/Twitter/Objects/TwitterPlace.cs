using Skybrud.Social.Json;

namespace Skybrud.Social.Twitter.Objects {

    public class TwitterPlace {

        public string Id { get; internal set; }
        public string Url { get; internal set; }
        public string Type { get; internal set; }
        public string Name { get; internal set; }
        public string FullName { get; internal set; }
        public string CountryCode { get; internal set; }
        public string Country { get; internal set; }
        public TwitterBoundingBox BoundingBox { get; internal set; }
        
        public static TwitterPlace Parse(JsonObject obj) {
            if (obj == null) return null;
            return new TwitterPlace {
                Id = obj.GetString("id"),
                Url = obj.GetString("url"),
                Type = obj.GetString("place_type"),
                Name = obj.GetString("name"),
                FullName = obj.GetString("full_name"),
                CountryCode = obj.GetString("country_code"),
                Country = obj.GetString("country"),
                BoundingBox = TwitterBoundingBox.Parse(obj.GetObject("bounding_box"))
            };
        }

        public static TwitterPlace[] ParseMultiple(JsonArray array) {
            return array == null ? new TwitterPlace[0] : array.ParseMultiple(Parse);
        }
    
    }

}
