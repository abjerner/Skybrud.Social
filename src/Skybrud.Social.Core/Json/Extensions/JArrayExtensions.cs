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
        public static Newtonsoft.Json.Linq.JObject GetObject(this JArray array, int index) {
            if (array == null) return null;
            return array[index] as Newtonsoft.Json.Linq.JObject;
        }

        /// <summary>
        /// Gets an object from the item at the specified <code>index</code> in the array. If an object is found, it is
        /// parsed to the type of <code>T</code>.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="index">The index of the item.</param>
        public static T GetObject<T>(this JArray array, int index) {
            if (array == null) return default(T);
            Newtonsoft.Json.Linq.JObject child = array[0] as Newtonsoft.Json.Linq.JObject;
            return child == null ? default(T) : child.ToObject<T>();
        }

        /// <summary>
        /// Gets an object from the item at the specified <code>index</code> in the array. If an object is found, the
        /// object is parsed using the specified delegate <code>func</code>.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="index">The index of the item.</param>
        /// <param name="func">The delegate (callback method) used for parsing the object.</param>
        public static T GetObject<T>(this JArray array, int index, Func<Newtonsoft.Json.Linq.JObject, T> func) {
            return array == null ? default(T) : func(array[index] as Newtonsoft.Json.Linq.JObject);
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
        /// Gets a 32-bit integer (int) from the item at the specified <code>index</code> in the array.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="index">The index of the item.</param>
        public static int GetInt32(this JArray array, int index) {
            if (array == null) return default(int);
            JToken property = array[index];
            return property == null ? default(int) : property.Value<int>();
        }

        /// <summary>
        /// Gets 64-bit integer (long) from the item at the specified <code>index</code> in the array.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="index">The index of the item.</param>
        public static long GetInt64(this JArray array, int index) {
            if (array == null) return default(long);
            JToken property = array[index];
            return property == null ? default(long) : property.Value<long>();
        }

        /// <summary>
        /// Gets a double from the item at the specified <code>index</code> in the array.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="index">The index of the item.</param>
        public static double GetDouble(this JArray array, int index) {
            if (array == null) return default(double);
            JToken property = array[index];
            return property == null ? default(double) : property.Value<double>();
        }

        /// <summary>
        /// Gets a boolean from the item at the specified <code>index</code> in the array.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="index">The index of the item.</param>
        public static bool GetBoolean(this JArray array, int index) {
            if (array == null) return default(bool);
            JToken property = array[index];
            return property != null && property.Value<bool>();
        }

        /// <summary>
        /// Gets an instance of <see cref="JArray"/> from the item at the specified <code>index</code> in the array.
        /// </summary>
        /// <param name="array">The parent array.</param>
        /// <param name="index">The index of the item.</param>
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
        public static T[] GetArray<T>(this JArray array, int index, Func<Newtonsoft.Json.Linq.JObject, T> func) {

            if (array == null) return null;

            JArray property = array[index] as JArray;
            if (property == null) return null;

            return (
                from Newtonsoft.Json.Linq.JObject child in property
                select func(child)
            ).ToArray();

        }

    }

}