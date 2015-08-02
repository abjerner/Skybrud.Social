using Skybrud.Social.Google.Analytics.Objects.Data;
using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.Google.Analytics.Responses.Data {

    /// <summary>
    /// Class representing the response of a request to get Analytics data.
    /// </summary>
    public class AnalyticsDataResponse : AnalyticsResponse<AnalyticsDataResponseBody> {
        
        #region Constructors

        private AnalyticsDataResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>AnalyticsDataResponse</code>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns></returns>
        public static AnalyticsDataResponse ParseResponse(SocialHttpResponse response) {

            if (response == null) return null;

            // Parse the raw JSON response
            JsonObject obj = response.GetBodyAsJsonObject();
            // TODO: Should we throw an exception here?
            if (obj == null) return null;

            // Validate the response
            ValidateResponse(response, obj);

            // Initialize the response object
            return new AnalyticsDataResponse(response) {
                Body = AnalyticsDataResponseBody.Parse(obj)
            };

        }

        #endregion

    }

}