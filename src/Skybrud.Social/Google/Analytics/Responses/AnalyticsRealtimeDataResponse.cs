using Skybrud.Social.Google.Analytics.Objects;
using Skybrud.Social.Google.Exceptions;
using Skybrud.Social.Json;

namespace Skybrud.Social.Google.Analytics.Responses {
    public class AnalyticsRealtimeDataResponse {
        
        public int TotalResults { get; private set; }
        public int ItemsPerPage { get; private set; }

        public AnalyticsRealtimeDataQuery Query { get; private set; }
        public AnalyticsDataColumnHeader[] ColumnHeaders { get; private set; }
        public AnalyticsDataRow[] Rows { get; private set; }

        public static AnalyticsRealtimeDataResponse ParseJson(string json) {
            return Parse(JsonConverter.ParseObject(json));
        }

        public static AnalyticsRealtimeDataResponse Parse(JsonObject obj) {
            
            // Check whether "obj" is NULL
            if (obj == null) return null;

            // Check for any API errors
            if (obj.HasValue("error")) {
                JsonObject error = obj.GetObject("error");
                throw new GoogleApiException(error.GetInt("code"), error.GetString("message"));
            }

            // Initialize the response object
            AnalyticsRealtimeDataResponse response = new AnalyticsRealtimeDataResponse {
                Query = obj.GetObject("query", AnalyticsRealtimeDataQuery.Parse),
                ColumnHeaders = obj.GetArray("columnHeaders", AnalyticsDataColumnHeader.Parse)
            };

            // Parse the rows
            JsonArray rows = obj.GetArray("rows");
            if (rows == null) {
                response.Rows = new AnalyticsDataRow[0];
            } else {
                response.Rows = new AnalyticsDataRow[rows.Length];
                for (int i = 0; i < rows.Length; i++) {
                    response.Rows[i] = new AnalyticsDataRow {
                        Index = i,
                        Cells = rows.GetArray(i).Cast<string>()
                    };
                }
            }
            
            
            return response;

        }

    }

}
