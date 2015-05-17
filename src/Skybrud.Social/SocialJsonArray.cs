using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Skybrud.Social.Json;

namespace Skybrud.Social {

    /// <summary>
    /// Class representing an array derived from A JSON array.
    /// </summary>
    public abstract class SocialJsonArray {

        #region Properties

        /// <summary>
        /// Gets the internal JsonArray the object was created from.
        /// </summary>
        [JsonIgnore]
        public JsonArray JsonArray { get; private set; }

        /// <summary>
        /// Gets the length of the array.
        /// </summary>
        public int Length {
            get { return JsonArray == null ? 0 : JsonArray.Length; }
        }

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
        /// Saves the object to a JSON file at the specified <code>path</code>.
        /// </summary>
        /// <param name="path">The path to save the file.</param>
        public virtual void SaveJson(string path) {
            if (JsonArray != null) JsonArray.SaveJson(path);
        }

        #endregion

    }

    /// <summary>
    /// Class representing an array derived from A JSON array.
    /// </summary>
    /// <typeparam name="T">The type of the items to be stored in the array.</typeparam>
    public class SocialJsonArray<T> : SocialJsonArray, IEnumerable<T> {

        /// <summary>
        /// Gets or sets the item at the specified <code>index</code>.
        /// </summary>
        /// <param name="index">The index of item.</param>
        public T this[int index] {
            get { return _array[index]; }
            set { _array[index] = value; }
        }

        private T[] _array;

        private SocialJsonArray(JsonArray array) : base(array) { }

        /// <summary>
        /// Parses the specified <code>array</code>.
        /// </summary>
        /// <param name="array">The array to be parsed.</param>
        /// <param name="func">The callback function to be used for parsing each item in the array.</param>
        public static SocialJsonArray<T> Parse(JsonArray array, Func<JsonObject, T> func) {
            return new SocialJsonArray<T>(array) {
                _array = array.ParseMultiple(func)
            };
        }

        public IEnumerator<T> GetEnumerator() {
            return ((IEnumerable<T>) _array).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    
    }

}