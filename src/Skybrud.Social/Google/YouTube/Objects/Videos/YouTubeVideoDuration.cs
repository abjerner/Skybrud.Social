using System;
using System.Xml;

namespace Skybrud.Social.Google.YouTube.Objects.Videos {

    /// <summary>
    /// Class representing the duration of a YouTube video.
    /// </summary>
    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/videos#contentDetails.duration</cref>
    /// </see>
    public class YouTubeVideoDuration {

        #region Properties

        /// <summary>
        /// Gets the raw string with the ISO 8601 duration.
        /// </summary>
        public string Raw { get; private set; }

        /// <summary>
        /// Gets the days component of the video's duration.
        /// </summary>
        public int Days {
            get { return Value.Days; }
        }

        /// <summary>
        /// Gets the hours component of the video's duration.
        /// </summary>
        public int Hours {
            get { return Value.Hours; }
        }

        /// <summary>
        /// Gets the minutes component of the video's duration.
        /// </summary>
        public int Minutes {
            get { return Value.Minutes; }
        }

        /// <summary>
        /// Gets the seconds component of the video's duration.
        /// </summary>
        public int Seconds {
            get { return Value.Seconds; }
        }

        /// <summary>
        /// Gets an instance of <see cref="TimeSpan"/> representing the duration of the video.
        /// </summary>
        public TimeSpan Value { get; private set; }

        #endregion

        #region Constructors

        private YouTubeVideoDuration(string raw, TimeSpan duration) {
            Raw = raw;
            Value = duration;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified ISO 8601 duration <paramref name="value"/> into an instance of <see cref="YouTubeVideoDuration"/>.
        /// </summary>
        /// <param name="value">The raw ISO 8601 string.</param>
        /// <returns>An instance of <see cref="YouTubeVideoDuration"/>.</returns>
        public static YouTubeVideoDuration Parse(string value) {
            return new YouTubeVideoDuration(value, XmlConvert.ToTimeSpan(value));
        }

        #endregion
    
    }

}
