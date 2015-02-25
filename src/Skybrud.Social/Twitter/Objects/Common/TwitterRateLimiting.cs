using System;
using Skybrud.Social.Http;

namespace Skybrud.Social.Twitter.Objects.Common {
    
    public class TwitterRateLimiting {

        #region Properties

        public int Limit { get; private set; }

        public int Remaining { get; private set; }

        public DateTime Reset { get; private set; }

        #endregion

        #region Constructors

        private TwitterRateLimiting(int limit, int remaining, int reset) {
            Limit = limit;
            Remaining = remaining;
            Reset = SocialUtils.GetDateTimeFromUnixTime(reset);
        }

        #endregion

        #region Static methods

        public static TwitterRateLimiting GetFromResponse(SocialHttpResponse response) {

            int limit;
            int remaining;
            int reset;

            if (!Int32.TryParse(response.Headers["x-rate-limit-limit"] ?? "", out limit)) {
                limit = -1;
            }

            if (!Int32.TryParse(response.Headers["x-rate-limit-remaining"] ?? "", out remaining)) {
                remaining = -1;
            }

            if (!Int32.TryParse(response.Headers["x-rate-limit-reset"] ?? "", out reset)) {
                reset = 0;
            }

            return new TwitterRateLimiting(limit, remaining, reset);

        }

        #endregion

    }

}