using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects.Likes {

    public class FacebookLikesSummary : SocialJsonObject {

        #region Properties

        /// <summary>
        /// Gets the total number of people who liked.
        /// </summary>
        public int TotalCount { get; private set; }

        #endregion

        #region Constructors

        private FacebookLikesSummary(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static FacebookLikesSummary Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookLikesSummary(obj) {
                TotalCount = obj.GetInt32("total_count")
            };
        }

        #endregion

    }

}