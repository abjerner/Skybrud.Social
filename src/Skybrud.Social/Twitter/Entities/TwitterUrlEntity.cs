using System.Collections.Generic;
using Skybrud.Social.Json;

namespace Skybrud.Social.Twitter.Entities {

    public class TwitterUrlEntity : TwitterBaseEntity {

        #region Properties

        public string Url { get; private set; }
        
        public string ExpandedUrl { get; private set; }
        
        public string DisplayUrl { get; private set; }

        #endregion

        #region Constructors

        private TwitterUrlEntity() { }

        #endregion

        #region Static methods

        public static TwitterUrlEntity Parse(JsonObject entity) {
            return new TwitterUrlEntity {
                Url = entity.GetString("url"),
                ExpandedUrl = entity.GetString("expanded_url"),
                DisplayUrl = entity.GetString("display_url"),
                StartIndex = entity.GetArray("indices").GetInt32(0),
                EndIndex = entity.GetArray("indices").GetInt32(1)
            };
        }

        #endregion

    }

}