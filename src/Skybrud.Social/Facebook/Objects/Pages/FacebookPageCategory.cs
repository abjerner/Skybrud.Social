using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects.Pages {
    
    public class FacebookPageCategory : SocialJsonObject {

        #region Properties

        public string Id { get; internal set; }

        public string Name { get; internal set; }

        #endregion

        #region Constructors

        private FacebookPageCategory(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static FacebookPageCategory Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookPageCategory(obj) {
                Id = obj.GetString("id"),
                Name = obj.GetString("name")
            };
        }

        #endregion

    }

}