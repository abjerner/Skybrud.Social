using Newtonsoft.Json;
using Skybrud.Social.Json;

namespace Skybrud.Social.GitHub.Objects {
    
    public class GitHubCommitStats : SocialJsonObject {

        #region Properties

        [JsonProperty("additions")]
        public int Additions { get; private set; }
        
        [JsonProperty("deletions")]
        public int Deletions { get; private set; }
        
        [JsonProperty("total")]
        public int Total { get; private set; }
        
        #endregion

        #region Constructor

        private GitHubCommitStats(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static GitHubCommitStats Parse(JsonObject obj) {
            if (obj == null) return null;
            return new GitHubCommitStats(obj) {
                Additions = obj.GetInt32("additions"),
                Deletions = obj.GetInt32("deletions"),
                Total = obj.GetInt32("total")
            };
        }

        #endregion

    }

}
