using Skybrud.Social.Facebook.Objects.Pagination;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects.Albums {
    
    public class FacebookAlbumsCollection : SocialJsonObject {

        #region Properties

        public FacebookAlbum[] Data { get; private set; }

        public FacebookCursorBasedPagination Paging { get; private set; }

        #endregion

        #region Constructors

        private FacebookAlbumsCollection(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static FacebookAlbumsCollection Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookAlbumsCollection(obj) {
                Data = obj.GetArray("data", FacebookAlbum.Parse),
                Paging = obj.GetObject("paging", FacebookCursorBasedPagination.Parse)
            };
        }

        #endregion
    
    }

}