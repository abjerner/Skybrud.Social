using Skybrud.Social.Json;

namespace Skybrud.Social.Twitter.Objects.Search {

    public class TwitterSearchTweetsMetaData : SocialJsonObject {

        #region Properties

        public float CompletedIn { get; private set; }
        
        public long MaxId { get; private set; }
        
        public string Query { get; private set; }
        
        public string RefreshUrl { get; private set; }
        
        public int Count { get; private set; }
        
        public long SinceId { get; private set; }

        #endregion

        #region Constructors

        public TwitterSearchTweetsMetaData(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static TwitterSearchTweetsMetaData Parse(JsonObject obj) {
            return new TwitterSearchTweetsMetaData(obj) {
                CompletedIn = obj.GetFloat("completed_in"),
                MaxId = obj.GetInt64("max_id"),
                Query = obj.GetString("query"),
                RefreshUrl = obj.GetString("refresh_url"),
                Count = obj.GetInt32("count"),
                SinceId = obj.GetInt64("since_id")
            };
        }

        #endregion

    }

}