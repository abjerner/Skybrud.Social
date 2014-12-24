using Skybrud.Social.Facebook.Objects;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Collections {
    
    public class FacebookAlbumsCollection : SocialJsonObject {

        #region Properties

        public FacebookAlbum[] Data { get; private set; }

        public FacebookPaging Paging { get; private set; }

        #endregion

        #region Constructors

        private FacebookAlbumsCollection(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static FacebookAlbumsCollection Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookAlbumsCollection(obj) {
                Data = obj.GetArray("data", FacebookAlbum.Parse),
                Paging = obj.GetObject("paging", FacebookPaging.Parse)
            };
        }

        #endregion
    
    }

}