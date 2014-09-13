using Newtonsoft.Json;
using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Objects {

    public class InstagramTaggedUser : SocialJsonObject {

        #region Properties

        [JsonProperty("position")]
        public InstagramPosition Position { get; private set; }

        [JsonProperty("user")]
        public InstagramUserSummary User { get; private set; }

        #endregion

        #region Constructors

        public InstagramTaggedUser(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static InstagramTaggedUser Parse(JsonObject obj) {
            if (obj == null) return null;
            return new InstagramTaggedUser(obj) {
                Position = obj.GetObject("position", InstagramPosition.Parse),
                User = obj.GetObject("user", InstagramUserSummary.Parse)
            };
        }

        #endregion

    }

}
