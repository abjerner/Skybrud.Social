using System;
using Skybrud.Social.Json;

namespace Skybrud.Social.Google.OAuth {
    
    public class GoogleAccessTokenResponse {

        /// <summary>
        /// The token that can be sent to a Google API.
        /// </summary>
        public string AccessToken { get; private set; }

        /// <summary>
        /// A token that may be used to obtain a new access token. Refresh tokens are valid until the user revokes
        /// access. This field is only present if <var>access_type=offline</var> is included in the authorization
        /// code request.
        /// </summary>
        public string RefreshToken { get; private set; }

        /// <summary>
        /// The remaining lifetime on the access token.
        /// </summary>
        public TimeSpan ExpiresIn { get; private set; }

        /// <summary>
        /// The remaining lifetime on the access token.
        /// </summary>
        public string TokenType { get; private set; }

        public static GoogleAccessTokenResponse Parse(JsonObject obj) {
            return new GoogleAccessTokenResponse {
                AccessToken = obj.GetString("access_token"),
                RefreshToken = obj.GetString("refresh_token"),
                ExpiresIn = TimeSpan.FromSeconds(obj.GetInt32("expires_in")),
                TokenType = obj.GetString("token_type")
            };
        }

    }

}