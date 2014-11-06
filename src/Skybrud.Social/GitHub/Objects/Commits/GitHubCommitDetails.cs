using Newtonsoft.Json;
using Skybrud.Social.Json;

namespace Skybrud.Social.GitHub.Objects.Commits {
    
    public class GitHubCommitDetails : SocialJsonObject {

        #region Properties

        [JsonProperty("author")]
        public GitHubCommitAuthor Author { get; private set; }
        
        [JsonProperty("comitter")]
        public GitHubCommitAuthor Committer { get; private set; }
        
        [JsonProperty("message")]
        public string Message { get; private set; }
        
        [JsonProperty("tree")]
        public GitHubCommitTree Tree { get; private set; }
        
        [JsonProperty("url")]
        public string Url { get; private set; }
        
        [JsonProperty("comment_count")]
        public int CommentCount { get; private set; }
        
        #endregion

        #region Constructor

        private GitHubCommitDetails(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static GitHubCommitDetails Parse(JsonObject obj) {
            if (obj == null) return null;
            return new GitHubCommitDetails(obj) {
                Author = obj.GetObject("author", GitHubCommitAuthor.Parse),
                Committer = obj.GetObject("committer", GitHubCommitAuthor.Parse),
                Message = obj.GetString("message"),
                Tree = obj.GetObject("tree", GitHubCommitTree.Parse),
                Url = obj.GetString("url"),
                CommentCount = obj.GetInt32("comment_count")
            };
        }

        #endregion

    }

}