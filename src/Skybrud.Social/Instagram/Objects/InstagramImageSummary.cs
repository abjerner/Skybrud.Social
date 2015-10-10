using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Objects {

    /// <summary>
    /// Class representing a summary of the image formats available for an Instagram media.
    /// </summary>
    public class InstagramImageSummary : SocialJsonObject {

        #region Properties

        /// <summary>
        /// Gets a summary of the low resolution format.
        /// </summary>
        public InstagramMediaSummary LowResolution { get; private set; }
        
        /// <summary>
        /// Gets a summary of the thumbnail format.
        /// </summary>
        public InstagramMediaSummary Thumbnail { get; private set; }

        /// <summary>
        /// Gets a summary of the standard resolution format.
        /// </summary>
        public InstagramMediaSummary StandardResolution { get; private set; }

        #endregion

        #region Constructors

        private InstagramImageSummary(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <code>InstagramImageSummary</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to be parsed.</param>
        /// <returns>Returns an instance of <code>InstagramImageSummary</code>.</returns>
        public static InstagramImageSummary Parse(JsonObject obj) {
            if (obj == null) return null;
            return new InstagramImageSummary(obj) {
                LowResolution = obj.GetObject("low_resolution", InstagramMediaSummary.Parse),
                Thumbnail = obj.GetObject("thumbnail", InstagramMediaSummary.Parse),
                StandardResolution = obj.GetObject("standard_resolution", InstagramMediaSummary.Parse)
            };
        }

        #endregion

    }

}