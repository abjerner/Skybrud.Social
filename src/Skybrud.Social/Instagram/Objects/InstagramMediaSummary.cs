using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Objects {
    
    /// <summary>
    /// Class representing a summary of a image or video format available for an Instagram media.
    /// </summary>
    public class InstagramMediaSummary : SocialJsonObject {

        #region Properties

        /// <summary>
        /// Gets the URL of the format.
        /// </summary>
        public string Url { get; private set; }

        /// <summary>
        /// Gets the width of the format.
        /// </summary>
        public int Width { get; private set; }
        
        /// <summary>
        /// Gets the height of the format.
        /// </summary>
        public int Height { get; private set; }

        #endregion

        #region Constructors

        internal InstagramMediaSummary(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <code>InstagramMediaSummary</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to be parsed.</param>
        /// <returns>Returns an instance of <code>InstagramMediaSummary</code>.</returns>
        public static InstagramMediaSummary Parse(JsonObject obj) {
            if (obj == null) return new InstagramMediaSummary(null);
            return new InstagramMediaSummary(obj) {
                Url = obj.GetString("url"),
                Width = obj.GetInt32("width"),
                Height = obj.GetInt32("height")
            };
        }

        #endregion

    }

}