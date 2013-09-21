using Skybrud.Social.Json;

namespace Skybrud.Social.BitBucket.Objects {

    /// <summary>
    /// Class describing a BitBucket user.
    /// </summary>
    public class BitBucketUser {

        #region Properties

        /// <summary>
        /// Gets the username of the user.
        /// </summary>
        public string Username { get; private set; }

        /// <summary>
        /// Gets the first name of the user.
        /// </summary>
        public string FirstName { get; private set; }

        /// <summary>
        /// Gets the last name of the user.
        /// </summary>
        public string LastName { get; private set; }

        /// <summary>
        /// Gets the display name of the user.
        /// </summary>
        public string DisplayName { get; private set; }

        /// <summary>
        /// Gets whether the user is team account.
        /// </summary>
        public bool IsTeam { get; private set; }

        /// <summary>
        /// Gets the secure Gravatar URL for the user's avatar.
        /// </summary>
        public string Avatar { get; private set; }

        /// <summary>
        /// Gets the relative API resource URL for the user.
        /// </summary>
        public string ResourceUri { get; private set; }

        #endregion

        #region Constructor

        internal BitBucketUser() {
            // Hide default constructor
        }

        #endregion

        #region Methods

        public static BitBucketUser Parse(JsonObject obj) {
            return new BitBucketUser {
                Username = obj.GetString("username"),
                FirstName = obj.GetString("first_name"),
                LastName = obj.GetString("last_name"),
                DisplayName = obj.GetString("display_name"),
                IsTeam = obj.GetBoolean("is_team"),
                Avatar = obj.GetString("avatar"),
                ResourceUri = obj.GetString("resource_uri")
            };
        }

        #endregion

    }

}