using System;
using System.Linq;

namespace Skybrud.Social.Google.YouTube.Objects.Videos {

    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/videos/list#part</cref>
    /// </see>
    public class YouTubeVideoPart {

        #region Properties

        public static readonly YouTubeVideoPart Id = new YouTubeVideoPart("id");
        public static readonly YouTubeVideoPart Snippet = new YouTubeVideoPart("snippet");
        public static readonly YouTubeVideoPart ContentDetails = new YouTubeVideoPart("contentDetails");
        public static readonly YouTubeVideoPart FileDetails = new YouTubeVideoPart("fileDetails");
        public static readonly YouTubeVideoPart LiveStreamingDetails = new YouTubeVideoPart("liveStreamingDetails");
        public static readonly YouTubeVideoPart Localizations = new YouTubeVideoPart("localizations");
        public static readonly YouTubeVideoPart ProcessingDetails = new YouTubeVideoPart("processingDetails");
        public static readonly YouTubeVideoPart RecordingDetails = new YouTubeVideoPart("recordingDetails");
        public static readonly YouTubeVideoPart Statistics = new YouTubeVideoPart("statistics");
        public static readonly YouTubeVideoPart Status = new YouTubeVideoPart("status");
        public static readonly YouTubeVideoPart Suggestions = new YouTubeVideoPart("suggestions");
        public static readonly YouTubeVideoPart TopicDetails = new YouTubeVideoPart("topicDetails");

        public static readonly YouTubeVideoPartsCollection Basic = new YouTubeVideoPartsCollection(
            Id, Snippet
        );

        public static readonly YouTubeVideoPartsCollection All = new YouTubeVideoPartsCollection(
            Id, Snippet, ContentDetails, FileDetails, LiveStreamingDetails, Localizations, ProcessingDetails,
            RecordingDetails, Statistics, Status, Suggestions, TopicDetails
        );

        public static YouTubeVideoPart[] Values {
            get { return All.ToArray(); }
        }

        public string Name { get; private set; }

        #endregion

        #region Constructors

        private YouTubeVideoPart(string name) {
            Name = name;
        }

        #endregion

        #region Static methods

        public static YouTubeVideoPart Parse(string str) {
            YouTubeVideoPart part;
            if (TryParse(str, out part)) return part;
            throw new Exception("Invalid part '" + str + "'");
        }

        public static bool TryParse(string str, out YouTubeVideoPart part) {
            part = Values.FirstOrDefault(temp => temp.Name == str);
            return part != null;
        }

        #endregion

        #region Operator overloading

        public static implicit operator YouTubeVideoPart(string name) {
            return Parse(name);
        }

        public static YouTubeVideoPartsCollection operator +(YouTubeVideoPart left, YouTubeVideoPart right) {
            return new YouTubeVideoPartsCollection(left, right);
        }

        #endregion
    
    }

}