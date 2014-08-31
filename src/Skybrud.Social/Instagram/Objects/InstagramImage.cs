using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Objects {

    public class InstagramImage : InstagramMedia {

        #region Constructors

        internal InstagramImage(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Loads an image from the JSON file at the specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public new static InstagramMedia LoadJson(string path) {
            return JsonObject.LoadJson(path, Parse);
        }

        /// <summary>
        /// Gets an image from the specified JSON string.
        /// </summary>
        /// <param name="json">The JSON string representation of the object.</param>
        public new static InstagramMedia ParseJson(string json) {
            return JsonObject.ParseJson(json, Parse);
        }

        /// <summary>
        /// Gets an image from the specified <var>JsonObject</var>.
        /// </summary>
        /// <param name="obj">The instance of <var>JsonObject</var> to parse.</param>
        public new static InstagramImage Parse(JsonObject obj) {
            return InstagramMedia.Parse(obj) as InstagramImage;
        }

        #endregion

    }

}