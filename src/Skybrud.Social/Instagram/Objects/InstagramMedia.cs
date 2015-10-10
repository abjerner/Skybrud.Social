using System;
using Skybrud.Social.Interfaces;
using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Objects {
    
    public abstract class InstagramMedia : SocialJsonObject, ISocialTimelineEntry {

        #region Properties

        // A photo/media may specify an attribution property, but the Instagram documentation has
        // no information regarding this property. However this Google Groups discussion sheds a
        // little light on what attribution is:
        //
        // https://groups.google.com/forum/#!topic/instagram-api-developers/KvGH1cnjljQ
        //
        // However since I haven't been able to find any media with the attribution property, and
        // that the official documentation doesn't have any information about this property, it is
        // currently not supported in Skybrud.Social.

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

        /// <summary>
        /// Gets an array of users tagged in the photo.
        /// </summary>
        public InstagramTaggedUser[] UsersInPhoto { get; private set; }

        public DateTime Date {
            get { return Created; }
        }

        public InstagramUserSummary[] Likes { get; internal set; }

        public DateTime SortDate {
            get { return Date; }
        }

        #endregion

        #region Constructors

        internal InstagramMedia(JsonObject obj) : base(obj) {
            // Hide default constructor
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Loads a media from the JSON file at the specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        [Obsolete]
        public static InstagramMedia LoadJson(string path) {
            // TODO: Remove for v1.0
            return JsonObject.LoadJson(path, Parse);
        }

        /// <summary>
        /// Gets a media from the specified JSON string.
        /// </summary>
        /// <param name="json">The JSON string representation of the object.</param>
        [Obsolete]
        public static InstagramMedia ParseJson(string json) {
            // TODO: Remove for v1.0
            return JsonObject.ParseJson(json, Parse);
        }

        /// <summary>
        /// Gets a media from the specified <var>JsonObject</var>.
        /// </summary>
        /// <param name="obj">The instance of <var>JsonObject</var> to parse.</param>
        public static InstagramMedia Parse(JsonObject obj) {

            if (obj == null) return null;

            JsonObject comments = obj.GetObject("comments");
            JsonObject likes = obj.GetObject("likes");

            string type = obj.GetString("type");

            InstagramMedia media = null;

            if (type == "image") {
                media = new InstagramImage(obj);
            } else if (type == "video") {
                media = new InstagramVideo(obj) {
                    Videos = obj.GetObject("videos", InstagramVideoSummary.Parse)
                };
            }

            if (media != null) {
                media.Id = obj.GetString("id");
                media.Type = type;
                media.Tags = obj.GetArray("tags").Cast<string>();
                media.Created = SocialUtils.GetDateTimeFromUnixTime(obj.GetInt64("created_time"));
                media.Link = obj.GetString("link");
                media.Filter = obj.GetString("filter");
                media.CommentCount = comments.GetInt32("count");
                media.Comments = comments.GetArray("data", InstagramComment.Parse);
                media.LikeCount = likes.GetInt32("count");
                media.Likes = likes.GetArray("data", InstagramUserSummary.Parse);
                media.Images = obj.GetObject("images", InstagramImageSummary.Parse);
                media.Caption = obj.GetObject("caption", InstagramComment.Parse);
                media.User = obj.GetObject("user", InstagramUser.Parse);
                media.Location = obj.GetObject("location", InstagramLocation.Parse);
                media.UsersInPhoto = obj.GetArray("users_in_photo", InstagramTaggedUser.Parse);
            }

            return media;

        }

        #endregion

    }

}
