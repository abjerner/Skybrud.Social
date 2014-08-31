using System;
using System.Collections.Generic;
using System.Linq;

namespace Skybrud.Social.Google.Analytics.Objects {
    
    public class AnalyticsDimensionCollection {

        #region Private fields

        private List<AnalyticsDimension> _list = new List<AnalyticsDimension>();

        #endregion

        #region Properties

        /// <summary>
        /// Gets the amount of dimensions currently in the collection.
        /// </summary>
        public int Count {
            get { return _list.Count; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes an empty collection.
        /// </summary>
        public AnalyticsDimensionCollection() {
            // Expose parameterless constructor
        }

        /// <summary>
        /// Initializes a collection containing the specified dimensions.
        /// </summary>
        /// <param name="dimensions">The dimensions to add.</param>
        public AnalyticsDimensionCollection(params AnalyticsDimension[] dimensions) {
            _list.AddRange(dimensions);
        }

        /// <summary>
        /// Initializes a collection containing the specified dimensions.
        /// </summary>
        /// <param name="dimensions">The dimensions to add.</param>
        public AnalyticsDimensionCollection(IEnumerable<AnalyticsDimension> dimensions) {
            _list.AddRange(dimensions);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds the specified dimension to the collection.
        /// </summary>
        /// <param name="dimension">The dimension to add.</param>
        public void Add(AnalyticsDimension dimension) {
            _list.Add(dimension);
        }

        /// <summary>
        /// Adds the specified range of dimensions to the collection.
        /// </summary>
        /// <param name="dimensions">The dimensions to add.</param>
        public void AddRange(IEnumerable<AnalyticsDimension> dimensions) {
            _list.AddRange(dimensions);
        }

        /// <summary>
        /// Gets an array of the dimensions currently in the collection.
        /// </summary>
        public AnalyticsDimension[] ToArray() {
            return _list.ToArray();
        }

        /// <summary>
        /// Gets a string array of the dimensions currently in the collection.
        /// </summary>
        public string[] ToStringArray() {
            return (from dimension in _list select dimension.Name).ToArray();
        }

        /// <summary>
        /// Gets a string representation if the dimensions currently in the collection.
        /// </summary>
        public override string ToString() {
            return String.Join(",", from dimension in _list select dimension.Name);
        }

        #endregion

        #region Operator overloading

        public static implicit operator AnalyticsDimensionCollection(AnalyticsDimension dimension) {
            return new AnalyticsDimensionCollection(dimension);
        }

        public static implicit operator AnalyticsDimensionCollection(AnalyticsDimension[] dimensions) {
            return new AnalyticsDimensionCollection(dimensions);
        }

        public static AnalyticsDimensionCollection operator +(AnalyticsDimensionCollection left, AnalyticsDimension right) {
            left.Add(right);
            return left;
        }

        public static implicit operator AnalyticsDimensionCollection(string[] dimensions) {
            return new AnalyticsDimensionCollection(from AnalyticsDimension dimension in dimensions select dimension);
        }

        #endregion

    }

}
