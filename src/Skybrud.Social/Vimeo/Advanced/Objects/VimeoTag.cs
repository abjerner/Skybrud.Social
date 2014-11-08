using Skybrud.Social.Json;

namespace Skybrud.Social.Vimeo.Advanced.Objects {
    
    public class VimeoTag : SocialJsonObject {

        #region Properties

        public int Author { get; private set; }
        public int Id { get; private set; }
        public string Normalized { get; private set; }
        public string Url { get; private set; }
        public string Content { get; private set; }

        #endregion

        #region Constructors

        private VimeoTag(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static VimeoTag Parse(JsonObject obj) {
            if (obj == null) return null;
            return new VimeoTag(obj) {
                Id = obj.GetInt32("id"),
                Author = obj.GetInt32("author"),
                Normalized = obj.GetString("normalized"),
                Url = obj.GetString("url"),
                Content = obj.GetString("_content")
            };
        }

        #endregion

    }

}