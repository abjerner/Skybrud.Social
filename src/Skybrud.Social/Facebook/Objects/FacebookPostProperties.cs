using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects {
    
    public class FacebookPostProperties : SocialJsonObject {

        #region Properties

        public string Name { get; internal set; }
        public string Text { get; internal set; }
        public string Href { get; internal set; }

        #endregion

        #region Constructors

        private FacebookPostProperties(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static FacebookPostProperties Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookPostProperties(obj) {
                Name = obj.GetString("name"),
                Text = obj.GetString("text"),
                Href = obj.GetString("href")
            };
        }

        #endregion

    }

}