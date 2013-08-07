using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Objects {

    public class InstagramVideo : InstagramMedia {

        #region Nested classes

        public class VideoSummary {

            public MediaSummary LowResolution { get; private set; }
            public MediaSummary StandardResolution { get; private set; }

            public XElement ToXElement() {
                return new XElement(
                    "Videos",
                    LowResolution.ToXElement("Low"),
                    StandardResolution.ToXElement("Standard")
                );
            }

            public static VideoSummary Parse(JsonObject obj) {
                if (obj == null) return null;
                return new VideoSummary {
                    LowResolution = obj.GetObject("low_resolution", MediaSummary.Parse),
                    StandardResolution = obj.GetObject("standard_resolution", MediaSummary.Parse)
                };
            }
        
        }

        #endregion

        #region Properties

        public VideoSummary Videos { get; internal set; }

        #endregion

        #region Constructor(s)

        internal InstagramVideo() {
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
                "Video",
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
                ),
                Videos.ToXElement()
            );
        }

        #endregion

        #region Static methods
        
        public new static InstagramVideo Parse(JsonObject obj) {
            return InstagramMedia.Parse(obj) as InstagramVideo;
        }

        public new static InstagramVideo[] ParseMultiple(JsonArray array) {
            return array == null ? new InstagramVideo[0] : array.ParseMultiple(Parse);
        }

        #endregion

    }

}