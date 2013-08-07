using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects {

    public class FacebookLikes {

        public int Count { get; private set; }
        public FacebookIdName[] Data { get; private set; }

        public static FacebookLikes Parse(JsonObject obj) {
            if (obj == null) return new FacebookLikes { Data = new FacebookIdName[0] };
            return new FacebookLikes {
                Count = obj.GetInt("count"),
                Data = obj.GetArray("data", FacebookIdName.Parse) ?? new FacebookIdName[0]
            };
        }

    }

}
