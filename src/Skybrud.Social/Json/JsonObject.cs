using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Skybrud.Social.Json {

    public class JsonObject : IJsonObject {

        #region Properties
        
        public IDictionary<string, object> Dictionary { get; private set; }

        public string[] Keys {
            get { return Dictionary.Keys.ToArray(); }
        }

        #endregion

        #region Constructor(s)

        public JsonObject(IDictionary<string, object> dictionary) {
            Dictionary = dictionary;
        }

        public JsonObject() {
            Dictionary = new Dictionary<string, object>();
        }

        #endregion

        public bool HasValue(string name) {
            return Dictionary.ContainsKey(name) && Dictionary[name] != null;
        }

        public JsonObject GetObject(string name) {
            object value;
            return Dictionary.TryGetValue(name, out value) && value is Dictionary<string, object> ? new JsonObject((Dictionary<string, object>) value) : null;
        }

        public T GetObject<T>(string name, Func<JsonObject, T> func) {
            JsonObject obj = GetObject(name);
            return obj == null ? default(T) : func(obj);
        }

        public JsonArray GetArray(string name) {
            object value;
            return Dictionary.TryGetValue(name, out value) && value is ArrayList ? new JsonArray((ArrayList) value) : null;
        }

        public T[] GetArray<T>(string name) {
            object value;
            JsonArray array = Dictionary.TryGetValue(name, out value) && value is ArrayList ? new JsonArray((ArrayList) value) : null;
            return array == null ? null : array.Cast<T>();
        }

        public T[] GetArray<T>(string name, Func<JsonObject, T> func) {
            JsonArray array = GetArray(name);
            return array == null ? null : array.ParseMultiple(func);
        }

        public T GetValue<T>(string name) {
            return GetValue<T>(name, CultureInfo.InvariantCulture);
        }
        
        public T GetValue<T>(string name, IFormatProvider provider) {
            if (!HasValue(name)) return default(T);
            if (typeof(T) == typeof(JsonObject)) {
                object obj = Dictionary[name];
                if (obj is Dictionary<string, object>) {
                    obj = new JsonObject((Dictionary<string, object>) Dictionary[name]);
                }
                return (T) obj;
            }
            return (T) Convert.ChangeType(Dictionary[name], typeof(T), provider);
        }

        public int GetInt(string name) {
            return GetValue<int>(name);
        }

        public long GetLong(string name) {
            return GetValue<long>(name);
        }

        public int GetInt32(string name) {
            return GetValue<int>(name);
        }

        public long GetInt64(string name) {
            return GetValue<long>(name);
        }

        public float GetFloat(string name) {
            return GetValue<float>(name);
        }

        public float GetFloat(string name, IFormatProvider provider) {
            return GetValue<float>(name, provider);
        }

        public double GetDouble(string name) {
            return GetValue<double>(name);
        }

        public double GetDouble(string name, IFormatProvider provider) {
            return GetValue<double>(name, provider);
        }

        public bool GetBoolean(string name) {
            return GetValue<bool>(name);
        }

        public string GetString(string name) {
            return GetValue<string>(name);
        }

        public DateTime GetDateTime(string name) {
            return GetValue<DateTime>(name);
        }

        public DateTime GetDateTimeFromUnixTimestamp(string name) {
            return SocialUtils.GetDateTimeFromUnixTime(GetValue<int>(name));
        }

        public DateTimeOffset GetDateTimeOffset(string name) {
            return GetValue<DateTimeOffset>(name);
        }

        public bool IsObject(string name) {
            return HasValue(name) && Dictionary[name] is IDictionary<string, object>;
        }

        public bool IsArray(string name) {
            return HasValue(name) && Dictionary[name] is ArrayList;
        }

        public void GetLong(string name, long value) {
            Dictionary[name] = value;
        }

        public void GetDouble(string name, double value) {
            Dictionary[name] = value;
        }

        public void GetBoolean(string name, bool value) {
            Dictionary[name] = value;
        }

        public void SetInt(string name, int value) {
            Dictionary[name] = value;
        }

        public void SetString(string name, string value) {
            Dictionary[name] = value;
        }

        public void SetObject(string name, JsonObject value) {
            Dictionary[name] = (value == null ? null : value.Dictionary);
        }

        public void SetArray(string name, JsonArray value) {
            Dictionary[name] = (value == null ? null : value.InternalArray);
        }

        public void SetNull(string name) {
            Dictionary[name] = null;
        }

        /// <summary>
        /// Gets a JSON string representing the object.
        /// </summary>
        public string ToJson() {
            return JsonConverter.ToJson(this);
        }

        /// <summary>
        /// Save the object to a JSON file at the specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to save the file.</param>
        public void SaveJson(string path) {
            File.WriteAllText(path, ToJson());
        }

        /// <summary>
        /// Load an instance of <var>JsonObject</var> from the JSON file at the specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public static JsonObject LoadJson(string path) {
            return JsonConverter.ParseObject(File.ReadAllText(path));
        }

        /// <summary>
        /// Load an instance of <var>T</var> from the JSON file at the specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="func">The function used to parse the object.</param>
        public static T LoadJson<T>(string path, Func<JsonObject, T> func) {
            return JsonConverter.ParseObject(File.ReadAllText(path), func);
        }

        /// <summary>
        /// Gets an instance of <var>JsonObject</var> from the specified JSON string.
        /// </summary>
        /// <param name="json">The JSON string representation of the object.</param>
        public static JsonObject ParseJson(string json) {
            return JsonConverter.ParseObject(json);
        }

        /// <summary>
        /// Gets an instance of <var>JsonObject</var> from the specified JSON string.
        /// </summary>
        /// <param name="json">The JSON string representation of the object.</param>
        /// <param name="func">The function used to parse the object.</param>
        public static T ParseJson<T>(string json, Func<JsonObject, T> func) {
            return JsonConverter.ParseObject(json, func);
        }
    
    }

}
