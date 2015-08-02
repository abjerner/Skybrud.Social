using System;
using Skybrud.Social.Google.Analytics.Endpoints.Raw;
using Skybrud.Social.Google.Analytics.Options.Data;
using Skybrud.Social.Google.Analytics.Responses.Data;

namespace Skybrud.Social.Google.Analytics.Endpoints {
    
    /// <summary>
    /// Implementation of the data endpoint.
    /// </summary>
    public class AnalyticsDataEndpoint {

        #region Properties

        /// <summary>
        /// Gets the parent endpoint of this endpoint.
        /// </summary>
        public AnalyticsEndpoint Analytics { get; private set; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public AnalyticsDataRawEndpoint Raw {
            get { return Analytics.Service.Client.Analytics.Data; }
        }

        #endregion

        #region Constructors

        internal AnalyticsDataEndpoint(AnalyticsEndpoint analytics) {
            Analytics = analytics;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets historical data based on the specified <code>options</code>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>Returns an instance of <code>AnalyticsDataResponse</code> representing the response.</returns>
        public AnalyticsDataResponse GetData(AnalyticsDataOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            return AnalyticsDataResponse.ParseResponse(Raw.GetData(options));
        }

        /// <summary>
        /// Gets realtime data based on the specified <code>options</code>.
        /// </summary>
        /// <param name="profileId">The ID of the Analytics profile.</param>
        /// <param name="options">The options specifying the query.</param>
        /// <returns>Returns an instance of <code>AnalyticsRealtimeDataResponse</code> representing the response.</returns>
        public AnalyticsRealtimeDataResponse GetRealtimeData(string profileId, AnalyticsRealtimeDataOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            return AnalyticsRealtimeDataResponse.ParseResponse(Raw.GetRealtimeData(options));
        }
        
        #endregion

    }

}