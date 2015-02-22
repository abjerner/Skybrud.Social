using Skybrud.Social.Json;

namespace Skybrud.Social.Google.YouTube.Objects.Videos {

    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/videos#snippet.thumbnails</cref>
    /// </see>
    public class YouTubeVideoThumbnails : GoogleApiObject {

        #region Properties

        public YouTubeVideoThumbnail Default { get; private set; }

        public YouTubeVideoThumbnail Medium { get; private set; }

        public YouTubeVideoThumbnail High { get; private set; }

        public YouTubeVideoThumbnail Standard { get; private set; }

        public YouTubeVideoThumbnail MaxRes { get; private set; }

        #endregion

        #region Constructors

        protected YouTubeVideoThumbnails(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static YouTubeVideoThumbnails Parse(JsonObject obj) {
            if (obj == null) return null;
            return new YouTubeVideoThumbnails(obj) {
                Default = obj.GetObject("default", YouTubeVideoThumbnail.Parse),
                Medium = obj.GetObject("medium", YouTubeVideoThumbnail.Parse),
                High = obj.GetObject("high", YouTubeVideoThumbnail.Parse),
                Standard = obj.GetObject("standard", YouTubeVideoThumbnail.Parse),
                MaxRes = obj.GetObject("maxres", YouTubeVideoThumbnail.Parse)
            };
        }

        #endregion

    }

}