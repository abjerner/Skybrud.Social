using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects.Feed {
    
    public class FacebookFeedCollection : SocialJsonObject {

        #region Properties

        public FacebookFeedEntry[] Data { get; private set; }

        public FacebookPaging Paging { get; private set; }

        #endregion

        #region Constructors

        private FacebookFeedCollection(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static FacebookFeedCollection Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookFeedCollection(obj) {
                Data = obj.GetArray("data", FacebookFeedEntry.Parse),
                Paging = obj.GetObject("paging", FacebookPaging.Parse)
            };
        }

        #endregion
    
    }

}