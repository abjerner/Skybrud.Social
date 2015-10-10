using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Objects {

    /// <summary>
    /// Class with various statistics about a user.
    /// </summary>
    public class InstagramUserCounts : SocialJsonObject {

        #region Properties

        /// <summary>
        /// Gets the amount of media the user has uploaded.
        /// </summary>
        public int Media { get; private set; }

        /// <summary>
        /// Gets the amount of other users following the user.
        /// </summary>
        public int FollowedBy { get; private set; }

        /// <summary>
        /// Gets the amount of other users followed by the user.
        /// </summary>
        public int Follows { get; private set; }

        #endregion

        #region Constructors

        private InstagramUserCounts(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <code>InstagramUserCounts</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to be parsed.</param>
        /// <returns>Returns an instance of <code>InstagramUserCounts</code>.</returns>
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