using System;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Skybrud.Social.Json.Extensions {
    
    /// <summary>
    /// Various extensions methods for <see cref="JObject"/> that makes manual parsing easier.
    /// </summary>
    public static class JObjectExtension {

        /// <summary>
        /// Gets whether a token matching the specified <code>path</code> exists and isn't <code>null</code> (or an empty string).
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>Returns <code>true</code> if the property exists and the value isn't <code>null</code>, otherwise <code>false</code>.</returns>
        public static bool HasValue(this JObject obj, string path) {
            JToken token = obj == null ? null : obj.SelectToken(path);
            return !(
                token == null
                ||
                (token.Type == JTokenType.Array && !token.HasValues)
                ||
                (token.Type == JTokenType.Object && !token.HasValues)
                ||
                (token.Type == JTokenType.String && token.ToString() == String.Empty)
                ||
                token.Type == JTokenType.Null
            );
        }

        /// <summary>
        /// Gets an object from a token matching the specified <code>path</code>.
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>Returns an instance of <see cref="JObject"/>, or <code>null</code> if not found.</returns>
        public static JObject GetObject(this JObject obj, string path) {
            if (obj == null) return null;
            return obj.SelectToken(path) as JObject;
        }

        /// <summary>
        /// Gets an object from a token matching the specified <code>path</code>.
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>Returns an instance of <see cref="T"/>, or the default value of <see cref="T"/> if not found.</returns>
        public static T GetObject<T>(this JObject obj, string path) {
            if (obj == null) return default(T);
            JObject child = obj.SelectToken(path) as JObject;
            return child == null ? default(T) : child.ToObject<T>();
        }

        /// <summary>
        /// Gets an object from a token matching the specified <code>path</code>.
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <param name="func">The delegate (callback method) used for parsing the object.</param>
        /// <returns>Returns an instance of <see cref="T"/>, or the default value of <see cref="T"/> if not found.</returns>
        public static T GetObject<T>(this JObject obj, string path, Func<JObject, T> func) {
            return obj == null ? default(T) : func(obj.SelectToken(path) as JObject);
        }

        /// <summary>
        /// Gets the string value of the token matching the specified <code>path</code>, or <code>null</code> if <code>path</code> doesn't match a token.
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>Returns an instance of <see cref="String"/>, or <code>null</code>.</returns>
        public static string GetString(this JObject obj, string path) {
            if (obj == null) return null;
            JToken token = obj.SelectToken(path);
            return token == null ? null : token.Value<string>();
        }

        /// <summary>
        /// Gets the value of the token matching the specified <code>path</code>, or <code>null</code> if <code>path</code> doesn't match a token.
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <param name="callback">The callback used for converting the string value.</param>
        /// <returns>Returns an instance of <see cref="T"/>, or <code>null</code>.</returns>
        public static T GetString<T>(this JObject obj, string path, Func<string, T> callback) {
            if (obj == null) return default(T);
            JToken token = obj.SelectToken(path);
            return token == null ? default(T) : callback(token.Value<string>());
        }
        
        /// <summary>
        /// Gets the <see cref="System.Int32"/> value of the token matching the specified <code>path</code>, or
        /// <code>0</code> if <code>path</code> doesn't match a token.
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>Returns an instance of <see cref="System.Int32"/>.</returns>
        public static int GetInt32(this JObject obj, string path) {
            if (obj == null) return default(int);
            JToken token = obj.SelectToken(path);
            return token == null || token.Type == JTokenType.Null ? default(int) : token.Value<int>();
        }

        /// <summary>
        /// Gets the <see cref="System.Int32"/> value of the token matching the specified <code>path</code> and parses
        /// it into an instance of <code>T</code>, or the default value of <code>T</code> if <code>path</code> doesn't
        /// match a token.
        /// </summary>
        /// <typeparam name="T">The type of the parsed type.</typeparam>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <param name="callback">The callback used for converting the integer value.</param>
        /// <returns>Returns an instance of <see cref="System.Int32"/>, or <code>0</code> if <code>path</code> doesn't
        /// match a token.</returns>
        public static T GetInt32<T>(this JObject obj, string path, Func<int, T> callback) {
            if (obj == null) return default(T);
            JToken token = obj.SelectToken(path);
            return token == null || token.Type == JTokenType.Null ? default(T) : callback(token.Value<int>());
        }

        /// <summary>
        /// Gets the <see cref="System.Int64"/> value of the token matching the specified <code>path</code>, or
        /// <code>0</code> if <code>path</code> doesn't match a token.
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>Returns an instance of <see cref="System.Int64"/>.</returns>
        public static long GetInt64(this JObject obj, string path) {
            if (obj == null) return default(long);
            JToken token = obj.SelectToken(path);
            return token == null || token.Type == JTokenType.Null ? default(long) : token.Value<long>();
        }

        /// <summary>
        /// Gets the <see cref="System.Int64"/> value of the token matching the specified <code>path</code> and parses
        /// it into an instance of <code>T</code>, or the default value of <code>T</code> if <code>path</code> doesn't
        /// match a token.
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <param name="callback">The callback used for converting the token value.</param>
        /// <returns>Returns an instance of <see cref="System.Int64"/>, or <code>0</code> if <code>path</code> doesn't
        /// match a token.</returns>
        public static T GetInt64<T>(this JObject obj, string path, Func<long, T> callback) {
            if (obj == null) return default(T);
            JToken token = obj.SelectToken(path);
            return token == null || token.Type == JTokenType.Null ? default(T) : callback(token.Value<long>());
        }

        /// <summary>
        /// Gets the <see cref="System.Single"/> value of the token matching the specified <code>path</code>, or
        /// <code>0</code> if <code>path</code> doesn't match a token.
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>Returns an instance of <see cref="System.Int64"/>.</returns>
        public static float GetFloat(this JObject obj, string path) {
            if (obj == null) return default(float);
            JToken token = obj.SelectToken(path);
            return token == null || token.Type == JTokenType.Null ? default(float) : token.Value<float>();
        }

        /// <summary>
        /// Gets the <see cref="System.Single"/> value of the token matching the specified <code>path</code> and parses
        /// it into an instance of <code>T</code>, or the default value of <code>T</code> if <code>path</code> doesn't
        /// match a token.
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <param name="callback">A callback function used for parsing or converting the token value.</param>
        /// <returns>Returns an instance of <see cref="System.Single"/>, or <code>0</code> if <code>path</code> doesn't
        /// match a token.</returns>
        public static T GetFloat<T>(this JObject obj, string path, Func<long, T> callback) {
            if (obj == null) return default(T);
            JToken token = obj.SelectToken(path);
            return token == null || token.Type == JTokenType.Null ? default(T) : callback(token.Value<long>());
        }

        /// <summary>
        /// Gets the <see cref="System.Double"/> value of the token matching the specified <code>path</code>, or
        /// <code>0</code> if <code>path</code> doesn't match a token.
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>Returns an instance of <see cref="System.Double"/>.</returns>
        public static double GetDouble(this JObject obj, string path) {
            if (obj == null) return default(double);
            JToken token = obj.SelectToken(path);
            return token == null || token.Type == JTokenType.Null ? default(double) : token.Value<double>();
        }

        /// <summary>
        /// Gets the <see cref="System.Double"/> value of the token matching the specified <code>path</code> and parses
        /// it into an instance of <code>T</code>, or the default value of <code>T</code> if <code>path</code> doesn't
        /// match a token.
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <param name="callback">A callback function used for parsing or converting the token value.</param>
        /// <returns>Returns an instance of <see cref="System.Double"/>, or <code>0</code> if <code>path</code> doesn't
        /// match a token.</returns>
        public static T GetDouble<T>(this JObject obj, string path, Func<double, T> callback) {
            if (obj == null) return default(T);
            JToken token = obj.SelectToken(path);
            return token == null || token.Type == JTokenType.Null ? default(T) : callback(token.Value<long>());
        }

        /// <summary>
        /// Gets the <see cref="System.Boolean"/> value of the token matching the specified <code>path</code>, or
        /// <code>0</code> if <code>path</code> doesn't match a token.
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>Returns an instance of <see cref="System.Boolean"/>.</returns>
        public static bool GetBoolean(this JObject obj, string path) {
            if (obj == null) return default(bool);
            JToken token = obj.SelectToken(path);
            return token == null || token.Type == JTokenType.Null ? default(bool) : token.Value<bool>();
        }

        /// <summary>
        /// Gets the <see cref="System.Boolean"/> value of the token matching the specified <code>path</code> and
        /// parses it into an instance of <code>T</code>, or the default value of <code>T</code> if <code>path</code>
        /// doesn't match a token.
        /// </summary>
        /// <param name="obj">The parent object.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <param name="callback">A callback function used for parsing or converting the token value.</param>
        /// <returns>Returns an instance of <see cref="System.Boolean"/>, or <code>false</code> if <code>path</code>
        /// doesn't match a token.</returns>
        public static T GetBoolean<T>(this JObject obj, string path, Func<double, T> callback) {
            if (obj == null) return default(T);
            JToken token = obj.SelectToken(path);
            return token == null || token.Type == JTokenType.Null ? default(T) : callback(token.Value<long>());
        }

        /// <summary>
        /// Gets an enum of type <code>T</code> from the token matching the specified <code>path</code>.
        /// </summary>
        /// <typeparam name="T">The type of the enum.</typeparam>
        /// <param name="obj">The instance of <see cref="JObject"/>.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>Returns an instance of <see cref="T"/>.</returns>
        public static T GetEnum<T>(this JObject obj, string path) where T : struct {
            return SocialUtils.Enums.ParseEnum<T>(GetString(obj, path));
        }

        /// <summary>
        /// Gets an enum of type <code>T</code> from the token matching the specified <code>path</code>.
        /// </summary>
        /// <typeparam name="T">The type of the enum.</typeparam>
        /// <param name="obj">The instance of <see cref="JObject"/>.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <param name="fallback">The fallback value if the value in the JSON couldn't be parsed.</param>
        public static T GetEnum<T>(this JObject obj, string path, T fallback) where T : struct {
            string value = GetString(obj, path);
            return String.IsNullOrWhiteSpace(value) ? fallback : SocialUtils.Enums.ParseEnum(value, fallback);
        }

        /// <summary>
        /// Gets an instance of <see cref="DateTime"/> from the value of the token matching the specified <code>path</code>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/>.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>Returns an instance of <see cref="DateTime"/> representing the value of the property.</returns>
        public static DateTime GetDateTime(this JObject obj, string path) {
            if (obj == null) return default(DateTime);
            JToken token = obj.SelectToken(path);
            if (token == null || token.Type == JTokenType.Null) return default(DateTime);
            return token.Type == JTokenType.Date ? token.Value<DateTime>() : DateTime.Parse(token.Value<string>());
        }

        /// <summary>
        /// Gets an instance of <see cref="DateTime"/> from the value of the token matching the specified <code>path</code>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/>.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <param name="styles">A bitwise combination of the enumeration values that indicates the style elements that
        /// can be present in the property value for the parse operation to succeed and that defines how to interpret
        /// the parsed date in relation to the current time zone or the current date. A typical value to specify is
        /// <see cref="System.Globalization.DateTimeStyles.None"/>.</param>
        /// <returns>Returns an instance of <see cref="DateTime"/> representing the value of the property.</returns>
        public static DateTime GetDateTime(this JObject obj, string path, DateTimeStyles styles) {
            return obj.GetString(path, x => DateTime.Parse(x, CultureInfo.InvariantCulture, styles));
        }

        /// <summary>
        /// Gets an instance of <see cref="DateTime"/> from the value of the token matching the specified <code>path</code>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/>.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information about the property value.</param>
        /// <param name="styles">A bitwise combination of the enumeration values that indicates the style elements that
        /// can be present in the property value for the parse operation to succeed and that defines how to interpret
        /// the parsed date in relation to the current time zone or the current date. A typical value to specify is
        /// <see cref="System.Globalization.DateTimeStyles.None"/>.</param>
        /// <returns>Returns an instance of <see cref="DateTime"/> representing the value of the property.</returns>
        public static DateTime GetDateTime(this JObject obj, string path, IFormatProvider provider, DateTimeStyles styles) {
            return obj.GetString(path, x => DateTime.Parse(x, provider, styles));
        }

        /// <summary>
        /// Gets an instance of <see cref="JArray"/> from the token matching the specified <code>path</code>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/>.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>Returns an instance of <see cref="JArray"/>, or <code>null</code> if not found.</returns>
        public static JArray GetArray(this JObject obj, string path) {
            if (obj == null) return null;
            JToken token = obj.SelectToken(path);
            return token == null || token.Type == JTokenType.Null ? null : token as JArray;
        }

        /// <summary>
        /// Gets an array of <code>T</code> from a property with the specified <code>propertyName</code> using the
        /// specified delegate <code>func</code> for parsing each item in the array.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/>.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <param name="callback">A callback function used for parsing or converting the token value.</param>
        public static T[] GetArray<T>(this JObject obj, string path, Func<JObject, T> callback) {

            if (obj == null) return null;

            JArray token = obj.SelectToken(path) as JArray;
            if (token == null) return null;

            return (
                from JObject child in token
                select callback(child)
            ).ToArray();

        }

        /// <summary>
        /// Gets the items of the <see cref="JArray"/> from the token matching the specfied <code>path</code>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/>.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>Returns an array of <see cref="JToken"/>. If the a matching token isn't found, an empty array will
        /// still be returned.</returns>
        public static JToken[] GetArrayItems(this JObject obj, string path) {
            JArray array = GetArray(obj, path);
            return array == null ? new JToken[0] : array.ToArray();
        }

        /// <summary>
        /// Gets the items of the <see cref="JArray"/> from the token matching the specfied <code>path</code>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/>.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>Returns an array of <see cref="T"/>. If the a matching token isn't found, an empty array will
        /// still be returned.</returns>
        public static T[] GetArrayItems<T>(this JObject obj, string path) {

            if (obj == null) return new T[0];

            JArray token = obj.SelectToken(path) as JArray;
            if (token == null) return new T[0];

            return (
                from JToken child in token
                select child.Value<T>()
            ).ToArray();

        }

        /// <summary>
        /// Gets the items of the <see cref="JArray"/> from the token matching the specfied <code>path</code>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/>.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <param name="callback">A callback function used for parsing or converting the token value.</param>
        /// <returns>Returns an array of <see cref="T"/>. If the a matching token isn't found, an empty array will
        /// still be returned.</returns>
        public static T[] GetArrayItems<T>(this JObject obj, string path, Func<JToken, T> callback) {

            if (obj == null) return new T[0];

            JArray token = obj.SelectToken(path) as JArray;
            if (token == null) return new T[0];

            return (
                from JObject child in token
                select callback(child)
            ).ToArray();

        }

        /// <summary>
        /// Gets the items of the <see cref="JArray"/> from the token matching the specfied <code>path</code>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/>.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <param name="callback">A callback function used for parsing or converting the token value.</param>
        /// <returns>Returns an array of <see cref="T"/>. If the a matching token isn't found, an empty array will
        /// still be returned.</returns>
        public static T[] GetArrayItems<T>(this JObject obj, string path, Func<JObject, T> callback) {

            if (obj == null) return new T[0];

            JArray token = obj.SelectToken(path) as JArray;
            if (token == null) return new T[0];

            return (
                from JObject child in token
                select callback(child)
            ).ToArray();

        }

        /// <summary>
        /// Gets the items of the <see cref="JArray"/> from the token matching the specfied <code>path</code>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/>.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <param name="callback">A callback function used for parsing or converting the token value.</param>
        /// <returns>Returns an array of <see cref="TValue"/>. If the a matching token isn't found, an empty array will
        /// still be returned.</returns>
        public static TValue[] GetArrayItems<TKey, TValue>(this JObject obj, string path, Func<TKey, TValue> callback) where TKey : JToken {

            if (obj == null) return new TValue[0];

            JArray token = obj.SelectToken(path) as JArray;
            if (token == null) return new TValue[0];

            return (
                from TKey child in token
                select callback(child)
            ).ToArray();
        
        }

        /// <summary>
        /// Gets an array of <see cref="System.String"/> from the token matching the specified <code>path</code>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/>.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>Returns the token value as an array of <see cref="System.String"/>.</returns>
        public static string[] GetStringArray(this JObject obj, string path) {
            return GetArrayItems<string>(obj, path);
        }

        /// <summary>
        /// Gets an array of <see cref="System.Int32"/> from the token matching the specified <code>path</code>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/>.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>Returns the token value as an array of <see cref="System.Int32"/>.</returns>
        public static int[] GetInt32Array(this JObject obj, string path) {
            return GetArrayItems<int>(obj, path);
        }

        /// <summary>
        /// Gets an array of <see cref="System.Int64"/> from the token matching the specified <code>path</code>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/>.</param>
        /// <param name="path">A <see cref="String"/> that contains a JPath expression.</param>
        /// <returns>Returns the token value as an array of <see cref="System.Int64"/>.</returns>
        public static long[] GetInt64Array(this JObject obj, string path) {
            return GetArrayItems<long>(obj, path);
        }

    }

}