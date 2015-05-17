using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects {

    /// <summary>
    /// Class with information on how many times a given object has been shared.
    /// </summary>
    public class FacebookShares : SocialJsonObject {

        #region Properties

        /// <summary>
        /// Gets the amount of shares the object has received.
        /// </summary>
        public int Count { get; private set; }

        #endregion

        #region Constructors

        private FacebookShares(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>JsonObject</code> into an instance of <code>FacebookShares</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to be parsed.</param>
        public static FacebookShares Parse(JsonObject obj) {
            return new FacebookShares(obj) {
                Count = obj.GetInt32("count")
            };
        }

        #endregion

    }

}