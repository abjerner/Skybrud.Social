using System.Net;
using Skybrud.Social.Http;
using Skybrud.Social.Json;
using Skybrud.Social.Twitter.Exceptions;
using Skybrud.Social.Twitter.Objects.Common;

namespace Skybrud.Social.Twitter.Responses {

    public class TwitterResponse {

        #region Properties

        /// <summary>
        /// Gets a reference to the underlying response.
        /// </summary>
        public SocialHttpResponse Response { get; private set; }

        /// <summary>
        /// Gets information about rate limiting.
        /// </summary>
        public TwitterRateLimiting RateLimiting { get; private set; }

        #endregion

        #region Constructors

        protected TwitterResponse(SocialHttpResponse response) {
            Response = response;
            RateLimiting = TwitterRateLimiting.GetFromResponse(response);
        }

        #endregion

        #region Static methods

        public static void ValidateResponse(SocialHttpResponse response) {

            // Skip error checking if the server responds with an OK status code
            if (response.StatusCode == HttpStatusCode.OK) return;

            JsonObject obj = response.GetBodyAsJsonObject();

            // For some types of errors, Twitter will only respond with an error message
            if (obj.HasValue("error")) {
                throw new TwitterException(response, obj.GetString("error"), 0);
            }

            // However in most cases, Twitter responds with an array of errors
            JsonArray errors = obj.GetArray("errors");

            // Get the first error (don't remember ever seeing multiple errors in the same response)
            JsonObject error = errors.GetObject(0);

            // Throw the exception
            throw new TwitterException(response, error.GetString("message"), error.GetInt32("code"));

        }

        #endregion

    }

    public class TwitterResponse<T> : TwitterResponse {

        #region Properties

        public T Body { get; protected set; }

        #endregion

        #region Constructors

        protected TwitterResponse(SocialHttpResponse response) : base(response) { }

        #endregion

    }

}