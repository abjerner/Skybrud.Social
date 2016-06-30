using System;
using System.Collections.Generic;
using System.IO;
using Skybrud.Social.Http.PostData;

namespace Skybrud.Social.Interfaces.Http {
    
    /// <summary>
    /// Interface decribing the request body of a HTTP POST request.
    /// </summary>
    public interface IHttpPostData {

        #region Properties

        /// <summary>
        /// Gets whether the request should be posted as multipart data.
        /// </summary>
        bool IsMultipart { get; }

        /// <summary>
        /// Gets the amount of POST data entries.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Gets an array of the keys of all POST data entiries.
        /// </summary>
        string[] Keys { get; }

        /// <summary>
        /// Gets values of all POST data entiries.
        /// </summary>
        Dictionary<string, IHttpPostValue>.ValueCollection Values { get; }

        /// <summary>
        /// Gets or sets the string value of the item with the specified <code>key</code>code>.
        /// </summary>
        /// <param name="key">The key of the item.</param>
        /// <returns>Returns the <see cref="String"/> value of the item, or <code>null</code> if not found.</returns>
        string this[string key] { get; set; }

        #endregion

        #region Member methods

        /// <summary>
        /// Returns whether the POST data contains an entry with the specified <code>key</code>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <returns>Returns <code>true</code> if the POST data contains an entry with the specified <code>key</code>,
        /// otherwise <code>false</code>.</returns>
        bool ContainsKey(string key);

        /// <summary>
        /// Adds an entry with the specified <code>key</code> and <code>value</code>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <param name="value">The value of the entry.</param>
        void Add(string key, string value);

        /// <summary>
        /// Adds an entry with the specified <code>key</code> and <code>value</code>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <param name="value">The value of the entry.</param>
        void Add(string key, object value);

        /// <summary>
        /// Adds a file entry with the specified <code>key</code> and <code>path</code>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <param name="path">The path to the file of the entry.</param>
        void AddFile(string key, string path);

        /// <summary>
        /// Adds a file entry with the specified <code>key</code>, <code>path</code>, <code>contentType</code> and
        /// <code>filename</code>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <param name="path">The path to the file of the entry.</param>
        /// <param name="contentType">The content type of the file.</param>
        /// <param name="filename">The filename of the file.</param>
        void AddFile(string key, string path, string contentType, string filename);

        /// <summary>
        /// Sets the value of the entry with specified <code>key</code>. If an entry with <code>key</code> already
        /// exists, it will be overwritten.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        /// <param name="value">The value of the entry.</param>
        void Set(string key, string value);

        /// <summary>
        /// Removes the entry with the specified <code>key</code>.
        /// </summary>
        /// <param name="key">The key of the entry.</param>
        void Remove(string key);

        /// <summary>
        /// Gets whether the value with the specified key is an instance of <see cref="SocialHttpPostFileValue"/>.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>Returns <code>true</code> if the item with the specified <code>key</code> is an instance of
        /// <see cref="SocialHttpPostFileValue"/>, otherwise <code>false</code>.</returns>
        bool IsFile(string key);
        
        /// <summary>
        /// Writes the multipart POST data to the specified <code>stream</code>.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="boundary">The multipart boundary.</param>
        void WriteMultipartFormData(Stream stream, string boundary);

        #endregion

    }

}