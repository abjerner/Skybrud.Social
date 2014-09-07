using Skybrud.Social.Json;

namespace Skybrud.Social.Google.Analytics.Objects {

    public class AnalyticsDataColumnHeader : SocialJsonObject {

        #region Properties
        
        public string Name { get; internal set; }
        public string ColumnType { get; internal set; }
        public string DataType { get; internal set; }

        #endregion

        #region Constructors

        private AnalyticsDataColumnHeader(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Loads an instance of <var>AnalyticsDataColumnHeader</var> from the JSON file at the
        /// specified <var>path</var>.
        /// </summary>
        /// <param name="path">The path to the JSON file.</param>
        public static AnalyticsDataColumnHeader LoadJson(string path) {
            return JsonObject.LoadJson(path, Parse);
        }

        /// <summary>
        /// Gets an instance of <var>AnalyticsDataColumnHeader</var> from the specified JSON
        /// string.
        /// </summary>
        /// <param name="json">The JSON string representation of the object.</param>
        public static AnalyticsDataColumnHeader ParseJson(string json) {
            return JsonObject.ParseJson(json, Parse);
        }

        /// <summary>
        /// Gets an instance of <var>AnalyticsDataColumnHeader</var> from the specified
        /// <var>JsonObject</var>.
        /// </summary>
        /// <param name="obj">The instance of <var>JsonObject</var> to parse.</param>
        public static AnalyticsDataColumnHeader Parse(JsonObject obj) {
            if (obj == null) return null;
            return new AnalyticsDataColumnHeader(obj) {
                Name = obj.GetString("name"),
                ColumnType = obj.GetString("columnType"),
                DataType = obj.GetString("dataType")
            };
        }

        #endregion
        
    }

}