using System.Collections.Generic;
using Skybrud.Social.Json;

namespace Skybrud.Social.Twitter.Entities {

    public class TwitterHashTagEntity : TwitterBaseEntity {

        public string Text { get; private set; }

        public static IEnumerable<TwitterHashTagEntity> ParseMultiple(JsonArray entities) {
            List<TwitterHashTagEntity> temp = new List<TwitterHashTagEntity>();
            if (entities != null) {
                for (int i = 0; i < entities.Length; i++) {
                    temp.Add(Parse(entities.GetObject(i)));
                }
            }
            return temp;
        }

        public static TwitterHashTagEntity Parse(JsonObject entity) {
            return new TwitterHashTagEntity {
                Text = entity.GetString("text"),
                StartIndex = entity.GetArray("indices").GetInt32(0),
                EndIndex = entity.GetArray("indices").GetInt32(1)
            };
        }

    }

}
