using Skybrud.Social.Facebook.Objects.Pagination;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects.Events {

    public class FacebookEventsCollection : SocialJsonObject {

        #region Properties

        public FacebookEventSummary[] Data { get; private set; }

        public FacebookCursorBasedPagination Paging { get; private set; }

        #endregion

        #region Constructors

        private FacebookEventsCollection(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static FacebookEventsCollection Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookEventsCollection(obj) {
                Data = obj.GetArray("data", FacebookEventSummary.Parse),
                Paging = obj.GetObject("paging", FacebookCursorBasedPagination.Parse)
            };
        }

        #endregion

    }

}