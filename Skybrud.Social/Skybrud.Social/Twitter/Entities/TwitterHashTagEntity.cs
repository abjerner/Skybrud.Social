using System.Collections.Generic;
using Skybrud.Social.Json;

namespace Skybrud.Social.Twitter.Entities {

    public class TwitterHashTagEntitity : TwitterBaseEntity {

        public string Text { get; private set; }

        public static IEnumerable<TwitterHashTagEntitity> ParseMultiple(JsonArray entities) {
            List<TwitterHashTagEntitity> temp = new List<TwitterHashTagEntitity>();
            if (entities != null) {
                for (int i = 0; i < entities.Length; i++) {
                    temp.Add(Parse(entities.GetObject(i)));
                }
            }
            return temp;
        }

        public static TwitterHashTagEntitity Parse(JsonObject entity) {
            return new TwitterHashTagEntitity {
                Text = entity.GetString("text"),
                StartIndex = entity.GetArray("indices").GetInt(0),
                EndIndex = entity.GetArray("indices").GetInt(1)
            };
        }

    }

}
