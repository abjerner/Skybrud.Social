using Newtonsoft.Json;
using Skybrud.Social.Json;

namespace Skybrud.Social {

    public abstract class SocialJsonArray {

        #region Properties

        /// <summary>
        /// Gets the internal JsonArray the object was created from.
        /// </summary>
        [JsonIgnore]
        public JsonArray JsonArray { get; private set; }

        #endregion

        #region Constructor

        protected SocialJsonArray(JsonArray array) {
            JsonArray = array;
        }

        #endregion

        #region Methods

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
