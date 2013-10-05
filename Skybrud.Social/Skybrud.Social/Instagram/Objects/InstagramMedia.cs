using System;
using Skybrud.Social.Interfaces;
using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Objects {
    
    public abstract class InstagramMedia : ISocialTimelineEntry {

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

        /// <summary>
        /// Array of tags used with this media.
        /// </summary>
        public string[] Tags { get; internal set; }

        /// <summary>
        /// The filter used for this media.
        /// </summary>
        public string Filter { get; internal set; }

        /// <summary>
        /// Specifies the time of creation in UTC/GMT 0.
        /// </summary>
        public DateTime Created { get; internal set; }

        public string Link { get; internal set; }
        public int LikeCount { get; internal set; }
        public int CommentCount { get; internal set; }
        public InstagramComment[] Comments { get; internal set; }

        public InstagramImageSummary Images { get; private set; }
        
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
            // Make default constructor internal
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
        /// Loads a media from the JSON file at the specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public static InstagramMedia LoadJson(string path) {
            return JsonObject.LoadJson(path, Parse);
        }

        /// <summary>
        /// Gets a media from the specified JSON string.
        /// </summary>
        /// <param name="json">The JSON string representation of the object.</param>
        public static InstagramMedia ParseJson(string json) {
            return JsonObject.ParseJson(json, Parse);
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
                    Videos = obj.GetObject("videos", InstagramVideoSummary.Parse)
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
                media.Images = obj.GetObject("images", InstagramImageSummary.Parse);
                media.Caption = obj.GetObject("caption", InstagramComment.Parse);
                media.User = obj.GetObject("user", InstagramUser.Parse);
                media.Location = obj.GetObject("location", InstagramLocation.Parse);
            }

            return media;

        }

        /// <summary>
        /// Gets an array of media from the specified instance of <var>JsonArray</var>.
        /// </summary>
        /// <param name="array">The instance of <var>JsonArray</var> to parse.</param>
        public static InstagramMedia[] ParseMultiple(JsonArray array) {
            return array == null ? new InstagramMedia[0] : array.ParseMultiple(Parse);
        }

        #endregion

    }

}
