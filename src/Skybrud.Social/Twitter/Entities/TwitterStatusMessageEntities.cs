using System.Collections.Generic;
using System.Linq;
using Skybrud.Social.Json;

namespace Skybrud.Social.Twitter.Entities {

    public class TwitterStatusMessageEntities : ITwitterEntities {

        #region Properties

        public TwitterHashTagEntity[] HashTags { get; private set; }
        
        public TwitterUrlEntity[] Urls { get; private set; }
        
        public TwitterMentionEntity[] Mentions { get; private set; }
        
        public TwitterMediaEntity[] Media { get; private set; }

        #endregion

        #region Constructors

        private TwitterStatusMessageEntities() { }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a collection of all entities in an ascending order.
        /// </summary>
        public IEnumerable<TwitterBaseEntity> GetAll() {
            List<TwitterBaseEntity> temp = new List<TwitterBaseEntity>();
            temp.AddRange(HashTags);
            temp.AddRange(Urls);
            temp.AddRange(Mentions);
            temp.AddRange(Media);
            return temp.OrderBy(x => x.StartIndex);
        }

        /// <summary>
        /// Gets a collection of all entities in an descending order.
        /// </summary>
        public IEnumerable<TwitterBaseEntity> GetAllReversed() {
            List<TwitterBaseEntity> temp = new List<TwitterBaseEntity>();
            temp.AddRange(HashTags);
            temp.AddRange(Urls);
            temp.AddRange(Mentions);
            temp.AddRange(Media);
            return temp.OrderByDescending(x => x.StartIndex);
        }

        #endregion

        #region Static methods

        public static TwitterStatusMessageEntities Parse(JsonObject entities) {
            if (entities == null) return null;
            return new TwitterStatusMessageEntities {
                HashTags = entities.GetArray("hashtags", TwitterHashTagEntity.Parse),
                Urls = entities.GetArray("urls", TwitterUrlEntity.Parse),
                Mentions = entities.GetArray("user_mentions", TwitterMentionEntity.Parse),
                Media = entities.GetArray("media", TwitterMediaEntity.Parse) ?? new TwitterMediaEntity[0]
            };
        }

        #endregion

    }

}