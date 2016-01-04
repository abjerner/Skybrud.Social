using System;
using System.Collections.Specialized;
using System.Net;

namespace Skybrud.Social.Http {

    /// <summary>
    /// Collection of HTTP headers.
    /// </summary>
    public class SocialHeaderCollection {

        #region Properties

        /// <summary>
        /// Gets a reference to the internal instance of <code>WebHeaderCollection</code>.
        /// </summary>
        public WebHeaderCollection Headers { get; private set; }

        /// <summary>
        /// Gets or sets the authorization header of the request.
        /// </summary>
        public string Authorization {
            get { return Headers["Authorization"]; }
            set { Headers["Authorization"] = value; }
        }

        /// <summary>
        /// Gets or sets the user agent header of the request,
        /// </summary>
        [Obsolete("Marking this as obsolete as it will most likely trigger an exception when setting it's value.")]
        public string UserAgent {
            get { return Headers["User-Agent"]; }
            set { Headers["User-Agent"] = value; }
        }

        /// <summary>
        /// Gets amount of headers added to the collection.
        /// </summary>
        public int Count {
            get { return Headers.Count; }
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
        /// <param name="headers">The <code>NameValueCollection</code> representing the headers.</param>
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
        /// <param name="headers">The <code>WebHeaderCollection</code> representing the headers.</param>
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