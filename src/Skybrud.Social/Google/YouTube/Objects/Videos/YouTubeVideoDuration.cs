using System;
using System.Text.RegularExpressions;

namespace Skybrud.Social.Google.YouTube.Objects.Videos {

    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/videos#contentDetails.duration</cref>
    /// </see>
    public class YouTubeVideoDuration {

        #region Properties

        public string Raw { get; private set; }

        public int Minutes { get; private set; }

        public int Seconds { get; private set; }

        public TimeSpan Value { get; private set; }

        #endregion

        #region Constructors

        private YouTubeVideoDuration(string raw, int minutes, int seconds) {
            Raw = raw;
            Minutes = minutes;
            Seconds = seconds;
            Value = new TimeSpan(0, minutes, seconds);
        }

        #endregion

        #region Static methods

        public static YouTubeVideoDuration Parse(string raw) {
            Match m1 = Regex.Match(raw ?? "", "^PT([0-9]+)M([0-9]+)S$");
            Match m2 = Regex.Match(raw ?? "", "^PT([0-9]+)M$");
            Match m3 = Regex.Match(raw ?? "", "^PT([0-9]+)S$");
            if (m1.Success) {
                int minutes = Int32.Parse(m1.Groups[1].Value);
                int seconds = Int32.Parse(m1.Groups[2].Value);
                return new YouTubeVideoDuration(raw, minutes, seconds);
            }
            if (m2.Success) {
                int minutes = Int32.Parse(m2.Groups[1].Value);
                return new YouTubeVideoDuration(raw, minutes, 0);
            }
            if (m3.Success) {
                int seconds = Int32.Parse(m3.Groups[1].Value);
                return new YouTubeVideoDuration(raw, 0, seconds);
            }
            return new YouTubeVideoDuration(raw, 0, 0);
        }

        #endregion
    
    }

}
