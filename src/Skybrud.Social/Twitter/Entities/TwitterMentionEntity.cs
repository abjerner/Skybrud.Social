using System.Collections.Generic;
using Skybrud.Social.Json;

namespace Skybrud.Social.Twitter.Entities {

    public class TwitterMentionEntity : TwitterBaseEntity {

        #region Properties

        public long UserId { get; private set; }
        
        public string UserIdStr { get; private set; }
        
        public string ScreenName { get; private set; }
        
        public string Name { get; private set; }

        #endregion

        #region Constructors

        private TwitterMentionEntity() { }

        #endregion

        #region Static methods

        public static TwitterMentionEntity Parse(JsonObject mention) {
            return new TwitterMentionEntity {
                UserId = mention.GetInt64("id"),
                UserIdStr = mention.GetString("id_str"),
                ScreenName = mention.GetString("screen_name"),
                Name = mention.GetString("name"),
                StartIndex = mention.GetArray("indices").GetInt32(0),
                EndIndex = mention.GetArray("indices").GetInt32(1)
            };
        }

        #endregion

    }

}