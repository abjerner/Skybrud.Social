using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects.Pagination {
    
    public class FacebookCursors : SocialJsonObject {

        #region Properties

        public string After { get; private set; }

        public string Before { get; private set; }

        #endregion

        #region Constructor

        public FacebookCursors(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static FacebookCursors Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookCursors(obj) {
                After = obj.GetString("after"),
                Before = obj.GetString("before")
            };
        }

        #endregion

    }

}