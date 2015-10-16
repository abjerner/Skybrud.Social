using System;
using System.Collections.Generic;
using System.Linq;

namespace Skybrud.Social.Pinterest.Fields {
    
    /// <summary>
    /// Class representing a collection of fields in the Pinterest API.
    /// </summary>
    public class PinterestFieldsCollection {

        #region Private fields

        private readonly List<PinterestField> _fields = new List<PinterestField>();

        #endregion

        #region Properties

        /// <summary>
        /// Gets an array of all the fields added to the collection.
        /// </summary>
        public PinterestField[] Fields {
            get { return _fields.ToArray(); }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new collection based on the specified <code>array</code> of fields.
        /// </summary>
        /// <param name="array">Array of fields.</param>
        public PinterestFieldsCollection(params PinterestField[] array) {
            _fields.AddRange(array);
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Adds the specified <code>field</code> to the collection.
        /// </summary>
        /// <param name="field">The field to be added.</param>
        public void Add(PinterestField field) {
            _fields.Add(field);
        }

        /// <summary>
        /// Returns an array of fields based on the collection.
        /// </summary>
        /// <returns>Array of fields contained in the collection.</returns>
        public PinterestField[] ToArray() {
            return _fields.ToArray();
        }

        /// <summary>
        /// Returns an array of strings representing each field in the collection.
        /// </summary>
        /// <returns>Array of strings representing each field in the collection.</returns>
        public string[] ToStringArray() {
            return (from field in _fields select field.Name).ToArray();
        }

        /// <summary>
        /// Returns a string representing the fields added to the collection using a comma as a separator.
        /// </summary>
        /// <returns>String of fields separated by a comma.</returns>
        public override string ToString() {
            return String.Join(",", from field in _fields select field.Name);
        }

        #endregion

        #region Operators

        /// <summary>
        /// Initializes a new collection based on the specified string of fields.
        /// </summary>
        /// <param name="fields">The string of fields the collection should be based on.</param>
        public static implicit operator PinterestFieldsCollection(string fields) {
            PinterestFieldsCollection collection = new PinterestFieldsCollection();
            foreach (string name in (fields ?? "").Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)) {
                collection.Add(name);
            }
            return collection;
        }

        /// <summary>
        /// Initializes a new collection based on the specified array of fields.
        /// </summary>
        /// <param name="fields">The array of fields the collection should be based on.</param>
        public static implicit operator PinterestFieldsCollection(string[] fields) {
            PinterestFieldsCollection collection = new PinterestFieldsCollection();
            foreach (string name in fields) {
                collection.Add(name);
            }
            return collection;
        }

        /// <summary>
        /// Initializes a new collection based on a single instance of <code>PinterestField</code>.
        /// </summary>
        /// <param name="field">The array of fields the collection should be based on.</param>
        public static implicit operator PinterestFieldsCollection(PinterestField field) {
            return new PinterestFieldsCollection(field);
        }

        /// <summary>
        /// Adds support for adding a <code>field</code> to the <code>collection</code> using the plus operator.
        /// </summary>
        /// <param name="collection">The collection to which <code>field</code> will be added.</param>
        /// <param name="field">The field to be added to the <code>collection</code>.</param>
        public static PinterestFieldsCollection operator +(PinterestFieldsCollection collection, PinterestField field) {
            collection.Add(field);
            return collection;
        }

        #endregion

    }

}