using System;
using Skybrud.Social.Json;
using Skybrud.Social.Microsoft.Scopes;

namespace Skybrud.Social.Microsoft.Objects.Authentication {
    
    /// <summary>
    /// Class representing the response body of a call to get a refresh token or an access token.
    /// </summary>
    public class MicrosoftTokenResponseBody : SocialJsonObject {

        #region Properties

        /// <summary>
        /// Gets the type of the topen.
        /// </summary>
        public string TokenType { get; private set; }

        /// <summary>
        /// Gets an instance of <code>TimeSpan</code> for when the access token will expire.
        /// </summary>
        public TimeSpan ExpiresIn { get; private set; }

        /// <summary>
        /// Gets a collection of the scopes the user has granted.
        /// </summary>
        public MicrosoftScopeCollection Scope { get; private set; }

        /// <summary>
        /// Gets the access token.
        /// </summary>
        public string AccessToken { get; private set; }

        /// <summary>
        /// Gets the authentication token.
        /// </summary>
        public string AuthenticationToken { get; private set; }

        /// <summary>
        /// Gets the refresh token.
        /// </summary>
        public string RefreshToken { get; private set; }

        /// <summary>
        /// Gets whether a authentication token was specified in the response.
        /// </summary>
        public bool HasAuthenticationToken {
            get { return !String.IsNullOrWhiteSpace(AuthenticationToken); }
        }

        /// <summary>
        /// Gets whether a refresh token was specified in the response.
        /// </summary>
        public bool HasRefreshToken {
            get { return !String.IsNullOrWhiteSpace(RefreshToken); }
        }

        #endregion

        #region Constructors

        private MicrosoftTokenResponseBody(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <code>MicrosoftTokenResponseBody</code> from the specified <code>JsonObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        public static MicrosoftTokenResponseBody Parse(JsonObject obj) {
            
            if (obj == null) return null;

            // Convert the "scope" string to a collection of scopes
            MicrosoftScopeCollection scopes = new MicrosoftScopeCollection();
            foreach (string name in obj.GetString("scope").Split(' ')) {
                MicrosoftScope scope = MicrosoftScope.GetScope(name) ?? MicrosoftScope.RegisterScope(name);
                scopes.Add(scope);
            }

            // Parse the rest of the response
            return new MicrosoftTokenResponseBody(obj) {
                TokenType = obj.GetString("token_type"),
                ExpiresIn = TimeSpan.FromSeconds(obj.GetInt32("expires_in")),
                Scope = scopes,
                AccessToken = obj.GetString("access_token"),
                AuthenticationToken = obj.GetString("authentication_token"),
                RefreshToken = obj.GetString("refresh_token")
            };
        
        }

        #endregion

    }

}