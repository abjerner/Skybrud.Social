using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects {

    public class FacebookShares : SocialJsonObject {

        #region Properties

        public int Count { get; private set; }

        #endregion

        #region Constructor

        private FacebookShares(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static FacebookShares Parse(JsonObject obj) {
            return new FacebookShares(obj) {
                Count = obj.GetInt32("id")
            };
        }

        #endregion

    }

}
