namespace Skybrud.Social.Twitter.Entities.Formatting {

    public class TwitterDefaultEntityFormatter : ITwitterEntityFormatter {

        /// <summary>
        /// Formats a hashtag in a status message, description or similar.
        /// </summary>
        /// <param name="text">The text being replaced.</param>
        /// <param name="tag">The hashtag.</param>
        public virtual string FormatTag(string text, TwitterHashTagEntity tag) {
            return "<a href=\"https://twitter.com/hashtag/" + tag.Text + "?src=hash\">#" + tag.Text + "</a>";
        }

        /// <summary>
        /// Formats an URL in a status message, description or similar.
        /// </summary>
        /// <param name="text">The text being replaced.</param>
        /// <param name="url">The URL.</param>
        public virtual string FormatUrl(string text, TwitterUrlEntity url) {
            return "<a href=\"" + url.ExpandedUrl + "\">" + url.DisplayUrl + "</a>";
        }

        /// <summary>
        /// Formats a user mention in a status message, description or similar.
        /// </summary>
        /// <param name="text">The text being replaced.</param>
        /// <param name="mention"></param>
        public virtual string FormatMention(string text, TwitterMentionEntity mention) {
            return "<a href=\"https://twitter.com/" + mention.ScreenName + "\">@" + mention.ScreenName + "</a>";
        }

        /// <summary>
        /// Formats a media in a status message, description or similar.
        /// </summary>
        /// <param name="text">The text being replaced.</param>
        /// <param name="media">The media.</param>
        public virtual string FormatMedia(string text, TwitterMediaEntity media) {
            return "<a href=\"" + media.ExpandedUrl + "\">" + media.DisplayUrl + "</a>";
        }

    }

}