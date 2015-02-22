using System;
using System.Linq;

namespace Skybrud.Social.Google.YouTube.Objects.Channels {

    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/channels/list#part</cref>
    /// </see>
    public class YouTubeChannelPart {

        #region Properties

        public static readonly YouTubeChannelPart Id = new YouTubeChannelPart("id");
        public static readonly YouTubeChannelPart Snippet = new YouTubeChannelPart("snippet");
        public static readonly YouTubeChannelPart ContentDetails = new YouTubeChannelPart("contentDetails");
        public static readonly YouTubeChannelPart Statistics = new YouTubeChannelPart("statistics");
        public static readonly YouTubeChannelPart Status = new YouTubeChannelPart("status");
        public static readonly YouTubeChannelPart TopicDetails = new YouTubeChannelPart("topicDetails");

        public static readonly YouTubeChannelPartsCollection Basic = new YouTubeChannelPartsCollection(
            Id, Snippet, Statistics
        );

        public static readonly YouTubeChannelPartsCollection All = new YouTubeChannelPartsCollection(
            Id, Snippet, ContentDetails, Statistics, Status, TopicDetails
        );

        public static YouTubeChannelPart[] Values {
            get { return All.ToArray(); }
        }

        public string Name { get; private set; }

        #endregion

        #region Constructors

        private YouTubeChannelPart(string name) {
            Name = name;
        }

        #endregion

        #region Static methods

        public static YouTubeChannelPart Parse(string str) {
            YouTubeChannelPart part;
            if (TryParse(str, out part)) return part;
            throw new Exception("Invalid part '" + str + "'");
        }

        public static bool TryParse(string str, out YouTubeChannelPart part) {
            part = Values.FirstOrDefault(temp => temp.Name == str);
            return part != null;
        }

        #endregion

        #region Operator overloading

        public static implicit operator YouTubeChannelPart(string name) {
            return Parse(name);
        }

        public static YouTubeChannelPartsCollection operator +(YouTubeChannelPart left, YouTubeChannelPart right) {
            return new YouTubeChannelPartsCollection(left, right);
        }

        #endregion
    
    }

}