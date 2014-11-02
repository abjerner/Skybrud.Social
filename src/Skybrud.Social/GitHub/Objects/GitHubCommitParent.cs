using Newtonsoft.Json;
using Skybrud.Social.Json;

namespace Skybrud.Social.GitHub.Objects {
    
    public class GitHubCommitParent : SocialJsonObject {

        #region Properties

        [JsonProperty("sha")]
        public string Sha { get; private set; }
        
        [JsonProperty("url")]
        public string Url { get; private set; }
        
        [JsonProperty("html_url")]
        public string HtmlUrl { get; private set; }
        
        #endregion

        #region Constructor

        private GitHubCommitParent(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static GitHubCommitParent Parse(JsonObject obj) {
            if (obj == null) return null;
            return new GitHubCommitParent(obj) {
                Sha = obj.GetString("sha"),
                Url = obj.GetString("url"),
                HtmlUrl = obj.GetString("html_url")
            };
        }

        #endregion

    }

}