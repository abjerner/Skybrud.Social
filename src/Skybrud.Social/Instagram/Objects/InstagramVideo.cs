using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Objects {

    /// <summary>
    /// Class representing an Instagram video.
    /// </summary>
    public class InstagramVideo : InstagramMedia {
        
        #region Properties

        /// <summary>
        /// Gets a summary of the video formats available for this Instagram video.
        /// </summary>
        public InstagramVideoSummary Videos { get; internal set; }

        #endregion

        #region Constructors

        internal InstagramVideo(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Loads a video from the JSON file at the specified <code>path</code>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        [Obsolete]
        public new static InstagramVideo LoadJson(string path) {
            // TODO: Remove for v1.0
            return JsonObject.LoadJson(path, Parse);
        }

        /// <summary>
        /// Gets a video from the specified JSON string.
        /// </summary>
        /// <param name="json">The JSON string representation of the object.</param>
        [Obsolete]
        public new static InstagramVideo ParseJson(string json) {
            // TODO: Remove for v1.0
            return JsonObject.ParseJson(json, Parse);
        }

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <code>InstagramVideo</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to be parsed.</param>
        /// <returns>Returns an instance of <code>InstagramVideo</code>.</returns>
        public new static InstagramVideo Parse(JsonObject obj) {
            return InstagramMedia.Parse(obj) as InstagramVideo;
        }

        #endregion

    }

}