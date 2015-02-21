using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.Google.YouTube.Objects.PlaylistItem {

    public class YouTubePlaylistItem : GoogleApiResource {

        #region Properties

        /// <summary>
        /// Gets or sets the ID of the playlist item.
        /// </summary>
        public string Id { get; private set; }
        
        /// <summary>
        /// Gets or sets the snippet object of the item.
        /// </summary>
        public YouTubePlaylistItemSnippet Snippet { get; private set; }

        /// <summary>
        /// Gets or sets the status object of the item.
        /// </summary>
        public YouTubePlaylistItemStatus Status { get; private set; }

        #region Shortcuts

        /// <summary>
        /// Gets the YouTube ID of the video.
        /// </summary>
        public string VideoId {
            get { return Snippet.VideoId; }
        }

        /// <summary>
        /// Gets the title of the YouTube video.
        /// </summary>
        public string Title {
            get { return Snippet.Title; }
        }

        /// <summary>
        /// Gets the publish date of the YouTube video.
        /// </summary>
        public DateTime PublishedAt {
            get { return Snippet.PublishedAt; }
        }

        #endregion

        #endregion

        #region Constructors

        private YouTubePlaylistItem(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Loads an instance of <var>YouTubePlaylistItem</var> from the JSON file at the specified
        /// <var>path</var>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public static YouTubePlaylistItem LoadJson(string path) {
            return JsonObject.LoadJson(path, Parse);
        }

        /// <summary>
        /// Gets an instance of <var>YouTubePlaylistItem</var> from the specified JSON string.
        /// </summary>
        /// <param name="json">The JSON string representation of the object.</param>
        public static YouTubePlaylistItem ParseJson(string json) {
            return JsonObject.ParseJson(json, Parse);
        }

        /// <summary>
        /// Gets an instance of <var>YouTubePlaylistItem</var> from the specified
        /// <var>JsonObject</var>.
        /// </summary>
        /// <param name="obj">The instance of <var>JsonObject</var> to parse.</param>
        public static YouTubePlaylistItem Parse(JsonObject obj) {
            if (obj == null) return null;
            return new YouTubePlaylistItem(obj) {
                Id = obj.GetString("id"),
                Snippet = obj.GetObject("snippet", YouTubePlaylistItemSnippet.Parse),
                Status = obj.GetObject("status", YouTubePlaylistItemStatus.Parse)
            };
        }

        #endregion

    }

}