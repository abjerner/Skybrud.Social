using System;
using System.Net;
using Skybrud.Social.GitHub.Exceptions;
using Skybrud.Social.Http;
using Skybrud.Social.Instagram.Exceptions;
using Skybrud.Social.Instagram.Objects;
using Skybrud.Social.Json;

namespace Skybrud.Social.GitHub.Responses {

    public abstract class GitHubResponse {

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

        /// <summary>
        /// Gets a reference to the underlying response.
        /// </summary>
        public SocialHttpResponse Response { get; private set; }

        #endregion

        #region Constructor

        protected GitHubResponse(SocialHttpResponse response) {
            RateLimit = Int32.Parse(response.Headers["X-RateLimit-Limit"]);
            RateLimitRemaining = Int32.Parse(response.Headers["X-RateLimit-Remaining"]);
            RateLimitReset = SocialUtils.GetDateTimeFromUnixTime(response.Headers["X-RateLimit-Reset"]);
            Response = response;
        }

        #endregion

        #region Static methods
        
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

    public class GitHubResponse<T> : GitHubResponse {

        public T Body { get; protected set; }

        protected GitHubResponse(SocialHttpResponse response) : base(response) { }

    }

}