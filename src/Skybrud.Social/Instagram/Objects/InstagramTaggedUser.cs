using Newtonsoft.Json;
using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Objects {

    /// <summary>
    /// Class representing information about the user tagged in a media.
    /// </summary>
    public class InstagramTaggedUser : SocialJsonObject {

        #region Properties

        /// <summary>
        /// Gets the posision of the user in the media.
        /// </summary>
        [JsonProperty("position")]
        public InstagramPosition Position { get; private set; }

        /// <summary>
        /// Gets information about the tagged user.
        /// </summary>
        [JsonProperty("user")]
        public InstagramUserSummary User { get; private set; }

        #endregion

        #region Constructors

        private InstagramTaggedUser(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <code>InstagramTaggedUser</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to be parsed.</param>
        /// <returns>Returns an instance of <code>InstagramTaggedUser</code>.</returns>
        public static InstagramTaggedUser Parse(JsonObject obj) {
            if (obj == null) return null;
            return new InstagramTaggedUser(obj) {
                Position = obj.GetObject("position", InstagramPosition.Parse),
                User = obj.GetObject("user", InstagramUserSummary.Parse)
            };
        }

        #endregion

    }

}