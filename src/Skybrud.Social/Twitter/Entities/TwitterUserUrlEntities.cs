using System.Collections.Generic;
using System.Linq;
using Skybrud.Social.Json;

namespace Skybrud.Social.Twitter.Entities {

    public class TwitterUserUrlEntities : ITwitterEntities {

        #region Properties

        /// <summary>
        /// Gets an array of URLs specified in the URL field for a user. Twitter users can only
        /// specify a single URL in their profiles, but an array is still returned by the Twitter
        /// API.
        /// </summary>
        public TwitterUrlEntity[] Urls { get; private set; }

        #endregion

        #region Constructors

        private TwitterUserUrlEntities() { }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a collection of all entities in ascending order.
        /// </summary>
        public IEnumerable<TwitterBaseEntity> GetAll() {
            List<TwitterBaseEntity> temp = new List<TwitterBaseEntity>();
            temp.AddRange(Urls);
            return temp.OrderBy(x => x.StartIndex);
        }

        /// <summary>
        /// Gets a collection of all entities in descending order.
        /// </summary>
        public IEnumerable<TwitterBaseEntity> GetAllReversed() {
            List<TwitterBaseEntity> temp = new List<TwitterBaseEntity>();
            temp.AddRange(Urls);
            return temp.OrderByDescending(x => x.StartIndex);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses a given instance of <code>JsonObject</code>.
        /// </summary>
        /// <param name="entities">The <code>JsonObject</code> to be parsed.</param>
        public static TwitterUserUrlEntities Parse(JsonObject entities) {
            if (entities == null) return null;
            return new TwitterUserUrlEntities {
                Urls = entities.GetArray("urls", TwitterUrlEntity.Parse)
            };
        }

        #endregion

    }

}