using Newtonsoft.Json;
using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Objects {
    
    /// <summary>
    /// Class describing the position of a tagged user in a photo.
    /// </summary>
    public class InstagramPosition : SocialJsonObject {

        #region Properties

        /// <summary>
        /// The Y coordinate of the position.
        /// </summary>
        [JsonProperty("y")]
        public double Y { get; private set; }

        /// <summary>
        /// The X coordinate of the position.
        /// </summary>
        [JsonProperty("x")]
        public double X { get; private set; }

        #endregion

        #region Constructors

        private InstagramPosition(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <code>InstagramPosition</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to be parsed.</param>
        /// <returns>Returns an instance of <code>InstagramPosition</code>.</returns>
        public static InstagramPosition Parse(JsonObject obj) {
            if (obj == null) return null;
            return new InstagramPosition(obj) {
                X = obj.GetDouble("x"),
                Y = obj.GetDouble("y")
            };
        }

        #endregion

    }

}