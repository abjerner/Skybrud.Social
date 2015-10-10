using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Objects {

    /// <summary>
    /// Class representing a summary of an Instagram user.
    /// </summary>
    public class InstagramUserSummary : SocialJsonObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the user.
        /// </summary>
        public long Id { get; private set; }

        /// <summary>
        /// Gets the username of the user.
        /// </summary>
        public string Username { get; private set; }

        /// <summary>
        /// Gets the full name of the users.
        /// </summary>
        public string FullName { get; private set; }

        /// <summary>
        /// Gets the profile picture of the user.
        /// </summary>
        public string ProfilePicture { get; private set; }

        #endregion

        #region Constructors

        private InstagramUserSummary(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Loads a user from the JSON file at the specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public static InstagramUserSummary LoadJson(string path) {
            return JsonObject.LoadJson(path, Parse);
        }

        /// <summary>
        /// Gets a user from the specified JSON string.
        /// </summary>
        /// <param name="json">The JSON string representation of the object.</param>
        public static InstagramUserSummary ParseJson(string json) {
            return JsonObject.ParseJson(json, Parse);
        }

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <code>InstagramUserSummary</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to be parsed.</param>
        /// <returns>Returns an instance of <code>InstagramUserSummary</code>.</returns>
        public static InstagramUserSummary Parse(JsonObject obj) {
            if (obj == null) return null;
            string fullname = obj.GetString("full_name");
            return new InstagramUserSummary(obj) {
                Id = obj.GetInt64("id"),
                Username = obj.GetString("username"),
                FullName = String.IsNullOrEmpty(fullname) ? null : fullname,
                ProfilePicture = obj.GetString("profile_picture")
            };
        }

        #endregion

    }

}