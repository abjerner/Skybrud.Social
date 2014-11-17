using Skybrud.Social.Facebook.Objects;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Collections {
    
    public class FacebookPhotosCollection : SocialJsonObject {

        public FacebookPhoto[] Data {
            get; private set;
        }

        public FacebookPaging Paging {
            get; private set;
        }
        
        #region Constructors

        private FacebookPhotosCollection(JsonObject obj) : base(obj) { }

        #endregion
        
        public static FacebookPhotosCollection Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookPhotosCollection(obj) {
                Data = obj.GetArray("data", FacebookPhoto.Parse),
                Paging = obj.GetObject("paging", FacebookPaging.Parse)
            };
        }
    
    }

}