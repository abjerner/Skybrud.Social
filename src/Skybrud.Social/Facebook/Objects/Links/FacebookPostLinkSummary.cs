using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects.Links {
    
    public class FacebookPostLinkSummary : SocialJsonObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the link.
        /// </summary>
        public string Id { get; private set; }

        #endregion

        #region Constructors

        private FacebookPostLinkSummary(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static FacebookPostLinkSummary Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookPostLinkSummary(obj) {
                Id = obj.GetString("id")
            };
        }

        #endregion

    }

}