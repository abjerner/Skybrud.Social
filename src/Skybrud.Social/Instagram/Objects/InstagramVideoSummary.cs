using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Objects {

    public class InstagramVideoSummary {

        #region Properties

        public InstagramMediaSummary LowResolution { get; private set; }
        public InstagramMediaSummary StandardResolution { get; private set; }

        #endregion

        #region Constructors

        private InstagramVideoSummary() {
            // Hide default constructor
        }

        #endregion

        #region Static methods

        public static InstagramVideoSummary Parse(JsonObject obj) {
            if (obj == null) return null;
            return new InstagramVideoSummary {
                LowResolution = obj.GetObject("low_resolution", InstagramMediaSummary.Parse),
                StandardResolution = obj.GetObject("standard_resolution", InstagramMediaSummary.Parse)
            };
        }

        #endregion
        
    }

}