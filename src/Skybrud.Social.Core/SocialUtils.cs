using System;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;

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

    }

}