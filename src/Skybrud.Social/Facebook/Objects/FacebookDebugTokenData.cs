using System;
using System.Linq;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects {
    
    /// <see>
    ///     <cref>https://developers.facebook.com/docs/graph-api/reference/v2.2/debug_token#read</cref>
    /// </see>
    public class FacebookDebugTokenData : SocialJsonObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the application this access token is for.
        /// </summary>
        public long AppId { get; private set; }

        /// <summary>
        /// Gets the name of the application this access token is for.
        /// </summary>
        public string Application { get; private set; }

        /// <summary>
        /// Gets the timestamp for when the token will expire.
        /// </summary>
        public DateTime? ExpiresAt { get; private set; }

        /// <summary>
        /// Gets whether the the access token is valid.
        /// </summary>
        public bool IsValid { get; private set; }

        /// <summary>
        /// Gets the timestamp for when the token was issued.
        /// </summary>
        public DateTime? IssuedAt { get; private set; }

        /// <summary>
        /// Gets the ID of the user. The ID is only present for user access tokens.
        /// </summary>
        public string UserId { get; private set; }

        /// <summary>
        /// For user access tokens, the user will grant the app one or multiple scopes. This property will be an array
        /// of all granted scopes. For any other types of access tokens, this array will be empty.
        /// </summary>
        public FacebookScope[] Scopes { get; private set; }

        #endregion

        #region Constructors

        private FacebookDebugTokenData(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <code>FacebookDebugTokenData</code> from the specified <var>JsonObject</var>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        public static FacebookDebugTokenData Parse(JsonObject obj) {
            
            // Check if NULL
            if (obj == null) return null;

            // If an access token doesn't have an expire date, it may be specified as "0". In other scenarios, the
            // property is not present at all. In either case, we should set the "ExpiresAt" property to "NULL".
            DateTime? expiresAt = null;
            if (obj.HasValue("expires_at")) {
                int value = obj.GetInt32("expires_at");
                if (value > 0) expiresAt = SocialUtils.GetDateTimeFromUnixTime(value);
            }

            // Parse the array of scopes
            FacebookScope[] scopes = (
                from name in obj.GetArray<string>("scopes") ?? new string[0]
                select FacebookScope.GetScope(name) ?? new FacebookScope(name, null)
            ).ToArray();

            // Initialize the instance of FacebookDebugTokenData
            return new FacebookDebugTokenData(obj) {
                AppId = obj.GetInt64("app_id"),
                Application = obj.GetString("application"),
                ExpiresAt = expiresAt,
                IsValid = obj.GetBoolean("is_valid"),
                IssuedAt = obj.HasValue("issued_at") ? (DateTime?) obj.GetDateTimeFromUnixTimestamp("issued_at") : null,
                UserId = obj.GetString("user_id"),
                Scopes = scopes
            };
        
        }

        #endregion

    }

}