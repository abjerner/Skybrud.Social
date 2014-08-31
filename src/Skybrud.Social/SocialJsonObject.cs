using Skybrud.Social.Json;

namespace Skybrud.Social {

    public abstract class SocialJsonObject {

        #region Properties

        /// <summary>
        /// Gets the internal JsonObject the object was created from.
        /// </summary>
        public JsonObject JsonObject { get; private set; }

        #endregion

        #region Constructor

        protected SocialJsonObject(JsonObject obj) {
            JsonObject = obj;
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
            return JsonObject == null ? null : JsonObject.ToJson();
        }

        /// <summary>
        /// Saves the object to a JSON file at the specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to save the file.</param>
        public virtual void SaveJson(string path) {
            if (JsonObject != null) JsonObject.SaveJson(path);
        }

        #endregion

    }

}
