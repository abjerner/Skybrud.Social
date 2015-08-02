using Skybrud.Social.Json;

namespace Skybrud.Social.Google.Analytics.Objects.Data {

    /// <summary>
    /// Class representing the response body of a request to get Analytics data.
    /// </summary>
    public class AnalyticsDataResponseBody : GoogleApiResource {

        #region Properties

        /// <summary>
        /// Gets the amount of results per page.
        /// </summary>
        public int ItemsPerPage { get; private set; }

        /// <summary>
        /// Gets the total amount of results.
        /// </summary>
        public int TotalResults { get; private set; }
        
        /// <summary>
        /// Gets a link for the current page.
        /// </summary>
        public string SelfLink { get; private set; }

        /// <summary>
        /// Gets a link for the previous page.
        /// </summary>
        public string PreviousLink { get; private set; }
        
        /// <summary>
        /// Gets a link for the next page.
        /// </summary>
        public string NextLink { get; private set; }

        /// <summary>
        /// Gets a reference to an object with information about the requested profile.
        /// </summary>
        public AnalyticsProfileInfo ProfileInfo { get; private set; }

        /// <summary>
        /// Gets an object describing the query.
        /// </summary>
        public AnalyticsDataQuery Query { get; private set; }

        /// <summary>
        /// Gets an array of the column headers.
        /// </summary>
        public AnalyticsDataColumnHeader[] ColumnHeaders { get; private set; }

        /// <summary>
        /// Gets an array of rows for the current page.
        /// </summary>
        public AnalyticsDataRow[] Rows { get; private set; }

        #endregion

        #region Constructors

        private AnalyticsDataResponseBody(JsonObject obj) : base(obj) { }

        #endregion
        
        #region Static methods
        
        /// <summary>
        /// Gets an instance of <code>AnalyticsDataResponseBody</code> from the specified <code>JsonObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        public static AnalyticsDataResponseBody Parse(JsonObject obj) {
            
            // Check whether "obj" is NULL
            if (obj == null) return null;

            // Get the column headers
            AnalyticsDataColumnHeader[] columns = obj.GetArray("columnHeaders", AnalyticsDataColumnHeader.Parse);

            // Initialize and return the response body
            return new AnalyticsDataResponseBody(obj) {
                Query = obj.GetObject("query", AnalyticsDataQuery.Parse),
                ItemsPerPage = obj.GetInt32("itemsPerPage"),
                TotalResults = obj.GetInt32("totalResults"),
                SelfLink = obj.GetString("selfLink"),
                PreviousLink = obj.GetString("nextLink"),
                NextLink = obj.GetString("previousLink"),
                ProfileInfo = obj.GetObject("profileInfo", AnalyticsProfileInfo.Parse),
                //ContainsSampledData = obj.GetBoolean("containsSampledData"),
                ColumnHeaders = columns,
                // TotalForAllResults = obj.GetBoolean("totalForAllResults"),
                Rows = AnalyticsDataRow.Parse(columns, obj.GetArray("rows"))
            };

        }

        #endregion

    }

}
