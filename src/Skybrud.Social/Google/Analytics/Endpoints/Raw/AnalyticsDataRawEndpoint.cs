using System;
using Skybrud.Social.Google.Analytics.Options.Data;
using Skybrud.Social.Google.OAuth;
using Skybrud.Social.Http;

namespace Skybrud.Social.Google.Analytics.Endpoints.Raw {
    
    /// <summary>
    /// Raw implementation of the data endpoint.
    /// </summary>
    public class AnalyticsDataRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Google OAuth client.
        /// </summary>
        public GoogleOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal AnalyticsDataRawEndpoint(GoogleOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods
        
        /// <summary>
        /// Gets historical data based on the specified <code>options</code>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>Returns an instance of <code>SocialHttpResponse</code> representing the response.</returns>
        public SocialHttpResponse GetData(AnalyticsDataOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            return Client.DoAuthenticatedGetRequest("https://www.googleapis.com/analytics/v3/data/ga", options);
        }

        /// <summary>
        /// Gets realtime data based on the specified <code>options</code>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>Returns an instance of <code>SocialHttpResponse</code> representing the response.</returns>
        public SocialHttpResponse GetRealtimeData(AnalyticsRealtimeDataOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            return Client.DoAuthenticatedGetRequest("https://www.googleapis.com/analytics/v3/data/realtime", options);
        }
        
        #endregion

    }

}