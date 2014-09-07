using System;
using System.Collections.Generic;
using System.Linq;
using Skybrud.Social.Google.Analytics.Interfaces;
using Skybrud.Social.Json;

namespace Skybrud.Social.Google.Analytics.Objects {
    
    public class AnalyticsDataRow {

        #region Private fields

        private readonly Dictionary<string, AnalyticsDataCell> _cells = new Dictionary<string, AnalyticsDataCell>();

        #endregion

        #region Properties

        /// <summary>
        /// Gets the index of the row (first row has index 0).
        /// </summary>
        public int Index { get; internal set; }

        /// <summary>
        /// Gets an array of all cells.
        /// </summary>
        public AnalyticsDataCell[] Cells { get; private set; }

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
        [Obsolete("Use method GetValue<T> instead")]
        public T GetCellValue<T>(int index) {
            return GetValue<T>(index);
        }
        
        /// <summary>
        /// Gets the value of the cell with the specified index and converts it to <var>T</var>.
        /// </summary>
        /// <typeparam name="T">The type to which the cell value should be converted.</typeparam>
        /// <param name="index">The index of the cell.</param>
        public T GetValue<T>(int index) {
            return Cells[index].GetValue<T>();
        }

        /// <summary>
        /// Gets the value of the cell with the specified <code>key</code> and converts it to
        /// <code>T</code> if found, otherwise the default value for <code>T</code> will be
        /// returned.
        /// </summary>
        /// <param name="key">The key of the cell.</param>
        public T GetValue<T>(string key) {
            AnalyticsDataCell cell;
            return _cells.TryGetValue(key, out cell) ? cell.GetValue<T>() : default(T);
        }

        /// <summary>
        /// Gets the value of the cell with the specified <code>field</code> and converts it to
        /// <code>T</code> if found, otherwise the default value for <code>T</code> will be
        /// returned.
        /// </summary>
        /// <param name="field">The field (key) of the cell.</param>
        public T GetValue<T>(IAnalyticsField field) {
            return GetValue<T>(field.Name);
        }

        public string GetString(string key) {
            AnalyticsDataCell cell;
            return _cells.TryGetValue(key, out cell) ? cell.GetString() : null;
        }

        public string GetString(IAnalyticsField field) {
            return GetValue<string>(field);
        }

        public int GetInt32(string key) {
            return GetValue<int>(key);
        }

        public int GetInt32(IAnalyticsField field) {
            return GetValue<int>(field);
        }

        public double GetDouble(string key) {
            return GetValue<double>(key);
        }

        public double GetDouble(IAnalyticsField field) {
            return GetValue<double>(field);
        }

        #endregion

        #region Static methods

        internal static AnalyticsDataRow[] Parse(AnalyticsDataColumnHeader[] columnHeaders, JsonArray array) {

            // If the query returns no rows, the array will be NULL
            if (array == null) return new AnalyticsDataRow[0];
            
            // Initialize the array of rows with a fixed length based on the input array
            AnalyticsDataRow[] rows = new AnalyticsDataRow[array.Length];

            // Iterate through each row
            for (int i = 0; i < array.Length; i++) {

                // Get the array of the row
                JsonArray row = array.GetArray(i);
                
                rows[i] = new AnalyticsDataRow {
                    Index = i
                };

                // Iterate through each cell
                for (int j = 0; j < row.Length; j++) {

                    // Get the column header
                    AnalyticsDataColumnHeader column = columnHeaders[j];

                    // Add the key and value to the dictionary
                    rows[i]._cells.Add(column.Name, new AnalyticsDataCell {
                        Index = j,
                        Column = column,
                        Value = row.GetString(j)
                    });

                    // Set the array
                    rows[i].Cells = rows[i]._cells.Values.ToArray();

                }

            }

            return rows;

        }

        #endregion
    
    }

}