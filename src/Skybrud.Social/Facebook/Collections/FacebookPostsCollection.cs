using Skybrud.Social.Facebook.Objects;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Collections {
    
    public class FacebookPostsCollection : SocialJsonObject {

        public FacebookPostSummary[] Data {
            get; private set;
        }

        public FacebookPaging Paging {
            get; private set;
        }
        
        #region Constructors

        private FacebookPostsCollection(JsonObject obj) : base(obj) { }

        #endregion

        public static FacebookPostsCollection Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookPostsCollection(obj) {
                Data = obj.GetArray("data", FacebookPostSummary.Parse),
                Paging = obj.GetObject("paging", FacebookPaging.Parse)
            };
        }
    
    }

}