using System;

namespace Skybrud.Social.Twitter.Entities.Formatting {
    
    public class TwitterExtendedEntityFormatter : TwitterDefaultEntityFormatter {

        public Func<string, TwitterHashTagEntity, string> Tags { get; set; }
        public Func<string, TwitterUrlEntity, string> Urls { get; set; }
        public Func<string, TwitterMentionEntity, string> Mentions { get; set; }
        public Func<string, TwitterMediaEntity, string> Media { get; set; }

        /// <summary>
        /// Formats a hashtag in a status message, description or similar.
        /// </summary>
        /// <param name="text">The text being replaced.</param>
        /// <param name="tag">The hashtag.</param>
        public override string FormatTag(string text, TwitterHashTagEntity tag) {
            return Tags == null ? base.FormatTag(text, tag) : Tags(text, tag);
        }

        /// <summary>
        /// Formats an URL in a status message, description or similar.
        /// </summary>
        /// <param name="text">The text being replaced.</param>
        /// <param name="url">The URL.</param>
        public override string FormatUrl(string text, TwitterUrlEntity url) {
            return Urls == null ? base.FormatUrl(text, url) : Urls(text, url);
        }

        /// <summary>
        /// Formats a user mention in a status message, description or similar.
        /// </summary>
        /// <param name="text">The text being replaced.</param>
        /// <param name="mention"></param>
        public override string FormatMention(string text, TwitterMentionEntity mention) {
            return Mentions == null ? base.FormatMention(text, mention) : Mentions(text, mention);
        }

        /// <summary>
        /// Formats a media in a status message, description or similar.
        /// </summary>
        /// <param name="text">The text being replaced.</param>
        /// <param name="media">The media.</param>
        public override string FormatMedia(string text, TwitterMediaEntity media) {
            return Media == null ? base.FormatMedia(text, media) : Media(text, media);
        }

    }

}