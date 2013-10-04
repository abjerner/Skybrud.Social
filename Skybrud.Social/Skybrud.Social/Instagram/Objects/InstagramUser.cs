using System;
using System.IO;
using System.Xml.Linq;
using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Objects {

    public class InstagramUser {

        #region Properties

        /// <summary>
        /// Gets the internal JsonObject the object was created from.
        /// </summary>
        public JsonObject JsonObject { get; private set; }

        public long Id { get; private set; }
        public string Username { get; private set; }
        public string FullName { get; private set; }
        public string ProfilePicture { get; private set; }
        public string Website { get; private set; }
        public string Bio { get; private set; }

        #endregion

        #region Constructor(s)

        private InstagramUser() {
            // make constructor private
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
        /// Save the object to a JSON file at the specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to save the file.</param>
        public void SaveJson(string path) {
            JsonObject.SaveJson(path);
        }

        /// <summary>
        /// Gets an XML string representing the object.
        /// </summary>
        public XElement ToXElement() {
            return new XElement(
                "User",
                new XAttribute("Id", Id),
                new XElement("Username", Username),
                new XElement("FullName", FullName),
                new XElement("ProfilePicture", ProfilePicture),
                new XElement("Website", Website),
                new XElement("Bio", Bio)
            );
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Load a user from the JSON file at the specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public static InstagramUser LoadJson(string path) {
            return ParseJson(File.ReadAllText(path));
        }

        /// <summary>
        /// Gets a user from the specified JSON string.
        /// </summary>
        /// <param name="json">The JSON string representation of the object.</param>
        public static InstagramUser ParseJson(string json) {
            return Parse(JsonConverter.ParseObject(json));
        }
        
        /// <summary>
        /// Gets a user from the specified <var>XElement</var>.
        /// </summary>
        /// <param name="xUser">The instance of <var>XElement</var> to parse.</param>
        [Obsolete(
            "This method will must likely be removed in the future since the server responses " +
            "are retrieved as JSON rather than XML."
        )]
        public static InstagramUser Parse(XElement xUser) {
            string website = SocialUtils.GetElementValueOrDefault<string>(xUser, "Website");
            string bio = SocialUtils.GetElementValueOrDefault<string>(xUser, "Bio");
            return new InstagramUser {
                Id = SocialUtils.GetAttributeValue<long>(xUser, "Id"),
                Username = SocialUtils.GetElementValue<string>(xUser, "Username"),
                FullName = SocialUtils.GetElementValue<string>(xUser, "FullName"),
                ProfilePicture = SocialUtils.GetElementValue<string>(xUser, "ProfilePicture"),
                Website = String.IsNullOrEmpty(website) ? null : website,
                Bio = String.IsNullOrEmpty(bio) ? null : bio
            };
        }

        /// <summary>
        /// Gets a user from the specified <var>JsonObject</var>.
        /// </summary>
        /// <param name="obj">The instance of <var>JsonObject</var> to parse.</param>
        public static InstagramUser Parse(JsonObject obj) {
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
