using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Skybrud.Social.Json.Extensions {

    /// <summary>
    /// Various extensions methods for <see cref="JArray"/> that makes manual parsing easier.
    /// </summary>
    public static class JArrayExtensions {

        /// <summary>
        /// Gets an object from the item at the specified <code>index</code> in the array.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="index">The index of the item.</param>
        /// <returns>Returns an instance of <see cref="JObject"/>, or <code>null</code> if not found.</returns>
        public static JObject GetObject(this JArray array, int index) {
            if (array == null) return null;
            return array[index] as JObject;
        }

        /// <summary>
        /// Gets an object from the item at the specified <code>index</code> in the array. If an object is found, it is
        /// parsed to the type of <code>T</code>.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="index">The index of the item.</param>
        /// <returns>Returns an instance of <code>T</code>, or the default value of <code>T</code> if not found.</returns>
        public static T GetObject<T>(this JArray array, int index) {
            if (array == null) return default(T);
            JObject child = array[0] as JObject;
            return child == null ? default(T) : child.ToObject<T>();
        }

        /// <summary>
        /// Gets an object from the item at the specified <code>index</code> in the array. If an object is found, the
        /// object is parsed using the specified delegate <code>func</code>.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="index">The index of the item.</param>
        /// <param name="func">The delegate (callback method) used for parsing the object.</param>
        /// <returns>Returns an instance of <code>T</code>.</returns>
        public static T GetObject<T>(this JArray array, int index, Func<JObject, T> func) {
            return func(array == null ? null : array[index] as JObject);
        }

        /// <summary>
        /// Gets an object from token matching the specified <code>path</code>.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>Returns an instance of <see cref="JObject"/>, or <code>null</code> if not found.</returns>
        public static JObject GetObject(this JArray array, string path) {
            if (array == null) return null;
            return array.SelectToken(path) as JObject;
        }

        /// <summary>
        /// Gets an object from token matching the specified <code>path</code>. If an object is found, it is
        /// parsed to the type of <code>T</code>.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>Returns an instance of <code>T</code>, or the default value of <code>T</code> if not found.</returns>
        public static T GetObject<T>(this JArray array, string path) {
            if (array == null) return default(T);
            JObject child = array.SelectToken(path) as JObject;
            return child == null ? default(T) : child.ToObject<T>();
        }

        /// <summary>
        /// Gets an object from token matching the specified <code>path</code>. If an object is found, the object is
        /// parsed using the specified delegate <code>func</code>.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <param name="func">The delegate (callback method) used for parsing the object.</param>
        /// <returns>Returns an instance of <code>T</code>.</returns>
        public static T GetObject<T>(this JArray array, string path, Func<JObject, T> func) {
            return func(array == null ? null : array.SelectToken(path) as JObject);
        }

        /// <summary>
        /// Gets a string from the item at the specified <code>index</code> in the array.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="index">The index of the item.</param>
        public static string GetString(this JArray array, int index) {
            if (array == null) return null;
            JToken property = array[index];
            return property == null ? null : property.Value<string>();
        }

        /// <summary>
        /// Gets a string from the token matching the specified <code>path</code>.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>Returns an instance of <see cref="String"/>, or <code>null</code> if <code>path</code> didn't match any tokens.</returns>
        public static string GetString(this JArray array, string path) {
            if (array == null) return null;
            JToken token = array.SelectToken(path);
            return token == null ? null : token.Value<string>();
        }

        /// <summary>
        /// Gets the <see cref="System.Int32"/> value of the item at the specified <code>index</code> in the array.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="index">The index of the item.</param>
        /// <returns>Returns an instance of <see cref="System.Int32"/>.</returns>
        public static int GetInt32(this JArray array, int index) {
            if (array == null) return default(int);
            JToken property = array[index];
            return property == null ? default(int) : property.Value<int>();
        }

        /// <summary>
        /// Gets the <see cref="System.Int32"/> value of the token matching the specified <code>path</code>, or
        /// <code>0</code> if <code>path</code> doesn't match a token.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>Returns an instance of <see cref="System.Int32"/>.</returns>
        public static int GetInt32(this JArray array, string path) {
            if (array == null) return default(int);
            JToken token = array.SelectToken(path);
            return token == null ? default(int) : token.Value<int>();
        }

        /// <summary>
        /// Gets the <see cref="System.Int64"/> value of the item at the specified <code>index</code> in the array.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="index">The index of the item.</param>
        /// <returns>Returns an instance of <see cref="System.Int64"/>.</returns>
        public static long GetInt64(this JArray array, int index) {
            if (array == null) return default(long);
            JToken property = array[index];
            return property == null ? default(long) : property.Value<long>();
        }

        /// <summary>
        /// Gets the <see cref="System.Int64"/> value of the token matching the specified <code>path</code>.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>Returns an instance of <see cref="System.Int64"/>.</returns>
        public static long GetInt64(this JArray array, string path) {
            if (array == null) return default(long);
            JToken token = array.SelectToken(path);
            return token == null ? default(long) : token.Value<long>();
        }

        /// <summary>
        /// Gets the <see cref="System.Double"/> value of the item at the specified <code>index</code> in the array.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="index">The index of the item.</param>
        /// <returns>Returns an instance of <see cref="System.Double"/>.</returns>
        public static double GetDouble(this JArray array, int index) {
            if (array == null) return default(double);
            JToken property = array[index];
            return property == null ? default(double) : property.Value<double>();
        }

        /// <summary>
        /// Gets the <see cref="System.Double"/> value of the token matching the specified <code>path</code>.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>Returns an instance of <see cref="System.Double"/>.</returns>
        public static double GetDouble(this JArray array, string path) {
            if (array == null) return default(double);
            JToken token = array.SelectToken(path);
            return token == null ? default(double) : token.Value<double>();
        }

        /// <summary>
        /// Gets the <see cref="System.Boolean"/> value of the item at the specified <code>index</code> in the array.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="index">The index of the item.</param>
        /// <returns>Returns an instance of <see cref="System.Boolean"/>.</returns>
        public static bool GetBoolean(this JArray array, int index) {
            if (array == null) return default(bool);
            JToken property = array[index];
            return property != null && property.Value<bool>();
        }

        /// <summary>
        /// Gets the <see cref="System.Boolean"/> value of the token matching the specified <code>path</code>.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>Returns an instance of <see cref="System.Boolean"/>.</returns>
        public static bool GetBoolean(this JArray array, string path) {
            if (array == null) return default(bool);
            JToken token = array.SelectToken(path);
            return token == null ? default(bool) : token.Value<bool>();
        }

        /// <summary>
        /// Gets an instance of <see cref="JArray"/> from the item at the specified <code>index</code> in the array.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="index">The index of the item.</param>
        /// <returns>Returns an instance of <see cref="JArray"/>.</returns>
        public static JArray GetArray(this JArray array, int index) {
            return array == null ? null : array[index] as JArray;
        }

        /// <summary>
        /// Gets an array of <code>T</code> from the item at the specified <code>index</code> in the array using the
        /// specified delegate <code>func</code> for parsing each item in the array.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="index">The index of the item.</param>
        /// <param name="func">The delegate (callback method) used for parsing each item in the array.</param>
        /// <returns>Returns an array of <code>T</code>.</returns>
        public static T[] GetArray<T>(this JArray array, int index, Func<JObject, T> func) {

            if (array == null) return null;

            JArray property = array[index] as JArray;
            if (property == null) return null;

            return (
                from JObject child in property
                select func(child)
            ).ToArray();

        }

        /// <summary>
        /// Gets an instance of <see cref="JArray"/> from the token matching the specified <code>path</code>.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>Returns an instance of <see cref="JArray"/>.</returns>
        public static JArray GetArray(this JArray array, string path) {
            return array == null ? null : array.SelectToken(path) as JArray;
        }

        /// <summary>
        /// Gets an array of <code>T</code> from the from the token matching the specified <code>path</code> in the array using the
        /// specified delegate <code>func</code> for parsing each item in the array.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <param name="func">The delegate (callback method) used for parsing each item in the array.</param>
        /// <returns>Returns an array of <code>T</code>.</returns>
        public static T[] GetArray<T>(this JArray array, string path, Func<JObject, T> func) {

            if (array == null) return null;

            JArray token = array.SelectToken(path) as JArray;
            if (token == null) return null;

            return (
                from JObject child in token
                select func(child)
            ).ToArray();

        }

    }

}