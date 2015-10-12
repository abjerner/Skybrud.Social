using Skybrud.Social.Json;

namespace Skybrud.Social.Instagram.Objects {
    
    /// <summary>
    /// Class representing the response body of a call to exchange an authorization code for an access token.
    /// </summary>
    public class InstagramAccessTokenSummary : SocialJsonObject {

        #region Properties
        
        /// <summary>
        /// Gets the access token.
        /// </summary>
        public string AccessToken { get; private set; }
        
        /// <summary>
        /// Gets information about the authenticated user.
        /// </summary>
        public InstagramUser User { get; private set; }

        #endregion

        #region Constructors

        private InstagramAccessTokenSummary(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <code>InstagramAccessTokenSummary</code> from the specified <code>JsonObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        public static InstagramAccessTokenSummary Parse(JsonObject obj) {
            if (obj == null) return null;
            return new InstagramAccessTokenSummary(obj) {
                AccessToken = obj.GetString("access_token"),
                User = obj.GetObject("user", InstagramUser.Parse)
            };
        }

        #endregion

    }

}