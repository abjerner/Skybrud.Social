using Skybrud.Social.Facebook.Exceptions;
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

        public static FacebookPhotosCollection ParseJson(string json) {
            return JsonConverter.ParseObject(json, Parse);
        }

        public static FacebookPhotosCollection Parse(JsonObject obj) {
            if (obj == null) return null;
            if (obj.HasValue("error")) throw obj.GetObject("error", FacebookException.Parse);
            return new FacebookPhotosCollection(obj) {
                Data = obj.GetArray("data", FacebookPhoto.Parse),
                Paging = FacebookPaging.Parse(obj.GetObject("paging"))
            };
        }
    
    }

}