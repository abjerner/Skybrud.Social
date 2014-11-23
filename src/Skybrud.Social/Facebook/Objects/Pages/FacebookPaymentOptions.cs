using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects.Pages {
    
    public class FacebookPaymentOptions : SocialJsonObject {

        #region Properties

        /// <summary>
        /// Indicates American Express is accepted.
        /// </summary>
        public bool AmericanExpress { get; private set; }

        /// <summary>
        /// Indicates cash is accepted.
        /// </summary>
        public bool CashOnly { get; private set; }

        /// <summary>
        /// Indicates Discover accepted.
        /// </summary>
        public bool Discover { get; private set; }

        /// <summary>
        /// Indicates MasterCard is accepted.
        /// </summary>
        public bool MasterCard { get; private set; }

        /// <summary>
        /// Indicates Visa is accepted.
        /// </summary>
        public bool Visa { get; private set; }

        #endregion

        #region Constructor

        private FacebookPaymentOptions(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static FacebookPaymentOptions Parse(JsonObject obj) {
            if (obj == null) return null;
            return new FacebookPaymentOptions(obj) {
                AmericanExpress = obj.GetBoolean("amex"),
                CashOnly = obj.GetBoolean("cash_only"),
                Discover = obj.GetBoolean("discover"),
                MasterCard = obj.GetBoolean("mastercard"),
                Visa = obj.GetBoolean("visa")
            };

        }

        #endregion

    }

}
