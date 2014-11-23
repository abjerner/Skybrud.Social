using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects {

    public class FacebookLikesSummary : SocialJsonObject {

        public int TotalCount { get; private set; }
        
        #region Constructors

        private FacebookLikesSummary(JsonObject obj) : base(obj) { }

        #endregion

        public static FacebookLikesSummary Parse(JsonObject obj) {
            return new FacebookLikesSummary(obj) {
                TotalCount = obj.GetInt32("total_count")
            };
        }

    }

}
