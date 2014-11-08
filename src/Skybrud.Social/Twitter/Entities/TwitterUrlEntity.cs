using System.Collections.Generic;
using Skybrud.Social.Json;

namespace Skybrud.Social.Twitter.Entities {

    public class TwitterUrlEntity : TwitterBaseEntity {

        public string Url { get; private set; }
        public string ExpandedUrl { get; private set; }
        public string DisplayUrl { get; private set; }

        public static IEnumerable<TwitterUrlEntity> ParseMultiple(JsonArray entities) {
            List<TwitterUrlEntity> temp = new List<TwitterUrlEntity>();
            if (entities != null) {
                for (int i = 0; i < entities.Length; i++) {
                    temp.Add(Parse(entities.GetObject(i)));
                }
            }
            return temp;
        }

        public static TwitterUrlEntity Parse(JsonObject entity) {
            return new TwitterUrlEntity {
                Url = entity.GetString("url"),
                ExpandedUrl = entity.GetString("expanded_url"),
                DisplayUrl = entity.GetString("display_url"),
                StartIndex = entity.GetArray("indices").GetInt32(0),
                EndIndex = entity.GetArray("indices").GetInt32(1)
            };
        }

    }

}
