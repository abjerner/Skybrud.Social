using System;

namespace Skybrud.Social.Attributes {

    /// <summary>
    /// Class similar to the <code>AssemblyMetadataAttribute</code> in .NET 4.5 and above.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true, Inherited = false)]
    public sealed class SkybrudMetadataAttribute : Attribute {

        #region Properties

        /// <summary>
        /// Gets the key of the metadata attribute.
        /// </summary>
        public string Key { get; private set; }

        /// <summary>
        /// Gets the value of the metadata attribute.
        /// </summary>
        public string Value { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new attribute from the specified <code>key</code> and <code>value</code>.
        /// </summary>
        /// <param name="key">The key of the attribute.</param>
        /// <param name="value">The value of attribute.</param>
        public SkybrudMetadataAttribute(string key, string value) {
            Key = key;
            Value = value;
        }

        #endregion

    }

}