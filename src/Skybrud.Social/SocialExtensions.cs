using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using Skybrud.Social.Interfaces;
using Skybrud.Social.Json;

namespace Skybrud.Social {

    public static class SocialExtensions {
        
        /// <summary>
        /// Serializes the specified collection of <code>SocialJsonObject</code> to a raw JSON
        /// string.
        /// </summary>
        /// <param name="collection">The collection to be serialized.</param>
        public static string ToJson(this IEnumerable<SocialJsonObject> collection) {
            if (collection == null) return null;
            var array = (from item in collection select (object) item.JsonObject).ToArray();
            return new JsonArray(array).ToJson();
        }

        /// <summary>
        /// Serializes and saves the specified collection of <code>SocialJsonObject</code> to a raw
        /// JSON string.
        /// </summary>
        /// <param name="collection">The collection to be serialized.</param>
        /// <param name="path">The path to the file.</param>
        public static void SaveJson(this IEnumerable<SocialJsonObject> collection, string path) {
            if (collection == null) return;
            var array = (from item in collection select (object) item.JsonObject).ToArray();
            new JsonArray(array).SaveJson(path);
        }

        /// <summary>
        /// Calculates the distance in meters between two GPS locations.
        /// </summary>
        /// <param name="loc1">The first location.</param>
        /// <param name="loc2">The second location.</param>
        public static double GetDistance(this ILocation loc1, ILocation loc2) {
            return SocialUtils.GetDistance(loc1, loc2);
        }
        
        public static string GetAsString(this HttpWebResponse response) {
            if (response == null) return null;
            using (var stream = response.GetResponseStream()) {
                if (stream == null) return null;
                using (StreamReader reader = new StreamReader(stream)) {
                    return reader.ReadToEnd();
                }
            }
        }

        public static IJsonObject GetAsJson(this HttpWebResponse response) {
            Stream stream = response.GetResponseStream();
            return stream == null ? null : JsonConverter.Parse(new StreamReader(stream).ReadToEnd());
        }

        public static JsonObject GetAsJsonObject(this HttpWebResponse response) {
            return GetAsJson(response) as JsonObject;
        }

        public static JsonArray GetAsJsonArray(this HttpWebResponse response) {
            return GetAsJson(response) as JsonArray;
        }
        
        public static void AppendQueryString(this UriBuilder builder, NameValueCollection values) {
            if (values == null || values.Count == 0) return;
            NameValueCollection nvc = HttpUtility.ParseQueryString(builder.Query);
            nvc.Add(values);
            builder.Query = SocialUtils.NameValueCollectionToQueryString(nvc);
        }
        
        public static UriBuilder MergeQueryString(this UriBuilder builder, NameValueCollection values) {
            if (values == null || values.Count == 0) return builder;
            builder.Query = SocialUtils.NameValueCollectionToQueryString(HttpUtility.ParseQueryString(builder.Query).Set(values));
            return builder;
        }
        
        public static NameValueCollection Set(this NameValueCollection subject, NameValueCollection values) {
            if (values == null || values.Count == 0) return subject;
            foreach (string key in values.AllKeys) {
                subject.Set(key, values[key]);
            }
            return subject;
        }
    
    }

}