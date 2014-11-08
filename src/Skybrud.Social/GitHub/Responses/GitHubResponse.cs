using System;
using Skybrud.Social.Http;

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

    }

}
