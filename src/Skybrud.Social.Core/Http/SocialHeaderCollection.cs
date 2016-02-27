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
        /// Gets or sets the authorization header of the request.
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