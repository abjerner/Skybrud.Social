using Skybrud.Social.Facebook.Objects.Pagination;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects.Photos {

    public class FacebookPhotosCollection : SocialJsonObject {

        #region Properties

        public FacebookPhoto[] Data { get; private set; }

        public FacebookCursorBasedPagination Paging { get; private set; }

        #endregion
        
        #region Constructors

        private FacebookPhotosCollection(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static FacebookPhotosCollection Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookPhotosCollection(obj) {
                Data = obj.GetArray("data", FacebookPhoto.Parse),
                Paging = obj.GetObject("paging", FacebookCursorBasedPagination.Parse)
            };
        }

        #endregion
    
    }

}