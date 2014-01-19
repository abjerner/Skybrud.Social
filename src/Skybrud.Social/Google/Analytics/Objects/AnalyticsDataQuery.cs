using Skybrud.Social.Json;

namespace Skybrud.Social.Google.Analytics.Objects {
    public class AnalyticsDataQuery {
        
        public string Ids { get; internal set; }
        public string StartDate { get; internal set; }
        public string EndDate { get; internal set; }
        public int StartIndex { get; internal set; }
        public int MaxResults { get; internal set; }
        public string Dimensions { get; internal set; }
        public string[] Metrics { get; internal set; }

        public static AnalyticsDataQuery Parse(JsonObject obj) {
            if (obj == null) return null;
            return new AnalyticsDataQuery {
                Ids = obj.GetString("ids"),
                StartDate = obj.GetString("start-date"),
                EndDate = obj.GetString("end-date"),
                StartIndex = obj.GetInt("start-index"),
                MaxResults = obj.GetInt("max-results"),
                Dimensions = obj.GetString("dimensions"),
                Metrics = obj.GetArray<string>("metrics")
            };
        }

    }
}