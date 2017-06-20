namespace Skybrud.Social.OAuth2 {
    
    /// <summary>
    /// Interface describing a token.
    /// </summary>
    public interface IOAuthToken {

        /// <summary>
        /// Gets the access token.
        /// </summary>
        string AccessToken { get; }

        /// <summary>
        /// Gets the type of the access token. Given the authentication flows currently supported by Skybrud.Social,
        /// this will always be <see cref="OAuthTokenType.Bearer"/>.
        /// </summary>
        OAuthTokenType TokenType { get; }
        
        /// <summary>
        /// Gets a refresh token that can be used to obtain a new access tokens. Not all services supports a refresh token.
        /// </summary>
        string RefreshToken { get; }

    }

}