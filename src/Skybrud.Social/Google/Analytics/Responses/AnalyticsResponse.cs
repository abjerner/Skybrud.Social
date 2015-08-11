using System;
using System.Net;
using Skybrud.Social.Google.Analytics.Exceptions;
using Skybrud.Social.Google.Exceptions;
using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.Google.Analytics.Responses {
    
    /// <summary>
    /// Class representing a response from the Analytics API.
    /// </summary>
    public class AnalyticsResponse : SocialResponse {

        #region Constructors
        
        protected AnalyticsResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Validates the specified <code>response</code>.
        /// </summary>
        /// <param name="response">The response to be validated.</param>
        /// <param name="obj">The object representing the response object.</param>
        public static void ValidateResponse(SocialHttpResponse response, JsonObject obj) {

            // Skip error checking if the server responds with an OK status code
            if (response.StatusCode == HttpStatusCode.OK) return;

            JsonObject error = obj.GetObject("error");

            int code = error.GetInt32("code");
            string message = error.GetString("message");

            // TODO: Parse "errors"

            throw new AnalyticsException(response, code, message);

        }

        #endregion

        #region Old validation methods kept for legacy support

        /// <summary>
        /// Validates the response body given the specified <code>obj</code>.
        /// </summary>
        /// <param name="obj">The JSON object representing the response object.</param>
        [Obsolete]
        public static JsonObject Validate(JsonObject obj) {

            // TODO: Remove in v1.0

            // Shoduln't be NULL
            if (obj == null) throw new ArgumentNullException("obj");

            // Attempt to get the error object
            JsonObject error = obj.GetObject("error");

            // Throw an exception based on the error response
            if (error != null) {
                throw new GoogleApiException(error.GetInt32("code"), error.GetString("message"));
            }

            // Just return the JSON object
            return obj;

        }

        /// <summary>
        /// Validates the response body given the specified <code>response</code>.
        /// </summary>
        /// <param name="response">The string representing the response body.</param>
        [Obsolete]
        public static JsonObject Validate(string response) {
            // TODO: Remove in v1.0
            return Validate(JsonObject.ParseJson(response));
        }

        #endregion

    }

    /// <summary>
    /// Class representing a response from the Analytics API.
    /// </summary>
    public class AnalyticsResponse<T> : AnalyticsResponse {

        #region Properties

        /// <summary>
        /// Gets the body of the response.
        /// </summary>
        public T Body { get; protected set; }

        #endregion

        #region Constructors

        protected AnalyticsResponse(SocialHttpResponse response) : base(response) { }

        #endregion

    }

}