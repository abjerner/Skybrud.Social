using System.IO;
using Skybrud.Social.Json;

namespace Skybrud.Social.BitBucket.Objects {

    /// <summary>
    /// Class describing a BitBucket user.
    /// </summary>
    public class BitBucketUser {

        private JsonObject _json;

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

        #region Member methods

        /// <summary>
        /// Gets a JSON string representing the user.
        /// </summary>
        public string ToJson() {
            return _json == null ? null : _json.ToJson();
        }

        /// <summary>
        /// Save the user to a JSON file at the specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to save the file.</param>
        public void Save(string path) {
            File.WriteAllText(path, ToJson());
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Load a user from the JSON file at thr specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public static BitBucketUser Load(string path) {
            return ParseJson(File.ReadAllText(path));
        }

        /// <summary>
        /// Gets a user from the specified JSON string.
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static BitBucketUser ParseJson(string json) {
            return Parse(JsonConverter.ParseObject(json));
        }

        /// <summary>
        /// Gets a user from the specified <var>JsonObject</var>.
        /// </summary>
        /// <param name="obj">The object to parse.</param>
        public static BitBucketUser Parse(JsonObject obj) {
            if (obj == null) return null;
            return new BitBucketUser {
                _json = obj,
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