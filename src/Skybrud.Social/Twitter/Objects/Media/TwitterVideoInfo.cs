using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.Twitter.Objects.Media {
    
    /// <summary>
    /// Class representing a resized format of a given media.
    /// </summary>
    public class TwitterVideoInfo : SocialJsonObject {

        #region Properties

        /// <summary>
        /// Gets a 2-element array with the aspect ratio of the video.
        /// </summary>
        public int[] AspectRatio { get; private set; }

        /// <summary>
        /// Gets the duration of the video. For animated GIFs a duration won't be specified.
        /// </summary>
        public TimeSpan Duration { get; private set; }

        /// <summary>
        /// Gets an array of all variants/formats of the video.
        /// </summary>
        public TwitterVideoFormat[] Variants { get; private set; }

        /// <summary>
        /// Gets whether a duration has been specified for the video.
        /// </summary>
        public bool HasDuration {
            get { return Duration.TotalMilliseconds > 0; }
        }

        #endregion

        #region Constructors

        private TwitterVideoInfo(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <code>TwitterVideoInfo</code> from the specified <code>JsonObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        public static TwitterVideoInfo Parse(JsonObject obj) {
            if (obj == null) return null;
            return new TwitterVideoInfo(obj) {
                AspectRatio = obj.GetArray("aspect_ratio").Cast<int>(),
                Duration = obj.GetDouble("duration_millis", TimeSpan.FromMilliseconds),
                Variants = obj.GetArray("variants", TwitterVideoFormat.Parse)
            };
        }

        #endregion

    }

}