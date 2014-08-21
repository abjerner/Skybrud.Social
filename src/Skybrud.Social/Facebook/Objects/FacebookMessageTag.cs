using System.Collections.Generic;
using Skybrud.Social.Interfaces;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects {

    public class FacebookMessageTag : SocialJsonObject {

        public long Id { get; private set; }
        public string Name { get; private set; }
        public string Type { get; private set; }
        public int Offset { get; private set; }
        public int Length { get; private set; }

        public static FacebookMessageTag Parse(JsonObject obj) {
            return new FacebookMessageTag {
                JsonObject = obj,
                Id = obj.GetLong("id"),
                Name = obj.GetString("name"),
                Type = obj.GetString("type"),
                Offset = obj.GetInt("offset"),
                Length = obj.GetInt("length")
            };
        }

        public static FacebookMessageTag[] ParseMultiple(JsonArray array) {
            return array == null ? new FacebookMessageTag[0] : array.ParseMultiple(Parse);
        }

        public static FacebookMessageTag[] ParseMultiple(JsonObject obj) {
            if (obj == null) return null;
            List<FacebookMessageTag> temp = new List<FacebookMessageTag>();
            foreach (string key in obj.Keys) {
                temp.AddRange(obj.GetArray(key, Parse));
            }
            return temp.ToArray();
        }

    }

}
