using System;
using Newtonsoft.Json;

namespace Skybrud.Social.Google.Analytics.Objects {

    public class AnalyticsDataCell {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent row.
        /// </summary>
        [JsonIgnore]
        public AnalyticsDataRow Row { get; internal set; }

        /// <summary>
        /// Gets the index of the cell.
        /// </summary>
        public int Index { get; internal set; }

        /// <summary>
        /// Gets the column header for the cell.
        /// </summary>
        public AnalyticsDataColumnHeader Column { get; internal set; }

        /// <summary>
        /// Gets the raw string value of the cell.
        /// </summary>
        public string Value { get; internal set; }

        #endregion

        #region Member properties

        /// <summary>
        /// Gets the value of the cell and converts it to <code>T</code>.
        /// </summary>
        public T GetValue<T>() {
            return (T) Convert.ChangeType(Value, typeof(T));
        }

        /// <summary>
        /// Gets the value of the cell. Since the value is stored as a string internally, no
        /// conversion is required.
        /// </summary>
        /// <returns></returns>
        public string GetString() {
            return Value;
        }

        /// <summary>
        /// Gets the value of the cell and convert it to an integer.
        /// </summary>
        public int GetInt32() {
            return GetValue<int>();
        }

        /// <summary>
        /// Gets the value of the cell and convert it to a double.
        /// </summary>
        public double GetDouble() {
            return GetValue<double>();
        }

        public override string ToString() {
            return Value;
        }

        #endregion

    }

}