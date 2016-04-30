using System.Collections.Specialized;
using System.Net;

namespace Skybrud.Social.Http {

    /// <summary>
    /// Collection of HTTP headers.
    /// </summary>
    public class SocialHeaderCollection {

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
        public SocialHeaderCollection() {
            Headers = new WebHeaderCollection();
        }

        /// <summary>
        /// Creates a new instance based on the specified <code>headers</code>.
        /// </summary>
        public SocialHeaderCollection(WebHeaderCollection headers) {
            Headers = headers ?? new WebHeaderCollection();
        }

        #endregion

        #region Operator overloading

        /// <summary>
        /// Creates a new instance from the specified <code>headers</code>.
        /// </summary>
        /// <param name="headers">The <see cref="NameValueCollection"/> representing the headers.</param>
        public static implicit operator SocialHeaderCollection(NameValueCollection headers) {

            // Initialize a new instance of SocialHeaderCollection
            SocialHeaderCollection collection = new SocialHeaderCollection();

            // Copy all items
            if (headers != null) {
                foreach (string key in headers.Keys) {
                    collection.Headers.Add(key, headers[key]);
                }
            }

            return collection;

        }

        /// <summary>
        /// Creates a new instance from the specified <code>headers</code>.
        /// </summary>
        /// <param name="headers">The <see cref="NameValueCollection"/> representing the headers.</param>
        public static implicit operator SocialHeaderCollection(WebHeaderCollection headers) {

            // Initialize a new instance of SocialHeaderCollection
            SocialHeaderCollection collection = new SocialHeaderCollection {
                Headers = headers ?? new WebHeaderCollection()
            };

            return collection;

        }

        #endregion

    }

}