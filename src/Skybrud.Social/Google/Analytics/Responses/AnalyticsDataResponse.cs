using System.Collections.Generic;
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
            
            if (obj == null) return null;
            
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



        /*
        {
          "kind":"analytics#gaData",
          "id":"https://www.googleapis.com/analytics/v3/data/ga?ids=ga:69656201&dimensions=ga:date,ga:year&metrics=ga:visits,ga:pageviews&start-date=2013-08-01&end-date=2013-08-31",
          "query":{
            "start-date":"2013-08-01",
            "end-date":"2013-08-31",
            "ids":"ga:69656201",
            "dimensions":"ga:date,ga:year",
            "metrics":[
              "ga:visits",
              "ga:pageviews"
            ],
            "start-index":1,
            "max-results":1000
          },
          "itemsPerPage":1000,
          "totalResults":31,
          "selfLink":"https://www.googleapis.com/analytics/v3/data/ga?ids=ga:69656201&dimensions=ga:date,ga:year&metrics=ga:visits,ga:pageviews&start-date=2013-08-01&end-date=2013-08-31",
          "profileInfo":{
            "profileId":"69656201",
            "accountId":"4864474",
            "webPropertyId":"UA-4864474-8",
            "internalWebPropertyId":"67676004",
            "profileName":"All Web Site Data",
            "tableId":"ga:69656201"
          },
          "containsSampledData":false,
          "columnHeaders":[
            {
              "name":"ga:date",
              "columnType":"DIMENSION",
              "dataType":"STRING"
            },
            {
              "name":"ga:year",
              "columnType":"DIMENSION",
              "dataType":"STRING"
            },
            {
              "name":"ga:visits",
              "columnType":"METRIC",
              "dataType":"INTEGER"
            },
            {
              "name":"ga:pageviews",
              "columnType":"METRIC",
              "dataType":"INTEGER"
            }
          ],
          "totalsForAllResults":{
            "ga:visits":"67",
            "ga:pageviews":"277"
          },
          "rows":[
            [
              "20130801",
              "2013",
              "2",
              "4"
            ],
            [
              "20130802",
              "2013",
              "1",
              "5"
            ],
            [
              "20130803",
              "2013",
              "1",
              "1"
            ],
            [
              "20130804",
              "2013",
              "2",
              "2"
            ],
            [
              "20130805",
              "2013",
              "6",
              "16"
            ],
            [
              "20130806",
              "2013",
              "3",
              "11"
            ],
            [
              "20130807",
              "2013",
              "5",
              "29"
            ],
            [
              "20130808",
              "2013",
              "1",
              "1"
            ],
            [
              "20130809",
              "2013",
              "3",
              "10"
            ],
            [
              "20130810",
              "2013",
              "2",
              "14"
            ],
            [
              "20130811",
              "2013",
              "6",
              "17"
            ],
            [
              "20130812",
              "2013",
              "1",
              "2"
            ],
            [
              "20130813",
              "2013",
              "3",
              "17"
            ],
            [
              "20130814",
              "2013",
              "2",
              "61"
            ],
            [
              "20130815",
              "2013",
              "1",
              "1"
            ],
            [
              "20130816",
              "2013",
              "1",
              "8"
            ],
            [
              "20130817",
              "2013",
              "0",
              "0"
            ],
            [
              "20130818",
              "2013",
              "1",
              "1"
            ],
            [
              "20130819",
              "2013",
              "0",
              "0"
            ],
            [
              "20130820",
              "2013",
              "1",
              "1"
            ],
            [
              "20130821",
              "2013",
              "2",
              "2"
            ],
            [
              "20130822",
              "2013",
              "2",
              "5"
            ],
            [
              "20130823",
              "2013",
              "1",
              "8"
            ],
            [
              "20130824",
              "2013",
              "0",
              "0"
            ],
            [
              "20130825",
              "2013",
              "1",
              "8"
            ],
            [
              "20130826",
              "2013",
              "6",
              "18"
            ],
            [
              "20130827",
              "2013",
              "3",
              "7"
            ],
            [
              "20130828",
              "2013",
              "5",
              "17"
            ],
            [
              "20130829",
              "2013",
              "1",
              "2"
            ],
            [
              "20130830",
              "2013",
              "4",
              "9"
            ],
            [
              "20130831",
              "2013",
              "0",
              "0"
            ]
          ]
        }
        */




    }

}
