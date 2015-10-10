using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Objects {

    /// <summary>
    /// Class representing an Instagram image.
    /// </summary>
    public class InstagramImage : InstagramMedia {

        #region Constructors

        internal InstagramImage(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Loads an image from the JSON file at the specified <code>path</code>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        [Obsolete]
        public new static InstagramMedia LoadJson(string path) {
            // TODO: Remove for v1.0
            return JsonObject.LoadJson(path, Parse);
        }

        /// <summary>
        /// Gets an image from the specified JSON string.
        /// </summary>
        /// <param name="json">The JSON string representation of the object.</param>
        [Obsolete]
        public new static InstagramMedia ParseJson(string json) {
            // TODO: Remove for v1.0
            return JsonObject.ParseJson(json, Parse);
        }

        /// <summary>
        /// Gets an image from the specified <code>JsonObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        public new static InstagramImage Parse(JsonObject obj) {
            return InstagramMedia.Parse(obj) as InstagramImage;
        }

        #endregion

    }

}