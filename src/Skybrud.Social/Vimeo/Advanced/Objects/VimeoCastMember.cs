using Skybrud.Social.Json;

namespace Skybrud.Social.Vimeo.Advanced.Objects {
    
    public class VimeoCastMember : SocialJsonObject {

        #region Properties

        public int Id { get; private set; }
        public string Username { get; private set; }
        public string DisplayName { get; private set; }
        public string Role { get; private set; }

        #endregion

        #region Constructors

        private VimeoCastMember(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static VimeoCastMember Parse(JsonObject obj) {
            if (obj == null) return null;
            return new VimeoCastMember(obj) {
                Id = obj.GetInt32("id"),
                Username = obj.GetString("username"),
                DisplayName = obj.GetString("display_name"),
                Role = obj.GetString("role")
            };
        }

        #endregion

    }

}
