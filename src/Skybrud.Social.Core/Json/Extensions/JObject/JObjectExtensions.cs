using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Skybrud.Social.Json.Extensions.JObject {
    
    /// <summary>
    /// Various extensions methods for <code>JObject</code> that makes manual parsing easier.
    /// </summary>
    public static class JObjectExtension {

        /// <summary>
        /// Gets an object from a property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="obj">The parent object of the property.</param>
        /// <param name="propertyName">The name of the property.</param>
        public static Newtonsoft.Json.Linq.JObject GetObject(this Newtonsoft.Json.Linq.JObject obj, string propertyName) {
            if (obj == null) return null;
            return obj.GetValue(propertyName) as Newtonsoft.Json.Linq.JObject;
        }

        /// <summary>
        /// Gets an object from a property with the specified <code>propertyName</code>. If an object is found, it is
        /// parsed to the type of <code>T</code>.
        /// </summary>
        /// <param name="obj">The parent object of the property.</param>
        /// <param name="propertyName">The name of the property.</param>
        public static T GetObject<T>(this Newtonsoft.Json.Linq.JObject obj, string propertyName) {
            if (obj == null) return default(T);
            Newtonsoft.Json.Linq.JObject child = obj.GetValue(propertyName) as Newtonsoft.Json.Linq.JObject;
            return child == null ? default(T) : child.ToObject<T>();
        }

        /// <summary>
        /// Gets an object from a property with the specified <code>propertyName</code>. If an object is found, the
        /// object is parsed using the specified delegate <code>func</code>.
        /// </summary>
        /// <param name="obj">The parent object of the property.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="func">The delegate (callback method) used for parsing the object.</param>
        public static T GetObject<T>(this Newtonsoft.Json.Linq.JObject obj, string propertyName, Func<Newtonsoft.Json.Linq.JObject, T> func) {
            return obj == null ? default(T) : func(obj.GetValue(propertyName) as Newtonsoft.Json.Linq.JObject);
        }

        /// <summary>
        /// Gets a string from a property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="obj">The parent object of the property.</param>
        /// <param name="propertyName">The name of the property.</param>
        public static string GetString(this Newtonsoft.Json.Linq.JObject obj, string propertyName) {
            if (obj == null) return null;
            JToken property = obj.GetValue(propertyName);
            return property == null ? null : property.Value<string>();
        }

        /// <summary>
        /// Gets the string value from the property with the specified <code>propertyName</code> and parses it into an
        /// instance of <code>T</code> using the specified <code>callback</code>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The parent object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="callback">The callback used for converting the string value.</param>
        public static T GetString<T>(this Newtonsoft.Json.Linq.JObject obj, string propertyName, Func<string, T> callback) {
            if (obj == null) return default(T);
            JToken property = obj.GetValue(propertyName);
            return property == null ? default(T) : callback(property.Value<string>());
        }

        /// <summary>
        /// Gets a 32-bit integer (int) from a property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="obj">The parent object of the property.</param>
        /// <param name="propertyName">The name of the property.</param>
        public static int GetInt32(this Newtonsoft.Json.Linq.JObject obj, string propertyName) {
            if (obj == null) return default(int);
            JToken property = obj.GetValue(propertyName);
            return property == null ? default(int) : property.Value<int>();
        }

        /// <summary>
        /// Gets a 32-bit integer (int) from a property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="obj">The parent object of the property.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="func">A callback function used for parsing or converting the property value.</param>
        public static T GetInt34<T>(this Newtonsoft.Json.Linq.JObject obj, string propertyName, Func<int, T> func) {
            if (obj == null) return default(T);
            JToken property = obj.GetValue(propertyName);
            return property == null ? default(T) : func(property.Value<int>());
        }

        /// <summary>
        /// Gets the integer value from the property with the specified <code>propertyName</code> and parses it into an instance of
        /// <code>T</code> using the specified <code>callback</code>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The parent object.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="callback">The callback used for converting the integer value.</param>
        public static T GetInt32<T>(this Newtonsoft.Json.Linq.JObject obj, string propertyName, Func<int, T> callback) {
            if (obj == null) return default(T);
            JToken property = obj.GetValue(propertyName);
            return property == null ? default(T) : callback(property.Value<int>());
        }

        /// <summary>
        /// Gets 64-bit integer (long) from a property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="obj">The parent object of the property.</param>
        /// <param name="propertyName">The name of the property.</param>
        public static long GetInt64(this Newtonsoft.Json.Linq.JObject obj, string propertyName) {
            if (obj == null) return default(long);
            JToken property = obj.GetValue(propertyName);
            return property == null ? default(long) : property.Value<long>();
        }

        /// <summary>
        /// Gets 64-bit integer (long) from a property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="obj">The parent object of the property.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="func">A callback function used for parsing or converting the property value.</param>
        public static T GetInt64<T>(this Newtonsoft.Json.Linq.JObject obj, string propertyName, Func<long, T> func) {
            if (obj == null) return default(T);
            JToken property = obj.GetValue(propertyName);
            return property == null ? default(T) : func(property.Value<long>());
        }

        /// <summary>
        /// Gets a float from a property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="obj">The parent object of the property.</param>
        /// <param name="propertyName">The name of the property.</param>
        public static float GetFloat(this Newtonsoft.Json.Linq.JObject obj, string propertyName) {
            if (obj == null) return default(float);
            JToken property = obj.GetValue(propertyName);
            return property == null ? default(float) : property.Value<float>();
        }

        /// <summary>
        /// Gets a float from a property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="obj">The parent object of the property.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="func">A callback function used for parsing or converting the property value.</param>
        public static T GetFloat<T>(this Newtonsoft.Json.Linq.JObject obj, string propertyName, Func<float, T> func) {
            if (obj == null) return default(T);
            JToken property = obj.GetValue(propertyName);
            return property == null ? default(T) : func(property.Value<float>());
        }

        /// <summary>
        /// Gets a double from a property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="obj">The parent object of the property.</param>
        /// <param name="propertyName">The name of the property.</param>
        public static double GetDouble(this Newtonsoft.Json.Linq.JObject obj, string propertyName) {
            if (obj == null) return default(double);
            JToken property = obj.GetValue(propertyName);
            return property == null ? default(double) : property.Value<double>();
        }

        /// <summary>
        /// Gets a double from a property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="obj">The parent object of the property.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="func">A callback function used for parsing or converting the property value.</param>
        public static T GetDouble<T>(this Newtonsoft.Json.Linq.JObject obj, string propertyName, Func<double, T> func) {
            if (obj == null) return default(T);
            JToken property = obj.GetValue(propertyName);
            return property == null ? default(T) : func(property.Value<double>());
        }

        /// <summary>
        /// Gets a boolean from a property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="obj">The parent object of the property.</param>
        /// <param name="propertyName">The name of the property.</param>
        public static bool GetBoolean(this Newtonsoft.Json.Linq.JObject obj, string propertyName) {
            if (obj == null) return default(bool);
            JToken property = obj.GetValue(propertyName);
            return property != null && property.Value<bool>();
        }

        /// <summary>
        /// Gets an enum of type <code>T</code> from the property with the specified <code>propertyName</code>.
        /// </summary>
        /// <typeparam name="T">The type of the enum.</typeparam>
        /// <param name="obj">The instance of <code>JObject</code>.</param>
        /// <param name="propertyName">The name of the property.</param>
        public static T GetEnum<T>(this Newtonsoft.Json.Linq.JObject obj, string propertyName) where T : struct {
            return SocialUtils.ParseEnum<T>(GetString(obj, propertyName));
        }

        /// <summary>
        /// Gets an enum of type <code>T</code> from the property with the specified <code>propertyName</code>.
        /// </summary>
        /// <typeparam name="T">The type of the enum.</typeparam>
        /// <param name="obj">The instance of <code>JObject</code>.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="fallback">The fallback value if the value in the JSON couldn't be parsed.</param>
        public static T GetEnum<T>(this Newtonsoft.Json.Linq.JObject obj, string propertyName, T fallback) where T : struct {
            string value = GetString(obj, propertyName);
            return String.IsNullOrWhiteSpace(value) ? fallback : SocialUtils.ParseEnum(value, fallback);
        }

        /// <summary>
        /// Gets an instance of <code>JArray</code> from a property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="obj">The parent object of the property.</param>
        /// <param name="propertyName">The name of the property.</param>
        public static JArray GetArray(this Newtonsoft.Json.Linq.JObject obj, string propertyName) {
            return obj == null ? null : obj.GetValue(propertyName) as JArray;
        }

        /// <summary>
        /// Gets an array of <code>T</code> from a property with the specified <code>propertyName</code> using the
        /// specified delegate <code>func</code> for parsing each item in the array.
        /// </summary>
        /// <param name="obj">The parent object of the property.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <param name="func">The delegate (callback method) used for parsing each item in the array.</param>
        public static T[] GetArray<T>(this Newtonsoft.Json.Linq.JObject obj, string propertyName, Func<Newtonsoft.Json.Linq.JObject, T> func) {

            if (obj == null) return null;

            JArray property = obj.GetValue(propertyName) as JArray;
            if (property == null) return null;

            return (
                from Newtonsoft.Json.Linq.JObject child in property
                select func(child)
            ).ToArray();

        }

        /// <summary>
        /// Gets an instance of <code>DateTime</code> from a property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="obj">The parent object of the property.</param>
        /// <param name="propertyName">The name of the property.</param>
        public static DateTime GetDateTime(this Newtonsoft.Json.Linq.JObject obj, string propertyName) {
            if (obj == null) return default(DateTime);
            JToken property = obj.GetValue(propertyName);
            return property == null ? default(DateTime) : DateTime.Parse(property.Value<string>());
        }

        /// <summary>
        /// Gets whether a property with the specified whether a property with the specified <code>propertyName</code>
        /// exists and isn't <code>null</code> (or an empty string).
        /// </summary>
        /// <param name="obj">The parent object of the property.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>Returns <code>true</code> if the property exists and the value isn't <code>null</code>, otherwise <code>false</code>.</returns>
        public static bool HasValue(this Newtonsoft.Json.Linq.JObject obj, string propertyName) {

            // Jusrt return "false" now if "obj" is "null"
            if (obj == null) return false;
            
            // Get the property (and return "null" if not found)
            JProperty property = obj.Property(propertyName);

            // And the final check
            return property != null && !String.IsNullOrEmpty(property.Value + "");

        }

        /// <summary>
        /// Gets a string array from the property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="obj">The parent object of the property.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>Returns the property value as a string array.</returns>
        public static string[] GetStringArray(this Newtonsoft.Json.Linq.JObject obj, string propertyName) {

            // Get the array
            JArray array = obj.GetArray(propertyName);

            // Parse the array items
            return array.Select(token => (string) Convert.ChangeType(token, typeof (string))).ToArray();
        
        }

        /// <summary>
        /// Gets an array of <code>int</code> from the property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="obj">The parent object of the property.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>Returns the property value as an array of <code>int</code>.</returns>
        public static int[] GetInt32Array(this Newtonsoft.Json.Linq.JObject obj, string propertyName) {
            return obj.GetArray(propertyName, x => (int) Convert.ChangeType(x, typeof(int)));
        }

        /// <summary>
        /// Gets an array of <code>long</code> from the property with the specified <code>propertyName</code>.
        /// </summary>
        /// <param name="obj">The parent object of the property.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>Returns the property value as an array of <code>long</code>.</returns>
        public static long[] GetInt64Array(this Newtonsoft.Json.Linq.JObject obj, string propertyName) {
            return obj.GetArray(propertyName, x => (long) Convert.ChangeType(x, typeof(long)));
        }

    }

}