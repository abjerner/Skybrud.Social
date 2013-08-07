using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Objects {

    public class InstagramComment {

        public long Id { get; internal set; }
        public DateTime Created { get; internal set; }
        public string Text { get; internal set; }
        public InstagramUserSummary User { get; internal set; }

        public XElement ToXElement() {
            return new XElement(
                "Comment",
                new XAttribute("Id", Id),
                new XElement("Created", Created.ToString("r")),
                new XElement("Text", Text),
                User.ToXElement()
            );
        }

        public static InstagramComment Parse(XElement xComment) {
            if (xComment == null) return null;
            return new InstagramComment {
                Id = SocialUtils.GetAttributeValue<long>(xComment, "Id"),
                Created = SocialUtils.GetElementValue<DateTime>(xComment, "Created"),
                Text = SocialUtils.GetElementValue<string>(xComment, "Text"),
                User = InstagramUserSummary.Parse(xComment.Element("User"))
            };
        }

        public static InstagramComment Parse(JsonObject obj) {
            if (obj == null) return null;
            return new InstagramComment {
                Id = obj.GetLong("id"),
                Created = SocialUtils.GetDateTimeFromUnixTime(obj.GetLong("created_time")),
                Text = obj.GetString("text"),
                User = InstagramUserSummary.Parse(obj.GetObject("from"))
            };
        }

        public static InstagramComment[] ParseMultiple(JsonArray array) {
            return array == null ? new InstagramComment[0] : array.ParseMultiple(Parse);
        }

    }

}
