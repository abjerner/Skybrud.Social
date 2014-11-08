using System.Collections.Specialized;
using System.Net;

namespace Skybrud.Social.Http {

    public class SocialHeaderCollection {

        #region Properties

        /// <summary>
        /// Gets a reference to the internal instance of <code>WebHeaderCollection</code>.
        /// </summary>
        public WebHeaderCollection Headers { get; private set; }

        public string Accept {
            get { return Headers["Accept"]; }
            set { Headers["Accept"] = value; }
        }

        public string Authorization {
            get { return Headers["Authorization"]; }
            set { Headers["Authorization"] = value; }
        }

        public string UserAgent {
            get { return Headers["User-Agent"]; }
            set { Headers["User-Agent"] = value; }
        }

        public int Count {
            get { return Headers.Count; }
        }

        #endregion

        #region Constructor

        public SocialHeaderCollection() {
            Headers = new WebHeaderCollection();
        }
       
        public SocialHeaderCollection(WebHeaderCollection headers) {
            Headers = headers ?? new WebHeaderCollection();
        }

        #endregion

        #region Operator overloading

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
