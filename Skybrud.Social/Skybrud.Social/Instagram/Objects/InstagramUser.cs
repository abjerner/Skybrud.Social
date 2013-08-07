using System;
using System.Xml.Linq;
using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Objects {

    public class InstagramUser {

        #region Properties

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

        internal static InstagramUser Parse(JsonObject obj) {
            string fullname = obj.GetString("full_name");
            string picture = obj.GetString("profile_picture");
            string website = obj.GetString("website");
            string bio = obj.GetString("bio");
            return new InstagramUser {
                Id = obj.GetLong("id"),
                Username = obj.GetString("username"),
                FullName = String.IsNullOrEmpty(fullname) ? null : fullname,
                ProfilePicture = String.IsNullOrEmpty(picture) ? null : picture,
                Website = String.IsNullOrEmpty(website) ? null : website,
                Bio = String.IsNullOrEmpty(bio) ? null : bio
            };
        }

        public static InstagramUser[] ParseMultiple(JsonArray array) {
            return array == null ? new InstagramUser[0] : array.ParseMultiple(Parse);
        }

        #endregion

    }

}
