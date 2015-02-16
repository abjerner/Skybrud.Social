using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Objects {

    public class InstagramMetaData : SocialJsonObject {

        #region Properties

        public int Code { get; private set; }

        public string ErrorType { get; private set; }

        public string ErrorMessage { get; private set; }

        #endregion

        #region Constructors

        private InstagramMetaData(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static InstagramMetaData Parse(JsonObject obj) {
            if (obj == null) return null;
            return new InstagramMetaData(obj) {
                Code = obj.GetInt32("code"),
                ErrorType = obj.GetString("error_type"),
                ErrorMessage = obj.GetString("error_message")
            };
        }

        #endregion

    }

}