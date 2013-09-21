using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Skybrud.Social.Facebook.Objects;

namespace Skybrud.Social.Json {

    public class JsonObject : IJsonObject {

        public IDictionary<string, object> Dictionary { get; set; }

        public JsonObject(IDictionary<string, object> dictionary) {
            Dictionary = dictionary;
        }

        public bool HasValue(string name) {
            return Dictionary.ContainsKey(name) && Dictionary[name] != null;
        }

        public JsonObject GetObject(string name) {
            object value;
            return Dictionary.TryGetValue(name, out value) && value is Dictionary<string, object> ? new JsonObject((Dictionary<string, object>) value) : null;
        }

        public T GetObject<T>(string name, Func<JsonObject, T> func) {
            JsonObject obj = GetObject(name);
            return obj == null ? default(T) : func(obj);
        }

        public JsonArray GetArray(string name) {
            object value;
            return Dictionary.TryGetValue(name, out value) && value is ArrayList ? new JsonArray((ArrayList) value) : null;
        }

        public T[] GetArray<T>(string name) {
            object value;
            JsonArray array = Dictionary.TryGetValue(name, out value) && value is ArrayList ? new JsonArray((ArrayList) value) : null;
            return array == null ? null : array.Cast<T>();
        }

        //public T[] GetArray<T>(string name, Func<JsonArray, T[]> func) {
        //    JsonArray array = GetArray(name);
        //    return array == null ? null : func(array);
        //}

        public T[] GetArray<T>(string name, Func<JsonObject, T> func) {
            JsonArray array = GetArray(name);
            return array == null ? null : array.ParseMultiple(func);
        }

        public T GetValue<T>(string name) {
            return GetValue<T>(name, CultureInfo.InvariantCulture);
        }
        
        public T GetValue<T>(string name, IFormatProvider provider) {
            if (!HasValue(name)) return default(T);
            if (typeof(T) == typeof(JsonObject)) {
                object obj = Dictionary[name];
                if (obj is Dictionary<string, object>) {
                    obj = new JsonObject((Dictionary<string, object>) Dictionary[name]);
                }
                return (T) obj;
            }
            return (T) Convert.ChangeType(Dictionary[name], typeof(T), provider);
        }

        public int GetInt(string name) {
            return GetValue<int>(name);
        }

        public long GetLong(string name) {
            return GetValue<long>(name);
        }

        public double GetDouble(string name) {
            return GetValue<double>(name);
        }

        public double GetDouble(string name, IFormatProvider provider) {
            return GetValue<double>(name, provider);
        }

        public bool GetBoolean(string name) {
            return GetValue<bool>(name);
        }

        public string GetString(string name) {
            return GetValue<string>(name);
        }

        public DateTime GetDateTime(string name) {
            return GetValue<DateTime>(name);
        }

        public DateTime GetDateTimeFromUnixTimestamp(string name) {
            return SocialUtils.GetDateTimeFromUnixTime(GetValue<int>(name));
        }

        public DateTimeOffset GetDateTimeOffset(string name) {
            return GetValue<DateTimeOffset>(name);
        }

        public bool IsObject(string name) {
            return HasValue(name) && Dictionary[name] is IDictionary<string, object>;
        }

        public bool IsArray(string name) {
            return HasValue(name) && Dictionary[name] is ArrayList;
        }
    
    }

}
