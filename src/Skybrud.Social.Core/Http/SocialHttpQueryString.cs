using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using Skybrud.Essentials.Strings;
using Skybrud.Social.Interfaces.Http;

namespace Skybrud.Social.Http {

    /// <summary>
    /// Class representing a basic HTTP query string.
    /// </summary>
    public class SocialHttpQueryString : IHttpQueryString {

        #region Private fields

        private readonly Dictionary<string, string> _values;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the number of key/value pairs contained in the internal dictionary instance.
        /// </summary>
        public int Count => _values.Count;

        /// <summary>
        /// Gets whether the internal dictionary is empty.
        /// </summary>
        public bool IsEmpty => _values.Count == 0;

        /// <summary>
        /// Gets an array of the keys of all items in the query string.
        /// </summary>
        public string[] Keys => _values.Keys.ToArray();

        /// <summary>
        /// Gets an array of all items in the query string.
        /// </summary>
        public KeyValuePair<string, string>[] Items => _values.ToArray();

        /// <summary>
        /// Gets the value of the item with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key of the item to match.</param>
        /// <returns>The <see cref="string"/> value of the item, or <c>null</c> if not found.</returns>
        public string this[string key] {
            get => GetString(key);
            set => _values[key] = value;
        }

        /// <summary>
        /// Gets whether this implementation of <see cref="IHttpQueryString"/> supports duplicate keys.
        /// </summary>
        public bool SupportsDuplicateKeys => false;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance without any entries.
        /// </summary>
        public SocialHttpQueryString() {
            _values = new Dictionary<string, string>();
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="dictionary"/>.
        /// </summary>
        /// <param name="dictionary">The dictionary the query string should be based.</param>
        public SocialHttpQueryString(Dictionary<string, string> dictionary) {
            _values = dictionary ?? throw new ArgumentNullException(nameof(dictionary));
        }

#if NET_FRAMEWORK

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="collection"/>.
        /// </summary>
        /// <param name="collection">The collection the query string should be based.</param>
        public SocialHttpQueryString(NameValueCollection collection) {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            _values = new Dictionary<string, string>();
            foreach (string key in collection.AllKeys) {
                _values.Add(key, collection[key]);
            }
        }

#endif

        #endregion

        #region Methods

        /// <summary>
        /// Adds an entry with the specified <paramref name="key"/> and <paramref name="value"/>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <param name="value">The value of the entry.</param>
        public void Add(string key, object value) {
            if (String.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));
            _values.Add(key, String.Format(CultureInfo.InvariantCulture, "{0}", value));
        }

        /// <summary>
        /// Sets the <paramref name="value"/> of an entry with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <param name="value">The value of the entry.</param>
        public void Set(string key, object value) {
            if (String.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));
            _values[key] = String.Format(CultureInfo.InvariantCulture, "{0}", value);
        }

        /// <summary>
        /// Gets a string representation of the query string.
        /// </summary>
        /// <returns>The query string as an URL encoded string.</returns>
        public override string ToString() {
            return String.Join("&", from pair in _values select StringUtils.UrlEncode(pair.Key) + "=" + StringHelper.UrlEncode(pair.Value));
        }

