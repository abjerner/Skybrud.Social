using System;
using System.Linq;
using System.Xml.Linq;
using Skybrud.Social.Interfaces;
using Skybrud.Social.Json;

namespace Skybrud.Social.Vimeo.Simple.Objects {

    public class VimeoVideo : SocialJsonObject {

        /// <summary>
        /// The ID of the video.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Video title.
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// The description of the video.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// URL to the Video Page.
        /// </summary>
        public string Url { get; private set; }

        /// <summary>
        /// The date/time the video was uploaded on.
        /// </summary>
        public DateTime UploadedDate { get; private set; }

        /// <summary>
        /// Duration of the video.
        /// </summary>
        public TimeSpan Duration { get; private set; }

        /// <summary>
        /// The width of the video.
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        /// The height of the video.
        /// </summary>
        public int Height { get; private set; }
        
        /// <summary>
        /// List of tags.
        /// </summary>
        public string[] Tags { get; private set; }

        public static VimeoVideo Parse(XElement xVideo) {
            if (xVideo == null || xVideo.Name != "video") return null;
            return new VimeoVideo {
                Id = SocialUtils.GetElementValue<int>(xVideo, "id"),
                Title = SocialUtils.GetElementValue<string>(xVideo, "title"),
                Description = SocialUtils.GetElementValue<string>(xVideo, "description"),
                Url = SocialUtils.GetElementValue<string>(xVideo, "url"),
                UploadedDate = SocialUtils.GetElementValue<DateTime>(xVideo, "upload_date"),
                Duration = TimeSpan.FromSeconds(SocialUtils.GetElementValue<int>(xVideo, "duration")),
                Width = SocialUtils.GetElementValue<int>(xVideo, "width"),
                Height = SocialUtils.GetElementValue<int>(xVideo, "height"),
                Tags = (SocialUtils.GetElementValue<string>(xVideo, "tags") ?? "").Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
            };
        }

        public static VimeoVideo Parse(JsonObject obj) {
            if (obj == null) return null;
            return new VimeoVideo {
                JsonObject = obj,
                Id = obj.GetInt("id"),
                Title = obj.GetString("title"),
                Description = obj.GetString("description"),
                Url = obj.GetString("url"),
                UploadedDate = obj.GetDateTime("upload_date"),
                Duration = TimeSpan.FromSeconds(obj.GetInt("duration")),
                Width = obj.GetInt("width"),
                Height = obj.GetInt("height"),
                Tags = obj.GetArray("tags").Cast<string>()
            };
        }

        public static VimeoVideo[] ParseMultiple(XElement xVideos) {
            if (xVideos == null || xVideos.Name != "videos") return null;
            return (from x in xVideos.Elements("video") select Parse(x)).ToArray();
        }

        public static VimeoVideo[] ParseMultiple(JsonArray array) {
            return array == null ? new VimeoVideo[0] : array.ParseMultiple(Parse);
        }

    }

}
