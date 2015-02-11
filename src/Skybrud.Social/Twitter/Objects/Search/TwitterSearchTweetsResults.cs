using Skybrud.Social.Json;

namespace Skybrud.Social.Twitter.Objects.Search {

    public class TwitterSearchTweetsResults : SocialJsonObject {

        #region Properties

        public TwitterStatusMessage[] Statuses { get; private set; }
        public TwitterSearchTweetsMetaData MetaData { get; private set; }

        #endregion

        #region Constructors

        public TwitterSearchTweetsResults(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static TwitterSearchTweetsResults Parse(JsonObject obj) {
            if (obj == null) return null;
            return new TwitterSearchTweetsResults(obj) {
                Statuses = obj.GetArray("statuses", TwitterStatusMessage.Parse),
                MetaData = obj.GetObject("search_metadata", TwitterSearchTweetsMetaData.Parse)
            };
        }

        #endregion

    }

}