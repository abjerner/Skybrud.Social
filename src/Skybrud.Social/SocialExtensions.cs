using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Web;
using Skybrud.Social.Interfaces;
using Skybrud.Social.Json;

namespace Skybrud.Social {
    
    public static class SocialExtensions {

        /// <summary>
        /// Calculates the distance in meters between two GPS locations.
        /// </summary>
        /// <param name="loc1">The first location.</param>
        /// <param name="loc2">The second location.</param>
        public static double GetDistance(this ILocation loc1, ILocation loc2) {
            return SocialUtils.GetDistance(loc1, loc2);
        }
        
        public static string GetAsString(this HttpWebResponse response) {
            StreamReader reader = new StreamReader(response.GetResponseStream());
            return reader.ReadToEnd();
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