using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces;
using Skybrud.Social.Time;

namespace Skybrud.Social {
    
    /// <summary>
    /// Static class with various utility methods used throughout Skybrud.Social.
    /// </summary>
    public static class SocialUtils {

        #region Version

        /// <summary>
        /// Gets the assembly version as a string.
        /// </summary>
        /// <returns>Returns a string containing the version of the assembly.</returns>
        public static string GetVersion() {
            return typeof (SocialUtils).Assembly.GetName().Version.ToString();
        }

        /// <summary>
        /// Gets the informational version as a string.
        /// </summary>
        /// <returns>Returns a string containing the informational version of the assembly.</returns>
        public static string GetInformationVersion() {
            Assembly assembly = typeof(SocialUtils).Assembly;
            return FileVersionInfo.GetVersionInfo(assembly.Location).ProductVersion;
        }

        /// <summary>
        /// Gets the file version as a string.
        /// </summary>
        /// <returns>Returns a string containing the file version of the assembly.</returns>
        public static string GetFileVersion() {
            Assembly assembly = typeof(SocialUtils).Assembly;
            return FileVersionInfo.GetVersionInfo(assembly.Location).FileVersion;
        }

        /// <summary>
        /// Gets the amount of days between the date of this build and the date the project was started - that is the
        /// 30th of July, 2012.
        /// </summary>
        /// <returns>Returns an integer representing the amount of days since the project was started.</returns>
        public static int GetDaysSinceStart() {

            // Get the third bit as a string
            string str = GetFileVersion().Split('.')[2];

            // Parse the string into an integer
            return Int32.Parse(str);

        }

        /// <summary>
        /// Gets the date of this build of Skybrud.Social.
        /// </summary>
        /// <returns>Gets an instance of <see cref="DateTime"/> representing the build date of the assembly.</returns>
        public static DateTime GetBuildDate() {
            return new DateTime(2012, 7, 30).AddDays(GetDaysSinceStart());
        }

        /// <summary>
        /// Gets the build number of the day. This is mostly used for internal
        /// purposes to distinguish builds with the same assembly version.
        /// </summary>
        /// <returns>Returns an integer representing the build number of the day.</returns>
        public static int GetBuildNumber() {

            // Get the fourth bit as a string
            string str = GetFileVersion().Split('.')[3];

            // Parse the string into an integer
            return Int32.Parse(str);

        }

        #endregion

        #region HTTP helpers

        /// <summary>
        /// Makes a HTTP request using the specified <code>url</code> and <code>method</code>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="method">The HTTP method of the request.</param>
        /// <param name="query">The query string of the request.</param>
        /// <param name="postData">The POST data of the request.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        private static SocialHttpResponse DoHttpRequest(string url, SocialHttpMethod method, SocialQueryString query, SocialPostData postData) {

            // Initialize the request
            SocialHttpRequest request = new SocialHttpRequest {
                Url = url,
                Method = method,
                QueryString = query,
                PostData = postData
            };

            // Make the call to the URL
            return request.GetResponse();

        }

