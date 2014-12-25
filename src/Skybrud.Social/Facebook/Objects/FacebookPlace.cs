using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects {
    
    public class FacebookPlace : SocialJsonObject {

        #region Properties

        public string Id { get; private set; }

        public string Name { get; private set; }

        public FacebookLocation Location { get; private set; }

        #endregion

        #region Constructor

        private FacebookPlace(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static FacebookPlace Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookPlace(obj) {
                Id = obj.GetString("id"),
                Name = obj.GetString("name"),
                Location = obj.GetObject("location", FacebookLocation.Parse)
            };

        }

        #endregion

    }

}