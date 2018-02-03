using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;

namespace Skybrud.Social.Http {

    /// <summary>
    /// Collection of HTTP headers.
    /// </summary>
    public class SocialHttpHeaderCollection : IEnumerable<KeyValuePair<string, string>> {

        #region Properties

        /// <summary>
        /// Gets a reference to the internal instance of <see cref="WebHeaderCollection"/>.
        /// </summary>
        public WebHeaderCollection Headers { get; private set; }

        /// <summary>
        /// Gets or sets the character sets that are acceptable - eg. <code>utf8</code>. This property corresponds to
        /// the <code>Accept-Charset</code> HTTP header.
        /// </summary>
        public string AcceptCharset {
            get => Headers["Accept-Charset"];
            set => Headers["Accept-Charset"] = value;
        }

        /// <summary>
        /// Gets or sets the a list of acceptable encodings - eg. <code>gzip</code> or <code>gzip, deflate</code>. This
        /// property corresponds to the <code>Accept-Encoding</code> HTTP header.
        /// </summary>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/HTTP_compression</cref>
        /// </see>
        public string AcceptEncoding {
            get => Headers["Accept-Encoding"];
            set => Headers["Accept-Encoding"] = value;
        }

        /// <summary>
        /// Gets or sets the accept language header of the request - eg. <code>en-US</code>, <code>en</code> or
        /// <code>da</code>. This property corresponds to the <code>Accept-Language</code> HTTP header.
        /// </summary>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/Content_negotiation</cref>
        /// </see>
        public string AcceptLanguage {
            get => Headers["Accept-Language"];
            set => Headers["Accept-Language"] = value;
        }

        /// <summary>
        /// Gets or sets the authentication credentials for HTTP authentication. This property corresponds to the
        /// <code>Authorization</code> HTTP header.
        /// </summary>
        public string Authorization {
            get => Headers["Authorization"];
            set => Headers["Authorization"] = value;
        }
        
        /// <summary>
        /// Gets amount of headers added to the collection.
        /// </summary>
        public int Count => Headers.Count;

        /// <summary>
        /// Gets a <see cref="System.String"/> array representing the keys of the header collection.
        /// </summary>
        public string[] Keys => Headers.AllKeys.ToArray();

        /// <summary>
        /// Gets or set the header with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key of the header.</param>
        /// <returns>Returns the value of the header.</returns>
        public string this[string key] {
            get => Headers[key];
            set => Headers[key] = value;
        }

        #endregion

        #region Constructor
        
        /// <summary>
        /// Creates an empty collection of headers.
        /// </summary>
        public SocialHttpHeaderCollection() {
            Headers = new WebHeaderCollection();
        }

        /// <summary>
        /// Creates a new instance based on the specified <paramref name="headers"/>.
        /// </summary>
        public SocialHttpHeaderCollection(WebHeaderCollection headers) {
            Headers = headers ?? new WebHeaderCollection();
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Adds a new header with the specified <paramref name="name"/> and <paramref name="value"/>.
        /// </summary>
        /// <param name="name">The name of the header.</param>
        /// <param name="value">The value of the header.</param>
        public void Add(string name, string value) {
            Headers[name] = value;
        }

        /// <summary>
        /// Adds a new header with the specified <paramref name="name"/> and <paramref name="value"/>.
        /// </summary>
        /// <param name="name">The name of the header.</param>
        /// <param name="value">The value of the header.</param>
        public void Add(string name, object value) {
            Headers[name] = String.Format(CultureInfo.InvariantCulture, "{0}", value);
        }

        
        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<KeyValuePair<string, string>> GetEnumerator() {
            return Headers.AllKeys.Select(x => new KeyValuePair<string, string>(x, Headers[x])).GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion

        #region Operator overloading

        /// <summary>
        /// Creates a new instance from the specified <paramref name="headers"/>.
        /// </summary>
        /// <param name="headers">The <see cref="WebHeaderCollection"/> representing the headers.</param>
        public static implicit operator SocialHttpHeaderCollection(WebHeaderCollection headers) {

            // Initialize a new instance of SocialHttpHeaderCollection
            SocialHttpHeaderCollection collection = new SocialHttpHeaderCollection {
                Headers = headers ?? new WebHeaderCollection()
            };

            return collection;

        }

        #endregion

    }

}