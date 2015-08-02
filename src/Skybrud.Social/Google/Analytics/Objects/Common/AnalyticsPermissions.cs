using Skybrud.Social.Json;

namespace Skybrud.Social.Google.Analytics.Objects.Common {
    
    /// <summary>
    /// Class describing the permissions to an Analytics account.
    /// </summary>
    public class AnalyticsPermissions : GoogleApiObject {

        #region Properties

        /// <summary>
        /// Gets an array of permissions to the parent account.
        /// </summary>
        public string[] Effective { get; private set; }

        #endregion

        #region Constructors

        private AnalyticsPermissions(JsonObject obj) : base(obj) {
            Effective = obj.GetStringArray("effective") ?? new string[0];
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <code>AnalyticsPermissions</code> from the specified <code>JsonObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        public static AnalyticsPermissions Parse(JsonObject obj) {
            return obj == null ? null : new AnalyticsPermissions(obj);
        }

        #endregion

    }

}