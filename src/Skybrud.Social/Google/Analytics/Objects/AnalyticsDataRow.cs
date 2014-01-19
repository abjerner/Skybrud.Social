using Skybrud.Social.Json;

namespace Skybrud.Social.Google.Analytics.Objects {
    
    public class AnalyticsDataRow {

        public int Index { get; internal set; }
        public string[] Cells { get; internal set; }

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
    
    }

}