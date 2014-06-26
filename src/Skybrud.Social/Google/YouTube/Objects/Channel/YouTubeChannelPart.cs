using System;
using System.Linq;
using System.Reflection;

namespace Skybrud.Social.Google.YouTube.Objects.Channel {
    
    public class YouTubeChannelPart {

        public static readonly YouTubeChannelPart Id = new YouTubeChannelPart("id");
        public static readonly YouTubeChannelPart Snippet = new YouTubeChannelPart("snippet");
        public static readonly YouTubeChannelPart AuditDetails = new YouTubeChannelPart("auditDetails");
        public static readonly YouTubeChannelPart BrandingSettings = new YouTubeChannelPart("brandingSettings");
        public static readonly YouTubeChannelPart ContentDetails = new YouTubeChannelPart("contentDetails");
        public static readonly YouTubeChannelPart InvideoPromotion = new YouTubeChannelPart("invideoPromotion");
        public static readonly YouTubeChannelPart Statistics = new YouTubeChannelPart("statistics");
        public static readonly YouTubeChannelPart Status = new YouTubeChannelPart("status");
        public static readonly YouTubeChannelPart TopicDetails = new YouTubeChannelPart("topicDetails");


        #region Static properties

        public static YouTubeChannelPart[] Values {
            get {
                return (
                    from property in typeof(YouTubeChannelPart).GetFields(BindingFlags.Public | BindingFlags.Static)
                    select (YouTubeChannelPart) property.GetValue(null)
                ).ToArray();
            }
        }

        #endregion

        public string Name { get; private set; }

        private YouTubeChannelPart(string name) {
            Name = name;
        }

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