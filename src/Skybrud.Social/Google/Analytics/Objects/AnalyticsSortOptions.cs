using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Skybrud.Social.Google.Analytics.Interfaces;

namespace Skybrud.Social.Google.Analytics.Objects {
    
    public class AnalyticsSortOptions {

        #region Private fields

        private List<IAnalyticsSortField> _fields = new List<IAnalyticsSortField>();

        #endregion

        #region Properties

        public bool HasFields {
            get { return _fields.Any(); }
        }

        public IAnalyticsSortField[] Fields {
            get { return _fields.ToArray(); }
            set { _fields = (value == null ? new List<IAnalyticsSortField>() : value.ToList()); }
        }

        #endregion

        #region Member methods

        public AnalyticsSortOptions Reset() {
            _fields = new List<IAnalyticsSortField>();
            return this;
        }

        public AnalyticsSortOptions Add(IAnalyticsSortField field) {
            if (field == null) throw new ArgumentNullException("field");
            _fields.Add(field);
            return this;
        }

        public AnalyticsSortOptions Add(AnalyticsDimension dimension, AnalyticsSortOrder order) {
            if (dimension == null) throw new ArgumentNullException("dimension");
            _fields.Add(new AnalyticsDimensionSortField(dimension, order));
            return this;
        }

        public AnalyticsSortOptions Add(AnalyticsMetric metric, AnalyticsSortOrder order) {
            if (metric == null) throw new ArgumentNullException("metric");
            _fields.Add(new AnalyticsMetricSortField(metric, order));
            return this;
        }

        public AnalyticsSortOptions AddAscending(AnalyticsDimension dimension) {
            if (dimension == null) throw new ArgumentNullException("dimension");
            return Add(dimension, AnalyticsSortOrder.Ascending);
        }

        public AnalyticsSortOptions AddAscending(AnalyticsMetric metric) {
            if (metric == null) throw new ArgumentNullException("metric");
            return Add(metric, AnalyticsSortOrder.Ascending);
        }

        public AnalyticsSortOptions AddDescending(AnalyticsDimension dimension) {
            if (dimension == null) throw new ArgumentNullException("dimension");
            return Add(dimension, AnalyticsSortOrder.Descending);
        }

        public AnalyticsSortOptions AddDescending(AnalyticsMetric metric) {
            if (metric == null) throw new ArgumentNullException("metric");
            return Add(metric, AnalyticsSortOrder.Descending);
        }

        public override string ToString() {
            return String.Join(",", _fields.Select(hai => (hai.Order == AnalyticsSortOrder.Ascending ? "" : "-") + hai.Field.Name));
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Converts the string representation of the sort options.
        /// </summary>
        /// <param name="str">A string containing the sort options to convert.</param>
        /// <returns>The converted sort options.</returns>
        public static AnalyticsSortOptions Parse(string str) {

            // If the strign is NULL, we also return NULL
            if (str == null) return null;

            AnalyticsSortOptions options = new AnalyticsSortOptions();

            // The sort fields are separated by commas
            string[] b = str.Split(new [] {","}, StringSplitOptions.RemoveEmptyEntries);

            for (int j = 0; j < b.Length; j++) {

                string piece = b[j];

                AnalyticsSortOrder order = AnalyticsSortOrder.Ascending;
                if (piece.StartsWith("-")) {
                    order = AnalyticsSortOrder.Descending;
                    piece = piece.Substring(1);
                }

                // Does the piece have the characteristics of a metric or dimension?
                Match m = Regex.Match(piece, "^(ga:[a-zA-Z]+)$");
                if (!m.Success) throw new Exception("Unable to parse metric or dimension '" + piece + "'");

                AnalyticsMetric metric;
                AnalyticsDimension dimension;
                if (AnalyticsMetric.TryParse(m.Groups[1].Value, out metric)) {
                    options.Add(metric, order);
                } else if (AnalyticsDimension.TryParse(m.Groups[1].Value, out dimension)) {
                    options.Add(dimension, order);
                } else {
                    // Currently the parsing will only work if the specified dimension or
                    // metric name matches a defined constant, so if Google adds a new
                    // dimension or metric, the constants must be updated before the parsing
                    // will work. I'm not sure how often Google adds new dimensions or metric,
                    // so perhaps this isn't a problem
                    throw new Exception("Unable to parse metric or dimension '" + m.Groups[1].Value + "'");
                }

            }

            return options;

        }

        /// <summary>
        /// Converts the string representation of the sort options. A return value indicates
        /// whether the conversion succeeded.
        /// </summary>
        /// <param name="str">A string containing the sort options to convert.</param>
        /// <param name="options">The converted options if successful.</param>
        /// <returns><var>true</var> if str was converted successfully; otherwise, <var>false</var>.</returns>
        public static bool TryParse(string str, out AnalyticsSortOptions options) {
            try {
                options = Parse(str);
                return true;
            } catch {
                options = null;
                return false;
            }
        }

        #endregion

        #region Operator overloading

        public static implicit operator AnalyticsSortOptions(string str) {
            return Parse(str);
        }

        public static implicit operator AnalyticsSortOptions(IAnalyticsSortField[] array) {
            return new AnalyticsSortOptions { Fields = array };
        }

        #endregion

    }

}