namespace Skybrud.Social.Google.OAuth {
    
    /// <summary>
    /// Static class containing references to global scopes of the Google APIs.
    /// </summary>
    /// <see>
    ///     <cref>https://developers.google.com/+/web/api/rest/oauth</cref>
    /// </see>
    public static class GoogleScopes {

        #region Constants (global Google scopes)

        /// <see>
        ///     <cref>https://developers.google.com/+/web/api/rest/oauth#openid</cref>
        /// </see>
        public static readonly GoogleScope OpenId = new GoogleScope("openid");

        /// <summary>
        /// Scope giving access the email address of the authenticated user.
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/+/web/api/rest/oauth#email</cref>
        /// </see>
        public static readonly GoogleScope Email = new GoogleScope("email");

        /// <summary>
        /// Scope giving access to profile information of the authenticated user.
        /// </summary>
        /// <see>
        ///     <cref>https://developers.google.com/+/web/api/rest/oauth#profile</cref>
        /// </see>
        public static readonly GoogleScope Profile = new GoogleScope("profile");

        #endregion

    }

}