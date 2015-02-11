using Skybrud.Social.Json;

namespace Skybrud.Social.Twitter.Entities {

    public class TwitterUserEntities {

        #region Properties

        public TwitterUserUrlEntities Url { get; private set; }
        
        public TwitterUserDescriptionEntities Description { get; private set; }

        #endregion

        #region Constructors

        private TwitterUserEntities() { }

        #endregion

        #region Static methods

        public static TwitterUserEntities Parse(JsonObject entities) {
            if (entities == null) return null;
            return new TwitterUserEntities {
                Url = entities.GetObject("url", TwitterUserUrlEntities.Parse),
                Description = entities.GetObject("description", TwitterUserDescriptionEntities.Parse)
            };
        }

        #endregion

    }

}