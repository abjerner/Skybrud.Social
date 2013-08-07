using System;
using System.Collections;
using System.Linq;
using System.Xml.Linq;
using Skybrud.Social.Interfaces;
using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Objects {

    public class InstagramImage : InstagramMedia {

        #region Constructor(s)

        internal InstagramImage() {
            // make default constructor internal
        }

        #endregion

        #region Member methods

        public override XElement ToXElement() {
            XElement xTags = new XElement("Tags");
            foreach (string tag in Tags) {
                xTags.Add(new XElement("Tag", tag));
            }
            return new XElement(
                "Image",
                new XAttribute("Id", Id),
                new XElement("Created", Created.ToString("r")),
                new XElement("Link", Link),
                User.ToXElement(),
                xTags,
                Caption == null ? new XElement("Caption") : new XElement("Caption", Caption.ToXElement()),
                new XElement("Comments", Comments.Select(c => c.ToXElement())),
                new XElement(
                    "Images",
                    new XElement("Thumbnail", Thumbnail),
                    new XElement("LowRes", LowRes),
                    new XElement("Standard", Standard)
                )
            );
        }

        #endregion

        #region Static methods
        
        public new static InstagramImage Parse(JsonObject obj) {
            return InstagramMedia.Parse(obj) as InstagramImage;
        }

        public new static InstagramImage[] ParseMultiple(JsonArray array) {
            return array == null ? new InstagramImage[0] : array.ParseMultiple(Parse);
        }

        #endregion

    }

}