        /// <summary>
        /// Makes a HTTP GET request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public static SocialHttpResponse DoHttpGetRequest(string url) {
            return DoHttpRequest(url, SocialHttpMethod.Get, null, null);
        }

        /// <summary>
        /// Makes a HTTP GET request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="query">The query string of the request.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public static SocialHttpResponse DoHttpGetRequest(string url, SocialQueryString query) {
            return DoHttpRequest(url, SocialHttpMethod.Get, query, null);
        }

        /// <summary>
        /// Makes a HTTP GET request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="query">The query string of the request.</param>
        /// <param name="postData">The POST data of the request.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public static SocialHttpResponse DoHttpPostRequest(string url, SocialQueryString query, SocialPostData postData) {
            return DoHttpRequest(url, SocialHttpMethod.Post, query, postData);
        }

        /// <summary>
        /// Makes a HTTP GET request to the specified <code>url</code>.
        /// </summary>
        /// <param name="url">The URL of the request.</param>
        /// <param name="postData">The POST data of the request.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the response.</returns>
        public static SocialHttpResponse DoHttpPostRequest(string url, SocialPostData postData) {
            return DoHttpRequest(url, SocialHttpMethod.Post, null, postData);
        }

        #endregion

        #region Other

        /// <summary>
        /// Converts a camel cased reprenstation of an enum to a lower case string where words are separated with underscore.
        /// </summary>
        /// <param name="e">The enum to be converted.</param>
        /// <returns>Returns the converted string.</returns>
        public static string CamelCaseToUnderscore(Enum e) {
            return CamelCaseToUnderscore(e.ToString());
        }

        /// <summary>
        /// Converts a camel cased string to a lower case string where words are separated with underscore.
        /// </summary>
        /// <param name="str">The camel cased string to be converted.</param>
        /// <returns>Returns the converted string.</returns>
        public static string CamelCaseToUnderscore(string str) {
            return Regex.Replace(str, @"(\p{Ll})(\p{Lu})", "$1_$2").ToLower();
        }

        /// <summary>
        /// Converts a string separated by underscoes to a upper camel cased string.
        /// </summary>
        /// <param name="str">The camel cased string to be converted.</param>
        /// <returns>Returns the converted string.</returns>
        public static string UnderscoreToCamelCase(string str) {
            if (String.IsNullOrWhiteSpace(str)) return str;
            List<string> temp = new List<string>();
            foreach (string piece in str.Split(new [] {'_'}, StringSplitOptions.RemoveEmptyEntries)) {
                if (piece.Length == 1) {
                    temp.Add(piece.ToUpper());
                } else if (piece.Length > 1) {
                    temp.Add(piece.Substring(0, 1).ToUpper() + piece.Substring(1));
                }
            }
            return String.Join("", temp);
        }

        /// <summary>
        /// Encodes a URL string.
        /// </summary>
        /// <param name="str">The string to be encoded.</param>
        /// <returns>Returns the encoded string.</returns>
        public static string UrlEncode(string str) {
            return HttpUtility.UrlEncode(str);
        }

        /// <summary>
        /// Decodes a URL string.
        /// </summary>
        /// <param name="str">The string to be decoded.</param>
        /// <returns>Returns the decoded string.</returns>
        public static string UrlDecode(string str) {
            return HttpUtility.UrlDecode(str);
        }

        /// <summary>
        /// Parses a query string into an instance of <see cref="NameValueCollection"/> using <see cref="Encoding.UTF8"/> encoding.
        /// </summary>
        /// <param name="query">The query string to parse.</param>
        /// <returns>A <code>System.Collections.Specialized.NameValueCollection</code> of query parameters and values.</returns>
        public static NameValueCollection ParseQueryString(string query) {
            return HttpUtility.ParseQueryString(query);
        }

        /// <summary>
        /// Converts the specified <code>collection</code> into a query string using the proper encoding.
        /// </summary>
        /// <param name="collection">The collection to convert.</param>
        /// <returns>Returns a query string based on the specified <code>collection</code>.</returns>
        public static string NameValueCollectionToQueryString(NameValueCollection collection) {
            return String.Join("&", Array.ConvertAll(collection.AllKeys, key => UrlEncode(key) + "=" + UrlEncode(collection[key])));
        }

        /// <summary>
        /// Converts the specified <code>collection</code> into a query string using the proper encoding.
        /// </summary>
        /// <param name="collection">The collection to convert.</param>
        /// <param name="includeIfNull">Specifies whether items that are <code>null</code> should be included in the query string.</param>
        /// <returns>Returns a query string based on the specified <code>collection</code>.</returns>
        public static string NameValueCollectionToQueryString(NameValueCollection collection, bool includeIfNull) {
            return String.Join("&", (
                from string key in collection.Keys
                where collection[key] != null || includeIfNull
                select UrlEncode(key) + "=" + UrlEncode(collection[key])
            ));
        }

        #endregion

        #region Timestamps

        /// <summary>
        /// ISO 8601 date format.
        /// </summary>
        public const string IsoDateFormat = SocialDateHelpers.IsoDateFormat;

        /// <summary>
        /// Returns the current Unix timestamp which is defined as the amount of seconds since the start of the Unix
        /// epoch - that is <code>1st of January, 1970 - 00:00:00 GMT</code>.
        /// </summary>
        /// <returns>Returns a 64-bit integer representing the current UNIX timestamp.</returns>
        public static long GetCurrentUnixTimestamp() {
            return SocialDateHelpers.GetCurrentUnixTimestamp();
        }

        /// <summary>
        /// Returns the current unix timestamp which is defined as the amount of seconds since the start of the Unix
        /// epoch - that is <code>1st of January, 1970 - 00:00:00 GMT</code>.
        /// </summary>
        /// <returns>Returns a <see cref="double"/> representing the current Unix timestamp.</returns>
        public static double GetCurrentUnixTimestampAsDouble() {
            return SocialDateHelpers.GetCurrentUnixTimestampAsDouble();
        }

        /// <summary>
        /// Gets an instance of <see cref="DateTime"/> from the specified <code>timestamp</code>.
        /// </summary>
        /// <param name="timestamp">The Unix timestamp.</param>
        /// <returns>Returns an instance of <see cref="DateTime"/> from the specified <code>timestamp</code>.</returns>
        public static DateTime GetDateTimeFromUnixTime(int timestamp) {
            return SocialDateHelpers.GetDateTimeFromUnixTime(timestamp);
        }

        /// <summary>
        /// Gets an instance of <see cref="DateTime"/> from the specified <code>timestamp</code>.
        /// </summary>
        /// <param name="timestamp">The Unix timestamp.</param>
        /// <returns>Returns an instance of <see cref="DateTime"/> from the specified <code>timestamp</code>.</returns>
        public static DateTime GetDateTimeFromUnixTime(double timestamp) {
            return SocialDateHelpers.GetDateTimeFromUnixTime(timestamp);
        }

        /// <summary>
        /// Gets an instance of <see cref="DateTime"/> from the specified <code>timestamp</code>.
        /// </summary>
        /// <param name="timestamp">The Unix timestamp.</param>
        /// <returns>Returns an instance of <see cref="DateTime"/> from the specified <code>timestamp</code>.</returns>
        public static DateTime GetDateTimeFromUnixTime(long timestamp) {
            return SocialDateHelpers.GetDateTimeFromUnixTime(timestamp);
        }

        /// <summary>
        /// Gets an instance of <see cref="DateTime"/> from the specified <code>timestamp</code>.
        /// </summary>
        /// <param name="timestamp">The Unix timestamp.</param>
        /// <returns>Returns an instance of <see cref="DateTime"/> from the specified <code>timestamp</code>.</returns>
        public static DateTime GetDateTimeFromUnixTime(string timestamp) {
            return SocialDateHelpers.GetDateTimeFromUnixTime(timestamp);
        }
        
        /// <summary>
        /// Gets a Unix timestamp from the specified <code>dateTime</code>.
        /// </summary>
        /// <param name="dateTime">The instance of <see cref="DateTime"/> to be converted.</param>
        /// <returns>Returns a 64-bit integer representing the the specified <code>dateTime</code>.</returns>
        public static long GetUnixTimeFromDateTime(DateTime dateTime) {
            return SocialDateHelpers.GetUnixTimeFromDateTime(dateTime);
        }

        #endregion

        #region Locations and distance

        /// <summary>
        /// Calculates the distance in meters between two GPS locations.
        /// </summary>
        /// <param name="loc1">The first location.</param>
        /// <param name="loc2">The second location.</param>
        /// <returns>Returns the distance in meters between the two locations.</returns>
        public static double GetDistance(ILocation loc1, ILocation loc2) {
            return GetDistance(loc1.Latitude, loc1.Longitude, loc2.Latitude, loc2.Longitude);
        }

        /// <summary>
        /// Calculates the distance in meters between two GPS locations.
        /// </summary>
        /// <param name="lat1">The latitude of the first location.</param>
        /// <param name="lng1">The longitude of the first location.</param>
        /// <param name="lat2">The latitude of the second location.</param>
        /// <param name="lng2">The longitude of the second location.</param>
        /// <returns>Returns the distance in meters between the two locations.</returns>
        public static double GetDistance(double lat1, double lng1, double lat2, double lng2) {

            // http://stackoverflow.com/a/3440123
            double ee = (Math.PI * lat1 / 180);
            double f = (Math.PI * lng1 / 180);
            double g = (Math.PI * lat2 / 180);
            double h = (Math.PI * lng2 / 180);
            double i = (Math.Cos(ee) * Math.Cos(g) * Math.Cos(f) * Math.Cos(h) + Math.Cos(ee) * Math.Sin(f) * Math.Cos(g) * Math.Sin(h) + Math.Sin(ee) * Math.Sin(g));
            double j = (Math.Acos(i));

            return (6371 * j) * 1000d;

        }

        #endregion

        #region Enums

        /// <summary>
        /// Parses the specified <code>str</code> into the enum of type <see cref="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the enum.</typeparam>
        /// <param name="str">The string to be parsed.</param>
        /// <returns>Returns an enum of type <see cref="T"/> from the specified <code>str</code>.</returns>
        public static T ParseEnum<T>(string str) where T : struct {

            // Check whether the type of T is an enum
            if (!typeof(T).IsEnum) throw new ArgumentException("Generic type T must be an enum");

            // Parse the enum
            foreach (string name in Enum.GetNames(typeof(T))) {
                if (name.ToLowerInvariant() == str.ToLowerInvariant()) {
                    return (T) Enum.Parse(typeof(T), str, true);
                }
            }

            throw new Exception("Unable to parse enum of type " + typeof(T).Name + " from value \"" + str + "\"");

        }

        /// <summary>
        /// Parses the specified <code>str</code> into the enum of type <see cref="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the enum.</typeparam>
        /// <param name="str">The string to be parsed.</param>
        /// <param name="fallback">The fallback if the enum could not be parsed.</param>
        /// <returns>Returns an enum of type <see cref="T"/> from the specified <code>str</code>.</returns>
        public static T ParseEnum<T>(string str, T fallback) where T : struct {

            // Check whether the type of T is an enum
            if (!typeof(T).IsEnum) throw new ArgumentException("Generic type T must be an enum");

            // Parse the enum
            foreach (string name in Enum.GetNames(typeof(T))) {
                if (name.ToLowerInvariant() == str.ToLowerInvariant()) {
                    return (T) Enum.Parse(typeof(T), str, true);
                }
            }

            return fallback;

        }

        #endregion

        #region JSON

        /// <summary>
        /// Parses the specified <code>json</code> string into an instance <see cref="JObject"/>.
        /// </summary>
        /// <param name="json">The JSON string to be parsed.</param>
        /// <returns>Returns an instance of <see cref="JObject"/> parsed from the specified <code>json</code> string.</returns>
        public static JObject ParseJsonObject(string json) {

            // JSON.net is automatically parsing strings that look like dates into in actual dates so that we can't
            // really read as strings without some localization going on. Since this is kinda annoying an we don't
            // really need it, we can luckily disable it with the lines below
            return JObject.Load(new JsonTextReader(new StringReader(json)) {
                DateParseHandling = DateParseHandling.None
            });

        }

        /// <summary>
        /// Parses the specified <code>json</code> string into an instance of <see cref="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to be returned.</typeparam>
        /// <param name="json">The JSON string to be parsed.</param>
        /// <param name="func">A callback function/method used for converting an instance of <see cref="JObject"/> into an instance of <see cref="T"/>.</param>
        /// <returns>Returns an instance of <see cref="T"/> parsed from the specified <code>json</code> string.</returns>
        public static T ParseJsonObject<T>(string json, Func<JObject, T> func) {
            return func(ParseJsonObject(json));
        }

        /// <summary>
        /// Parses the specified <code>json</code> string into an instance of <see cref="JArray"/>.
        /// </summary>
        /// <param name="json">The JSON string to be parsed.</param>
        /// <returns>Returns an instance of <see cref="JArray"/> parsed from the specified <code>json</code> string.</returns>
        public static JArray ParseJsonArray(string json) {

            // JSON.net is automatically parsing strings that look like dates into in actual dates so that we can't
            // really read as strings without some localization going on. Since this is kinda annoying an we don't
            // really need it, we can luckily disable it with the lines below
            return JArray.Load(new JsonTextReader(new StringReader(json)) {
                DateParseHandling = DateParseHandling.None
            });

        }

        /// <summary>
        /// Parses the specified <code>json</code> string into an array of <see cref="T"/>.
        /// </summary>
        /// <param name="json">The JSON string to be parsed.</param>
        /// <param name="func">A callback function/method used for converting an instance of <see cref="JObject"/> into an instance of <see cref="T"/>.</param>
        /// <returns>Returns an array of <see cref="T"/> parsed from the specified <code>json</code> string.</returns>
        public static T[] ParseJsonArray<T>(string json, Func<JObject, T> func) {
            return (
                from JObject item in ParseJsonArray(json)
                select func(item)
            ).ToArray();
        }

        #endregion

    }

}