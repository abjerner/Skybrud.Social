using System;
using Skybrud.Social.Interfaces;
using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Objects {
    
    /// <summary>
    /// Abstract class representing an Instagram media. Concrete classes are <code>InstagramImage</code> and <code>InstagramVideo</code>.
    /// </summary>
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
        /// Gets the ID of the media.
        /// </summary>
        public string Id { get; internal set; }

        /// <summary>
        /// Gets the type of the media.
        /// </summary>
        public string Type { get; internal set; }

        /// <summary>
        /// Gets an array of tags used with this media.
        /// </summary>
        public string[] Tags { get; internal set; }

        /// <summary>
        /// Gets the filter used for this media.
        /// </summary>
        public string Filter { get; internal set; }

        /// <summary>
        /// Specifies the time of creation in UTC/GMT 0.
        /// </summary>
        public DateTime Created { get; internal set; }

        /// <summary>
        /// Gets the link (URL) of the page on instagram.com for the media.
        /// </summary>
        public string Link { get; internal set; }

        /// <summary>
        /// Gets the amount of likes the media has received. This equals calling <code>Likes.Count</code>.
        /// </summary>
        public int LikeCount { get; internal set; }

        /// <summary>
        /// Gets the amount of comments the media has received. This equals calling <code>Comments.Count</code>.
        /// </summary>
        public int CommentCount { get; internal set; }

        /// <summary>
        /// Gets an array of comments of the media. If the media has received many comments, this array may just be a
        /// subset of all the comments.
        /// </summary>
        public InstagramComment[] Comments { get; internal set; }

        /// <summary>
        /// Gets a summary of the image formats available for this Instagram media. The image formats are available
        /// for both images and videos.
        /// </summary>
        public InstagramImageSummary Images { get; private set; }

        /// <summary>
        /// Gets the URL of the low resolution format. This equals calling <code>Images.LowResolution.Url</code>.
        /// </summary>
        public string LowRes {
            get { return Images.LowResolution.Url; }
        }
        
        /// <summary>
        /// Gets the URL of the thumbnail format. This equals calling <code>Images.Thumbnail.Url</code>.
        /// </summary>
        public string Thumbnail {
            get { return Images.Thumbnail.Url; }
        }

        /// <summary>
        /// Gets the URL of the standard resolution format. This equals calling <code>Images.StandardResolution.Url</code>.
        /// </summary>
        public string Standard {
            get { return Images.StandardResolution.Url; }
        }

        /// <summary>
        /// Gets the comment representing the caption of the media.
        /// </summary>
        public InstagramComment Caption { get; set; }

        /// <summary>
        /// Gets the caption text of the media, or <code>null</code> if not specified.
        /// </summary>
        public string CaptionText {
            get { return Caption == null ? null : Caption.Text; }
        }

        /// <summary>
        /// Gets an object with information about the user who posted the media.
        /// </summary>
        public InstagramUser User { get; private set; }

        /// <summary>
        /// Gets the location of the media, or <code>null</code> if not specified.
        /// </summary>
        public InstagramLocation Location { get; private set; }

        /// <summary>
        /// Gets an array of users tagged in the photo.
        /// </summary>
        public InstagramTaggedUser[] UsersInPhoto { get; private set; }

        /// <summary>
        /// Gets the creation date of the media. This property is just an alias of the <code>Created</code> property.
        /// </summary>
        public DateTime Date {
            get { return Created; }
        }

        /// <summary>
        /// Gets an array of likes of the media. If the media has received many likes, this array may just be a subset
        /// of all the likes.
        /// </summary>
        public InstagramUserSummary[] Likes { get; internal set; }

        /// <summary>
        /// Gets the creation date of the media. This property is just an alias of the <code>Created</code> property.
        /// </summary>
        public DateTime SortDate {
            get { return Date; }
        }

        #endregion

        #region Constructors

        internal InstagramMedia(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Loads a media from the JSON file at the specified <code>path</code>.
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
        /// Parses the specified <code>obj</code> into an instance of <code>InstagramMedia</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to be parsed.</param>
        /// <returns>Returns an instance of <code>InstagramMedia</code>.</returns>
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
                media.Created = obj.GetInt64("created_time", SocialUtils.GetDateTimeFromUnixTime);
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