using System.Collections.Generic;
using System.Linq;
using Skybrud.Social.Json;

namespace Skybrud.Social.Twitter.Entities {

    public class TwitterUserDescriptionEntities : ITwitterEntities {

        #region Properties

        public TwitterUrlEntity[] Urls { get; private set; }

        #endregion

        #region Constructors

        private TwitterUserDescriptionEntities() { }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a collection of all entities in an ascending order.
        /// </summary>
        public IEnumerable<TwitterBaseEntity> GetAll() {
            List<TwitterBaseEntity> temp = new List<TwitterBaseEntity>();
            temp.AddRange(Urls);
            return temp.OrderBy(x => x.StartIndex);
        }

        /// <summary>
        /// Gets a collection of all entities in an descending order.
        /// </summary>
        public IEnumerable<TwitterBaseEntity> GetAllReversed() {
            List<TwitterBaseEntity> temp = new List<TwitterBaseEntity>();
            temp.AddRange(Urls);
            return temp.OrderByDescending(x => x.StartIndex);
        }

        #endregion

        #region Static methods

        public static TwitterUserDescriptionEntities Parse(JsonObject entities) {
            if (entities == null) return null;
            return new TwitterUserDescriptionEntities {
                Urls = entities.GetArray("urls", TwitterUrlEntity.Parse)
            };
        }

        #endregion

    }

}