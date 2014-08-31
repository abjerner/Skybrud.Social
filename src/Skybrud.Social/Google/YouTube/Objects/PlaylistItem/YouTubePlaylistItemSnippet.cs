using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.Google.YouTube.Objects.PlaylistItem {
    
    public class YouTubePlaylistItemSnippet : GoogleApiObject {

        #region Properties
        
        public DateTime PublishedAt { get; private set; }
        public string ChannelId { get; private set; }
        public string ChannelTitle { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string PlaylistId { get; private set; }
        public string VideoId { get; private set; }
        public int Position { get; private set; }

        #endregion
        
        #region Constructors

        private YouTubePlaylistItemSnippet(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Loads an instance of <var>YouTubePlaylistItemSnippet</var> from the JSON file at the
        /// specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public static YouTubePlaylistItemSnippet LoadJson(string path) {
            return JsonObject.LoadJson(path, Parse);
        }

        /// <summary>
        /// Gets an instance of <var>YouTubePlaylistItemSnippet</var> from the specified JSON
        /// string.
        /// </summary>
        /// <param name="json">The JSON string representation of the object.</param>
        public static YouTubePlaylistItemSnippet ParseJson(string json) {
            return JsonObject.ParseJson(json, Parse);
        }

        /// <summary>
        /// Gets an instance of <var>YouTubePlaylistItemSnippet</var> from the specified
        /// <var>JsonObject</var>.
        /// </summary>
        /// <param name="obj">The instance of <var>JsonObject</var> to parse.</param>
        public static YouTubePlaylistItemSnippet Parse(JsonObject obj) {
            
            // Check whether "obj" is NULL
            if (obj == null) return null;
            
            // Initialize the snippet object
            YouTubePlaylistItemSnippet snippet = new YouTubePlaylistItemSnippet(obj) {
                ChannelId = obj.GetString("channelId"),
                ChannelTitle = obj.GetString("channelTitle"),
                PublishedAt = obj.GetDateTime("publishedAt"),
                Title = obj.GetString("title"),
                Description = obj.GetString("description"),
                PlaylistId = obj.GetString("playlistId"),
                Position = obj.GetInt("position")
            };

            // If the item is a video (which it most likely is), we grab the ID of the video
            JsonObject resourceId = obj.GetObject("resourceId");
            if (resourceId != null && resourceId.GetString("kind") == "youtube#video") {
                snippet.VideoId = resourceId.GetString("videoId");
            }

            return snippet;

        }

        #endregion

    }

}