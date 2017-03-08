using System;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using Skybrud.Essentials.Strings;

namespace Skybrud.Social {

    public static partial class SocialUtils {

        /// <summary>
        /// Static class with miscellaneous utility methods.
        /// </summary>
        public static class Misc {

            /// <summary>
            /// Parses the specified <paramref name="query"/> into an instance of <see cref="NameValueCollection"/>
            /// using <see cref="Encoding.UTF8"/> encoding.
            /// </summary>
            /// <param name="query">The query string to parse.</param>
            /// <returns>An instance of <see cref="NameValueCollection"/> with the query parameters and values.</returns>
            public static NameValueCollection ParseQueryString(string query) {
                return HttpUtility.ParseQueryString(query);
            }

            /// <summary>
            /// Converts the specified <paramref name="collection"/> into a query string using the proper encoding.
            /// </summary>
            /// <param name="collection">The collection to convert.</param>
            /// <returns>A query string based on the specified <paramref name="collection"/>.</returns>
            public static string NameValueCollectionToQueryString(NameValueCollection collection) {
                return String.Join("&", Array.ConvertAll(collection.AllKeys, key => StringHelper.UrlEncode(key) + "=" + StringHelper.UrlEncode(collection[key])));
            }

            /// <summary>
            /// Converts the specified <paramref name="collection"/> into a query string using the proper encoding.
            /// </summary>
            /// <param name="collection">The collection to convert.</param>
            /// <param name="includeIfNull">Specifies whether items that are <code>null</code> should be included in
            /// the query string.</param>
            /// <returns>A query string based on the specified <paramref name="collection"/>.</returns>
            public static string NameValueCollectionToQueryString(NameValueCollection collection, bool includeIfNull) {
                return String.Join("&", (
                    from string key in collection.Keys
                    where collection[key] != null || includeIfNull
                    select StringHelper.UrlEncode(key) + "=" + StringHelper.UrlEncode(collection[key])
                ));
            }

        }

    }

}