using System;
using System.Collections.Generic;
using Skybrud.Social.Google.Analytics.Objects;
using Skybrud.Social.Google.Exceptions;
using Skybrud.Social.Json;

namespace Skybrud.Social.Google.Analytics.Responses {

    public class AnalyticsRealtimeDataResponse {

        #region Private fields

        private Dictionary<string, string> _totalsForAllResults = new Dictionary<string, string>();

        #endregion

        #region Properties

        /// <summary>
        /// Gets the internal JsonObject the object was created from.
        /// </summary>
        public JsonObject JsonObject { get; private set; }
        
        public int TotalResults { get; private set; }

        public AnalyticsRealtimeDataQuery Query { get; private set; }
        public AnalyticsDataColumnHeader[] ColumnHeaders { get; private set; }
        public AnalyticsDataRow[] Rows { get; private set; }

        public Dictionary<string, string> TotalsForAllResults {
            get { return _totalsForAllResults; }
        }

        #endregion

        #region Constructors

        private AnalyticsRealtimeDataResponse() {
            // Hide default constructor
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a JSON string representing the object.
        /// </summary>
        public string ToJson() {
            return JsonObject == null ? null : JsonObject.ToJson();
        }

        /// <summary>
        /// Saves the object to a JSON file at the specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to save the file.</param>
        public void SaveJson(string path) {
            if (JsonObject != null) JsonObject.SaveJson(path);
        }

        /// <summary>
        /// Gets the total value of the name and converts it to <var>T</var>.
        /// </summary>
        /// <typeparam name="T">The type to which the value should be converted.</typeparam>
        /// <param name="name">The name of the value.</param>
        public T GetTotalValue<T>(string name) {
            return (T) Convert.ChangeType(_totalsForAllResults[name], typeof(T));
        }

        /// <summary>
        /// Gets the total value of the metric and converts it to <var>T</var>.
        /// </summary>
        /// <typeparam name="T">The type to which the value should be converted.</typeparam>
        /// <param name="metric">The metric of the value.</param>
        public T GetTotalValue<T>(AnalyticsMetric metric) {
            return (T) Convert.ChangeType(_totalsForAllResults[metric.Name], typeof(T));
        }

        /// <summary>
        /// Gets the total value of the metric and converts it to <var>T</var>.
        /// </summary>
        /// <typeparam name="T">The type to which the value should be converted.</typeparam>
        /// <param name="dimension">The name of the value.</param>
        public T GetTotalValue<T>(AnalyticsDimension dimension) {
            return (T) Convert.ChangeType(_totalsForAllResults[dimension.Name], typeof(T));
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Loads an instance of <var>AnalyticsRealtimeDataResponse</var> from the JSON file at the
        /// specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to the JSON file.</param>
        public static AnalyticsRealtimeDataResponse LoadJson(string path) {
            return JsonObject.LoadJson(path, Parse);
        }

        /// <summary>
        /// Gets an instance of <var>AnalyticsRealtimeDataResponse</var> from the specified JSON
        /// string.
        /// </summary>
        /// <param name="json">The JSON string representation of the object.</param>
        public static AnalyticsRealtimeDataResponse ParseJson(string json) {
            return JsonObject.ParseJson(json, Parse);
        }

        /// <summary>
        /// Gets an instance of <var>AnalyticsRealtimeDataResponse</var> from the specified
        /// <var>JsonObject</var>.
        /// </summary>
        /// <param name="obj">The instance of <var>JsonObject</var> to parse.</param>
        public static AnalyticsRealtimeDataResponse Parse(JsonObject obj) {
            
            // Check whether "obj" is NULL
            if (obj == null) return null;

            // Check for any API errors
            if (obj.HasValue("error")) {
                JsonObject error = obj.GetObject("error");
                throw new GoogleApiException(error.GetInt("code"), error.GetString("message"));
            }

            // Get the column headers
            AnalyticsDataColumnHeader[] columns = obj.GetArray("columnHeaders", AnalyticsDataColumnHeader.Parse);
            
            // Initialize the response object
            AnalyticsRealtimeDataResponse response = new AnalyticsRealtimeDataResponse {
                JsonObject = obj,
                Query = obj.GetObject("query", AnalyticsRealtimeDataQuery.Parse),
                TotalResults = obj.GetInt("totalResults"),
                ColumnHeaders = columns,
                Rows = AnalyticsDataRow.Parse(columns, obj.GetArray("rows"))
            };

            // Get total result values
            foreach (KeyValuePair<string, object> pair in obj.GetObject("totalsForAllResults").Dictionary) {
                response._totalsForAllResults.Add(pair.Key, pair.Value.ToString());
            }
            
            return response;

        }

        #endregion

    }

}
