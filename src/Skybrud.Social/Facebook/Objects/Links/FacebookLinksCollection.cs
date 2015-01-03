using Skybrud.Social.Facebook.Objects.Pagination;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects.Links {

    public class FacebookLinksCollection : SocialJsonObject {

        #region Properties

        public FacebookLink[] Data { get; private set; }

        public FacebookCursorBasedPagination Paging { get; private set; }

        #endregion
        
        #region Constructors

        private FacebookLinksCollection(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static FacebookLinksCollection Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookLinksCollection(obj) {
                Data = obj.GetArray("data", FacebookLink.Parse),
                Paging = obj.GetObject("paging", FacebookCursorBasedPagination.Parse)
            };
        }

        #endregion
    
    }

}