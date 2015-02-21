using System;
using System.Text.RegularExpressions;
using Skybrud.Social.Json;

namespace Skybrud.Social.Google.YouTube.Objects.Videos {
   
    public class YouTubeVideo : GoogleApiResource {

        #region Properties

        /// <summary>
        /// Gets or sets the ID of the video.
        /// </summary>
        public string Id { get; private set; }

        public YouTubeVideoSnippet Snippet { get; private set; }
        public YouTubeVideoContentDetails ContentDetails { get; private set; }

        public string Duration {
            get { return ContentDetails.Duration; }
        }

        public int DurationAsSeconds {
            get {
                if (ContentDetails != null) {
                    Match m1 = Regex.Match(ContentDetails.Duration, "^PT([0-9]+)M([0-9]+)S$");
                    Match m2 = Regex.Match(ContentDetails.Duration, "^PT([0-9]+)M$");
                    Match m3 = Regex.Match(ContentDetails.Duration, "^PT([0-9]+)S$");
                    if (m1.Success) {
                        int minutes = Int32.Parse(m1.Groups[1].Value);
                        int seconds = Int32.Parse(m1.Groups[2].Value);
                        return (minutes * 60) + seconds;
                    } else if (m2.Success) {
                        int minutes = Int32.Parse(m2.Groups[1].Value);
                        return minutes * 60;
                    } else if (m3.Success) {
                        int seconds = Int32.Parse(m3.Groups[1].Value);
                        return seconds;
                    }
                }
                return -1;
            }
        }

        #endregion

        #region Constructors

        private YouTubeVideo(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Loads an instance of <var>YouTubeVideo</var> from the JSON file at the specified
        /// <var>path</var>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public static YouTubeVideo LoadJson(string path) {
            return JsonObject.LoadJson(path, Parse);
        }

        /// <summary>
        /// Gets an instance of <var>YouTubeVideo</var> from the specified JSON string.
        /// </summary>
        /// <param name="json">The JSON string representation of the object.</param>
        public static YouTubeVideo ParseJson(string json) {
            return JsonObject.ParseJson(json, Parse);
        }

        /// <summary>
        /// Gets an instance of <var>YouTubeVideo</var> from the specified
        /// <var>JsonObject</var>.
        /// </summary>
        /// <param name="obj">The instance of <var>JsonObject</var> to parse.</param>
        public static YouTubeVideo Parse(JsonObject obj) {
            if (obj == null) return null;
            return new YouTubeVideo(obj) {
                Id = obj.GetString("id"),
                Snippet = obj.GetObject("snippet", YouTubeVideoSnippet.Parse),
                ContentDetails = obj.GetObject("contentDetails", YouTubeVideoContentDetails.Parse)
            };
        }

        #endregion
    
    }

}
