using System.Net;

namespace Skybrud.Social.OAuth2 {
    /// <summary>
    /// Interface describing a basic OAuth 2.0 client.
    /// </summary>
    public interface IOAuthClient {

        /// <summary>
        /// Gets the ID of the client/application.
        /// </summary>
        string ClientId { get; set; }

        /// <summary>
        /// Gets the secret of the client/application. Guard this with your life!
        /// </summary>
        string ClientSecret { get; set; }

        /// <summary>
        /// Gets the redirect URL. Must be specified in Google's APIs console.
        /// </summary>
        string RedirectUri { get; set; }

        /// <summary>
        /// Gets the access token.
        /// </summary>
        string AccessToken { get; }

        /// <summary>
        /// Gets the authorization URL for the login page of the OAuth provider, based on the based
        /// <paramref name="state"/>.
        /// </summary>
        /// <param name="state">A unique state for the request.</param>
        /// <returns>The generated authorization URL.</returns>
        string GetAuthorizationUrl(string state);

        /// <summary>
        /// Gets the authorization URL for the login page of the OAuth provider, base on the specified
        /// <paramref name="state"/> and <paramref name="scope"/>.
        /// </summary>
        /// <param name="state">A unique state for the request.</param>
        /// <param name="scope">The scope of your application.</param>
        /// <returns>The generated authorization URL.</returns>
        string GetAuthorizationUrl(string state, params string[] scope);

        /// <summary>
        /// Exchanges the specified <paramref name="authorizationCode"/> for an access token.
        /// </summary>
        /// <param name="authorizationCode">The authorization code received from the OAuth login dialog.</param>
        /// <returns>An instance of <see cref="IOAuthTokenResponse"/> representing the response.</returns>
        IOAuthTokenResponse GetAccessTokenFromAuthorizationCode(string authorizationCode);

    }

    /// <summary>
    /// Interface describing an OAuth 2.0 client that supports refresh tokens.
    /// </summary>
    public interface IOAuthClientRefreshToken : IOAuthClient {

        /// <summary>
        /// Gets a new access token from the specified <paramref name="refreshToken"/>.
        /// </summary>
        /// <param name="refreshToken">The refresh token of the user.</param>
        /// <returns>An instance of <see cref="IOAuthTokenResponse"/> representing the response.</returns>
        IOAuthTokenResponse GetAccessTokenFromRefreshToken(string refreshToken);

    }

}