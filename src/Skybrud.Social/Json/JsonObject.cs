using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Skybrud.Social.Json {

    /// <summary>
    /// Class representing a JSON object.
    /// </summary>
    public class JsonObject : IJsonObject {

        #region Properties
        
        /// <summary>
        /// Gets a reference to the underlying dictionary.
        /// </summary>
        public IDictionary<string, object> Dictionary { get; private set; }

        /// <summary>
        /// Gets an array of all keys in the underlying dictionary.
        /// </summary>
        public string[] Keys {
            get { return Dictionary.Keys.ToArray(); }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new JSON object.
        /// </summary>
        public JsonObject() {
            Dictionary = new Dictionary<string, object>();
        }

        /// <summary>
        /// Initializes a new JSON object from the specified <code>dictionary</code>.
        /// </summary>
        /// <param name="dictionary">The dictionary the JSON object should be based on.</param>
        public JsonObject(IDictionary<string, object> dictionary) {
            Dictionary = dictionary;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets whether a property with the specified <code>propertyName</code> exists, and has a value different from <code>null</code>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        public bool HasValue(string propertyName) {
            return Dictionary.ContainsKey(propertyName) && Dictionary[propertyName] != null;
        }

        /// <summary>
        /// Gets an instance of <code>JsonObject</code> from a property with specified <code>propertyName</code>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        public JsonObject GetObject(string propertyName) {
            object value;
            return Dictionary.TryGetValue(propertyName, out value) && value is Dictionary<string, object> ? new JsonObject((Dictionary<string, object>)value) : null;
        }

        /// <summary>
        /// Gets an instance of <code>T</code> from the <code>JsonObject</code> of the property with the specified <code>propertyName</code>.
        /// </summary>
        /// <typeparam name="T">The return type.</typeparam>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="func">A callback function used for parsing or converting the property value.</param>
        public T GetObject<T>(string propertyName, Func<JsonObject, T> func) {
            JsonObject obj = GetObject(propertyName);
            return obj == null ? default(T) : func(obj);
        }

        /// <summary>
        /// Gets an instance of <code>JsonArray</code> from a property with specified <code>propertyName</code>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        public JsonArray GetArray(string propertyName) {
            object value;
            return Dictionary.TryGetValue(propertyName, out value) && value is ArrayList ? new JsonArray((ArrayList)value) : null;
        }

        /// <summary>
        /// Gets an array of <code>T</code> from a property with specified <code>propertyName</code>.
        /// </summary>
        /// <typeparam name="T">The type of items in the array.</typeparam>
        /// <param name="propertyName">The name of the property.</param>
        public T[] GetArray<T>(string propertyName) {
            object value;
            JsonArray array = Dictionary.TryGetValue(propertyName, out value) && value is ArrayList ? new JsonArray((ArrayList)value) : null;
            return array == null ? null : array.Cast<T>();
        }

        /// <summary>
        /// Gets an array of <code>T</code> from a property with specified <code>propertyName</code>.
        /// </summary>
        /// <typeparam name="T">The type of items in the array.</typeparam>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="func">A callback function used for parsing or converting the property value.</param>
        public T[] GetArray<T>(string propertyName, Func<JsonObject, T> func) {
            JsonArray array = GetArray(propertyName);
            return array == null ? null : array.ParseMultiple(func);
        }

        /// <summary>
        /// Gets an array of strings.
        /// </summary>
        /// <param name="propertyName">The name of the property holding the array.</param>
        public string[] GetStringArray(string propertyName) {
            JsonArray array = GetArray(propertyName);
            return array == null ? null : array.For((arr, index) => arr.GetString(index));
        }

        /// <summary>
        /// Gets an array of 32-bit integers (<code>int</code>).
        /// </summary>
        /// <param name="propertyName">The name of the property holding the array.</param>
        public int[] GetInt32Array(string propertyName) {
            JsonArray array = GetArray(propertyName);
            return array == null ? null : array.For((arr, index) => arr.GetInt32(index));
        }

        /// <summary>
        /// Gets an array of 64-bit integers (<code>long</code>).
        /// </summary>
        /// <param name="propertyName">The name of the property holding the array.</param>
        public long[] GetInt64Array(string propertyName) {
            JsonArray array = GetArray(propertyName);
            return array == null ? null : array.For((arr, index) => arr.GetInt64(index));
        }

        /// <summary>
        /// Gets an array of floating point values (<code>float</code>).
        /// </summary>
        /// <param name="propertyName">The name of the property holding the array.</param>
        public float[] GetFloatArray(string propertyName) {
            JsonArray array = GetArray(propertyName);
            return array == null ? null : array.For((arr, index) => arr.GetFloat(index));
        }

        /// <summary>
        /// Gets an array of doubles.
        /// </summary>
        /// <param name="propertyName">The name of the property holding the array.</param>
        public double[] GetDoubleArray(string propertyName) {
            JsonArray array = GetArray(propertyName);
            return array == null ? null : array.For((arr, index) => arr.GetDouble(index));
        }

        /// <summary>
        /// Gets the value of the property with the specified <code>propertyName</code>.
        /// </summary>
        /// <typeparam name="T">The return type.</typeparam>
        /// <param name="propertyName">The name of the property holding the array.</param>
        public T GetValue<T>(string propertyName) {
            return GetValue<T>(propertyName, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Gets the value of the property with the specified <code>propertyName</code>.
        /// </summary>
        /// <typeparam name="T">The return type.</typeparam>
        /// <param name="propertyName">The name of the property holding the array.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        public T GetValue<T>(string propertyName, IFormatProvider provider) {
            if (!HasValue(propertyName)) return default(T);
            if (typeof(T) == typeof(JsonObject)) {
                object obj = Dictionary[propertyName];
                if (obj is Dictionary<string, object>) {
                    obj = new JsonObject((Dictionary<string, object>)Dictionary[propertyName]);
                }
                return (T) obj;
            }
            return (T) Convert.ChangeType(Dictionary[propertyName], typeof(T), provider);
        }

        /// <summary>
        /// Gets the value of the property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        public int GetInt32(string propertyName) {
            return GetValue<int>(propertyName);
        }

        /// <summary>
        /// Gets the value of the property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="func">A callback function used for parsing or converting the property value.</param>
        public T GetInt32<T>(string propertyName, Func<int, T> func) {
            return func(GetValue<int>(propertyName));
        }

        /// <summary>
        /// Gets the value of the property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        public long GetInt64(string propertyName) {
            return GetValue<long>(propertyName);
        }

        /// <summary>
        /// Gets the value of the property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="func">A callback function used for parsing or converting the property value.</param>
        public T GetInt64<T>(string propertyName, Func<long, T> func) {
            return func(GetValue<long>(propertyName));
        }

        /// <summary>
        /// Gets the value of the property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        public float GetFloat(string propertyName) {
            return GetValue<float>(propertyName);
        }

        /// <summary>
        /// Gets the value of the property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="func">A callback function used for parsing or converting the property value.</param>
        public T GetFloat<T>(string propertyName, Func<float, T> func) {
            return func(GetValue<float>(propertyName));
        }

        /// <summary>
        /// Gets the value of the property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        public float GetFloat(string propertyName, IFormatProvider provider) {
            return GetValue<float>(propertyName, provider);
        }

        /// <summary>
        /// Gets the value of the property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <param name="func">A callback function used for parsing or converting the property value.</param>
        public T GetFloat<T>(string propertyName, IFormatProvider provider, Func<float, T> func) {
            return func(GetValue<float>(propertyName, provider));
        }

        /// <summary>
        /// Gets the value of the property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        public double GetDouble(string propertyName) {
            return GetValue<double>(propertyName);
        }

        /// <summary>
        /// Gets the value of the property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="func">A callback function used for parsing or converting the property value.</param>
        public T GetDouble<T>(string propertyName, Func<double, T> func) {
            return func(GetValue<double>(propertyName));
        }

        /// <summary>
        /// Gets the value of the property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        public double GetDouble(string propertyName, IFormatProvider provider) {
            return GetValue<double>(propertyName, provider);
        }

        /// <summary>
        /// Gets the value of the property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <param name="func">A callback function used for parsing or converting the property value.</param>
        public T GetDouble<T>(string propertyName, IFormatProvider provider, Func<double, T> func) {
            return func(GetValue<double>(propertyName, provider));
        }

        /// <summary>
        /// Gets the value of the property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        public bool GetBoolean(string propertyName) {
            return GetValue<bool>(propertyName);
        }

        /// <summary>
        /// Gets the value of the property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="func">A callback function used for parsing or converting the property value.</param>
        public T GetBoolean<T>(string propertyName, Func<bool, T> func) {
            return func(GetValue<bool>(propertyName));
        }

        /// <summary>
        /// Gets the value of the property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        public string GetString(string propertyName) {
            return GetValue<string>(propertyName);
        }

        /// <summary>
        /// Gets the value of the property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="func">A callback function used for parsing or converting the property value.</param>
        public T GetString<T>(string propertyName, Func<string, T> func) {
            return func(GetValue<string>(propertyName));
        }

        /// <summary>
        /// Gets the value of the property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        public DateTime GetDateTime(string propertyName) {
            return GetValue<DateTime>(propertyName);
        }

        /// <summary>
        /// Gets the value of the property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        public DateTime GetDateTimeFromUnixTimestamp(string propertyName) {
            return SocialUtils.GetDateTimeFromUnixTime(GetValue<int>(propertyName));
        }

        /// <summary>
        /// Gets the value of the property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        public DateTimeOffset GetDateTimeOffset(string propertyName) {
            return GetValue<DateTimeOffset>(propertyName);
        }

        /// <summary>
        /// Gets whether the value of the property with the specified <code>propertyName</code> is an object.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        public bool IsObject(string propertyName) {
            return HasValue(propertyName) && Dictionary[propertyName] is IDictionary<string, object>;
        }

        /// <summary>
        /// Gets whether the value of the property with the specified <code>propertyName</code> is an array.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        public bool IsArray(string propertyName) {
            return HasValue(propertyName) && Dictionary[propertyName] is ArrayList;
        }

        /// <summary>
        /// Gets the value of the property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        public T GetEnum<T>(string propertyName) where T : struct {
            return SocialUtils.ParseEnum<T>(GetString(propertyName));
        }

        /// <summary>
        /// Gets the value of the property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="fallback">The fallback value if the property value could not be parsed.</param>
        public T GetEnum<T>(string propertyName, T fallback) where T : struct {
            string value = GetString(propertyName);
            return String.IsNullOrWhiteSpace(value) ? fallback : SocialUtils.ParseEnum(value, fallback);
        }

        /// <summary>
        /// Sets the value of the property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="value">The new value of the property.</param>
        [Obsolete("Use the SetInt32 method instead.")]
        public void SetInt(string propertyName, int value) {
            Dictionary[propertyName] = value;
        }

        /// <summary>
        /// Sets the value of the property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="value">The new value of the property.</param>
        public void SetInt32(string propertyName, int value) {
            Dictionary[propertyName] = value;
        }

        /// <summary>
        /// Sets the value of the property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="value">The new value of the property.</param>
        public void SetInt64(string propertyName, long value) {
            Dictionary[propertyName] = value;
        }

        /// <summary>
        /// Sets the value of the property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="value">The new value of the property.</param>
        public void SetDouble(string propertyName, double value) {
            Dictionary[propertyName] = value;
        }

        /// <summary>
        /// Sets the value of the property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="value">The new value of the property.</param>
        public void SetBoolean(string propertyName, bool value) {
            Dictionary[propertyName] = value;
        }

        /// <summary>
        /// Sets the value of the property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="value">The new value of the property.</param>
        public void SetString(string propertyName, string value) {
            Dictionary[propertyName] = value;
        }

        /// <summary>
        /// Sets the value of the property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="value">The new value of the property.</param>
        public void SetObject(string propertyName, JsonObject value) {
            Dictionary[propertyName] = (value == null ? null : value.Dictionary);
        }

        /// <summary>
        /// Sets the value of the property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="value">The new value of the property.</param>
        public void SetArray(string propertyName, JsonArray value) {
            Dictionary[propertyName] = (value == null ? null : value.InternalArray);
        }

        /// <summary>
        /// Sets the value of the property with the specified <code>propertyName</code> to <code>null</code>.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        public void SetNull(string propertyName) {
            Dictionary[propertyName] = null;
        }

        /// <summary>
        /// Gets a JSON string representing the object.
        /// </summary>
        public string ToJson() {
            return JsonConverter.ToJson(this);
        }

        /// <summary>
        /// Save the object to a JSON file at the specified <code>path</code>.
        /// </summary>
        /// <param name="path">The path to save the file.</param>
        public void SaveJson(string path) {
            File.WriteAllText(path, ToJson());
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Loads an instance of <code>JsonObject</code> from the JSON file at the specified <code>path</code>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public static JsonObject LoadJson(string path) {
            return JsonConverter.ParseObject(File.ReadAllText(path));
        }

        /// <summary>
        /// Loads an instance of <code>T</code> from the JSON file at the specified <code>path</code>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="func">The function used to parse the object.</param>
        public static T LoadJson<T>(string path, Func<JsonObject, T> func) {
            return JsonConverter.ParseObject(File.ReadAllText(path), func);
        }

        /// <summary>
        /// Gets an instance of <code>JsonObject</code> from the specified JSON string.
        /// </summary>
        /// <param name="json">The JSON string representation of the object.</param>
        public static JsonObject ParseJson(string json) {
            return JsonConverter.ParseObject(json);
        }

        /// <summary>
        /// Gets an instance of <code>T</code> from the specified JSON string.
        /// </summary>
        /// <param name="json">The JSON string representation of the object.</param>
        /// <param name="func">The function used to parse the object.</param>
        public static T ParseJson<T>(string json, Func<JsonObject, T> func) {
            return JsonConverter.ParseObject(json, func);
        }

        #endregion

    }

}