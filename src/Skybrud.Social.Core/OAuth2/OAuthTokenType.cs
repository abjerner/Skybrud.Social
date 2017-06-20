namespace Skybrud.Social.OAuth2 {
    
    /// <summary>
    /// Enum class indicating the type of an access token. Given the authentication flows currently supported by
    /// Skybrud.Social, this will always be <see cref="OAuthTokenType.Bearer"/>.
    /// </summary>
    public enum OAuthTokenType {

        /// <summary>
        /// Indicates an access token of the bearer type.
        /// </summary>
        Bearer
    
    }

}