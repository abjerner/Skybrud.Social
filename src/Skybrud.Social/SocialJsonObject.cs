using Newtonsoft.Json;
using Skybrud.Social.Json;

namespace Skybrud.Social {

    public abstract class SocialJsonObject {

        #region Properties

        /// <summary>
        /// Gets the internal JsonObject the object was created from.
        /// </summary>
        [JsonIgnore]
        public JsonObject JsonObject { get; private set; }

        #endregion

        #region Constructor

        protected SocialJsonObject(JsonObject obj) {
            JsonObject = obj;
        }

        #endregion

        #region Methods
        
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