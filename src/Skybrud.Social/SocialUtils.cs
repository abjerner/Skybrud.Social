using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Linq;
using Skybrud.Social.Interfaces;
using Skybrud.Social.Json;

namespace Skybrud.Social {
    
    /// <summary>
    /// Static class with various utility methods used througout Skybrud.Social.
    /// </summary>
    public static class SocialUtils {

        #region Version

        /// <summary>
        /// Gets the assembly version as a string.
        /// </summary>
        public static string GetVersion() {
            return typeof (SocialUtils).Assembly.GetName().Version.ToString();
        }

        /// <summary>
        /// Gets the file version as a string.
        /// </summary>
        /// <returns></returns>
        public static string GetFileVersion() {
            Assembly assembly = typeof(SocialUtils).Assembly;
            return FileVersionInfo.GetVersionInfo(assembly.Location).FileVersion;
        }

        /// <summary>
        /// Gets the amount of days between the date of this build and the date the project was started - that is the 30th of July, 2012.
        /// </summary>
        public static int GetDaysSinceStart() {

            // Get the third bit as a string
            string str = GetFileVersion().Split('.')[2];

            // Parse the string into an integer
            return Int32.Parse(str);

        }

        /// <summary>
        /// Gets the date of this build of Skybrud.Social.
        /// </summary>
        public static DateTime GetBuildDate() {
            return new DateTime(2012, 7, 30).AddDays(GetDaysSinceStart());
        }

        /// <summary>
        /// Gets the build number of the day. This is mostly used for internal
        /// purposes to distinguish builds with the same assembly version.
        /// </summary>
        public static int GetBuildNumber() {

            // Get the fourth bit as a string
            string str = GetFileVersion().Split('.')[3];

            // Parse the string into an integer
            return Int32.Parse(str);

        }

        #endregion

        #region HTTP helpers

        private static HttpWebResponse DoHttpRequest(string url, string method, NameValueCollection queryString, NameValueCollection postData) {

            // TODO: Decide better naming of method

            // Merge the query string
            url = new UriBuilder(url).MergeQueryString(queryString).ToString();

            // Initialize the request
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);

            // Set the method
            request.Method = method;

            // Add the request body (if a POST request)
            if (method == "POST" && postData != null && postData.Count > 0) {
                string dataString = NameValueCollectionToQueryString(postData);
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = dataString.Length;
                using (Stream stream = request.GetRequestStream()) {
                    stream.Write(Encoding.UTF8.GetBytes(dataString), 0, dataString.Length);
                }
            }

            // Get the response
            try {
                return (HttpWebResponse)request.GetResponse();
            } catch (WebException ex) {
                return (HttpWebResponse)ex.Response;
            }

        }

        #region GET

        public static HttpWebResponse DoHttpGetRequest(string baseUrl, NameValueCollection queryString = null) {
            return DoHttpRequest(baseUrl, "GET", queryString, null);
        }

        public static string DoHttpGetRequestAndGetBodyAsString(string url, NameValueCollection queryString = null) {
            return DoHttpGetRequest(url, queryString).GetAsString();
        }

        public static IJsonObject DoHttpGetRequestAndGetBodyAsJson(string url, NameValueCollection queryString = null) {
            return DoHttpGetRequest(url, queryString).GetAsJson();
        }

        public static JsonObject DoHttpGetRequestAndGetBodyAsJsonObject(string url, NameValueCollection queryString = null) {
            return DoHttpGetRequest(url, queryString).GetAsJsonObject();
        }

        public static JsonArray DoHttpGetRequestAndGetBodyAsJsonArray(string url, NameValueCollection queryString = null) {
            return DoHttpGetRequest(url, queryString).GetAsJsonArray();
        }

        public static XElement DoHttpGetRequestAndGetBodyAsXml(string url, NameValueCollection queryString = null) {
            HttpWebResponse response = DoHttpGetRequest(url, queryString);
            Stream stream = response.GetResponseStream();
            return stream == null ? null : XElement.Parse(new StreamReader(stream).ReadToEnd());
        }

        #endregion

        #region POST

        public static HttpWebResponse DoHttpPostRequest(string baseUrl, NameValueCollection queryString, NameValueCollection postData) {
            return DoHttpRequest(baseUrl, "POST", queryString, postData);
        }

        public static string DoHttpPostRequestAndGetBodyAsString(string url, NameValueCollection queryString = null, NameValueCollection postData = null) {
            return DoHttpPostRequest(url, queryString, postData).GetAsString();
        }

        public static IJsonObject DoHttpPostRequestAndGetBodyAsJson(string url, NameValueCollection queryString = null, NameValueCollection postData = null) {
            return DoHttpPostRequest(url, queryString, postData).GetAsJson();
        }

        public static JsonObject DoHttpPostRequestAndGetBodyAsJsonObject(string url, NameValueCollection queryString = null, NameValueCollection postData = null) {
            return DoHttpPostRequest(url, queryString, postData).GetAsJsonObject();
        }

