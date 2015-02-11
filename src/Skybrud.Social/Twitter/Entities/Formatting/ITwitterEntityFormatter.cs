namespace Skybrud.Social.Twitter.Entities.Formatting {

    public interface ITwitterEntityFormatter {

        /// <summary>
        /// Formats a hashtag in a status message, description or similar.
        /// </summary>
        /// <param name="text">The text being replaced.</param>
        /// <param name="tag">The hashtag.</param>
        string FormatTag(string text, TwitterHashTagEntity tag);

        /// <summary>
        /// Formats an URL in a status message, description or similar.
        /// </summary>
        /// <param name="text">The text being replaced.</param>
        /// <param name="url">The URL.</param>
        string FormatUrl(string text, TwitterUrlEntity url);

        /// <summary>
        /// Formats a user mention in a status message, description or similar.
        /// </summary>
        /// <param name="text">The text being replaced.</param>
        /// <param name="mention"></param>
        /// <returns></returns>
        string FormatMention(string text, TwitterMentionEntity mention);

        /// <summary>
        /// Formats a media in a status message, description or similar.
        /// </summary>
        /// <param name="text">The text being replaced.</param>
        /// <param name="media">The media.</param>
        string FormatMedia(string text, TwitterMediaEntity media);

    }

}