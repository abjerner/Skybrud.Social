using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects.Accounts {
    
    public class FacebookAccountsCollection : SocialJsonObject {

        #region Properties

        public FacebookAccount[] Data { get; private set; }

        public FacebookPaging Paging { get; private set; }

        #endregion

        #region Constructors

        private FacebookAccountsCollection(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static FacebookAccountsCollection Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookAccountsCollection(obj) {
                Data = obj.GetArray("data", FacebookAccount.Parse),
                Paging = obj.GetObject("paging", FacebookPaging.Parse)
            };
        }

        #endregion
    
    }

}