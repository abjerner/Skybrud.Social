using System.Collections.Generic;

namespace Skybrud.Social.Interfaces.Http {
    
    /// <summary>
    /// Interface describing a collection of items representing a query string. Depending on the implementation, the
    /// collection may support multiple items sharing the same key.
    /// </summary>
    public interface IHttpQueryString : IEnumerable<KeyValuePair<string, string>> {

        #region Properties

        /// <summary>
        /// Gets the amount of items stored in the query string.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Gets whether the query string is empty.
        /// </summary>
        bool IsEmpty { get; }

        /// <summary>
        /// Gets an array of the keys of all items in the query string.
        /// </summary>
        string[] Keys { get; }

        /// <summary>
        /// Gets an array of all items in the query string.
        /// </summary>
        KeyValuePair<string, string>[] Items { get; }

        /// <summary>
        /// Gets the value of the first item with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key of the item to match.</param>
        /// <returns>The <see cref="string"/> value of the item, or <c>null</c> if not found.</returns>
        string this[string key] { get; }

        /// <summary>
        /// Gets whether this implementation of <see cref="IHttpQueryString"/> supports duplicate keys.
        /// </summary>
        bool SupportsDuplicateKeys { get; }

        #endregion

        #region Member methods

        /// <summary>
        /// Adds an item with the specified <paramref name="key"/> and <paramref name="value"/>.
        /// </summary>
        /// <param name="key">The key of the item.</param>
        /// <param name="value">The value of the item.</param>
        void Add(string key, object value);

        /// <summary>
        /// Sets the <paramref name="value"/> of an entry with the specified <paramref name="key"/>. If one or more entries with
        /// <paramref name="key"/> already exist, these will be overwritten.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <param name="value">The value of the entry.</param>
        void Set(string key, object value);

        /// <summary>
        /// Gets a string representation of the query string.
        /// </summary>
        /// <returns>The query string as an URL encoded string.</returns>
        string ToString();

        /// <summary>
        /// Return whether the query string contains an entry with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <returns><c>true</c> if the query string contains the specified <paramref name="key"/>, otherwise
        /// <c>false</c>.</returns>
        bool ContainsKey(string key);

        /// <summary>
        /// Gets the <see cref="System.String"/> value of the entry with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <returns>The <see cref="System.String"/> value of the entry, or <c>null</c> if not found.</returns>
        string GetString(string key);

        /// <summary>
        /// Gets the <see cref="System.Int32"/> value of the entry with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <returns>The <see cref="System.Int32"/> value of the entry, or <c>0</c> if not found.</returns>
        int GetInt32(string key);

        /// <summary>
        /// Gets the <see cref="System.Int64"/> value of the entry with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <returns>The <see cref="System.Int64"/> value of the entry, or <c>0</c> if not found.</returns>
        long GetInt64(string key);

        /// <summary>
        /// Gets the <see cref="System.Boolean"/> value of the entry with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <returns>The <see cref="System.Boolean"/> value of the entry, or <c>0</c> if not found.</returns>
        bool GetBoolean(string key);

        /// <summary>
        /// Gets the <see cref="System.Double"/> value of the entry with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <returns>The <see cref="System.Double"/> value of the entry, or <c>0</c> if not found.</returns>
        double GetDouble(string key);

        /// <summary>
        /// Gets the <see cref="System.Single"/> value of the entry with the specified <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <returns>The <see cref="System.Single"/> value of the entry, or <c>0</c> if not found.</returns>
        float GetFloat(string key);

        #endregion

    }

}