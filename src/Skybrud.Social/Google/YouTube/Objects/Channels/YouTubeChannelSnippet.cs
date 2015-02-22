using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.Google.YouTube.Objects.Channels {

    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/channels#snippet</cref>
    /// </see>
    public class YouTubeChannelSnippet : GoogleApiObject {

        #region Properties

        public string Title { get; private set; }

        public string Description { get; private set; }

        public DateTime PublishedAt { get; private set; }

        public YouTubeChannelThumbnails Thumbnails { get; private set; }

        public YouTubeChannelLocalized Localized { get; private set; }

        #endregion

        #region Constructors

        protected YouTubeChannelSnippet(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <code>YouTubeChannelSnippet</code> from the specified <code>JsonObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        public static YouTubeChannelSnippet Parse(JsonObject obj) {
            if (obj == null) return null;
            return new YouTubeChannelSnippet(obj) {
                Title = obj.GetString("title"),
                Description = obj.GetString("description"),
                PublishedAt = obj.GetDateTime("publishedAt"),
                Thumbnails = obj.GetObject("thumbnails", YouTubeChannelThumbnails.Parse),
                Localized = obj.GetObject("localized", YouTubeChannelLocalized.Parse)
            };
        }

        #endregion

    }

}