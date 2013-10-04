using System;
using System.IO;
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

        /// <summary>
        /// Gets the internal JsonObject the object was created from.
        /// </summary>
        public JsonObject JsonObject { get; private set; }

        /// <summary>
        /// The ID of the media.
        /// </summary>
        public string Id { get; internal set; }

        /// <summary>
        /// The type of the media.
        /// </summary>
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

        [Obsolete(
            "This method will must likely be removed in the future since the server responses " +
            "are retrieved as JSON rather than XML."
        )]
        public abstract XElement ToXElement();

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
            File.WriteAllText(path, ToJson());
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Load a media from the JSON file at the specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public static InstagramMedia LoadJson(string path) {
            return ParseJson(File.ReadAllText(path));
        }

        /// <summary>
        /// Gets a media from the specified JSON string.
        /// </summary>
        /// <param name="json">The JSON string representation of the object.</param>
        public static InstagramMedia ParseJson(string json) {
            return Parse(JsonConverter.ParseObject(json));
        }

        /// <summary>
        /// Gets a media from the specified <var>JsonObject</var>.
        /// </summary>
        /// <param name="obj">The instance of <var>JsonObject</var> to parse.</param>
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
                media.JsonObject = obj;
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
