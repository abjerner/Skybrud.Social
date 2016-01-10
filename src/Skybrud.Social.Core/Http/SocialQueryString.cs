using System;
using System.Linq;
using System.Collections.Specialized;
using System.Globalization;

namespace Skybrud.Social.Http {

    /// <summary>
    /// A wrapper class extending the functionality of <code>NameValueCollection</code>.
    /// </summary>
    public class SocialQueryString {

        #region Private fields

        private readonly NameValueCollection _nvc = new NameValueCollection();

        #endregion

        #region Properties

        /// <summary>
        /// Gets a reference to the internal <code>NameValueCollection</code>.
        /// </summary>
        public NameValueCollection NameValueCollection {
            get { return _nvc; }
        }

        /// <summary>
        /// Gets the number of key/value pairs contained in the internal <code>NameValueCollection</code> instance.
        /// </summary>
        public int Count {
            get { return _nvc.Count; }
        }

        /// <summary>
        /// Gets whether the internal <code>NameValueCollection</code> is empty.
        /// </summary>
        public bool IsEmpty {
            get { return _nvc.Count == 0; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance without any entries.
        /// </summary>
        public SocialQueryString() { }

        /// <summary>
        /// Initializes a new instance based on the specified <code>query</code>.
        /// </summary>
        /// <param name="query">An instance of <code>NameValueCollection</code> that should make up the query string.</param>
        public SocialQueryString(NameValueCollection query) {
            _nvc = query ?? new NameValueCollection();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds an entry with the specified <code>key</code> and <code>value</code>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <param name="value">The value of the entry.</param>
        public void Add(string key, object value) {
            _nvc.Add(key, String.Format(CultureInfo.InvariantCulture, "{0}", value));
        }

        /// <summary>
        /// Sets the <code>value</code> of an entry with the specified <code>key</code>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <param name="value">The value of the entry.</param>
        public void Set(string key, object value) {
            _nvc.Add(key, String.Format(CultureInfo.InvariantCulture, "{0}", value));
        }

        public override string ToString() {
            return SocialUtils.NameValueCollectionToQueryString(_nvc);
        }
        
        /// <summary>
        /// Return whether the query string contains an entry with the specified <code>key</code>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <returns>Returns <code>true</code> if the query string contains the specified <code>key</code>, otherwise
        /// <code>false</code>.</returns>
        public bool ContainsKey(string key) {
            return _nvc.Get(key) != null || _nvc.AllKeys.Contains(key);
        }

        // TODO: Determine which methods from NameValueCollection that also should be exposed in this class

        #endregion

        #region Operator overloading

        /// <summary>
        /// Initializes a new instance based on the specified <code>query</code>.
        /// </summary>
        /// <param name="query">An instance of <code>NameValueCollection</code> that should make up the query string.</param>
        /// <returns>An instance of <code>SocialQueryString</code> based on the specified <code>query</code>.</returns>
        public static implicit operator SocialQueryString(NameValueCollection query) {
            return new SocialQueryString(query);
        }

        #endregion

    }

}
