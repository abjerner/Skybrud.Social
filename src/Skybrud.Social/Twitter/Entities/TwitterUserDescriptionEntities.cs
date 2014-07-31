using System.Collections.Generic;
using System.Linq;
using Skybrud.Social.Json;

namespace Skybrud.Social.Twitter.Entities {

    public class TwitterUserDescriptionEntities {

        #region Properties

        public TwitterUrlEntity[] Urls { get; private set; }

        #endregion

        #region Constructor(s)

        private TwitterUserDescriptionEntities() {
            // Hide default constructor
        }

        #endregion

        #region Member method(s)

        public IOrderedEnumerable<TwitterBaseEntity> GetAll() {
            List<TwitterBaseEntity> temp = new List<TwitterBaseEntity>();
            temp.AddRange(Urls);
            return temp.OrderBy(x => x.StartIndex);
        }

        public IOrderedEnumerable<TwitterBaseEntity> GetAllReversed() {
            List<TwitterBaseEntity> temp = new List<TwitterBaseEntity>();
            temp.AddRange(Urls);
            return temp.OrderByDescending(x => x.StartIndex);
        }

        #endregion

        #region Static method(s)

        public static TwitterUserDescriptionEntities Parse(JsonObject entities) {
            if (entities == null) return null;
            return new TwitterUserDescriptionEntities {
                Urls = entities.GetArray("urls", TwitterUrlEntity.Parse)
            };
        }

        #endregion

    }

}