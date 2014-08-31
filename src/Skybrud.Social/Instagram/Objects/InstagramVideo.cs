using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Objects {
    
    public class InstagramVideo : InstagramMedia {
        
        #region Properties

        public InstagramVideoSummary Videos { get; internal set; }

        #endregion

        #region Constructors

        internal InstagramVideo(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Loads a video from the JSON file at the specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public new static InstagramVideo LoadJson(string path) {
            return JsonObject.LoadJson(path, Parse);
        }

        /// <summary>
        /// Gets a video from the specified JSON string.
        /// </summary>
        /// <param name="json">The JSON string representation of the object.</param>
        public new static InstagramVideo ParseJson(string json) {
            return JsonObject.ParseJson(json, Parse);
        }

        /// <summary>
        /// Gets a video from the specified <var>JsonObject</var>.
        /// </summary>
        /// <param name="obj">The instance of <var>JsonObject</var> to parse.</param>
        public new static InstagramVideo Parse(JsonObject obj) {
            return InstagramMedia.Parse(obj) as InstagramVideo;
        }

        #endregion

    }

}