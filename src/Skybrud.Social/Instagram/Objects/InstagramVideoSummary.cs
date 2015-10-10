using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Objects {

    public class InstagramVideoSummary : SocialJsonObject {

        #region Properties

        /// <summary>
        /// Gets information about the low bandwidth format.
        /// </summary>
        public InstagramMediaSummary LowBandwidth { get; private set; }

        public InstagramMediaSummary LowResolution { get; private set; }
        public InstagramMediaSummary StandardResolution { get; private set; }

        #endregion

        #region Constructors

        private InstagramVideoSummary(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

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