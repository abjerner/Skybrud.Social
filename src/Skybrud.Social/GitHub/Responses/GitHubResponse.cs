using System;
using System.Net;
using Skybrud.Social.GitHub.Exceptions;
using Skybrud.Social.Http;
using Skybrud.Social.Json;

namespace Skybrud.Social.GitHub.Responses {

    /// <summary>
    /// Class representing a response from the GitHub API.
    /// </summary>
    public abstract class GitHubResponse : SocialResponse {

        #region Properties

        /// <summary>
        /// Gets the total amount of calls that can be made to the API in the current timeframe.
        /// </summary>
        public int RateLimit { get; private set; }

        /// <summary>
        /// Gets the remaining amount of calls that can be made to the API in the current
        /// timeframe.
        /// </summary>
        public int RateLimitRemaining { get; private set; }

        /// <summary>
        /// Gets the timestamp of the next rate limit timeframe.
        /// </summary>
        public DateTime RateLimitReset { get; private set; }

        #endregion

        #region Constructor

        protected GitHubResponse(SocialHttpResponse response) : base(response) {
            RateLimit = Int32.Parse(response.Headers["X-RateLimit-Limit"]);
            RateLimitRemaining = Int32.Parse(response.Headers["X-RateLimit-Remaining"]);
            RateLimitReset = SocialUtils.GetDateTimeFromUnixTime(response.Headers["X-RateLimit-Reset"]);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Validates the specified <code>response</code>.
        /// </summary>
        /// <param name="response">The response to be validated.</param>
        public static void ValidateResponse(SocialHttpResponse response) {

            // Skip error checking if the server responds with an OK status code
            if (response.StatusCode == HttpStatusCode.OK) return;

            // Get the "meta" object
            JsonObject obj = response.GetBodyAsJsonObject();

            // Now throw some exceptions
            string message = obj.GetString("message");
            string url = obj.GetString("documentation_url");
            throw new GitHubHttpException(response, message, url);

        }

        #endregion

    }

    /// <summary>
    /// Class representing a response from the GitHub API.
    /// </summary>
    public class GitHubResponse<T> : GitHubResponse {

        #region Properties

        /// <summary>
        /// Gets the body of the response.
        /// </summary>
        public T Body { get; protected set; }

        #endregion

        #region Constructors

        protected GitHubResponse(SocialHttpResponse response) : base(response) { }

        #endregion

    }

}