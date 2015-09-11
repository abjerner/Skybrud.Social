using Skybrud.Social.Json;

namespace Skybrud.Social.Microsoft.WindowsLive.Objects.Users {
    
    public class WindowsLiveUserEmailsInfo : SocialJsonObject {

        #region Properties

        public string Preferred { get; private set; }

        public string Account { get; private set; }

        public string Personal { get; private set; }

        public string Business { get; private set; }

        #endregion

        #region Constructors

        private WindowsLiveUserEmailsInfo(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <code>WindowsLiveUserEmailsInfo</code> from the specified <code>JsonObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        public static WindowsLiveUserEmailsInfo Parse(JsonObject obj) {
            if (obj == null) return null;
            return new WindowsLiveUserEmailsInfo(obj) {
                Preferred = obj.GetString("preferred"),
                Account = obj.GetString("account"),
                Personal = obj.GetString("personal"),
                Business = obj.GetString("business")
            };
        }

        #endregion

    }

}