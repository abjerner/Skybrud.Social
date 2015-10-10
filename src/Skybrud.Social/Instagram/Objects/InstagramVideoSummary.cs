using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Objects {

    /// <summary>
    /// Class representing a summary of the video formats available for an Instagram media.
    /// </summary>
    public class InstagramVideoSummary : SocialJsonObject {

        #region Properties

        /// <summary>
        /// Gets information about the low bandwidth format.
        /// </summary>
        public InstagramMediaSummary LowBandwidth { get; private set; }

        /// <summary>
        /// Gets information about the low resolution format.
        /// </summary>
        public InstagramMediaSummary LowResolution { get; private set; }

        /// <summary>
        /// Gets information about the standard resolution format.
        /// </summary>
        public InstagramMediaSummary StandardResolution { get; private set; }

        #endregion

        #region Constructors

        private InstagramVideoSummary(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <code>InstagramVideoSummary</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to be parsed.</param>
        /// <returns>Returns an instance of <code>InstagramVideoSummary</code>.</returns>
        public static InstagramVideoSummary Parse(JsonObject obj) {
            if (obj == null) return null;
            return new InstagramVideoSummary(obj) {
                LowBandwidth = obj.GetObject("low_bandwidth", InstagramMediaSummary.Parse),
                LowResolution = obj.GetObject("low_resolution", InstagramMediaSummary.Parse),
                StandardResolution = obj.GetObject("standard_resolution", InstagramMediaSummary.Parse)
            };
        }

        #endregion
        
    }

}