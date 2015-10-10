using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Objects {

    /// <summary>
    /// Class representing a tag in the Instagram API.
    /// </summary>
    public class InstagramTag : SocialJsonObject {

        #region Properties

        /// <summary>
        /// The amount of media using this tag.
        /// </summary>
        public long MediaCount { get; private set; }

        /// <summary>
        /// The name of the tag.
        /// </summary>
        public string Name { get; private set; }

        #endregion

        #region Constructors

        private InstagramTag(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <code>InstagramTag</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to be parsed.</param>
        /// <returns>Returns an instance of <code>InstagramTag</code>.</returns>
        public static InstagramTag Parse(JsonObject obj) {
            return new InstagramTag(obj) {
                MediaCount = obj.GetInt64("media_count"),
                Name = obj.GetString("name")
            };
        }

        #endregion

    }

}