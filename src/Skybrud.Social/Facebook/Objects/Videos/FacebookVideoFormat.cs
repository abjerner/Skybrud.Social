using Skybrud.Social.Json;

namespace Skybrud.Social.Facebook.Objects.Videos {
    
    /// <summary>
    /// Class representing a Facebook video.
    /// </summary>
    /// <see>
    ///     <cref>https://developers.facebook.com/docs/graph-api/reference/video-format/</cref>
    /// </see>
    public class FacebookVideoFormat : SocialJsonObject {

        #region Properties

        /// <summary>
        /// Gets the HTML to embed the video in this format.
        /// </summary>
        public string EmbedHtml { get; private set; }

        /// <summary>
        /// Gets the filter applied to this video format.
        /// </summary>
        public string Filter { get; private set; }

        /// <summary>
        /// Gets the height of the video in this format.
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// Gets the thumbnail for the video in this format.
        /// </summary>
        public string Picture { get; private set; }

        /// <summary>
        /// Gets the width of the video in this format.
        /// </summary>
        public int Width { get; private set; }

        #endregion

        #region Constructors

        private FacebookVideoFormat(JsonObject obj) : base(obj) {
            EmbedHtml = obj.GetString("embed_html");
            Filter = obj.GetString("filter");
            Height = obj.GetInt32("height");
            Picture = obj.GetString("picture");
            Width = obj.GetInt32("width");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets a new instance of <see cref="FacebookVideoFormat"/> from the specified <see cref="JsonObject"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JsonObject"/> to parse.</param>
        public static FacebookVideoFormat Parse(JsonObject obj) {
            return obj == null ? null : new FacebookVideoFormat(obj);
        }

        #endregion

    }

}