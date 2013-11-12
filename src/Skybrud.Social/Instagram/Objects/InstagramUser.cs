using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Objects {

    public class InstagramUser {

        #region Properties

        /// <summary>
        /// Gets the internal JsonObject the object was created from.
        /// </summary>
        public JsonObject JsonObject { get; private set; }

        /// <summary>
        /// The ID of the user.
        /// </summary>
        public long Id { get; private set; }

        /// <summary>
        /// The username of the user.
        /// </summary>
        public string Username { get; private set; }

        /// <summary>
        /// The full name of the user. A user may not have specified a full name.
        /// </summary>
        public string FullName { get; private set; }

        /// <summary>
        /// The profile picture of the user.
        /// </summary>
        public string ProfilePicture { get; private set; }

        /// <summary>
        /// The website of the user. A user may not have specified a website.
        /// </summary>
        public string Website { get; private set; }

        /// <summary>
        /// The bio of the user. A user may not have specified a bio.
        /// </summary>
        public string Bio { get; private set; }

        #endregion

        #region Constructors

        private InstagramUser() {
            // Hide default constructor
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a JSON string representing the object.
        /// </summary>
        public string ToJson() {
            return JsonObject == null ? null : JsonObject.ToJson();
        }

        /// <summary>
        /// Saves the object to a JSON file at the specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to save the file.</param>
        public void SaveJson(string path) {
            if (JsonObject != null) JsonObject.SaveJson(path);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Loads a user from the JSON file at the specified <var>path</var>.
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
        /// Gets a user from the specified <var>JsonObject</var>.
        /// </summary>
        /// <param name="obj">The instance of <var>JsonObject</var> to parse.</param>
        public static InstagramUser Parse(JsonObject obj) {
            if (obj == null) return null;
            string fullname = obj.GetString("full_name");
            string picture = obj.GetString("profile_picture");
            string website = obj.GetString("website");
            string bio = obj.GetString("bio");
            return new InstagramUser {
                JsonObject = obj,
                Id = obj.GetLong("id"),
                Username = obj.GetString("username"),
                FullName = String.IsNullOrEmpty(fullname) ? null : fullname,
                ProfilePicture = String.IsNullOrEmpty(picture) ? null : picture,
                Website = String.IsNullOrEmpty(website) ? null : website,
                Bio = String.IsNullOrEmpty(bio) ? null : bio
            };
        }

        /// <summary>
        /// Gets an array of multiple users from the specified <var>JsonArray</var>.
        /// </summary>
        /// <param name="array">The instance of <var>JsonArray</var> to parse.</param>
        public static InstagramUser[] ParseMultiple(JsonArray array) {
            return array == null ? new InstagramUser[0] : array.ParseMultiple(Parse);
        }

        #endregion

    }

}
