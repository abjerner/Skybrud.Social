using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects.Posts {
    
    public class FacebookPostsCollection : SocialJsonObject {

        #region Properties

        public FacebookPost[] Data { get; private set; }

        public FacebookPaging Paging { get; private set; }

        #endregion

        #region Constructors

        private FacebookPostsCollection(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static FacebookPostsCollection Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookPostsCollection(obj) {
                Data = obj.GetArray("data", FacebookPost.Parse),
                Paging = obj.GetObject("paging", FacebookPaging.Parse)
            };
        }

        #endregion
    
    }

}