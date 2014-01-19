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

        private AnalyticsDataRow() {
            // Hide default constructor
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