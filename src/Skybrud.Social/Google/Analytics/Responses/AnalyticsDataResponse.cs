using System.Collections.Generic;
using Skybrud.Social.Google.Exceptions;
using Skybrud.Social.Json;

namespace Skybrud.Social.Google.Analytics.Responses {

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
    
    public class AnalyticsDataResponse {
        
        public int TotalResults { get; private set; }
        public int ItemsPerPage { get; private set; }

        public AnalyticsDataQuery Query { get; private set; }
        public AnalyticsDataColumnHeader[] ColumnHeaders { get; private set; }
        public AnalyticsDataRow[] Rows { get; private set; }

        public static AnalyticsDataResponse ParseJson(string json) {
            return Parse(JsonConverter.ParseObject(json));
        }

        public static AnalyticsDataResponse Parse(JsonObject obj) {
            
            // Check whether "obj" is NULL
            if (obj == null) return null;

            // Check for any API errors
            if (obj.HasValue("error")) {
                JsonObject error = obj.GetObject("error");
                throw new GoogleApiException(error.GetInt("code"), error.GetString("message"));
            }

            // Initialize the response object
            AnalyticsDataResponse response = new AnalyticsDataResponse {
                Query = obj.GetObject("query", AnalyticsDataQuery.Parse),
                ColumnHeaders = obj.GetArray("columnHeaders", AnalyticsDataColumnHeader.Parse)
            };

            // Parse the rows
            JsonArray rows = obj.GetArray("rows");
            response.Rows = new AnalyticsDataRow[rows.Length];
            for (int i = 0; i < rows.Length; i++) {
                response.Rows[i] = new AnalyticsDataRow {
                    Index = i,
                    Cells = rows.GetArray(i).Cast<string>()
                };
            }
            
            return response;

        }

    }

}
