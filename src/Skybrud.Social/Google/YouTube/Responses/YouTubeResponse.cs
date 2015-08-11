using System.Net;
using Skybrud.Social.Google.YouTube.Exceptions;
using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.Google.YouTube.Responses {

    /// <summary>
    /// Class representing a response from the YouTube API.
    /// </summary>
    public class YouTubeResponse : SocialResponse {

        #region Constructors

        protected YouTubeResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methodssponse = response;

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

            throw new YouTubeException(response, code, message);

        }

        #endregion

    }

    /// <summary>
    /// Class representing a response from the YouTube API.
    /// </summary>
    public class YouTubeResponse<T> : YouTubeResponse {

        /// <summary>
        /// Gets the body of the response.
        /// </summary>
        public T Body { get; protected set; }

        protected YouTubeResponse(SocialHttpResponse response) : base(response) { }

    }

}