using Newtonsoft.Json;
using Skybrud.Social.Json;

namespace Skybrud.Social.GitHub.Objects.Commits {
    
    public class GitHubCommitTree : SocialJsonObject {

        #region Properties

        [JsonProperty("sha")]
        public string Sha { get; private set; }
        
        [JsonProperty("url")]
        public string Url { get; private set; }
        
        #endregion

        #region Constructor

        private GitHubCommitTree(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static GitHubCommitTree Parse(JsonObject obj) {
            if (obj == null) return null;
            return new GitHubCommitTree(obj) {
                Sha = obj.GetString("sha"),
                Url = obj.GetString("url")
            };
        }

        #endregion

    }

}