using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Objects {
    
    public class InstagramImageSummary {

        #region Properties

        public InstagramMediaSummary LowResolution { get; private set; }
        public InstagramMediaSummary Thumbnail { get; private set; }
        public InstagramMediaSummary StandardResolution { get; private set; }

        #endregion

        #region Constructors

        private InstagramImageSummary() {
            // Hide default constructor
        }

        #endregion

        #region Static methods

        public static InstagramImageSummary Parse(JsonObject obj) {
            if (obj == null) return new InstagramImageSummary {
                LowResolution = new InstagramMediaSummary(),
                Thumbnail = new InstagramMediaSummary(),
                StandardResolution = new InstagramMediaSummary()
            };
            return new InstagramImageSummary {
                LowResolution = obj.GetObject("low_resolution", InstagramMediaSummary.Parse),
                Thumbnail = obj.GetObject("thumbnail", InstagramMediaSummary.Parse),
                StandardResolution = obj.GetObject("standard_resolution", InstagramMediaSummary.Parse)
            };
        }

        #endregion

    }

}