        public static JsonArray DoHttpPostRequestAndGetBodyAsJsonArray(string url, NameValueCollection queryString = null, NameValueCollection postData = null) {
            return DoHttpPostRequest(url, queryString, postData).GetAsJsonArray();
        }

        public static XElement DoHttpPostRequestAndGetBodyAsXml(string url, NameValueCollection queryString = null, NameValueCollection postData = null) {
            HttpWebResponse response = DoHttpPostRequest(url, queryString, postData);
            Stream stream = response.GetResponseStream();
            return stream == null ? null : XElement.Parse(new StreamReader(stream).ReadToEnd());
        }

        #endregion

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
        /// Parses a query string into a <code>System.Collections.Specialized.NameValueCollection</code> using <code>System.Text.Encoding.UTF8</code> encoding.
        /// </summary>
        /// <param name="query">The query string to parse.</param>
        /// <returns>A <code>System.Collections.Specialized.NameValueCollection</code> of query parameters and values.</returns>
        public static NameValueCollection ParseQueryString(string query) {
            return HttpUtility.ParseQueryString(query);
        }

        /// <summary>
        /// Converts the specified <var>NameValueCollection</var> into a query string using the proper encoding.
        /// </summary>
        /// <param name="collection">The collection to convert.</param>
        /// <returns></returns>
        public static string NameValueCollectionToQueryString(NameValueCollection collection) {
            return String.Join("&", Array.ConvertAll(collection.AllKeys, key => UrlEncode(key) + "=" + UrlEncode(collection[key])));
        }

        public static string NameValueCollectionToQueryString(NameValueCollection collection, bool includeIfNull) {
            return String.Join("&", (
                from string key in collection.Keys
                where collection[key] != null || includeIfNull
                select UrlEncode(key) + "=" + UrlEncode(collection[key])
            ));
        }

        public static T GetAttributeValue<T>(XElement xElement, string name) {
            string value = xElement.Attribute(name).Value;
            return (T)Convert.ChangeType(value, typeof(T));
        }

        public static T GetAttributeValueOrDefault<T>(XElement xElement, string name) {
            XAttribute attr = xElement.Attribute(name);
            if (attr == null) return default(T);
            return (T)Convert.ChangeType(attr.Value, typeof(T));
        }

        public static T GetElementValue<T>(XElement xElement, string name) {
            string value = xElement.Element(name).Value;
            return (T)Convert.ChangeType(value, typeof(T));
        }

        public static T GetElementValueOrDefault<T>(XElement xElement, string name) {
            XElement e = xElement.Element(name);
            if (e == null) return default(T);
            return (T)Convert.ChangeType(e.Value, typeof(T));
        }

        #endregion

        #region Timestamps

        /// <summary>
        /// ISO 8601 date format.
        /// </summary>
        public const string IsoDateFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ssK";

        /// <summary>
        /// Returns the current unix timestamp which is defined as the amount of seconds
        /// since the start of the Unix epoch - 1st of January, 1970 - 00:00:00 GMT.
        /// </summary>
        public static long GetCurrentUnixTimestamp() {
            return (long) Math.Floor(GetCurrentUnixTimestampAsDouble());
        }

        /// <summary>
        /// Returns the current unix timestamp which is defined as the amount of seconds
        /// since the start of the Unix epoch - 1st of January, 1970 - 00:00:00 GMT.
        /// </summary>
        public static double GetCurrentUnixTimestampAsDouble() {
            return (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
        }

        public static DateTime GetDateTimeFromUnixTime(int timestamp) {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(timestamp);
        }

        public static DateTime GetDateTimeFromUnixTime(double timestamp) {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(timestamp);
        }

        public static DateTime GetDateTimeFromUnixTime(long timestamp) {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(timestamp);
        }

        public static DateTime GetDateTimeFromUnixTime(string timestamp) {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(Int64.Parse(timestamp));
        }
        
        public static long GetUnixTimeFromDateTime(DateTime dateTime) {
            return (int) (dateTime.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
        }

        #endregion

        #region Locations and distance

        /// <summary>
        /// Calculates the distance in meters between two GPS locations.
        /// </summary>
        /// <param name="loc1">The first location.</param>
        /// <param name="loc2">The second location.</param>
        public static double GetDistance(ILocation loc1, ILocation loc2) {
            return GetDistance(loc1.Latitude, loc1.Longitude, loc2.Latitude, loc2.Longitude);
        }

        /// <summary>
        /// Calculates the distance in meters between two GPS locations.
        /// </summary>
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
        
        public static T ParseEnum<T>(string str, T fallback) where T : struct {

            // Check whether the type of T is an enum
            if (!typeof(T).IsEnum) throw new ArgumentException("Generic type T must be an enum");

            // Parse the enum
            foreach (string name in Enum.GetNames(typeof(T))) {
                if (name.ToLowerInvariant() == str.ToLowerInvariant()) {
                    return (T)Enum.Parse(typeof(T), str, true);
                }
            }

            return fallback;

        }

        #endregion

    }

}
