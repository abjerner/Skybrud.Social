using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Objects {
    
    public class InstagramLocation {

        public int Id { get; private set; }
        public string Name { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }

        public static InstagramLocation Parse(JsonObject obj) {
            if (obj == null) return null;
            return new InstagramLocation {
                Id = obj.GetInt("id"),
                Name = obj.GetString("name"),
                Latitude = obj.GetDouble("latitude"),
                Longitude = obj.GetDouble("longitude")
            };
        }

        public static InstagramLocation[] ParseMultiple(JsonArray array) {
            return array == null ? new InstagramLocation[0] : array.ParseMultiple(Parse);
        }

    }

}
