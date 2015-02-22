using System;
using Skybrud.Social.Google.Analytics;
using Skybrud.Social.Google.OAuth;
using Skybrud.Social.Google.YouTube;
using Skybrud.Social.Google.YouTube.Endpoints;

namespace Skybrud.Social.Google {

    public class GoogleService {

        #region Private fields

        private AnalyticsEndpoint _analytics;
        private YouTubeEndpoint _youtube;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the internal OAuth client.
        /// </summary>
        public GoogleOAuthClient Client { get; private set; }

        /// <summary>
        /// Gets the endpoint for the Analytics API.
        /// </summary>
        public AnalyticsEndpoint Analytics {
            get { return _analytics ?? (_analytics = new AnalyticsEndpoint(this)); }
        }

        /// <summary>
        /// Gets the endpoint for the YouTube API.
        /// </summary>
        public YouTubeEndpoint YouTube {
            get { return _youtube ?? (_youtube = new YouTubeEndpoint(this)); }
        }

        #endregion

        #region Constructors

        private GoogleService() {}

        #endregion

        #region Member methods

        public GoogleUserInfo GetUserInfo() {
            return GoogleUserInfo.ParseJson(Client.GetUserInfo());
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Initializes a new instance based on the specified OAuth client. The
        /// OAuth client must have an access token. Calling this method will
        /// not make any calls to the Google Accounts API.
        /// </summary>
        /// <param name="client">The OAuth client.</param>
        public static GoogleService CreateFromOAuthClient(GoogleOAuthClient client) {
            if (String.IsNullOrWhiteSpace(client.AccessToken)) throw new ArgumentException("An access token must be present in the OAuth Client");
            return new GoogleService {
                Client = client
            };
        }

        /// <summary>
        /// Initializes a new instance based on an access token. Calling this
        /// method will not make any calls to the Google Accounts API.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        public static GoogleService CreateFromAccessToken(string accessToken) {
            return new GoogleService {
                Client = new GoogleOAuthClient {
                    AccessToken = accessToken
                }
            };
        }

        /// <summary>
        /// Initializes a new instance based on the specified refresh token.
        /// The refresh token is used for making a call to the Google Accounts
        /// API to get a new access token. Access tokens typically expire after
        /// an hour (3600 seconds).
        /// </summary>
        /// <param name="clientId">The client ID.</param>
        /// <param name="clientSecret">The client secret.</param>
        /// <param name="refreshToken">The refresh token of the user.</param>
        public static GoogleService CreateFromRefreshToken(string clientId, string clientSecret, string refreshToken) {
            
            // Validation
            if (String.IsNullOrWhiteSpace(clientId)) throw new ArgumentException("Parameter \"clientId\" cannot be NULL or empty", "clientId");
            if (String.IsNullOrWhiteSpace(clientSecret)) throw new ArgumentException("Parameter \"clientSecret\" cannot be NULL or empty", "clientSecret");
            if (String.IsNullOrWhiteSpace(refreshToken)) throw new ArgumentException("Parameter \"refreshToken\" cannot be NULL or empty", "refreshToken");

            // Partial client ID?
            if (!clientId.EndsWith(".apps.googleusercontent.com")) clientId = clientId + ".apps.googleusercontent.com";

            // Initialize a new OAuth client with the specified client id and client secret
            GoogleOAuthClient client = new GoogleOAuthClient {
                ClientId = clientId,
                ClientSecret = clientSecret
            };

            // Get a new access token from the specified request token
            GoogleAccessTokenResponse response = client.GetAccessTokenFromRefreshToken(refreshToken);

            // Set the access token on the client
            client.AccessToken = response.AccessToken;

            // Initialize a new GoogleService instance based on the OAuth client
            return new GoogleService {
                Client = client
            };

        }

        #endregion

    }

}