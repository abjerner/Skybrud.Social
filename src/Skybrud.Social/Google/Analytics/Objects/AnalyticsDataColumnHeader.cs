using Skybrud.Social.Json;

namespace Skybrud.Social.Google.Analytics.Objects {
    
    public class AnalyticsDataColumnHeader {
        
        public string Name { get; internal set; }
        public string ColumnType { get; internal set; }
        public string DataType { get; internal set; }

        public static AnalyticsDataColumnHeader Parse(JsonObject obj) {
            if (obj == null) return null;
            return new AnalyticsDataColumnHeader {
                Name = obj.GetString("name"),
                ColumnType = obj.GetString("columnType"),
                DataType = obj.GetString("dataType")
            };
        }
        
    }

}