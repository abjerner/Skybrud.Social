using System;
using System.Xml.Linq;
using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Objects {

    public class InstagramUserSummary {

        #region Properties

        public long Id { get; private set; }
        public string Username { get; private set; }
        public string FullName { get; private set; }
        public string ProfilePicture { get; private set; }

        #endregion

        #region Constructor(s)

        private InstagramUserSummary() {
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
                new XElement("ProfilePicture", ProfilePicture)
            );
        }

        #endregion

        #region Static methods

        public static InstagramUserSummary Parse(XElement xUser) {
            return new InstagramUserSummary {
                Id = SocialUtils.GetAttributeValue<long>(xUser, "Id"),
                Username = SocialUtils.GetElementValue<string>(xUser, "Username"),
                FullName = SocialUtils.GetElementValue<string>(xUser, "FullName"),
                ProfilePicture = SocialUtils.GetElementValue<string>(xUser, "ProfilePicture")
            };
        }

        public static InstagramUserSummary Parse(JsonObject obj) {
            string fullname = obj.GetString("full_name");
            return new InstagramUserSummary {
                Id = obj.GetLong("id"),
                Username = obj.GetString("username"),
                FullName = String.IsNullOrEmpty(fullname) ? null : fullname,
                ProfilePicture = obj.GetString("profile_picture")
            };
        }

        public static InstagramUserSummary[] ParseMultiple(JsonArray array) {
            return array == null ? new InstagramUserSummary[0] : array.ParseMultiple(Parse);
        }

        #endregion

    }

}
