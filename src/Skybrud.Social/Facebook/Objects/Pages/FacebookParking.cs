using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects.Pages {
    
    public class FacebookParking : SocialJsonObject {

        #region Properties

        /// <summary>
        /// Indicates street parking is available.
        /// </summary>
        public bool Street { get; private set; }

        /// <summary>
        /// Indicates a parking lot is available.
        /// </summary>
        public bool Lot { get; private set; }

        /// <summary>
        /// Indicates a valet is available.
        /// </summary>
        public bool Valet { get; private set; }

        #endregion

        #region Constructor

        private FacebookParking(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static FacebookParking Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookParking(obj) {
                Street = obj.GetBoolean("street"),
                Lot = obj.GetBoolean("lot"),
                Valet = obj.GetBoolean("valet")
            };

        }

        #endregion

    }

}
