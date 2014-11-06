using Newtonsoft.Json;
using Skybrud.Social.Json;

namespace Skybrud.Social.GitHub.Objects {
    
    public class GitHubCommit : SocialJsonObject {

        #region Properties

        [JsonProperty("url")]
        public string Url { get; private set; }

        [JsonProperty("sha")]
        public string Sha { get; private set; }

        [JsonProperty("html_url")]
        public string HtmlUrl { get; private set; }

        [JsonProperty("comments_url")]
        public string CommentsUrl { get; private set; }

        [JsonProperty("commit")]
        public GitHubCommitDetails Commit { get; private set; }

        [JsonProperty("author")]
        public GitHubUserSummary Author { get; private set; }

        [JsonProperty("committer")]
        public GitHubUserSummary Committer { get; private set; }

        [JsonProperty("parents")]
        public GitHubCommitParent[] Parents { get; private set; }

        [JsonProperty("stats")]
        public GitHubCommitStats Stats { get; private set; }

        [JsonProperty("files")]
        public GitHubCommitFile[] Files { get; private set; }

        #endregion

        #region Constructor

        private GitHubCommit(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static GitHubCommit Parse(JsonObject obj) {
            if (obj == null) return null;
            return new GitHubCommit(obj) {
                Sha = obj.GetString("sha"),
                Commit = obj.GetObject("commit", GitHubCommitDetails.Parse),
                Url = obj.GetString("url"),
                HtmlUrl = obj.GetString("html_url"),
                CommentsUrl = obj.GetString("comments_url"),
                Author = obj.GetObject("author", GitHubUserSummary.Parse),
                Committer = obj.GetObject("committer", GitHubUserSummary.Parse),
                Parents = obj.GetArray("parents", GitHubCommitParent.Parse),
                Stats = obj.GetObject("stats", GitHubCommitStats.Parse),
                Files = obj.GetArray("files", GitHubCommitFile.Parse)
            };
        }

        #endregion

    }

}
