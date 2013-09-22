using System;
using Skybrud.Social.Google.Analytics;
using Skybrud.Social.Google.OAuth;

namespace Skybrud.Social.Google {

    public class GoogleService {

        private AnalyticsEndpoint _analytics;

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
        /// Initializes a new instance based on the specified request token.
        /// The request token is used for making a call to the Google Accounts
        /// API to get a new access token. Access tokens typically expire after
        /// an hour (3600 seconds).
        /// </summary>
        /// <param name="clientId">The client ID.</param>
        /// <param name="clientSecret">The client secret.</param>
        /// <param name="requestToken">The request token of the user.</param>
        /// <returns></returns>
        public static GoogleService CreateFromRequestToken(string clientId, string clientSecret, string requestToken) {
            
            // Initialize a new OAuth client with the specified client id and client secret
            GoogleOAuthClient client = new GoogleOAuthClient {
                ClientId = clientId,
                ClientSecret = clientSecret
            };

            // Get a new access token from the specified request token
            GoogleAccessTokenResponse response = client.GetAccessTokenFromRefreshToken(requestToken);

            // Set the access token on the client
            client.AccessToken = response.AccessToken;

            // Initialize a new GoogleService instance based on the OAuth client
            return new GoogleService {
                Client = client
            };

        }
    
    }

}
