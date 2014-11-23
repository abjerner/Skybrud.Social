using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects.Pagination {

    public class FacebookCursorBasedPagination : SocialJsonObject {

        #region Properties

        public FacebookCursors Cursors { get; private set; }

        public string Previous { get; private set; }

        public string Next { get; private set; }

        #endregion

        #region Constructor

        public FacebookCursorBasedPagination(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static FacebookCursorBasedPagination Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookCursorBasedPagination(obj) {
                Cursors = obj.GetObject("cursors", FacebookCursors.Parse),
                Previous = obj.GetString("previous"),
                Next = obj.GetString("next")
            };
        }

        #endregion

    }
}
