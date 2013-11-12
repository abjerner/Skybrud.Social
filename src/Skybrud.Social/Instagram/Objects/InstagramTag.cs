using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Objects {

    /// <summary>
    /// Class representing a tag in the Instagram API.
    /// </summary>
    public class InstagramTag {

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

        internal InstagramTag() {
            // Hide default constructor
        }

        #endregion

        #region Methods

        public static InstagramTag Parse(JsonObject obj) {
            return new InstagramTag {
                MediaCount = obj.GetLong("media_count"),
                Name = obj.GetString("name")
            };
        }

        #endregion

    }

}