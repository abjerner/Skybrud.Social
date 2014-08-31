using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.Google.YouTube.Objects.Videos {
    
    public class YouTubeVideoSnippet : GoogleApiObject {

        #region Properties
        
        /// <summary>
        /// Gets or sets the publish date of the video.
        /// </summary>
        public DateTime PublishedAt { get; private set; }

        /// <summary>
        /// Gets or sets the ID of the parent channel.
        /// </summary>
        public string ChannelId { get; private set; }

        /// <summary>
        /// Gets or sets the title of the parent channel.
        /// </summary>
        public string ChannelTitle { get; private set; }

        /// <summary>
        /// gets or sets the title of the YouTube video.
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// Gets or sets the description of the video.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Gets or sets the "liveBroadcastContent" property.
        /// </summary>
        public string LiveBroadcastContent { get; private set; } 

        #endregion
        
        #region Constructors

        private YouTubeVideoSnippet() {
            // Hide default constructor
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Loads an instance of <var>YouTubeVideoSnippet</var> from the JSON file at the
        /// specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public static YouTubeVideoSnippet LoadJson(string path) {
            return JsonObject.LoadJson(path, Parse);
        }

        /// <summary>
        /// Gets an instance of <var>YouTubeVideoSnippet</var> from the specified JSON
        /// string.
        /// </summary>
        /// <param name="json">The JSON string representation of the object.</param>
        public static YouTubeVideoSnippet ParseJson(string json) {
            return JsonObject.ParseJson(json, Parse);
        }

        /// <summary>
        /// Gets an instance of <var>YouTubeVideoSnippet</var> from the specified
        /// <var>JsonObject</var>.
        /// </summary>
        /// <param name="obj">The instance of <var>JsonObject</var> to parse.</param>
        public static YouTubeVideoSnippet Parse(JsonObject obj) {
            
            // Check whether "obj" is NULL
            if (obj == null) return null;
            
            // Initialize the snippet object
            YouTubeVideoSnippet snippet = new YouTubeVideoSnippet {
                JsonObject = obj,
                ChannelId = obj.GetString("channelId"),
                ChannelTitle = obj.GetString("channelTitle"),
                PublishedAt = obj.GetDateTime("publishedAt"),
                Title = obj.GetString("title"),
                Description = obj.GetString("description"),
                LiveBroadcastContent = obj.GetString("liveBroadcastContent")
            };

            return snippet;

        }

        #endregion

    }

}