using System;
using System.Collections;
using System.Collections.Generic;
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

    public class SocialJsonArray<T> : SocialJsonArray, IEnumerable<T> {

        private T[] _array;

        private SocialJsonArray(JsonArray array) : base(array) { }

        public static SocialJsonArray<T> Parse(JsonArray array, Func<JsonObject, T> func) {
            return new SocialJsonArray<T>(array) {
                _array = array.ParseMultiple(func)
            };
        }

        public T this[int i] {
            get { return _array[i]; }
            set { _array[i] = value; }
        }

        public int Length {
            get { return _array.Length; }
        }

        public IEnumerator<T> GetEnumerator() {
            return ((IEnumerable<T>) _array).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    
    }

}
