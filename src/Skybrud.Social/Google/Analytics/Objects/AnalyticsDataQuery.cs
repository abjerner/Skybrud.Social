using Skybrud.Social.Json;

namespace Skybrud.Social.Google.Analytics.Objects {

    public class AnalyticsDataQuery {

        #region Properties

        /// <summary>
        /// Gets the internal JsonObject the object was created from.
        /// </summary>
        public JsonObject JsonObject { get; private set; }
        
        public string Ids { get; internal set; }
        public string StartDate { get; internal set; }
        public string EndDate { get; internal set; }
        public int StartIndex { get; internal set; }
        public int MaxResults { get; internal set; }
        public string Dimensions { get; internal set; }
        public string[] Metrics { get; internal set; }

        #endregion
        
        #region Constructors

        private AnalyticsDataQuery() {
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

        #endregion

        #region Static methods

        /// <summary>
        /// Loads an instance of <var>AnalyticsDataQuery</var> from the JSON file at the specified
        /// <var>path</var>.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public static AnalyticsDataQuery LoadJson(string path) {
            return JsonObject.LoadJson(path, Parse);
        }

        /// <summary>
        /// Gets an instance of <var>AnalyticsDataQuery</var> from the specified JSON string.
        /// </summary>
        /// <param name="json">The JSON string representation of the object.</param>
        public static AnalyticsDataQuery ParseJson(string json) {
            return JsonObject.ParseJson(json, Parse);
        }

        /// <summary>
        /// Gets an instance of <var>AnalyticsDataQuery</var> from the specified
        /// <var>JsonObject</var>.
        /// </summary>
        /// <param name="obj">The instance of <var>JsonObject</var> to parse.</param>
        public static AnalyticsDataQuery Parse(JsonObject obj) {
            if (obj == null) return null;
            return new AnalyticsDataQuery {
                JsonObject = obj,
                Ids = obj.GetString("ids"),
                StartDate = obj.GetString("start-date"),
                EndDate = obj.GetString("end-date"),
                StartIndex = obj.GetInt32("start-index"),
                MaxResults = obj.GetInt32("max-results"),
                Dimensions = obj.GetString("dimensions"),
                Metrics = obj.GetArray<string>("metrics")
            };
        }

        #endregion

    }

}