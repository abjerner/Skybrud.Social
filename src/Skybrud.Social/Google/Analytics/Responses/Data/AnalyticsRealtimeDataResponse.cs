using Skybrud.Social.Google.Analytics.Objects.Data;
using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.Google.Analytics.Responses.Data {

    /// <summary>
    /// Class representing the response of a request to get Analytics realtime data.
    /// </summary>
    public class AnalyticsRealtimeDataResponse : AnalyticsResponse<AnalyticsDataResponseBody> {
        
        #region Constructors

        private AnalyticsRealtimeDataResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>AnalyticsDataResponse</code>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns></returns>
        public static AnalyticsRealtimeDataResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            // TODO: Should we throw an exception here?
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new AnalyticsRealtimeDataResponse(response) {
                // TODO: Check whether the realtime data response body is the same as for historical data
                Body = AnalyticsDataResponseBody.Parse(obj)
            };

        }

        #endregion

    }

}