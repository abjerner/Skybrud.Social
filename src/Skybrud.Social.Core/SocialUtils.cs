using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
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
    public static partial class SocialUtils {
        

        #region Other
        
        /// <summary>
        /// Parses a query string into an instance of <see cref="NameValueCollection"/> using <see cref="Encoding.UTF8"/> encoding.
        /// </summary>
        /// <param name="query">The query string to parse.</param>
        /// <returns>A <see cref="NameValueCollection"/> of query parameters and values.</returns>
        public static NameValueCollection ParseQueryString(string query) {
            return HttpUtility.ParseQueryString(query);
        }

        /// <summary>
        /// Converts the specified <code>collection</code> into a query string using the proper encoding.
        /// </summary>
        /// <param name="collection">The collection to convert.</param>
        /// <returns>Returns a query string based on the specified <code>collection</code>.</returns>
        public static string NameValueCollectionToQueryString(NameValueCollection collection) {
            return String.Join("&", Array.ConvertAll(collection.AllKeys, key => Strings.UrlEncode(key) + "=" + Strings.UrlEncode(collection[key])));
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
                select Strings.UrlEncode(key) + "=" + Strings.UrlEncode(collection[key])
            ));
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
        /// Parses the specified <code>str</code> into the enum of type <code>T</code>.
        /// </summary>
        /// <typeparam name="T">The type of the enum.</typeparam>
        /// <param name="str">The string to be parsed.</param>
        /// <returns>Returns an enum of type <code>T</code> from the specified <code>str</code>.</returns>
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
        /// Parses the specified <code>str</code> into the enum of type <code>T</code>.
        /// </summary>
        /// <typeparam name="T">The type of the enum.</typeparam>
        /// <param name="str">The string to be parsed.</param>
        /// <param name="fallback">The fallback if the enum could not be parsed.</param>
        /// <returns>Returns an enum of type <code>T</code> from the specified <code>str</code>.</returns>
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
        /// Parses the specified <code>json</code> string into an instance of <code>T</code>.
        /// </summary>
        /// <typeparam name="T">The type to be returned.</typeparam>
        /// <param name="json">The JSON string to be parsed.</param>
        /// <param name="func">A callback function/method used for converting an instance of <see cref="JObject"/> into an instance of <code>T</code>.</param>
        /// <returns>Returns an instance of <code>T</code> parsed from the specified <code>json</code> string.</returns>
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
        /// Parses the specified <code>json</code> string into an array of <code>T</code>.
        /// </summary>
        /// <param name="json">The JSON string to be parsed.</param>
        /// <param name="func">A callback function/method used for converting an instance of <see cref="JObject"/> into an instance of <code>T</code>.</param>
        /// <returns>Returns an array of <code>T</code> parsed from the specified <code>json</code> string.</returns>
        public static T[] ParseJsonArray<T>(string json, Func<JObject, T> func) {
            return (
                from JObject item in ParseJsonArray(json)
                select func(item)
            ).ToArray();
        }

        #endregion

    }

}