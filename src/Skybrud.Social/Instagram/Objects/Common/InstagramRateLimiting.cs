using System;
using Skybrud.Social.Http;

namespace Skybrud.Social.Instagram.Objects.Common {
    
    public class InstagramRateLimiting {

        #region Properties

        public int Limit { get; private set; }

        public int Remaining { get; private set; }

        #endregion

        #region Constructors

        internal InstagramRateLimiting(int limit, int remaining) {
            Limit = limit;
            Remaining = remaining;
        }

        #endregion

        #region Static methods

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