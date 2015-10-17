using Skybrud.Social.Json;
using Skybrud.Social.Twitter.Objects.Media;

namespace Skybrud.Social.Twitter.Entities {

    public class TwitterMediaEntity : TwitterBaseEntity {

        #region Properties

        public long Id { get; private set; }
        
        public string IdStr { get; private set; }
        
        public string MediaUrl { get; private set; }
        
        public string MediaUrlHttps { get; private set; }
        
        public string Url { get; private set; }
        
        public string DisplayUrl { get; private set; }

        public string ExpandedUrl { get; private set; }

        public string Type { get; private set; }

        /// <summary>
        /// Gets an object with references to the resized formats of the media.
        /// </summary>
        public TwitterMediaFormats Sizes { get; private set; }

        /// <summary>
        /// Gets an object with video information if the media is a video, otherwise <code>null</code>.
        /// </summary>
        public TwitterVideoInfo VideoInfo { get; private set; }

        /// <summary>
        /// Gets whether the media entity has any video information.
        /// </summary>
        public bool HasVideoInfo {
            get { return VideoInfo != null; }
        }

        #endregion

        #region Constructors

        private TwitterMediaEntity() { }

        #endregion

        #region Static methods

        public static TwitterMediaEntity Parse(JsonObject entity) {
            return new TwitterMediaEntity {
                Id = entity.GetInt64("id"),
                IdStr = entity.GetString("id_str"),
                StartIndex = entity.GetArray("indices").GetInt32(0),
                EndIndex = entity.GetArray("indices").GetInt32(1),
                MediaUrl = entity.GetString("media_url"),
                MediaUrlHttps = entity.GetString("media_url_https"),
                Url = entity.GetString("url"),
                DisplayUrl = entity.GetString("display_url"),
                ExpandedUrl = entity.GetString("expanded_url"),
                Type = entity.GetString("type"),
                Sizes = entity.GetObject("sizes", TwitterMediaFormats.Parse),
                VideoInfo = entity.GetObject("video_info", TwitterVideoInfo.Parse)
            };
        }

        #endregion

    }

}