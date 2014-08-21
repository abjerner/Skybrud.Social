using System;
using Skybrud.Social.Interfaces;
using Skybrud.Social.Json;

namespace Skybrud.Social.Vimeo.Advanced.Objects {
    
    public class VimeoVideo : SocialJsonObject, ISocialTimelineEntry {

        #region Properties

        /// <summary>
        /// The ID of the video.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Specifies whether the videos has a HD resolution.
        /// </summary>
        public bool IsHd { get; private set; }

        /// <summary>
        /// Whether the video is transcoding.
        /// </summary>
        public bool IsTranscoding { get; private set; }

        /// <summary>
        /// The privacy of the video.
        /// </summary>
        public string Privacy { get; private set; }

        /// <summary>
        /// The license of the video (if any).
        /// </summary>
        public string License { get; private set; }

        /// <summary>
        /// The title of the video.
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// The description of the video (if any).
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// The upload date of the video. The Vimeo Advanced API doesn't
        /// specify a timezone, so GMT is assumed.
        /// </summary>
        public DateTime UploadDate { get; private set; }

        /// <summary>
        /// The modified date of the video. The Vimeo Advanced API doesn't
        /// specify a timezone, so GMT is assumed.
        /// </summary>
        public DateTime ModifiedDate { get; private set; }

        /// <summary>
        /// The number of plays.
        /// </summary>
        public int Plays { get; private set; }

        /// <summary>
        /// The number of likes.
        /// </summary>
        public int Likes { get; private set; }

        /// <summary>
        /// The number of comments.
        /// </summary>
        public int Comments { get; private set; }

        /// <summary>
        /// The width of the video.
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        /// The height of the video.
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// The onwer of the video.
        /// </summary>
        public VimeoVideoOwner Owner { get; private set; }

        /// <summary>
        /// The duration of the video.
        /// </summary>
        public TimeSpan Duration { get; private set; }

        /// <summary>
        /// The tags associated with the video.
        /// </summary>
        public VimeoTag[] Tags { get; private set; }

        /// <summary>
        /// Thumbnails of the video in various sizes.
        /// </summary>
        public VimeoThumbnail[] Thumbnails { get; private set; }

        /// <summary>
        /// The cast members of the video.
        /// </summary>
        public VimeoCastMember[] Cast { get; private set; }

        /// <summary>
        /// The URLs of the video.
        /// </summary>
        public VimeoUrl[] Urls { get; private set; }

        /// <summary>
        /// A date for sorting as specified in the <var>ISocialTimelineEntry</var>
        /// interface. This value of this property is the same as <var>UploadDate</var>.
        /// </summary>
        public DateTime SortDate {
            get { return UploadDate; }
        }

        #endregion

        #region Static initializers

        public static VimeoVideo[] Parse(JsonArray array) {
            return array == null ? new VimeoVideo[0] : array.ParseMultiple(Parse);
        }
        
        public static VimeoVideo Parse(JsonObject obj) {
            if (obj == null) return null;
            return new VimeoVideo {
                JsonObject = obj,
                Id = obj.GetInt("id"),
                IsHd = obj.GetString("is_hd") == "1",
                IsTranscoding = obj.GetString("is_transcoding") == "1",
                Privacy = obj.GetString("privacy"),
                License = VimeoUtils.TrimToNull(obj.GetString("license")),
                Title = obj.GetString("title"),
                Description = VimeoUtils.TrimToNull(obj.GetString("description")),
                UploadDate = obj.GetDateTime("upload_date").ToUniversalTime(),
                ModifiedDate = obj.GetDateTime("modified_date").ToUniversalTime(),
                Likes = obj.GetInt("number_of_likes"),
                Plays = obj.GetInt("number_of_plays"),
                Comments = obj.GetInt("number_of_comments"),
                Width = obj.GetInt("width"),
                Height = obj.GetInt("height"),
                Owner = obj.GetObject("owner", VimeoVideoOwner.Parse),
                Duration = TimeSpan.FromSeconds(obj.GetInt("duration")),
                Tags = VimeoUtils.ParseFromParent(obj, "tags", "tag", VimeoTag.Parse),
                Cast = VimeoUtils.ParseFromParent(obj, "cast", "member", VimeoCastMember.Parse),
                Thumbnails = VimeoUtils.ParseFromParent(obj, "thumbnails", "thumbnail", VimeoThumbnail.Parse),
                Urls = VimeoUtils.ParseFromParent(obj, "urls", "url", VimeoUrl.Parse)
            };
        }

        #endregion

    }

}