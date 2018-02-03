using System;
using System.Collections;
using System.Collections.Generic;
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
    public class SocialHttpPostData : IHttpPostData, IEnumerable<KeyValuePair<string, string>> {

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
        /// Gets or sets the string value of the item with the specified <paramref name="key"/>code>.
        /// </summary>
        /// <param name="key">The key of the item.</param>
        /// <returns>Returns the <see cref="String"/> value of the item, or <code>null</code> if not found.</returns>
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

        #endregion

        #region Member methods

        /// <summary>
        /// Returns whether the POST data contains an entry with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <returns><code>true</code> if the POST data contains an entry with the specified <paramref name="key"/>,
        /// otherwise <code>false</code>.</returns>
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
        /// <paramref name="contentType"/> and <code>filename</code>.
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
        /// <returns><code>true</code> if the item with the specified <paramref name="key"/> is an instance of
        /// <see cref="SocialHttpPostFileValue"/>, otherwise <code>false</code>.</returns>
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