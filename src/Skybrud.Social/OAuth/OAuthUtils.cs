using System;

namespace Skybrud.Social.OAuth {

    public static class OAuthUtils {

        /// <summary>
        /// Generates a nonce (random value) used for creating the
        /// authorization header.
        /// </summary>
        public static string GenerateNonce() {
            return Guid.NewGuid().ToString().Replace("-", "");
        }

        /// <summary>
        /// Returns the current UNIX timestamp as a string.
        /// </summary>
        public static string GetTimestamp() {
            return SocialUtils.GetCurrentUnixTimestamp() + "";
        }

    }

}
