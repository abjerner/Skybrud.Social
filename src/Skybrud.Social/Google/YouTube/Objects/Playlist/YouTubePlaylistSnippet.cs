using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.Google.YouTube.Objects.Playlist {
    
    public class YouTubePlaylistSnippet : GoogleApiObject {
        
        public DateTime PublishedAt { get; private set; }
        public string ChannelId { get; private set; }
        public string ChannelTitle { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }

        /// <summary>
        /// Gets an instance of <var>YouTubePlaylist</var> from the specified
        /// <var>JsonObject</var>.
        /// </summary>
        /// <param name="obj">The instance of <var>JsonObject</var> to parse.</param>
        public static YouTubePlaylistSnippet Parse(JsonObject obj) {
            if (obj == null) return null;
            return new YouTubePlaylistSnippet {
                JsonObject = obj,
                ChannelId = obj.GetString("channelId"),
                ChannelTitle = obj.GetString("channelTitle"),
                PublishedAt = obj.GetDateTime("publishedAt"),
                Title = obj.GetString("title"),
                Description = obj.GetString("description")
            };
        }

    }

}