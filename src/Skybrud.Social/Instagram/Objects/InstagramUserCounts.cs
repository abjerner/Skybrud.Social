using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Objects {

    public class InstagramUserCounts : SocialJsonObject {

        #region Properties

        public int Media { get; private set; }

        public int FollowedBy { get; private set; }

        public int Follows { get; private set; }

        #endregion

        #region Constructors

        private InstagramUserCounts(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets a user from the specified <var>JsonObject</var>.
        /// </summary>
        /// <param name="obj">The instance of <var>JsonObject</var> to parse.</param>
        public static InstagramUserCounts Parse(JsonObject obj) {
            if (obj == null) return null;
            return new InstagramUserCounts(obj) {
                Media = obj.GetInt32("media"),
                FollowedBy = obj.GetInt32("followed_by"),
                Follows = obj.GetInt32("follows")
            };
        }

        #endregion

    }

}
