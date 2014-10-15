using Skybrud.Social.Json;

namespace Skybrud.Social.GitHub.Objects {
    
    public class GitHubEmail : SocialJsonObject {

        #region Properties

        public string Email { get; private set; }

        public bool IsVerified { get; private set; }

        public bool IsPrimary { get; private set; }

        #endregion

        #region Constructor

        private GitHubEmail(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static GitHubEmail Parse(JsonObject obj) {
            if (obj == null) return null;
            return new GitHubEmail(obj) {
                Email = obj.GetString("email"),
                IsVerified = obj.GetBoolean("verified"),
                IsPrimary = obj.GetBoolean("primary")
            };
        
        }

        #endregion

    }

}
