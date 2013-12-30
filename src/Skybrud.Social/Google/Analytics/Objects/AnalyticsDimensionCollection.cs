using System;
using System.Collections.Generic;
using System.Linq;

namespace Skybrud.Social.Google.Analytics.Objects {
    
    public class AnalyticsDimensionCollection {

        private List<AnalyticsDimension> _list = new List<AnalyticsDimension>();

        #region Constructors

        public AnalyticsDimensionCollection(params AnalyticsDimension[] dimensions) {
            _list.AddRange(dimensions);
        }

        public AnalyticsDimensionCollection(IEnumerable<AnalyticsDimension> dimensions) {
            _list.AddRange(dimensions);
        }

        #endregion

        #region Methods

        public void Add(AnalyticsDimension dimension) {
            _list.Add(dimension);
        }

        public void AddRange(IEnumerable<AnalyticsDimension> dimensions) {
            _list.AddRange(dimensions);
        }

        public AnalyticsDimension[] ToArray() {
            return _list.ToArray();
        }

        public string[] ToStringArray() {
            return (from dimension in _list select dimension.Name).ToArray();
        }

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
