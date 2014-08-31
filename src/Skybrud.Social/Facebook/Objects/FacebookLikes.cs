using Skybrud.Social.Interfaces;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects {

    public class FacebookLikes : SocialJsonObject {

        public int Count { get; private set; }
        public FacebookObject[] Data { get; private set; }

        public static FacebookLikes Parse(JsonObject obj) {
            if (obj == null) return new FacebookLikes { Data = new FacebookObject[0] };
            return new FacebookLikes {
                JsonObject = obj,
                Count = obj.GetInt("count"),
                Data = obj.GetArray("data", FacebookObject.Parse) ?? new FacebookObject[0]
            };
        }

    }

}
