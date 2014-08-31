using System.Collections.Generic;
using Skybrud.Social.Json;

namespace Skybrud.Social.Twitter.Entities {

    public class TwitterMentionEntity : TwitterBaseEntity {

        public long UserId { get; private set; }
        public string UserIdStr { get; private set; }
        public string ScreenName { get; private set; }
        public string Name { get; private set; }

        public static IEnumerable<TwitterMentionEntity> ParseMultiple(JsonArray mentions) {
            List<TwitterMentionEntity> temp = new List<TwitterMentionEntity>();
            if (mentions != null) {
                for (int i = 0; i < mentions.Length; i++) {
                    temp.Add(Parse(mentions.GetObject(i)));
                }
            }
            return temp;
        }

        public static TwitterMentionEntity Parse(JsonObject mention) {
            return new TwitterMentionEntity {
                UserId = mention.GetLong("id"),
                UserIdStr = mention.GetString("id_str"),
                ScreenName = mention.GetString("screen_name"),
                Name = mention.GetString("name"),
                StartIndex = mention.GetArray("indices").GetInt(0),
                EndIndex = mention.GetArray("indices").GetInt(1)
            };
        }

    }

}
