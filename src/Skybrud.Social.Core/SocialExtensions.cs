using System;
using System.Collections.Specialized;
using Skybrud.Social.Interfaces;

namespace Skybrud.Social {

    /// <summary>
    /// Varois extension methods used throughout the Skybrud.Social implementation.
    /// </summary>
    public static class SocialExtensions {
        
        /// <summary>
        /// Calculates the distance in meters between two GPS locations.
        /// </summary>
        /// <param name="loc1">The first location.</param>
        /// <param name="loc2">The second location.</param>
        public static double GetDistance(this ILocation loc1, ILocation loc2) {
            return SocialUtils.Locations.GetDistance(loc1, loc2);
        }
        
        /// <summary>
        /// Appends the specified <code>query</code> to <code>builder</code>.
        /// </summary>
        /// <param name="builder">The URI builder.</param>
        /// <param name="query">The query string.</param>
        public static void AppendQueryString(this UriBuilder builder, NameValueCollection query) {
            if (query == null || query.Count == 0) return;
            NameValueCollection nvc = SocialUtils.ParseQueryString(builder.Query);
            nvc.Add(query);
            builder.Query = SocialUtils.NameValueCollectionToQueryString(nvc);
        }

        /// <summary>
        /// Merges <code>builder</code> with the specified <code>query</code>.
        /// </summary>
        /// <param name="builder">The URI builder.</param>
        /// <param name="query">The query string.</param>
        /// <returns>Returns the builder.</returns>
        public static UriBuilder MergeQueryString(this UriBuilder builder, NameValueCollection query) {
            if (query == null || query.Count == 0) return builder;
            builder.Query = SocialUtils.NameValueCollectionToQueryString(SocialUtils.ParseQueryString(builder.Query).Set(query));
            return builder;
        }
        
        /// <summary>
        /// Merges the values of <code>query</code> into <code>subject</code>.
        /// </summary>
        /// <param name="subject">The subject.</param>
        /// <param name="query">The query with the new values.</param>
        /// <returns>Returns the subject.</returns>
        public static NameValueCollection Set(this NameValueCollection subject, NameValueCollection query) {
            if (query == null || query.Count == 0) return subject;
            foreach (string key in query.AllKeys) {
                subject.Set(key, query[key]);
            }
            return subject;
        }
    
    }

}