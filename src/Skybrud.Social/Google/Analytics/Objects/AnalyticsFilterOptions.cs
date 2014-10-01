using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Skybrud.Social.Google.Analytics.Interfaces;

namespace Skybrud.Social.Google.Analytics.Objects {
    
    public class AnalyticsFilterOptions {

        #region Private fields

        private List<IAnalyticsFilterBlock> _filters = new List<IAnalyticsFilterBlock>();

        #endregion

        #region Properties

        public bool HasBlocks {
            get { return _filters.Any(); }
        }

        public IAnalyticsFilterBlock[] Blocks {
            get { return _filters.ToArray(); }
            set { _filters = (value == null ? new List<IAnalyticsFilterBlock>() : Normalize(value.ToList())); }
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Adds a filter to the list of filters. If a filter already has been added, the new
        /// filter will be prefixed with an OR operator. 
        /// </summary>
        /// <param name="filter">The filter to add.</param>
        public AnalyticsFilterOptions Add(IAnalyticsFilter filter) {
            return Add(filter, AnalyticsFilterOperator.Or);
        }

        /// <summary>
        /// Adds a filter to the list of filters. If a filter already has been added, the new
        /// filter will be prefixed with the specified operator.
        /// </summary>
        /// <param name="filter">The filter to add.</param>
        /// <param name="op">The operator to use.</param>
        public AnalyticsFilterOptions Add(IAnalyticsFilter filter, AnalyticsFilterOperator op) {
            if (filter == null) throw new ArgumentNullException("filter");
            op = op ?? AnalyticsFilterOperator.Or;
            if (_filters.Any()) {
                if (_filters.Last() is AnalyticsFilterOperator) {
                    _filters.RemoveAt(_filters.Count - 1);
                }
                _filters.Add(op);
            }
            _filters.Add(filter);
            return this;
        }

        public AnalyticsFilterOptions Where(IAnalyticsFilter filter) {
            return Add(filter, AnalyticsFilterOperator.Or);
        }

        public AnalyticsFilterOptions And(IAnalyticsFilter filter) {
            return Add(filter, AnalyticsFilterOperator.And);
        }

        public AnalyticsFilterOptions Or(IAnalyticsFilter filter) {
            return Add(filter, AnalyticsFilterOperator.Or);
        }

        /// <summary>
        /// Removes any existing filters.
        /// </summary>
        public AnalyticsFilterOptions Reset() {
            _filters = new List<IAnalyticsFilterBlock>();
            return this;
        }

        /// <summary>
        /// Normalizes the list of filters.
        /// </summary>
        /// <param name="list">The list to normalize.</param>
        /// <returns>The normalized list.</returns>
        private List<IAnalyticsFilterBlock> Normalize(List<IAnalyticsFilterBlock> list) {

            List<IAnalyticsFilterBlock> temp = new List<IAnalyticsFilterBlock>();

            foreach (IAnalyticsFilterBlock current in list) {
                
                // Get the previous valid block (last in temp)
                var prev = temp.LastOrDefault();

                // Normalizing
                if (prev == null) {
                    if (current is AnalyticsFilterOperator) {
                        continue;
                    }
                } else if (current is AnalyticsFilterOperator) {
                    if (prev is AnalyticsFilterOperator) {
                        temp.RemoveAt(temp.Count - 1);
                    }
                } else if (current is IAnalyticsFilter) {
                    if (prev is IAnalyticsFilter) {
                        temp.Add(AnalyticsFilterOperator.Or);
                    }
                }

                // Add the block
                temp.Add(current);
            
            }

            return temp;

        }

        /// <summary>
        /// Generates a string representation of the filter options.
        /// </summary>
        public override string ToString() {
            string temp = "";
            foreach (var block in _filters) {
                var filter = block as IAnalyticsFilter;
                if (filter == null) {
                    temp += block.ToString();
                } else {
                    temp += filter.Name + filter.OperatorValue + EscapeFilterValue(filter.Value);
                }
            }
            return temp;
        }

        private string EscapeFilterValue(object value) {

            // Make sure the value is property formatted (eg. if the value is a double)
            string str = String.Format(CultureInfo.InvariantCulture, "{0}", value);

            // Escape special characters (according to https://developers.google.com/analytics/devguides/reporting/core/v3/reference#filterExpressions)
            str = str.Replace("\\", "\\\\,");
            str = str.Replace(";", "\\;");
            str = str.Replace(",", "\\,");

            return str;

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Converts the string representation of the filter options.
        /// </summary>
        /// <param name="str">A string containing the filter options to convert.</param>
        /// <returns>The converted filter options.</returns>
        public static AnalyticsFilterOptions Parse(string str) {

            AnalyticsFilterOptions options = new AnalyticsFilterOptions();

            string[] a = str.Split(';');

            for (int i = 0; i < a.Length; i++) {

                string[] b = a[i].Split(',');

                if (i > 0) options._filters.Add(AnalyticsFilterOperator.And);

                for (int j = 0; j < b.Length; j++) {

                    if (j > 0) options._filters.Add(AnalyticsFilterOperator.Or);

                    Match m = Regex.Match(b[j], "^(ga:[a-zA-Z]+)(.{1,2})(.+?)$");

                    if (!m.Success) {
                        throw new Exception("Unable to parse filter '" + b[j] + "'");
                    }

                    AnalyticsMetric metric;
                    AnalyticsMetricOperator metricOperator;
                    AnalyticsDimension dimension;
                    AnalyticsDimensionOperator dimensionOperator;

                    if (AnalyticsMetric.TryParse(m.Groups[1].Value, out metric) && AnalyticsMetricOperator.TryParse(m.Groups[2].Value, out metricOperator)) {
                        options._filters.Add(new AnalyticsMetricFilter(metric, metricOperator, HttpUtility.UrlDecode(m.Groups[3].Value)));
                    } else if (AnalyticsDimension.TryParse(m.Groups[1].Value, out dimension) && AnalyticsDimensionOperator.TryParse(m.Groups[2].Value, out dimensionOperator)) {
                        options._filters.Add(new AnalyticsDimensionFilter(dimension, dimensionOperator, HttpUtility.UrlDecode(m.Groups[3].Value)));
                    } else {
                        // Currently the parsing will only work if the specified dimension or
                        // metric name matches a defined constant, so if Google adds a new
                        // dimension or metric, the constants must be updated before the parsing
                        // will work. I'm not sure how often Google adds new dimensions or metric,
                        // so perhaps this isn't a problem
                        throw new Exception("Unable to parse filter '" + b[j] + "'");
                    }

                }

            }

            return options;

        }

        /// <summary>
        /// Converts the string representation of the filter options. A return value indicates
        /// whether the conversion succeeded.
        /// </summary>
        /// <param name="str">A string containing the filter options to convert.</param>
        /// <param name="options">The converted options if successful.</param>
        /// <returns><var>true</var> if str was converted successfully; otherwise, <var>false</var>.</returns>
        public static bool TryParse(string str, out AnalyticsFilterOptions options)  {
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

        public static implicit operator AnalyticsFilterOptions(string str) {
            return Parse(str);
        }

        public static implicit operator AnalyticsFilterOptions(IAnalyticsFilter[] array) {
            return new AnalyticsFilterOptions { Blocks = array };
        }

        public static implicit operator AnalyticsFilterOptions(IAnalyticsFilterBlock[] array) {
            return new AnalyticsFilterOptions { Blocks = array };
        }

        public static implicit operator AnalyticsFilterOptions(AnalyticsMetricFilter filter) {
            return new AnalyticsFilterOptions().Add(filter);
        }

        public static implicit operator AnalyticsFilterOptions(AnalyticsDimensionFilter filter) {
            return new AnalyticsFilterOptions().Add(filter);
        }

        #endregion

    }

}
