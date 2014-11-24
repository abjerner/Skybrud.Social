using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects.Pages {

    public class FacebookRestaurantServices : SocialJsonObject {

        #region Properties

        /// <summary>
        /// Gets whether the restaurant is kids-friendly.
        /// </summary>
        public bool Kids { get; private set; }

        /// <summary>
        /// Gets whether the restaurant has delivery service.
        /// </summary>
        public bool Delivery { get; private set; }

        /// <summary>
        /// Gets whether the restaurant welcomes walkins.
        /// </summary>
        public bool Walkins { get; private set; }

        /// <summary>
        /// Gets whether the restaurant has catering service.
        /// </summary>
        public bool Catering { get; private set; }

        /// <summary>
        /// Gets whether the restaurant takes reservations.
        /// </summary>
        public bool Reserve { get; private set; }

        /// <summary>
        /// Gets whether the restaurant is group-friendly.
        /// </summary>
        public bool Groups { get; private set; }

        /// <summary>
        /// Gets whether the restaurant has waiters.
        /// </summary>
        public bool Waiter { get; private set; }

        /// <summary>
        /// Gets whether the restaurant has outdoor seating.
        /// </summary>
        public bool Outdoor { get; private set; }

        /// <summary>
        /// Gets whether the restaurant has takeout service.
        /// </summary>
        public bool Takeout { get; private set; }

        #endregion

        #region Constructor

        private FacebookRestaurantServices(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static FacebookRestaurantServices Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookRestaurantServices(obj) {
                Kids = obj.GetBoolean("kids"),
                Delivery = obj.GetBoolean("delivery"),
                Walkins = obj.GetBoolean("walkins"),
                Catering = obj.GetBoolean("catering"),
                Reserve = obj.GetBoolean("reserve"),
                Groups = obj.GetBoolean("groups"),
                Waiter = obj.GetBoolean("waiter"),
                Outdoor = obj.GetBoolean("outdoor"),
                Takeout = obj.GetBoolean("takeout")
            };

        }

        #endregion

    }

}