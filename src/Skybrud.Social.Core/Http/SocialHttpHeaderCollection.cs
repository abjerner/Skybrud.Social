using System;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Net;

namespace Skybrud.Social.Http {

    /// <summary>
    /// Collection of HTTP headers.
    /// </summary>
    public class SocialHttpHeaderCollection {

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
            get { return Headers["Accept-Charset"]; }
            set { Headers["Accept-Charset"] = value; }
        }

        /// <summary>
        /// Gets or sets the a list of acceptable encodings - eg. <code>gzip</code> or <code>gzip, deflate</code>. This
        /// property corresponds to the <code>Accept-Encoding</code> HTTP header.
        /// </summary>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/HTTP_compression</cref>
        /// </see>
        public string AcceptEncoding {
            get { return Headers["Accept-Encoding"]; }
            set { Headers["Accept-Encoding"] = value; }
        }

        /// <summary>
        /// Gets or sets the accept language header of the request - eg. <code>en-US</code>, <code>en</code> or
        /// <code>da</code>. This property corresponds to the <code>Accept-Language</code> HTTP header.
        /// </summary>
        /// <see>
        ///     <cref>https://en.wikipedia.org/wiki/Content_negotiation</cref>
        /// </see>
        public string AcceptLanguage {
            get { return Headers["Accept-Language"]; }
            set { Headers["Accept-Language"] = value; }
        }

        /// <summary>
        /// Gets or sets the authentication credentials for HTTP authentication. This property corresponds to the
        /// <code>Authorization</code> HTTP header.
        /// </summary>
        public string Authorization {
            get { return Headers["Authorization"]; }
            set { Headers["Authorization"] = value; }
        }
        
        /// <summary>
        /// Gets amount of headers added to the collection.
        /// </summary>
        public int Count {
            get { return Headers.Count; }
        }

        /// <summary>
        /// Gets a <see cref="System.String"/> array representing the keys of the header collection.
        /// </summary>
        public string[] Keys {
            get { return Headers.AllKeys.OfType<string>().ToArray(); }
        }

        /// <summary>
        /// Gets or set the header with the specified <code>key</code>.
        /// </summary>
        /// <param name="key">The key of the header.</param>
        /// <returns>Returns the value of the header.</returns>
        public string this[string key] {
            get { return Headers[key]; }
            set { Headers[key] = value; }
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
        /// Creates a new instance based on the specified <code>headers</code>.
        /// </summary>
        public SocialHttpHeaderCollection(WebHeaderCollection headers) {
            Headers = headers ?? new WebHeaderCollection();
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Adds a new header with the specified <code>name</code> and <code>value</code>.
        /// </summary>
        /// <param name="name">The name of the header.</param>
        /// <param name="value">The value of the header.</param>
        public void Add(string name, object value) {
            Headers[name] = String.Format(CultureInfo.InvariantCulture, "{0}", value);
        }

        #endregion

        #region Operator overloading

        /// <summary>
        /// Creates a new instance from the specified <code>headers</code>.
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