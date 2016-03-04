using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Skybrud.Social.Http.PostData;

namespace Skybrud.Social.Http {

    /// <summary>
    /// Class representing the POST data of a HTTP request.
    /// </summary>
    public class SocialPostData {

        #region Private fields

        private readonly Dictionary<string, ISocialPostValue> _data = new Dictionary<string, ISocialPostValue>();

        #endregion

        #region Properties

        /// <summary>
        /// Gets the amount of POST data entries.
        /// </summary>
        public int Count {
            get { return _data.Count; }
        }

        /// <summary>
        /// Gets keys of all POST data entiries.
        /// </summary>
        public Dictionary<string, ISocialPostValue>.KeyCollection Keys {
            get { return _data.Keys; }
        }

        /// <summary>
        /// Gets values of all POST data entiries.
        /// </summary>
        public Dictionary<string, ISocialPostValue>.ValueCollection Values {
            get { return _data.Values; }
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Adds an entry with the specified <code>key</code> and <code>value</code>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <param name="value">The value of the entry.</param>
        public void Add(string key, string value) {
            _data.Add(key, new SocialPostValue(key, value));
        }
        
        /// <summary>
        /// Adds an entry with the specified <code>key</code> and <code>value</code>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <param name="value">The value of the entry.</param>
        public void Add(string key, object value) {
            _data.Add(key, new SocialPostValue(key, String.Format(CultureInfo.InvariantCulture, "{0}", value)));
        }

        /// <summary>
        /// Adds a file entry with the specified <code>key</code> and <code>path</code>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <param name="path">The path to the file of the entry.</param>
        public void AddFile(string key, string path) {
            _data.Add(key, new SocialPostFileValue(key, path));
        }

        /// <summary>
        /// Adds a file entry with the specified <code>key</code>, <code>path</code>, <code>contentType</code> and
        /// <code>filename</code>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <param name="path">The path to the file of the entry.</param>
        /// <param name="contentType">The content type of the file.</param>
        /// <param name="filename">The filename of the file.</param>
        public void AddFile(string key, string path, string contentType, string filename) {
            _data.Add(key, new SocialPostFileValue(key, path, contentType, filename));
        }

        internal static void Write(Stream stream, string str) {
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            stream.Write(bytes, 0, bytes.Length);
        }

        /// <summary>
        /// Writes the multipart POST data to the specified <code>stream</code>.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="boundary">The multipart boundary.</param>
        public void WriteMultipartFormData(Stream stream, string boundary) {
            int i = 0;
            foreach (ISocialPostValue value in _data.Values) {
                value.WriteToMultipartStream(stream, boundary, "\n", i++ == _data.Count - 1);
            }
        }

        /// <summary>
        /// Gets a string representation of the POST data.
        /// </summary>
        /// <returns>Returns the POST data as an URL encoded string.</returns>
        public override string ToString() {
            return String.Join("&", _data.Select(pair => SocialUtils.UrlEncode(pair.Key) + "=" + SocialUtils.UrlEncode(pair.Value.ToString())));
        }

        /// <summary>
        /// Converts the POST data into an instance of <see cref="NameValueCollection"/>.
        /// </summary>
        /// <returns>Returns an instance of <see cref="NameValueCollection"/> representing the POST data.</returns>
        public virtual NameValueCollection ToNameValueCollection() {
            NameValueCollection nvc = new NameValueCollection();
            foreach (var pair in _data) {
                nvc.Add(pair.Key, String.Format(CultureInfo.InvariantCulture, "{0}", pair.Value));
            }
            return nvc;
        }

        #endregion

        #region Operator overloading

        /// <summary>
        /// Initializes a new instance based on the specified <see cref="NameValueCollection"/>.
        /// </summary>
        /// <param name="nvc">An instance of <see cref="NameValueCollection"/> representing the POST data.</param>
        /// <returns>Returns an instance of <see cref="SocialPostData"/> based on the specified <code>nvc</code>.</returns>
        public static implicit operator SocialPostData(NameValueCollection nvc) {
            SocialPostData data = new SocialPostData();
            foreach (string key in nvc.Keys) {
                data.Add(key, nvc[key]);
            }
            return data;
        }

        #endregion

    }

}