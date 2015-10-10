using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Objects {

    /// <summary>
    /// Class representing an Instagram user.
    /// </summary>
    public class InstagramUser : SocialJsonObject {

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
        /// Gets the full name of the user. A user may not have specified a full name.
        /// </summary>
        public string FullName { get; private set; }

        /// <summary>
        /// Gets the profile picture of the user.
        /// </summary>
        public string ProfilePicture { get; private set; }

        /// <summary>
        /// Gets the website of the user. A user may not have specified a website.
        /// </summary>
        public string Website { get; private set; }

        /// <summary>
        /// Gets the bio of the user. A user may not have specified a bio.
        /// </summary>
        public string Bio { get; private set; }

        /// <summary>
        /// Gets a reference to various statistics about the user.
        /// </summary>
        public InstagramUserCounts Counts { get; private set; }

        #endregion

        #region Constructors

        private InstagramUser(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Loads a user from the JSON file at the specified <code>path</code>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public static InstagramUser LoadJson(string path) {
            return JsonObject.LoadJson(path, Parse);
        }

        /// <summary>
        /// Gets a user from the specified JSON string.
        /// </summary>
        /// <param name="json">The JSON string representation of the object.</param>
        public static InstagramUser ParseJson(string json) {
            return JsonObject.ParseJson(json, Parse);
        }

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <code>InstagramUser</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to be parsed.</param>
        /// <returns>Returns an instance of <code>InstagramUser</code>.</returns>
        public static InstagramUser Parse(JsonObject obj) {
            if (obj == null) return null;
            string fullname = obj.GetString("full_name");
            string picture = obj.GetString("profile_picture");
            string website = obj.GetString("website");
            string bio = obj.GetString("bio");
            return new InstagramUser(obj) {
                Id = obj.GetInt64("id"),
                Username = obj.GetString("username"),
                FullName = String.IsNullOrEmpty(fullname) ? null : fullname,
                ProfilePicture = String.IsNullOrEmpty(picture) ? null : picture,
                Website = String.IsNullOrEmpty(website) ? null : website,
                Bio = String.IsNullOrEmpty(bio) ? null : bio,
                Counts = obj.GetObject("counts", InstagramUserCounts.Parse)
            };
        }

        #endregion

    }

}
