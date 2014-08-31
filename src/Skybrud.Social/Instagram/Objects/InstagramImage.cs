using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Objects {

    public class InstagramImage : InstagramMedia {

        #region Constructors

        internal InstagramImage() {
            // Hide default constructor
        }

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

        /// <summary>
        /// Gets an array of images from the specified <var>JsonArray</var>.
        /// </summary>
        /// <param name="array">The instance of <var>JsonArray</var> to parse.</param>
        public new static InstagramImage[] ParseMultiple(JsonArray array) {
            return array == null ? new InstagramImage[0] : array.ParseMultiple(Parse);
        }

        #endregion

    }

}