using Skybrud.Social.Json;

namespace Skybrud.Social.Google.Analytics.Objects {
    
    public class AnalyticsRealtimeDataQuery {
        
        public string Ids { get; internal set; }
        public int StartIndex { get; internal set; }
        public int MaxResults { get; internal set; }
        public string Dimensions { get; internal set; }
        public string[] Metrics { get; internal set; }

        public static AnalyticsRealtimeDataQuery Parse(JsonObject obj) {
            if (obj == null) return null;
            return new AnalyticsRealtimeDataQuery {
                Ids = obj.GetString("ids"),
                StartIndex = obj.GetInt("start-index"),
                MaxResults = obj.GetInt("max-results"),
                Dimensions = obj.GetString("dimensions"),
                Metrics = obj.GetArray<string>("metrics")
            };
        }

    }

}