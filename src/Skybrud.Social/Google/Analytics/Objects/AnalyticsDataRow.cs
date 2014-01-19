using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.Google.Analytics.Objects {

    public class AnalyticsDataRow {

        #region Properties

        /// <summary>
        /// Gets the index of the row (first row has index 0).
        /// </summary>
        public int Index { get; internal set; }

        /// <summary>
        /// Gets the string array representing the cells of the row.
        /// </summary>
        public string[] Cells { get; internal set; }

        #endregion

        #region Constructors

        internal AnalyticsDataRow() {
            // Hide default constructor
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets the call value with the specified index and converts it to <var>T</var>.
        /// </summary>
        /// <typeparam name="T">The type to which the cell value should be converted.</typeparam>
        /// <param name="index">The index of the cell.</param>
        public T GetCellValue<T>(int index) {
            return (T) Convert.ChangeType(Cells[index], typeof (T));
        }

        #endregion

        #region Static methods

        public static AnalyticsDataRow[] ParseMultiDimensionArray(JsonArray array) {
            AnalyticsDataRow[] rows = new AnalyticsDataRow[array.Length];
            for (int i = 0; i < array.Length; i++) {
                rows[i] = new AnalyticsDataRow {
                    Index = i,
                    Cells = array.GetArray(i).Cast<string>()
                };
            }
            return rows;
        }

        #endregion
    
    }

}