using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Skybrud.Social.Interfaces;
using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Objects {

    public abstract class InstagramMedia : ISocialTimelineEntry {
        
        #region Nested classes

        public class MediaSummary {

            public string Url { get; private set; }
            public int Width { get; private set; }
            public int Height { get; private set; }

            public XElement ToXElement(string name) {
                return new XElement(
                    name,
                    new XAttribute("Url", Url),
                    new XAttribute("Width", Width),
                    new XAttribute("Height", Height)
                );
            }

            public static MediaSummary Parse(JsonObject obj) {
                if (obj == null) return new MediaSummary();
                return new MediaSummary {
                    Url = obj.GetString("url"),
                    Width = obj.GetInt("width"),
                    Height = obj.GetInt("height")
                };
            }

        }

        public class ImageSummary {

            public MediaSummary LowResolution { get; private set; }
            public MediaSummary Thumbnail { get; private set; }
            public MediaSummary StandardResolution { get; private set; }

            public XElement ToXElement() {
                return new XElement(
                    "Images",
                    LowResolution.ToXElement("Low"),
                    Thumbnail.ToXElement("Thumbnail"),
                    StandardResolution.ToXElement("Standard")
                );
            }

            public static ImageSummary Parse(JsonObject obj) {
                if (obj == null) return new ImageSummary {
                    LowResolution = new MediaSummary(),
                    Thumbnail = new MediaSummary(),
                    StandardResolution = new MediaSummary()
                };
                return new ImageSummary {
                    LowResolution = obj.GetObject("low_resolution", MediaSummary.Parse),
                    Thumbnail = obj.GetObject("thumbnail", MediaSummary.Parse),
                    StandardResolution = obj.GetObject("standard_resolution", MediaSummary.Parse)
                };
            }

        }

        #endregion

        #region Properties

        public string Id { get; internal set; }
        public string Type { get; internal set; }
        public string[] Tags { get; internal set; }
        public string Filter { get; internal set; }

        /// <summary>
        /// Specifies the time of creation in UTC/GMT 0.
        /// </summary>
        public DateTime Created { get; internal set; }

        public string Link { get; internal set; }
        public int LikeCount { get; internal set; }
        public int CommentCount { get; internal set; }
        public InstagramComment[] Comments { get; internal set; }

        public ImageSummary Images { get; private set; }
        
        public string Thumbnail {
            get { return Images.Thumbnail.Url; }
        }

        public string LowRes {
            get { return Images.LowResolution.Url; }
        }

        public string Standard {
            get { return Images.StandardResolution.Url; }
        }

        public InstagramComment Caption { get; set; }
        public string CaptionText {
            get { return Caption == null ? null : Caption.Text; }
        }

        public InstagramUser User { get; private set; }
        public InstagramLocation Location { get; private set; }

        public DateTime Date {
            get { return Created; }
        }

        public InstagramUserSummary[] Likes { get; internal set; }

        public DateTime SortDate {
            get { return Date; }
        }

        #endregion


        #region Constructor(s)

        internal InstagramMedia() {
            // make default constructor internal
        }

        #endregion

        #region Member methods

        public abstract XElement ToXElement();

        #endregion

        #region Static methods

        public static InstagramMedia Parse(JsonObject obj) {

            JsonObject comments = obj.GetObject("comments");
            JsonObject likes = obj.GetObject("likes");

            string type = obj.GetString("type");

            InstagramMedia media = null;

            if (type == "image") {
                media = new InstagramImage();
            } else if (type == "video") {
                media = new InstagramVideo {
                    Videos = obj.GetObject("videos", InstagramVideo.VideoSummary.Parse)
                };
            }

            if (media != null) {
                media.Id = obj.GetString("id");
                media.Type = type;
                media.Tags = obj.GetArray("tags").Cast<string>();
                media.Created = SocialUtils.GetDateTimeFromUnixTime(obj.GetLong("created_time"));
                media.Link = obj.GetString("link");
                media.Filter = obj.GetString("filter");
                media.CommentCount = comments.GetInt("count");
                media.Comments = comments.GetArray("data", InstagramComment.Parse);
                media.LikeCount = likes.GetInt("count");
                media.Images = obj.GetObject("images", ImageSummary.Parse);
                media.Caption = obj.GetObject("caption", InstagramComment.Parse);
                media.User = obj.GetObject("user", InstagramUser.Parse);
                media.Location = obj.GetObject("location", InstagramLocation.Parse);
            }

            return media;

        }

        public static InstagramMedia[] ParseMultiple(JsonArray array) {
            return array == null ? new InstagramMedia[0] : array.ParseMultiple(Parse);
        }

        #endregion

    }

}
