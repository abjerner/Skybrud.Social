using Skybrud.Social.Json;
using Skybrud.Social.Slack.Scopes;

namespace Skybrud.Social.Slack.Objects.Authentication {
    
    /// <summary>
    /// Class representing the response body of a call to get an access token.
    /// </summary>
    public class SlackTokenInfo : SlackObject {

        #region Properties
        
        /// <summary>
        /// Gets the access token.
        /// </summary>
        public string AccessToken { get; private set; }

        /// <summary>
        /// Gets a collection of the scopes the user has granted.
        /// </summary>
        public SlackScopeCollection Scope { get; private set; }

        /// <summary>
        /// Gets the name of the team selected by the user.
        /// </summary>
        public string TeamName { get; private set; }

        #endregion

        #region Constructors

        private SlackTokenInfo(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <code>SlackTokenInfo</code> from the specified <code>JsonObject</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JsonObject</code> to parse.</param>
        public static SlackTokenInfo Parse(JsonObject obj) {

            if (obj == null) return null;

            // Convert the "scope" string to a collection of scopes
            SlackScopeCollection scopes = new SlackScopeCollection();
            foreach (string name in obj.GetString("scope").Split(',')) {
                SlackScope scope = SlackScope.GetScope(name) ?? SlackScope.RegisterScope(name);
                scopes.Add(scope);
            }

            // Parse the rest of the response
            return new SlackTokenInfo(obj) {
                AccessToken = obj.GetString("access_token"),
                Scope = scopes,
                TeamName = obj.GetString("team_name")
            };
        
        }

        #endregion

    }

}