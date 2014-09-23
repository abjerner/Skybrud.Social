using System;
using System.Collections.Specialized;
using Skybrud.Social.Google.Analytics;
using Skybrud.Social.Google.Exceptions;
using Skybrud.Social.Google.YouTube;
using Skybrud.Social.Json;

namespace Skybrud.Social.Google.OAuth {
    
    /// <summary>
    /// A client for handling the communication with the Google APIs using
    /// OAuth 2.0. The client is also responsible for the raw communication
    /// with the various Google APIs.
    /// </summary>
    public class GoogleOAuthClient {

        #region Private fields

        private AnalyticsRawEndpoint _analytics;
        private YouTubeRawEndpoint _youtube;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the ID of the client/application. The client ID can be specified as either
        /// the first part of the client ID (eg. "123456") or or the full
        /// client ID (eg. "123456.apps.googleusercontent.com").
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Gets the full client ID of the application.
        /// </summary>
        public string ClientIdFull {
            get {
                if (String.IsNullOrWhiteSpace(ClientId)) return null;
                return ClientId.EndsWith(".apps.googleusercontent.com") ? ClientId : ClientId + ".apps.googleusercontent.com";
            }
        }

        /// <summary>
        /// Gets or sets the the secret of the client/application. Guard this with your life!
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets the redirect URL. Must be specified in Google's APIs console.
        /// </summary>
        public string RedirectUri { get; set; }

        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets a reference to the raw Analytics endpoint.
        /// </summary>
        public AnalyticsRawEndpoint Analytics {
            get { return _analytics ?? (_analytics = new AnalyticsRawEndpoint(this)); }
        }

        /// <summary>
        /// Gets a reference to the raw YouTube endpoint.
        /// </summary>
        public YouTubeRawEndpoint YouTube {
            get { return _youtube ?? (_youtube = new YouTubeRawEndpoint(this)); }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the authorization URL at accounts.google.com for your application.
        /// </summary>
        /// <param name="state">The state of the application.</param>
        /// <param name="scope">The scope of the application.</param>
        /// <param name="offline">Whether the application should be enabled for offline access. Default is false.</param>
        public string GetAuthorizationUrl(string state, string scope, bool offline = false) {
            return GenerateUrl("https://accounts.google.com/o/oauth2/auth", new NameValueCollection {
                {"response_type", "code"},
                {"client_id", ClientIdFull},
                {"access_type", offline ? "offline" : "online"},
                {"scope", scope},
                {"redirect_uri", RedirectUri},
                {"state", state}
            });
        }
        
        /// <summary>
        /// Gets the authorization URL at accounts.google.com for your application.
        /// </summary>
        /// <param name="state">The state of the application.</param>
        /// <param name="scope">The scope of the application.</param>
        /// <param name="offline">Whether the application should be enabled for offline access. Default is false.</param>
        public string GetAuthorizationUrl(string state, GoogleScopeCollection scope, bool offline = false) {
            return GenerateUrl("https://accounts.google.com/o/oauth2/auth", new NameValueCollection {
                {"response_type", "code"},
                {"client_id", ClientIdFull},
                {"access_type", offline ? "offline" : "online"},
                {"scope", scope + "" },
                {"redirect_uri", RedirectUri},
                {"state", state}
            });
        }

        /// <summary>
        /// Gets the authorization URL at accounts.google.com for your application.
        /// </summary>
        /// <param name="state">The state of the application.</param>
        /// <param name="scope">The scope of the application.</param>
        /// <param name="accessType">Whether the application should be enabled for offline access. Default is online.</param>
        /// <param name="approvalPrompt">Whether the user should be re-prompted for scopes that he/she already has approved.</param>
        public string GetAuthorizationUrl(string state, string scope, GoogleAccessType accessType = GoogleAccessType.Online, GoogleApprovalPrompt approvalPrompt = GoogleApprovalPrompt.Auto) {
            return GenerateUrl("https://accounts.google.com/o/oauth2/auth", new NameValueCollection {
                {"response_type", "code"},
                {"client_id", ClientIdFull},
                {"access_type", accessType.ToString().ToLower()},
                {"approval_prompt", approvalPrompt.ToString().ToLower()},
                {"scope", scope},
                {"redirect_uri", RedirectUri},
                {"state", state}
            });
        }

        /// <summary>
        /// Gets the authorization URL at accounts.google.com for your application.
        /// </summary>
        /// <param name="state">The state of the application.</param>
        /// <param name="scope">The scope of the application.</param>
        /// <param name="accessType">Whether the application should be enabled for offline access. Default is online.</param>
        /// <param name="approvalPrompt">Whether the user should be re-prompted for scopes that he/she already has approved.</param>
        public string GetAuthorizationUrl(string state, GoogleScopeCollection scope, GoogleAccessType accessType = GoogleAccessType.Online, GoogleApprovalPrompt approvalPrompt = GoogleApprovalPrompt.Auto) {
            return GenerateUrl("https://accounts.google.com/o/oauth2/auth", new NameValueCollection {
                {"response_type", "code"},
                {"client_id", ClientIdFull},
                {"access_type", accessType.ToString().ToLower()},
                {"approval_prompt", approvalPrompt.ToString().ToLower()},
                {"scope", scope + ""},
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
                {"client_id", ClientIdFull},
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
                {"client_id", ClientIdFull},
                {"client_secret", ClientSecret},
                {"refresh_token", refreshToken},
                {"grant_type", "refresh_token"}
            };

            // Make a call to the server
            JsonObject json = SocialUtils.DoHttpPostRequestAndGetBodyAsJsonObject("https://accounts.google.com/o/oauth2/token", null, postData);

            // Check for an error message
            if (json.HasValue("error")) {
                throw new GoogleOAuthException(json.GetString("error"), json.GetString("error_description"));
            }

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

        /// <summary>
        /// Makes an authenticated GET request to the specified URL. The access token is
        /// automatically appended to the query string.
        /// </summary>
        /// <param name="url">The URL to call.</param>
        public string DoAuthenticatedGetRequest(string url) {
            return DoAuthenticatedGetRequest(url, null);
        }

        /// <summary>
        /// Makes an authenticated GET request to the specified URL. The access token is
        /// automatically appended to the query string.
        /// </summary>
        /// <param name="url">The URL to call.</param>
        /// <param name="query">The query string for the call.</param>
        public string DoAuthenticatedGetRequest(string url, NameValueCollection query) {

            // Initialize a new NameValueCollection if NULL
            if (query == null) query = new NameValueCollection();

            // Set the access token in the query string
            // TODO: Specify access token in HTTP header instead
            query.Set("access_token", AccessToken);

            // Make a call to the server
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString(url, query);

        }

        #endregion

    }

}
