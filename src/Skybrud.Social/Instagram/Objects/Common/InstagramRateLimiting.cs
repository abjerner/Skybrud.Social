using System;
using Skybrud.Social.Http;

namespace Skybrud.Social.Instagram.Objects.Common {
    
    /// <summary>
    /// Class with rate-limiting information about a response from the Instagram API.
    /// </summary>
    /// <see>
    ///     <cref>https://instagram.com/developer/limits/</cref>
    /// </see>
    public class InstagramRateLimiting {

        #region Properties

        /// <summary>
        /// Gets the total number of calls allowed within the current 1-hour window.
        /// </summary>
        public int Limit { get; private set; }

        /// <summary>
        /// Gets the remaining number of calls available to your app within the current 1-hour window.
        /// </summary>
        public int Remaining { get; private set; }

        #endregion

        #region Constructors

        private InstagramRateLimiting(int limit, int remaining) {
            Limit = limit;
            Remaining = remaining;
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses rate-limiting information from the specified <code>response</code>.
        /// </summary>
        /// <param name="response">The response that holds the rate-limiting information.</param>
        /// <returns>Returns an instance of <code>InstagramRateLimiting</code>.</returns>
        public static InstagramRateLimiting GetFromResponse(SocialHttpResponse response) {

            int limit;
            int remaining;

            if (!Int32.TryParse(response.Headers["X-Ratelimit-Limit"] ?? "", out limit)) {
                limit = -1;
            }

            if (!Int32.TryParse(response.Headers["X-Ratelimit-Remaining"] ?? "", out remaining)) {
                remaining = -1;
            }

            return new InstagramRateLimiting(limit, remaining);

        }

        #endregion

    }

}