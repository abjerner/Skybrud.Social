using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skybrud.Social.Json {
    
    public class JsonArray : IJsonObject {

        private object[] _array;

        public int Length {
            get { return _array.Length; }
        }

        public object this[int pos] {
            get {
                var temp = _array[pos];
                if (temp is object[]) return new JsonArray((object[])temp);
                return temp;
            }
        }

        public JsonArray(object[] array) {
            _array = array;
        }

        public JsonArray(ArrayList array) {
            _array = array.ToArray();
        }

        public bool IsArray(int index) {
            return _array[index] is object[];
        }

        public bool IsObject(int index) {
            return _array[index] is JsonObject;
        }

        public bool IsSimpleType(int index) {
            return !IsArray(index) && IsArray(index);
        }

        public JsonArray GetArray(int index) {
            if (this[index] is object[]) return new JsonArray(this[index] as object[]);
            if (this[index] is ArrayList) return new JsonArray(this[index] as ArrayList);
            return null;
        }

        //public T[] GetArray<T>(int index, Func<JsonArray, T[]> func) {
        //    JsonArray array = GetArray(index);
        //    return array == null ? null : func(array);
        //}

        public T[] GetArray<T>(int index, Func<JsonObject, T> func) {
            JsonArray array = GetArray(index);
            return array == null ? null : array.ParseMultiple(func);
        }

        public Type GetElementType(int index) {
            return this[index].GetType();
        }

        public JsonObject GetObject(int index) {
            JsonObject v1 = this[index] as JsonObject;
            Dictionary<string, object> v2 = this[index] as Dictionary<string, object>;
            if (v1 != null) return v1;
            return v2 == null ? null : new JsonObject(v2);
        }

        public int GetInt(int index) {
            return (int) Convert.ChangeType(this[index], typeof(int));
        }

        public double GetDouble(int index) {
            return (double) Convert.ChangeType(this[index], typeof(double));
        }

        public string GetString(int index) {
            return (string)Convert.ChangeType(this[index], typeof(string));
        }

        public T GetSimpleType<T>(int index) {
            return (T) Convert.ChangeType(this[index], typeof(T));
        }

        public T[] ParseMultiple<T>(Func<JsonObject, T> func) {
            T[] temp = new T[Length];
            for (int i = 0; i < Length; i++) temp[i] = func(GetObject(i));
            return temp;
        }

        public T[] Cast<T>() {
            return _array.Cast<T>().ToArray();
        }

    }

}
