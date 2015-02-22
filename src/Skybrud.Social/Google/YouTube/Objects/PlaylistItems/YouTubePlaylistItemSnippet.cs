using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.Google.YouTube.Objects.PlaylistItems {

    /// <see>
    ///     <cref>https://developers.google.com/youtube/v3/docs/playlistItems#snippet</cref>
    /// </see> 
    public class YouTubePlaylistItemSnippet : GoogleApiObject {

        #region Properties
        
        public DateTime PublishedAt { get; private set; }

        public string ChannelId { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public YouTubePlaylistItemThumbnails Thumbnails { get; private set; }
        
        public string ChannelTitle { get; private set; }

        public string PlaylistId { get; private set; }

        public int Position { get; private set; }

        public YouTubePlaylistItemResourceId ResourceId { get; private set; }

        #endregion
        
        #region Constructors

        private YouTubePlaylistItemSnippet(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <code>YouTubePlaylistItemSnippet</code> from the specified <code>JsonObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        public static YouTubePlaylistItemSnippet Parse(JsonObject obj) {
            if (obj == null) return null;
            return new YouTubePlaylistItemSnippet(obj) {
                PublishedAt = obj.GetDateTime("publishedAt"),
                ChannelId = obj.GetString("channelId"),
                Title = obj.GetString("title"),
                Description = obj.GetString("description"),
                Thumbnails = obj.GetObject("thumbnails", YouTubePlaylistItemThumbnails.Parse),
                ChannelTitle = obj.GetString("channelTitle"),
                PlaylistId = obj.GetString("playlistId"),
                Position = obj.GetInt32("position"),
                ResourceId = obj.GetObject("resourceId", YouTubePlaylistItemResourceId.Parse)
            };
        }

        #endregion

    }

}