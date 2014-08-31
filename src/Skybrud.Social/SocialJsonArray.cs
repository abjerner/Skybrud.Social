using Skybrud.Social.Json;

namespace Skybrud.Social {

    public abstract class SocialJsonArray {

        #region Properties

        /// <summary>
        /// Gets the internal JsonArray the object was created from.
        /// </summary>
        public JsonArray JsonArray { get; private set; }

        #endregion

        #region Constructor

        protected SocialJsonArray(JsonArray array) {
            JsonArray = array;
        }

        #endregion

        #region Methods

        /// <summary>
        /// This method is only here to make sure that the JsonObject property
        /// isn't serialized by the <code>JSON.net</code> package. By having
        /// this method rather than using the <code>JsonIgnore</code>
        /// attribute, we don't have to create any references to the
        /// <code>JSON.net</code> package.
        /// </summary>
        private bool ShouldSerializeJsonObject() {
            return false;
        }

        /// <summary>
        /// Generates a JSON string representing the object.
        /// </summary>
        public virtual string ToJson() {
            return JsonArray == null ? null : JsonArray.ToJson();
        }

        /// <summary>
        /// Saves the object to a JSON file at the specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to save the file.</param>
        public virtual void SaveJson(string path) {
            if (JsonArray != null) JsonArray.SaveJson(path);
        }

        #endregion

    }

}
