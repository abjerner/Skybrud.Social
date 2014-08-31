using Skybrud.Social.Json;

namespace Skybrud.Social.Vimeo.Advanced.Objects {

    public class VimeoUrl : SocialJsonObject {

        #region Properties

        public string Type { get; private set; }
        public string Content { get; private set; }

        #endregion

        #region Constructors

        private VimeoUrl(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static VimeoUrl Parse(JsonObject obj) {
            if (obj == null) return null;
            return new VimeoUrl(obj) {
                Type = obj.GetString("type"),
                Content = obj.GetString("_content")
            };
        }

        #endregion

    }

}