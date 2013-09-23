using System;
using System.Collections.Specialized;
using Skybrud.Social.Google.Analytics;
using Skybrud.Social.Json;

namespace Skybrud.Social.Google.OAuth {

    public static class GoogleScope {

        public const string OpenId = "openid";
        public const string Email = "email";
        public const string Profile = "profile";
        public const string AnalyticsReadonly = "https://www.googleapis.com/auth/analytics.readonly";
        
    }

    /// <summary>
    /// A client for handling the communication with the Google APIs using
    /// OAuth 2.0. The client is also responsible for the raw communication
    /// with the various Google APIs.
    /// </summary>
    public class GoogleOAuthClient {

        private AnalyticsRawEndpoint _analytics;

        /// <summary>
        /// The ID of the client/application.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// The secret of the client/application. Guard this with your life!
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// The redirect URL. Must be specified in Google's APIs console.
        /// </summary>
        public string RedirectUri { get; set; }

        public string AccessToken { get; set; }

        public AnalyticsRawEndpoint Analytics {
            get { return _analytics ?? (_analytics = new AnalyticsRawEndpoint(this)); }
        }

        /// <summary>
        /// Gets the authorization URL at accounts.google.com for your application.
        /// </summary>
        /// <param name="scope">The scope of the application.</param>
        /// <param name="state">The state of the application.</param>
        /// <param name="offline">Whether the application should be enabled for offline access. Default is false.</param>
        public string GetAuthorizationUrl(string scope, string state, bool offline = false) {
            return GenerateUrl("https://accounts.google.com/o/oauth2/auth", new NameValueCollection {
                {"response_type", "code"},
                {"client_id", ClientId + ".apps.googleusercontent.com"},
                {"access_type", offline ? "offline" : "online"},
                {"scope", scope},
                {"redirect_uri", RedirectUri},
                {"state", state}
            });
        }

        public string GenerateUrl(string url, NameValueCollection query) {
            return url + (query.Count == 0 ? "" : "?" + SocialUtils.NameValueCollectionToQueryString(query));
        }

        public GoogleAccessTokenResponse GetAccessTokenFromAuthorizationCode(string code) {

            // Declare the POST data
            NameValueCollection postData = new NameValueCollection {
                {"code", code},
                {"client_id", ClientId + ".apps.googleusercontent.com"},
                {"client_secret", ClientSecret},
                {"redirect_uri", RedirectUri},
                {"grant_type", "authorization_code"}
            };

            // Make a call to the server
            JsonObject json = SocialUtils.DoHttpPostRequestAndGetBodyAsJsonObject("https://accounts.google.com/o/oauth2/token", null, postData);

            // Check for an error message
            if (json.HasValue("error")) throw new Exception(json.GetString("error"));

            // Parse the JSON response
            return GoogleAccessTokenResponse.Parse(json);

        }

        public GoogleAccessTokenResponse GetAccessTokenFromRefreshToken(string refreshToken) {

            // Declare the POST data
            NameValueCollection postData = new NameValueCollection {
                {"client_id", ClientId + ".apps.googleusercontent.com"},
                {"client_secret", ClientSecret},
                {"refresh_token", refreshToken},
                {"grant_type", "refresh_token"}
            };

            // Make a call to the server
            JsonObject json = SocialUtils.DoHttpPostRequestAndGetBodyAsJsonObject("https://accounts.google.com/o/oauth2/token", null, postData);

            // Check for an error message
            if (json.HasValue("error")) throw new Exception(json.GetString("error"));

            // Parse the JSON response
            return GoogleAccessTokenResponse.Parse(json);

        }

        public string GetUserInfo() {

            // Declare the query string
            NameValueCollection query = new NameValueCollection {
                {"access_token", AccessToken},
            };

            // Make a call to the server
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString("https://www.googleapis.com/oauth2/v3/userinfo", query);

        }

    }

}
