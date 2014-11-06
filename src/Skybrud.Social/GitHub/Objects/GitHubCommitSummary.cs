using Newtonsoft.Json;
using Skybrud.Social.GitHub.Objects.Commits;
using Skybrud.Social.Json;

namespace Skybrud.Social.GitHub.Objects {
    
    public class GitHubCommitSummary : SocialJsonObject {

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

        #endregion

        #region Constructor

        private GitHubCommitSummary(JsonObject obj) : base(obj) { }

        #endregion

        #region Static methods

        public static GitHubCommitSummary Parse(JsonObject obj) {
            if (obj == null) return null;
            return new GitHubCommitSummary(obj) {
                Sha = obj.GetString("sha"),
                Commit = obj.GetObject("commit", GitHubCommitDetails.Parse),
                Url = obj.GetString("url"),
                HtmlUrl = obj.GetString("html_url"),
                CommentsUrl = obj.GetString("comments_url"),
                Author = obj.GetObject("author", GitHubUserSummary.Parse),
                Committer = obj.GetObject("committer", GitHubUserSummary.Parse),
                Parents = obj.GetArray("parents", GitHubCommitParent.Parse)
            };
        }

        #endregion

    }

}
