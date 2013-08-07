using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Linq;
using Skybrud.Social.Json;

namespace Skybrud.Social {
    
    public static class SocialUtils {

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

        public static string CamelCaseToUnderscore(Enum e) {
            return CamelCaseToUnderscore(e.ToString());
        }
        
        public static string CamelCaseToUnderscore(string str) {
            return Regex.Replace(str, @"(\p{Ll})(\p{Lu})", "$1_$2").ToLower();
        }

        /// <summary>
        /// Converts the specified <var>NameValueCollection</var> into a query string using the proper encoding.
        /// </summary>
        /// <param name="collection">The collection to convert.</param>
        /// <returns></returns>
        public static string NameValueCollectionToQueryString(NameValueCollection collection) {
            return String.Join("&", Array.ConvertAll(collection.AllKeys, key => HttpUtility.UrlEncode(key) + "=" + HttpUtility.UrlEncode(collection[key])));
        }

        public static string NameValueCollectionToQueryString(NameValueCollection collection, bool includeIfNull) {
            return String.Join("&", (
                from string key in collection.Keys
                where collection[key] != null || includeIfNull
                select HttpUtility.UrlEncode(key) + "=" + HttpUtility.UrlEncode(collection[key])
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
            return new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(timestamp);
        }

        public static DateTime GetDateTimeFromUnixTime(double timestamp) {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(timestamp);
        }

        public static DateTime GetDateTimeFromUnixTime(long timestamp) {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(timestamp);
        }

        public static DateTime GetDateTimeFromUnixTime(string timestamp) {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(Int64.Parse(timestamp));
        }

        #endregion

    }

}
