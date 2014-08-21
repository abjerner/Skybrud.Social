using System.Collections.Generic;
using Skybrud.Social.Json;

namespace Skybrud.Social.Twitter.Entities {

    public class TwitterMediaEntity : TwitterBaseEntity {

        public long Id { get; private set; }
        public string IdStr { get; private set; }
        public string MediaUrl { get; private set; }
        public string MediaUrlHttps { get; private set; }
        public string Url { get; private set; }
        public string DisplayUrl { get; private set; }
        public string ExpandedUrl { get; private set; }
        public string Type { get; private set; }
        public long SourceStatusId { get; private set; }

        public static IEnumerable<TwitterMediaEntity> ParseMultiple(JsonArray entities) {
            List<TwitterMediaEntity> temp = new List<TwitterMediaEntity>();
            if (entities != null) {
                for (int i = 0; i < entities.Length; i++) {
                    temp.Add(Parse(entities.GetObject(i)));
                }
            }
            return temp;
        }

        public static TwitterMediaEntity Parse(JsonObject entity) {
            return new TwitterMediaEntity {
                Id = entity.GetLong("id"),
                IdStr = entity.GetString("id_str"),
                StartIndex = entity.GetArray("indices").GetInt(0),
                EndIndex = entity.GetArray("indices").GetInt(1),
                MediaUrl = entity.GetString("media_url"),
                MediaUrlHttps = entity.GetString("media_url_https"),
                Url = entity.GetString("url"),
                DisplayUrl = entity.GetString("display_url"),
                ExpandedUrl = entity.GetString("expanded_url"),
                Type = entity.GetString("type"),
                //SourceStatusId = entity.source_status_id
            };
        }

    }

}
