using System;
using Skybrud.Social.Json;
using Skybrud.Social.Slack.Enums;

namespace Skybrud.Social.Slack.Objects.Users {
    
    public class SlackUser : SlackObject {

        #region Properties

        public string Id { get; private set; }

        public string Name { get; private set; }

        public bool IsDeleted { get; private set; }

        public string Color { get; private set; }

        public string RealName { get; private set; }

        public string TimeZone { get; private set; }

        public string TimeZoneLabel { get; private set; }

        public TimeSpan TimeZoneOffset { get; private set; }

        public SlackUserProfile Profile { get; private set; }

        public bool IsAdmin { get; private set; }
        
        public bool IsOwner { get; private set; }
        
        public bool IsPrimaryOwner { get; private set; }
        
        public bool IsRestricted { get; private set; }
        
        public bool IsUltraRestricted { get; private set; }
        
        public bool IsBot { get; private set; }
        
        public bool HasFiles { get; private set; }
        
        /// <summary>
        /// Gets whether the user has enabled 2 factor authentication.
        /// </summary>
        public bool Has2Fa { get; private set; }

        /// <summary>
        /// Gets the presence of the user.
        /// </summary>
        public SlackPresence Presence { get; private set; }

        #endregion

        #region Constructors

        private SlackUser(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <code>SlackUser</code> from the specified <code>JsonObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        public static SlackUser Parse(JsonObject obj) {
            if (obj == null) return null;
            return new SlackUser(obj) {
                Id = obj.GetString("id"),
                Name = obj.GetString("name"),
                IsDeleted = obj.GetBoolean("deleted"),
                Color = obj.GetString("color"),
                RealName = obj.GetString("real_name"),
                TimeZone = obj.GetString("tz"),
                TimeZoneLabel = obj.GetString("tz_label"),
                TimeZoneOffset = obj.GetDouble("tz_offset", TimeSpan.FromSeconds),
                Profile = obj.GetObject("profile", SlackUserProfile.Parse),
                IsAdmin = obj.GetBoolean("is_admin"),
                IsOwner = obj.GetBoolean("is_owner"),
                IsPrimaryOwner = obj.GetBoolean("is_primary_owner"),
                IsRestricted = obj.GetBoolean("is_restricted"),
                IsUltraRestricted = obj.GetBoolean("is_ultra_restricted"),
                IsBot = obj.GetBoolean("is_bot"),
                HasFiles = obj.GetBoolean("has_files"),
                Has2Fa = obj.GetBoolean("has_2fa"),
                Presence = obj.GetEnum("presence", SlackPresence.Unspecified)
            };
        }

        #endregion

    }

}