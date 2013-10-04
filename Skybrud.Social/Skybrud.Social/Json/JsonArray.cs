using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;

namespace Skybrud.Social.Json {
    
    public class JsonArray : IJsonObject {

        private object[] _array;

        public object[] InternalArray {
            get { return _array; }
        }

        public int Length {
            get { return _array.Length; }
        }

        public object this[int pos] {
            get {
                var temp = _array[pos];
                if (temp is object[]) return new JsonArray((object[])temp);
                return temp;
            }
        }

        public JsonArray(object[] array) {
            _array = array;
        }

        public JsonArray(ArrayList array) {
            _array = array.ToArray();
        }

        public bool IsArray(int index) {
            return _array[index] is object[];
        }

        public bool IsObject(int index) {
            return _array[index] is JsonObject;
        }

        public bool IsSimpleType(int index) {
            return !IsArray(index) && IsArray(index);
        }

        public JsonArray GetArray(int index) {
            if (_array[index] is object[]) return new JsonArray(_array[index] as object[]);
            if (_array[index] is ArrayList) return new JsonArray(_array[index] as ArrayList);
            return null;
        }

        public T[] GetArray<T>(int index, Func<JsonObject, T> func) {
            JsonArray array = GetArray(index);
            return array == null ? null : array.ParseMultiple(func);
        }

        public Type GetElementType(int index) {
            return this[index].GetType();
        }

        public JsonObject GetObject(int index) {
            JsonObject v1 = this[index] as JsonObject;
            Dictionary<string, object> v2 = this[index] as Dictionary<string, object>;
            if (v1 != null) return v1;
            return v2 == null ? null : new JsonObject(v2);
        }

        public int GetInt(int index) {
            return (int) Convert.ChangeType(this[index], typeof(int));
        }

        public double GetDouble(int index) {
            return (double) Convert.ChangeType(this[index], typeof(double));
        }

        public string GetString(int index) {
            return (string)Convert.ChangeType(this[index], typeof(string));
        }

        public T GetSimpleType<T>(int index) {
            return (T) Convert.ChangeType(this[index], typeof(T));
        }

        public T[] ParseMultiple<T>(Func<JsonObject, T> func) {
            T[] temp = new T[Length];
            for (int i = 0; i < Length; i++) temp[i] = func(GetObject(i));
            return temp;
        }

        public T[] Cast<T>() {
            return _array.Cast<T>().ToArray();
        }

        /// <summary>
        /// Gets a JSON string representing the array.
        /// </summary>
        public string ToJson() {
            return JsonConverter.ToJson(this);
        }

        /// <summary>
        /// Save the array to a JSON file at the specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to save the file.</param>
        public void SaveJson(string path) {
            File.WriteAllText(path, ToJson());
        }

        /// <summary>
        /// Load an instance of <var>JsonObject</var> from the JSON file at the specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public static JsonArray LoadJson(string path) {
            return JsonConverter.ParseArray(File.ReadAllText(path));
        }

        /// <summary>
        /// Load an array of <var>T</var> from the JSON file at the specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="func">The function used to parse the array.</param>
        public static T[] LoadJson<T>(string path, Func<JsonArray, T[]> func) {
            return JsonConverter.ParseArray(File.ReadAllText(path), func);
        }

        /// <summary>
        /// Gets an instance of <var>JsonObject</var> from the specified JSON string.
        /// </summary>
        /// <param name="json">The JSON string representation of the array.</param>
        public static JsonArray ParseJson(string json) {
            return JsonConverter.ParseArray(json);
        }

        /// <summary>
        /// Gets an array of <var>T</var> from the specified JSON string.
        /// </summary>
        /// <param name="json">The JSON string representation of the array.</param>
        /// <param name="func">The function used to parse the array.</param>
        public static T[] ParseJson<T>(string json, Func<JsonArray, T[]> func) {
            return JsonConverter.ParseArray(json, func);
        }

    }

}
