using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects {

    public class FacebookIdName {

        public long Id { get; internal set; }
        public string Name { get; internal set; }

        public static FacebookIdName Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookIdName {
                Id = obj.GetLong("id"),
                Name = obj.GetString("name")
            };
        }

        public static FacebookIdName[] ParseMultiple(JsonArray array) {
            return array == null ? new FacebookIdName[0] : array.ParseMultiple(Parse);
        }

    }

}
