using System;
using Skybrud.Social.Interfaces;
using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects.Videos {
    
    /// <summary>
    /// Class representing a Facebook video.
    /// </summary>
    /// <see>
    ///     <cref>https://developers.facebook.com/docs/graph-api/reference/video/</cref>
    /// </see>
    public class FacebookVideo : SocialJsonObject, ISocialTimelineEntry {

        #region Properties

        /// <summary>
        /// Gets an instance of <see cref="DateTime"/> representing when the video was created (added to Facebook).
        /// </summary>
        public DateTime CreatedTime { get; private set; }
        
        /// <summary>
        /// Gets the description of the video.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Gets a HTML element that may be embedded in a web page to play the video.
        /// </summary>
        public string EmbedHtml  { get; private set; }

        /// <summary>
        /// Gets the ID of the video.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Gets a ? with the different formats of the video.
        /// </summary>
        public FacebookVideoFormat[] Format { get; private set; }

        /// <summary>
        /// Gets information about the profile that created the video.
        /// </summary>
        public FacebookFrom From { get; private set; }
        
        /// <summary>
        /// Gets the duration of the video.
        /// </summary>
        public TimeSpan Length { get; private set; }
        
        /// <summary>
        /// Gets the URL representing the permalink to the video page.
        /// </summary>
        public string PermalinkUrl { get; private set; }
        
        /// <summary>
        /// Gets the URL for the thumbnail picture of the video.
        /// </summary>
        public string Picture { get; private set; }

        /// <summary>
        /// Gets the URL to the raw, playable video file.
        /// </summary>
        public string Source { get; private set; }

        /// <summary>
        /// Gets the URL to the raw, playable video file.
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// Gets an instance of <see cref="DateTime"/> representing when the video was last updated.
        /// </summary>
        public DateTime UpdatedTime { get; private set; }
        
        /// <summary>
        /// Gets an instance of <see cref="DateTime"/> representing when the video was created (added to Facebook).
        /// </summary>
        public DateTime SortDate {
            get { return CreatedTime; }
        }

        #endregion

        #region Constructors

        private FacebookVideo(JsonObject obj) : base(obj) {
            // backdated_time_granularity
            // content_category
            CreatedTime = obj.GetDateTime("created_time");
            Description = obj.GetString("description");
            EmbedHtml = obj.GetString("embed_html");
            Id = obj.GetString("id");
            // backdated_time
            // content_tags
            // embeddable
            // event
            Format = obj.GetArray("format", FacebookVideoFormat.Parse) ?? new FacebookVideoFormat[0];
            From = obj.GetObject("from", FacebookFrom.Parse);
            // icon
            // is_crossposting_eligible
            // is_instagram_eligible
            // is_reference_only
            Length = TimeSpan.FromSeconds(obj.GetDouble("length"));
            // live_status (eg. "live_status": "LIVE" )
            PermalinkUrl = obj.GetString("permalink_url");
            Picture = obj.GetString("picture");
            // place
            // privacy
            // published
            // scheduled_publish_time
            Source = obj.GetString("source");
            // status
            Title = obj.GetString("title");
            UpdatedTime = obj.GetDateTime("updated_time");

            /*
{
  "length": 14400,
  "embeddable": true,
  "live_status": "LIVE",
  "status": {
    "video_status": "ready"
  }
}

{
  "length": 51.71,
  "embeddable": true,
  "status": {
    "video_status": "ready"
  }
}
             */

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets a new instance of <see cref="FacebookVideo"/> from the specified <see cref="JsonObject"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JsonObject"/> to parse.</param>
        public static FacebookVideo Parse(JsonObject obj) {
            return obj == null ? null : new FacebookVideo(obj);
        }

        #endregion

    }

}