        /// <summary>
        /// Return whether the query string contains an entry with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <returns><c>true</c> if the query string contains the specified <paramref name="key"/>, otherwise
        /// <c>false</c>.</returns>
        public bool ContainsKey(string key) {
            if (String.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));
            return _values.ContainsKey(key);
        }

        /// <summary>
        /// Gets the <see cref="System.String"/> value of the entry with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <returns>The <see cref="System.String"/> value of the entry, or <c>null</c> if not found.</returns>
        public string GetString(string key) {
            if (String.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));
            return _values.TryGetValue(key, out string value) ? value : null;
        }

        /// <summary>
        /// Gets the <see cref="System.Int32"/> value of the entry with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <returns>The <see cref="System.Int32"/> value of the entry, or <c>0</c> if not found.</returns>
        public int GetInt32(string key) {
            return GetValue<int>(key);
        }

        /// <summary>
        /// Gets the <see cref="System.Int64"/> value of the entry with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <returns>The <see cref="System.Int64"/> value of the entry, or <c>0</c> if not found.</returns>
        public long GetInt64(string key) {
            return GetValue<long>(key);
        }

        /// <summary>
        /// Gets the <see cref="System.Boolean"/> value of the entry with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <returns>The <see cref="System.Boolean"/> value of the entry, or <c>0</c> if not found.</returns>
        public bool GetBoolean(string key) {
            return GetValue<bool>(key);
        }

        /// <summary>
        /// Gets the <see cref="System.Double"/> value of the entry with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <returns>The <see cref="System.Double"/> value of the entry, or <c>0</c> if not found.</returns>
        public double GetDouble(string key) {
            return GetValue<double>(key);
        }

        /// <summary>
        /// Gets the <see cref="System.Single"/> value of the entry with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <returns>The <see cref="System.Single"/> value of the entry, or <c>0</c> if not found.</returns>
        public float GetFloat(string key) {
            return GetValue<float>(key);
        }

        /// <summary>
        /// Gets the <typeparamref name="T"/> value of the entry with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <returns>The <typeparamref name="T"/> value of the entry, or the default value of <typeparamref name="T"/> if not found.</returns>
        private T GetValue<T>(string key) {
            if (String.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));
            string value;
            if (!_values.TryGetValue(key, out value)) return default(T);
            return String.IsNullOrWhiteSpace(value) ? default(T) : (T) Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<KeyValuePair<string, string>> GetEnumerator() {
            return _values.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified query string into an instance of <see cref="SocialHttpQueryString"/>.
        /// </summary>
        /// <param name="str">The query string to parse.</param>
        /// <returns>An instance of <see cref="SocialHttpQueryString"/>.</returns>
        public static SocialHttpQueryString ParseQueryString(string str) {
            return ParseQueryString(str, false);
        }

        /// <summary>
        /// Parses the specified query string into an instance of <see cref="SocialHttpQueryString"/>.
        /// </summary>
        /// <param name="str">The query string to parse.</param>
        /// <param name="urlencoded">Whether the query string is URL encoded</param>
        /// <returns>An instance of <see cref="SocialHttpQueryString"/> representing the parsed query string.</returns>
        /// <see>
        ///     <cref>https://referencesource.microsoft.com/#System.Web/HttpValueCollection.cs,222f9a1bfd1f9a98,references</cref>
        /// </see>
        public static SocialHttpQueryString ParseQueryString(string str, bool urlencoded) {

            // Return an empty instance if "str" is NULL or empty
            if (String.IsNullOrWhiteSpace(str)) return new SocialHttpQueryString();

            Dictionary<string, string> values = new Dictionary<string, string>();
            
            int length = str.Length;

            int i = 0;

            while (i < length) {

                int si = i;
                int ti = -1;

                while (i < length) {
                    char ch = str[i];

                    if (ch == '=') {
                        if (ti < 0)
                            ti = i;
                    } else if (ch == '&') {
                        break;
                    }

                    i++;
                }

                // extract the name / value pair
                String name = null;
                String value;

                if (ti >= 0) {
                    name = str.Substring(si, ti - si);
                    value = str.Substring(ti + 1, i - ti - 1);
                } else {
                    value = str.Substring(si, i - si);
                }

                // TODO: Should we throw an exception if the key already exists? (I think Add might do it for us)

                // add name / value pair to the collection
                if (urlencoded) {
                    values.Add(StringUtils.UrlDecode(name), StringUtils.UrlDecode(value));
                } else {
                    values.Add(name ?? "", value);
                }

                // trailing '&'
                if (i == length - 1 && str[i] == '&') {
                    values.Add("", String.Empty);
                }

                i++;

            }

            return new SocialHttpQueryString(values);

        }

        #endregion

    }

}