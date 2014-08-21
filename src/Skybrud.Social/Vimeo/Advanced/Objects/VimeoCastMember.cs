using Skybrud.Social.Interfaces;
using Skybrud.Social.Json;

namespace Skybrud.Social.Vimeo.Advanced.Objects {
    
    public class VimeoCastMember : SocialJsonObject {
        
        public int Id { get; private set; }
        public string Username { get; private set; }
        public string DisplayName { get; private set; }
        public string Role { get; private set; }

        public static VimeoCastMember[] Parse(JsonArray array) {
            return array == null ? new VimeoCastMember[0] : array.ParseMultiple(Parse);
        }

        public static VimeoCastMember Parse(JsonObject obj) {
            if (obj == null) return null;
            return new VimeoCastMember {
                JsonObject = obj,
                Id = obj.GetInt("id"),
                Username = obj.GetString("username"),
                DisplayName = obj.GetString("display_name"),
                Role = obj.GetString("role")
            };
        }
    
    }

}
