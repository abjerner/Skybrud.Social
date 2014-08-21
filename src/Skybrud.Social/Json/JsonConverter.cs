using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web.Script.Serialization;

namespace Skybrud.Social.Json {

    public class JsonConverter : JavaScriptConverter {

        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer) {

            if (dictionary == null)
                throw new ArgumentNullException("dictionary");

            if (type == typeof(object[])) {
                return new JsonObject(dictionary);
            }

            if (type == typeof(object)) {
                return new JsonObject(dictionary);
            }

            return null;
        }

        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer) {
            throw new NotImplementedException();
        }

        public override IEnumerable<Type> SupportedTypes {
            get { return new ReadOnlyCollection<Type>(new List<Type>(new [] { typeof(object) })); }
        }

        /// <summary>
        /// Returns an instance of <var>IJsonObject</var>, which can either be
        /// a <var>JsonObject</var> or a <var>JsonArray</var> depending on the
        /// specified JSON string. <var>NULL</var> may be returned if the
        /// parsed value cannot be converted to either of these two types.
        /// </summary>
        /// <param name="json">The JSON string to parsed.</param>
        public static IJsonObject Parse(string json) {

            // Setup the serializer
            JavaScriptSerializer jss = new JavaScriptSerializer();
            jss.RegisterConverters(new JavaScriptConverter[] { new JsonConverter() });

            // Deserialize the specified JSON string
            object deserialized = jss.Deserialize(json, typeof(object));

            // Handle arrays
            if (deserialized is object[]) {
                return new JsonArray((object[])deserialized);
            }

            // Return the JSON object
            return deserialized as JsonObject;

        }

        /// <summary>
        /// Returns an instance of <var>JsonObject</var> based on the specified
        /// JSON string. <var>NULL</var> may be returned if the parsed value
        /// cannot be converted to an instance of <var>JsonObject</var>.
        /// </summary>
        /// <param name="json">The JSON string to parsed.</param>
        public static JsonObject ParseObject(string json) {
            return Parse(json) as JsonObject;
        }

        /// <summary>
        /// Returns an instance of <var>JsonArray</var> based on the specified
        /// JSON string. <var>NULL</var> may be returned if the parsed value
        /// cannot be converted to an instance of <var>JsonArray</var>.
        /// </summary>
        /// <param name="json">The JSON string to parsed.</param>
        public static JsonArray ParseArray(string json) {
            return Parse(json) as JsonArray;
        }

        public static T ParseObject<T>(string json, Func<JsonObject, T> parse) {
            JsonObject obj = ParseObject(json);
            return obj == null ? default(T) : parse(obj);
        }

        public static T[] ParseArray<T>(string json, Func<JsonArray, T[]> parse) {
            var array = ParseArray(json);
            return array == null ? null : parse(array);
        }

        public static string ToJson(IJsonObject obj) {

            object value = null;

            if (obj is JsonArray) {
                value = ToJsonInternal((JsonArray) obj);
            } else if (obj is JsonObject) {
                value = ToJsonInternal((JsonObject) obj);
            }

            return new JavaScriptSerializer().Serialize(value);

        }

        private static object ToJsonInternal(JsonObject obj) {

            Dictionary<string, object> temp = new Dictionary<string, object>();

            foreach (string key in obj.Dictionary.Keys) {
                if (obj.IsObject(key)) {
                    temp.Add(key, ToJsonInternal(obj.GetObject(key)));
                } else if (obj.IsArray(key)) {
                    temp.Add(key, ToJsonInternal(obj.GetArray(key)));
                } else {
                    temp.Add(key, obj.Dictionary[key]);
                }
            }

            return temp;

        }

        public static object ToJsonInternal(JsonArray array) {

            object[] temp = new object[array.Length];

            for (int i = 0; i < array.Length; i++) {
                if (array.IsObject(i)) {
                    temp[i] = ToJsonInternal(array.GetObject(i));
                } else if (array.IsArray(i)) {
                    temp[i] = ToJsonInternal(array.GetArray(i));
                } else {
                    temp[i] = array.InternalArray[i];
                }
            }

            return temp;

        }
    
    }

}
