using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Skybrud.Essentials.Strings;
using Skybrud.Social.Http.PostData;
using Skybrud.Social.Interfaces.Http;

namespace Skybrud.Social.Http {

    /// <summary>
    /// Class representing the POST data of a HTTP request.
    /// </summary>
    public class SocialHttpPostData : IHttpPostData {

        #region Private fields

        private readonly Dictionary<string, IHttpPostValue> _data;

        #endregion

        #region Properties

        /// <summary>
        /// Gets whether the request should be posted as multipart data.
        /// </summary>
        public bool IsMultipart { get; set; }

        /// <summary>
        /// Gets the amount of POST data entries.
        /// </summary>
        public int Count => _data.Count;

        /// <summary>
        /// Gets keys of all POST data entiries.
        /// </summary>
        public string[] Keys => _data.Keys.ToArray();

        /// <summary>
        /// Gets values of all POST data entiries.
        /// </summary>
        public Dictionary<string, IHttpPostValue>.ValueCollection Values => _data.Values;

        /// <summary>
        /// Gets or sets the string value of the item with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key of the item.</param>
        /// <returns>The <see cref="String"/> value of the item, or <c>null</c> if not found.</returns>
        public string this[string key] {
            get {
                IHttpPostValue value;
                return _data.TryGetValue(key, out value) ? value.ToString() : null;
            }
            set => _data[key] = new SocialHttpPostValue(key, value);
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes an empty collection.
        /// </summary>
        public SocialHttpPostData() {
            _data = new Dictionary<string, IHttpPostValue>();
        }

#if NET_FRAMEWORK

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="collection"/>.
        /// </summary>
        /// <param name="collection">The collection the query string should be based.</param>
        public SocialHttpPostData(NameValueCollection collection) {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            _data = new Dictionary<string, IHttpPostValue>();
            foreach (string key in collection.AllKeys) {
                _data.Add(key, new SocialHttpPostValue(key, collection[key]));
            }
        }

#endif

        #endregion

        #region Member methods

        /// <summary>
        /// Returns whether the POST data contains an entry with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <returns><c>true</c> if the POST data contains an entry with the specified <paramref name="key"/>,
        /// otherwise <c>false</c>.</returns>
        public bool ContainsKey(string key) {
            return _data.ContainsKey(key);
        }

        /// <summary>
        /// Adds an entry with the specified <paramref name="key"/> and <paramref name="value"/>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <param name="value">The value of the entry.</param>
        public void Add(string key, string value) {
            _data.Add(key, new SocialHttpPostValue(key, value));
        }
        
        /// <summary>
        /// Adds an entry with the specified <paramref name="key"/> and <paramref name="value"/>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <param name="value">The value of the entry.</param>
        public void Add(string key, object value) {
            _data.Add(key, new SocialHttpPostValue(key, String.Format(CultureInfo.InvariantCulture, "{0}", value)));
        }

        /// <summary>
        /// Adds a file entry with the specified <paramref name="key"/> and <paramref name="path"/>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <param name="path">The path to the file of the entry.</param>
        public void AddFile(string key, string path) {
            _data.Add(key, new SocialHttpPostFileValue(key, path));
        }

        /// <summary>
        /// Adds a file entry with the specified <paramref name="key"/>, <paramref name="path"/>,
        /// <paramref name="contentType"/> and <paramref name="filename"/>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <param name="path">The path to the file of the entry.</param>
        /// <param name="contentType">The content type of the file.</param>
        /// <param name="filename">The filename of the file.</param>
        public void AddFile(string key, string path, string contentType, string filename) {
            _data.Add(key, new SocialHttpPostFileValue(key, path, contentType, filename));
        }

        /// <summary>
        /// Sets the value of the entry with specified <paramref name="key"/>. If an entry with <paramref name="key"/> already
        /// exists, it will be overwritten.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <param name="value">The value of the entry.</param>
        public void Set(string key, string value) {
            _data[key] = new SocialHttpPostValue(key, value);
        }

        /// <summary>
        /// Sets the value of the entry with specified <paramref name="key"/>. If an entry with <paramref name="key"/> already
        /// exists, it will be overwritten.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <param name="value">The value of the entry.</param>
        public void Set(string key, object value) {
            _data[key] = new SocialHttpPostValue(key, String.Format(CultureInfo.InvariantCulture, "{0}", value));
        }

        /// <summary>
        /// Removes the entry with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        public void Remove(string key) {
            _data.Remove(key);
        }

        /// <summary>
        /// Gets whether the value with the specified <paramref name="key"/> is an instance of
        /// <see cref="SocialHttpPostFileValue"/>.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns><c>true</c> if the item with the specified <paramref name="key"/> is an instance of
        /// <see cref="SocialHttpPostFileValue"/>, otherwise <c>false</c>.</returns>
        public bool IsFile(string key) {
            IHttpPostValue value;
            return _data.TryGetValue(key, out value) && value is SocialHttpPostFileValue;
        }

        internal static void Write(Stream stream, string str) {
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            stream.Write(bytes, 0, bytes.Length);
        }

        /// <summary>
        /// Writes the multipart POST data to the specified <paramref name="stream"/>.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="boundary">The multipart boundary.</param>
        public void WriteMultipartFormData(Stream stream, string boundary) {
            int i = 0;
            foreach (IHttpPostValue value in _data.Values) {
                value.WriteToMultipartStream(stream, boundary, "\n", i++ == _data.Count - 1);
            }
        }

        /// <summary>
        /// Gets a string representation of the POST data.
        /// </summary>
        /// <returns>Returns the POST data as an URL encoded string.</returns>
        public override string ToString() {
            return String.Join("&", _data.Select(pair => StringUtils.UrlEncode(pair.Key) + "=" + StringUtils.UrlEncode(pair.Value.ToString())));
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<KeyValuePair<string, string>> GetEnumerator() {
            return _data.Select(x => new KeyValuePair<string, string>(x.Key, x.Value.ToString())).GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion

    }

}