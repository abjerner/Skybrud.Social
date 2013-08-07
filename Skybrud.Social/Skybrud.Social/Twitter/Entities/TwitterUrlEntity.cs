using System.Collections.Generic;
using Skybrud.Social.Json;

namespace Skybrud.Social.Twitter.Entities {

    public class TwitterUrlEntitity : TwitterBaseEntity {

        public string Url { get; private set; }
        public string ExpandedUrl { get; private set; }
        public string DisplayUrl { get; private set; }

        public static IEnumerable<TwitterUrlEntitity> ParseMultiple(JsonArray entities) {
            List<TwitterUrlEntitity> temp = new List<TwitterUrlEntitity>();
            if (entities != null) {
                for (int i = 0; i < entities.Length; i++) {
                    temp.Add(Parse(entities.GetObject(i)));
                }
            }
            return temp;
        }

        public static TwitterUrlEntitity Parse(JsonObject entity) {
            return new TwitterUrlEntitity {
                Url = entity.GetString("url"),
                ExpandedUrl = entity.GetString("expanded_url"),
                DisplayUrl = entity.GetString("display_url"),
                StartIndex = entity.GetArray("indices").GetInt(0),
                EndIndex = entity.GetArray("indices").GetInt(1)
            };
        }

    }

}
