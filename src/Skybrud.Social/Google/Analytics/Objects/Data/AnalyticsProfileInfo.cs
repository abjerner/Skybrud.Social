using Skybrud.Social.Json;

namespace Skybrud.Social.Google.Analytics.Objects.Data {

    /// <summary>
    /// Class representing an object wih information about a profile.
    /// </summary>
    public class AnalyticsProfileInfo : GoogleApiObject  {

        #region Properties

        /// <summary>
        /// Gets the ID of the profile.
        /// </summary>
        public string ProfileId { get; private set; }

        /// <summary>
        /// Gets the ID of the parent account.
        /// </summary>
        public string AccountId { get; private set; }
        
        /// <summary>
        /// Gets the ID of the parent web property.
        /// </summary>
        public string WebPropertyId { get; private set; }
        
        /// <summary>
        /// Gets the internal ID of the parent web property.
        /// </summary>
        public string InternalWebPropertyId { get; private set; }
        
        /// <summary>
        /// Gets the name of the property.
        /// </summary>
        public string ProfileName { get; private set; }

        /// <summary>
        /// Gets the ID of the table.
        /// </summary>
        public string TableId { get; private set; }

        #endregion

        #region Constructors

        private AnalyticsProfileInfo(JsonObject obj) : base(obj) { }

        #endregion
        
        #region Static methods
        
        /// <summary>
        /// Gets an instance of <code>AnalyticsProfileInfo</code> from the specified <code>JsonObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        public static AnalyticsProfileInfo Parse(JsonObject obj) {
            if (obj == null) return null;
            return new AnalyticsProfileInfo(obj) {
                ProfileId = obj.GetString("profileId"),
                AccountId = obj.GetString("accountId"),
                WebPropertyId = obj.GetString("webPropertyId"),
                InternalWebPropertyId = obj.GetString("internalWebPropertyId"),
                ProfileName = obj.GetString("profileName"),
                TableId = obj.GetString("tableId"),
            };
        }

        #endregion

    }

}